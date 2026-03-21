using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    internal class FbxReader : IImporter
    {
        public Scene Import(Stream stream, LoadOptions options)
        {
            if (options is FbxLoadOptions fbxOptions)
            {
                return Read(stream, fbxOptions);
            }
            throw new ArgumentException("Options must be FbxLoadOptions", nameof(options));
        }

        private static Scene Read(Stream stream, FbxLoadOptions options)
        {
            var buffer = new byte[18];
            var bytesRead = stream.Read(buffer, 0, 18);
            stream.Seek(0, SeekOrigin.Begin);

            var header = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
            if (header.Contains("Kaydara FBX Binary"))
            {
                return ReadBinaryFbx(stream, options);
            }

            return ReadAsciiFbx(stream, options);
        }

        private static Scene ReadBinaryFbx(Stream stream, FbxLoadOptions options)
        {
            var scene = new Scene();

            using var reader = new BinaryReader(stream);
            
            var header = reader.ReadBytes(18);
            if (System.Text.Encoding.ASCII.GetString(header) != "Kaydara FBX Binary")
            {
                throw new InvalidOperationException("Invalid FBX binary file header");
            }

            reader.ReadBytes(5);

            var version = reader.ReadUInt32();

            bool is64Bit = version >= 7500;

            var tokens = new List<Token>();
            while (stream.Position < stream.Length)
            {
                try
                {
                    if (!ReadScope(reader, tokens, is64Bit, stream.Length))
                        break;
                }
                catch (EndOfStreamException)
                {
                    break;
                }
            }

            var parser = new FbxParser(tokens);
            ParseScene(parser.RootScope, scene, options);

            return scene;
        }

        private static Scene ReadAsciiFbx(Stream stream, FbxLoadOptions options)
        {
            var scene = new Scene();

            using var reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            
            Console.WriteLine($"ReadAsciiFbx: content length = {content.Length}");

            var tokenizer = new FbxTokenizer(content);
            var tokens = tokenizer.Tokenize();
            Console.WriteLine($"ReadAsciiFbx: tokens count = {tokens.Count}");

            var parser = new FbxParser(tokens);
            ParseScene(parser.RootScope, scene, options);

            return scene;
        }

        private static bool ReadScope(BinaryReader reader, List<Token> tokens, bool is64Bit, long streamLength)
        {
            ulong endOffset = is64Bit ? reader.ReadUInt64() : reader.ReadUInt32();

            if (endOffset == 0)
                return false;

            if (endOffset > (ulong)streamLength)
                return false;

            var propCount = (int)(is64Bit ? reader.ReadUInt64() : reader.ReadUInt32());
            var propLength = (int)(is64Bit ? reader.ReadUInt64() : reader.ReadUInt32());

            var name = ReadString(reader, longLength: false);
            tokens.Add(new Token(name, TokenType.KEY));

            long beginCursor = reader.BaseStream.Position;

            for (int i = 0; i < propCount; i++)
            {
                var data = ReadData(reader, beginCursor + propLength);
                tokens.Add(new Token(data, TokenType.DATA));

                if (i != propCount - 1)
                {
                    tokens.Add(new Token(",", TokenType.COMMA));
                }
            }

            if (reader.BaseStream.Position - beginCursor != propLength)
            {
                reader.BaseStream.Seek(beginCursor + propLength - reader.BaseStream.Position, SeekOrigin.Current);
            }

            int sentinelBlockLength = is64Bit ? 25 : 13;

            if (reader.BaseStream.Position < (long)endOffset)
            {
                if ((long)endOffset - reader.BaseStream.Position < sentinelBlockLength)
                    return false;

                tokens.Add(new Token("{", TokenType.OPEN_BRACKET));

                long end = (long)endOffset - sentinelBlockLength;
                while (reader.BaseStream.Position < end)
                {
                    if (!ReadScope(reader, tokens, is64Bit, streamLength))
                        break;
                }

                tokens.Add(new Token("}", TokenType.CLOSE_BRACKET));

                var sentinel = reader.ReadBytes(sentinelBlockLength);
                if (sentinel.Length > 0 && Array.FindIndex(sentinel, b => b != 0) >= 0)
                {
                    throw new InvalidOperationException("Failed to read nested block sentinel");
                }
            }

            if (reader.BaseStream.Position != (long)endOffset)
            {
                reader.BaseStream.Seek((long)endOffset - reader.BaseStream.Position, SeekOrigin.Current);
            }

            return true;
        }

        private static object ReadData(BinaryReader reader, long limit)
        {
            if (reader.BaseStream.Position >= reader.BaseStream.Length)
                throw new EndOfStreamException();

            var typeChar = (char)reader.ReadByte();
            long startCursor = reader.BaseStream.Position - 1;

            switch (typeChar)
            {
                case 'Y':
                    reader.BaseStream.Seek(2, SeekOrigin.Current);
                    return reader.ReadInt16();
                case 'C':
                    return reader.ReadByte() != 0;
                case 'I':
                    return reader.ReadInt32();
                case 'F':
                    return reader.ReadSingle();
                case 'D':
                    return reader.ReadDouble();
                case 'L':
                    return reader.ReadInt64();
                case 'R':
                    var length = reader.ReadInt32();
                    return reader.ReadBytes(length);
                case 'f':
                case 'd':
                case 'i':
                case 'l':
                case 'c':
                    var arrayLength = reader.ReadInt32();
                    var encoding = reader.ReadInt32();
                    var compLength = reader.ReadInt32();

                    var arrayData = reader.ReadBytes(compLength);

                    int stride = 1;
                    if (typeChar == 'f' || typeChar == 'i')
                        stride = 4;
                    else if (typeChar == 'd' || typeChar == 'l')
                        stride = 8;

                    if (typeChar == 'f' && arrayLength > 0)
                    {
                        var values = new float[arrayLength];
                        Buffer.BlockCopy(arrayData, 0, values, 0, arrayLength * 4);
                        return values;
                    }
                    else if (typeChar == 'i' && arrayLength > 0)
                    {
                        var values = new int[arrayLength];
                        Buffer.BlockCopy(arrayData, 0, values, 0, arrayLength * 4);
                        return values;
                    }
                    else if (typeChar == 'd' && arrayLength > 0)
                    {
                        var values = new double[arrayLength];
                        Buffer.BlockCopy(arrayData, 0, values, 0, arrayLength * 8);
                        return values;
                    }
                    else if (typeChar == 'l' && arrayLength > 0)
                    {
                        var values = new long[arrayLength];
                        Buffer.BlockCopy(arrayData, 0, values, 0, arrayLength * 8);
                        return values;
                    }
                    else if (typeChar == 'c' && arrayLength > 0)
                    {
                        return arrayData;
                    }
                    break;
                case 'S':
                    return ReadString(reader, longLength: true);
                default:
                    throw new InvalidOperationException($"Unexpected type code: {typeChar}");
            }

            return null;
        }

        private static string ReadString(BinaryReader reader, bool longLength = false)
        {
            int lenLen = longLength ? 4 : 1;
            int length = longLength ? reader.ReadInt32() : reader.ReadByte();

            var bytes = reader.ReadBytes(length);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        private static void ParseScene(FbxScope rootScope, Scene scene, FbxLoadOptions options)
        {
            var objectsElement = rootScope.GetFirstElement("Objects");
            if (objectsElement == null || objectsElement.Compound == null)
            {
                Console.WriteLine("ParseScene: objectsElement=" + (objectsElement != null) + ", Compound=" + (objectsElement?.Compound != null));
                return;
            }

            Console.WriteLine("ParseScene: objectsElement=True, Compound=True");
            
            var objectsScope = objectsElement.Compound;
            var objectMap = new Dictionary<ulong, object>();

            var geometryElements = objectsScope.GetElements("Geometry");
            var modelElements = objectsScope.GetElements("Model");
            var materialElements = objectsScope.GetElements("Material");
            
            Console.WriteLine($"ParseScene: {geometryElements.Count} geometry elements, {modelElements.Count} model elements, {materialElements.Count} material elements");

            ParseGeometries(geometryElements, scene, objectMap);
            ParseModels(modelElements, scene, objectMap);
            ParseConnections(rootScope, scene, objectMap);
        }

        private static void ParseGeometries(List<FbxElement> geometryElements, Scene scene, Dictionary<ulong, object> objectMap)
        {
            foreach (var geomElem in geometryElements)
            {
                var geomScope = geomElem.Compound;
                if (geomScope == null)
                    continue;

                ulong geomId = ParseId(geomElem);
                if (geomId == 0)
                    continue;

                var mesh = new Mesh();
                objectMap[geomId] = mesh;

                var verticesElement = geomScope.GetFirstElement("Vertices");
                if (verticesElement?.Compound != null)
                {
                    var aElem = verticesElement.Compound.GetFirstElement("a");
                    if (aElem != null)
                    {
                        Console.WriteLine($"ParseGeometries: aElem has {aElem.Tokens.Count} tokens");
                        var vertices = new List<double>();
                        foreach (var t in aElem.Tokens)
                        {
                            var vals = ParseFloatArray(t.Text);
                            vertices.AddRange(vals);
                        }
                        Console.WriteLine($"ParseGeometries: Vertices count: {vertices.Count}");
                        for (int i = 0; i < vertices.Count - 2; i += 3)
                        {
                            mesh.ControlPoints.Add(new Vector4((float)vertices[i], (float)vertices[i + 1], (float)vertices[i + 2], 1.0f));
                        }
                        Console.WriteLine($"ParseGeometries: Added {mesh.ControlPoints.Count} ControlPoints");
                    }
                }

                var polygonElement = geomScope.GetFirstElement("PolygonVertexIndex");
                if (polygonElement?.Compound != null)
                {
                    var aElem = polygonElement.Compound.GetFirstElement("a");
                    if (aElem != null)
                    {
                        Console.WriteLine($"ParseGeometries: PolygonVertexIndex has {aElem.Tokens.Count} tokens");
                        var indices = new List<int>();
                        foreach (var t in aElem.Tokens)
                        {
                            var vals = ParseIntArray(t.Text);
                            indices.AddRange(vals);
                        }
                        Console.WriteLine($"ParseGeometries: PolygonVertexIndex count: {indices.Count}");
                        Console.WriteLine($"First few indices: {string.Join(",", indices.Take(20))}");
                        int polygonStart = 0;
                        for (int i = 0; i < indices.Count; i++)
                        {
                            var idx = indices[i];
                            if (idx < 0)
                            {
                                int polygonSize = i - polygonStart;
                                Console.WriteLine($"  Polygon at i={i}, size={polygonSize}, start={polygonStart}, total available={indices.Count - polygonStart}");
                                if (polygonSize < 3)
                                {
                                    Console.WriteLine($"    ERROR: Polygon must have at least 3 vertices (got {polygonSize})");
                                    break;
                                }
                                int[] poly = new int[polygonSize];
                                for (int j = 0; j < polygonSize; j++)
                                {
                                    poly[j] = indices[polygonStart + j];
                                }
                                try
                                {
                                    mesh.CreatePolygon(poly);
                                    polygonStart = i + 1;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"    ERROR: {ex.Message}");
                                    break;
                                }
                            }
                        }
                        Console.WriteLine($"ParseGeometries: Added {mesh.PolygonCount} polygons");
                    }
                }

                // Parse vertex elements (normals, UVs)
                ParseVertexElements(geomScope, mesh);

                Console.WriteLine($"ParseGeometries: Mesh has {mesh.ControlPoints.Count} vertices and {mesh.PolygonCount} polygons");
                if (mesh.ControlPoints.Count > 0 && mesh.PolygonCount > 0)
                {
                    var meshNode = scene.RootNode.CreateChildNode(mesh.Name, mesh);
                    Console.WriteLine($"ParseGeometries: Created mesh node '{meshNode.Name}'");
                }
            }
        }

        private static void ParseVertexElements(FbxScope geomScope, Mesh mesh)
        {
            // Parse normals
            var normalElement = geomScope.GetFirstElement("LayerElementNormal");
            if (normalElement?.Compound != null)
            {
                var normalScope = normalElement.Compound;
                var mappingElement = normalScope.GetFirstElement("MappingInformationType");
                var refElement = normalScope.GetFirstElement("ReferenceInformationType");
                var normalsData = normalScope.GetFirstElement("Normals");

                MappingMode mappingMode = MappingMode.ControlPoint;
                ReferenceMode referenceMode = ReferenceMode.Direct;

                if (mappingElement?.Tokens.Count > 0)
                {
                    string mapping = mappingElement.Tokens[0].Text.Trim('"');
                    if (mapping == "PolygonVertex") mappingMode = MappingMode.PolygonVertex;
                }

                if (refElement?.Tokens.Count > 0)
                {
                    string @ref = refElement.Tokens[0].Text.Trim('"');
                    if (@ref == "IndexToDirect") referenceMode = ReferenceMode.IndexToDirect;
                }

                if (normalsData?.Compound != null)
                {
                    var aElem = normalsData.Compound.GetFirstElement("a");
                    if (aElem != null)
                    {
                        var normals = new List<double>();
                        foreach (var t in aElem.Tokens)
                        {
                            var vals = ParseFloatArray(t.Text);
                            normals.AddRange(vals);
                        }

                        // Create vertex element for normals
                        var vertexElement = mesh.CreateElement(VertexElementType.Normal, mappingMode, referenceMode);
                        
                        if (vertexElement is VertexElementVector vectorElement)
                        {
                            // Parse normals - 4 floats per normal (x, y, z, w)
                            for (int i = 0; i < normals.Count - 3; i += 4)
                            {
                                var nx = (float)normals[i];
                                var ny = (float)normals[i + 1];
                                var nz = (float)normals[i + 2];
                                var nw = (float)normals[i + 3];
                                vectorElement.Data.Add(new FVector4(nx, ny, nz, nw));
                            }

                            // Handle indices for IndexToDirect mode
                            if (referenceMode == ReferenceMode.IndexToDirect && vectorElement is IIndexedVertexElement indexed)
                            {
                                // The number of normals vs control points determines how indices are mapped
                                if (normals.Count / 4 != mesh.ControlPoints.Count)
                                {
                                    // For ByPolygonVertex, we need per-vertex normals (one per polygon corner)
                                    int vertexCount = normals.Count / 4;
                                    var indexedElement = (IIndexedVertexElement)vertexElement;
                                    int[] indices = new int[vertexCount];
                                    for (int i = 0; i < vertexCount; i++)
                                    {
                                        indices[i] = i;
                                    }
                                    indexedElement.SetIndices(indices);
                                }
                            }
                        }
                    }
                }
            }

            // Parse UVs
            var uvElement = geomScope.GetFirstElement("LayerElementUV");
            if (uvElement?.Compound != null)
            {
                var uvScope = uvElement.Compound;
                var mappingElement = uvScope.GetFirstElement("MappingInformationType");
                var refElement = uvScope.GetFirstElement("ReferenceInformationType");
                var uvData = uvScope.GetFirstElement("UV");
                var nameElement = uvScope.GetFirstElement("Name");

                MappingMode mappingMode = MappingMode.ControlPoint;
                ReferenceMode referenceMode = ReferenceMode.Direct;
                TextureMapping uvMapping = TextureMapping.Diffuse;

                if (mappingElement?.Tokens.Count > 0)
                {
                    string mapping = mappingElement.Tokens[0].Text.Trim('"');
                    if (mapping == "PolygonVertex") mappingMode = MappingMode.PolygonVertex;
                }

                if (refElement?.Tokens.Count > 0)
                {
                    string @ref = refElement.Tokens[0].Text.Trim('"');
                    if (@ref == "IndexToDirect") referenceMode = ReferenceMode.IndexToDirect;
                }

                if (nameElement?.Tokens.Count > 0)
                {
                    string uvName = nameElement.Tokens[0].Text.Trim('"');
                    // Map UV name to TextureMapping
                    // For simplicity, we use Diffuse for "MainTex" and similar
                }

                if (uvData?.Compound != null)
                {
                    var aElem = uvData.Compound.GetFirstElement("a");
                    if (aElem != null)
                    {
                        var uvCoords = new List<double>();
                        foreach (var t in aElem.Tokens)
                        {
                            var vals = ParseFloatArray(t.Text);
                            uvCoords.AddRange(vals);
                        }

                        // Create UV element
                        var vertexElement = mesh.CreateElementUV(uvMapping, mappingMode, referenceMode);
                        
                        if (vertexElement is VertexElementUV uvDataElement)
                        {
                            // Parse UVs - 2 floats per UV coordinate
                            int uvCount = uvCoords.Count / 2;
                            int[] indices = new int[uvCount];
                            
                            // Add UV data and indices
                            for (int i = 0; i < uvCount; i++)
                            {
                                var u = (float)uvCoords[i * 2];
                                var v = (float)uvCoords[i * 2 + 1];
                                uvDataElement.Data.Add(new FVector2(u, v));
                                indices[i] = i;
                            }
                            
                            uvDataElement.SetIndices(indices);
                        }
                    }
                }
            }
        }

        private static void ParseModels(List<FbxElement> modelElements, Scene scene, Dictionary<ulong, object> objectMap)
        {
            foreach (var modelElem in modelElements)
            {
                ulong modelId = ParseId(modelElem);
                if (modelId == 0)
                    continue;

                var node = new Node();
                objectMap[modelId] = node;

                if (modelElem.Tokens.Count > 1)
                {
                    var tokenValue = modelElem.Tokens[1].Text;
                    if (!string.IsNullOrEmpty(tokenValue))
                    {
                        node.Name = tokenValue.Trim('"');
                    }
                }

                var modelScope = modelElem.Compound;
                if (modelScope != null)
                {
                    ParseNodeTransform(node, modelScope);
                }
            }
        }

        private static void ParseNodeTransform(Node node, FbxScope modelScope)
        {
            var transformElement = modelScope.GetFirstElement("Properties70");
            if (transformElement?.Compound == null)
                return;

            var translation = FVector3.Zero;
            var rotation = FVector3.Zero;
            var scale = FVector3.One;

            var props = transformElement.Compound.GetElements("P");
            foreach (var prop in props)
            {
                if (prop.Tokens.Count < 5)
                    continue;

                var propName = prop.Tokens[0].Text.Trim('"');
                if (propName == "Lcl Translation")
                {
                    translation.X = ParseFloat(prop.Tokens[2].Text);
                    translation.Y = ParseFloat(prop.Tokens[3].Text);
                    translation.Z = ParseFloat(prop.Tokens[4].Text);
                }
                else if (propName == "Lcl Rotation")
                {
                    rotation.X = ParseFloat(prop.Tokens[2].Text);
                    rotation.Y = ParseFloat(prop.Tokens[3].Text);
                    rotation.Z = ParseFloat(prop.Tokens[4].Text);
                }
                else if (propName == "Lcl Scaling")
                {
                    scale.X = ParseFloat(prop.Tokens[2].Text);
                    scale.Y = ParseFloat(prop.Tokens[3].Text);
                    scale.Z = ParseFloat(prop.Tokens[4].Text);
                }
            }

            node.Transform.Translation = translation;
            var radX = rotation.X * (float)Math.PI / 180.0f;
            var radY = rotation.Y * (float)Math.PI / 180.0f;
            var radZ = rotation.Z * (float)Math.PI / 180.0f;
            var q = FromEulerAngles(radX, radY, radZ);
            node.Transform.Rotation = q;
            node.Transform.Scale = scale;
        }

        private static void ParseConnections(FbxScope rootScope, Scene scene, Dictionary<ulong, object> objectMap)
        {
            var connectionsElement = rootScope.GetFirstElement("Connections");
            if (connectionsElement?.Compound == null)
                return;

            var connectionsScope = connectionsElement.Compound;
            var connectionElements = connectionsScope.GetElements("C");

            foreach (var connElem in connectionElements)
            {
                if (connElem.Tokens.Count < 3)
                    continue;

                var connType = connElem.Tokens[0].Text.Trim('"');
                if (connType != "OO")
                    continue;

                var childId = ParseId(connElem.Tokens[1].Text);
                var parentId = ParseId(connElem.Tokens[2].Text);

                ConnectObjects(childId, parentId, scene, objectMap);
            }
        }

        private static void ConnectObjects(ulong childId, ulong parentId, Scene scene, Dictionary<ulong, object> objectMap)
        {
            if (!objectMap.TryGetValue(childId, out var childObj))
                return;

            Node parentObj;
            if (parentId == 0)
            {
                parentObj = scene.RootNode;
            }
            else
            {
                if (!objectMap.TryGetValue(parentId, out var parentObjObj))
                    return;
                parentObj = parentObjObj as Node;
                if (parentObj == null)
                    return;
            }

            if (childObj is Mesh mesh)
            {
                parentObj.AddEntity(mesh);
            }
            else if (childObj is Node childNode)
            {
                parentObj.AddChildNode(childNode);
            }
        }

        private static ulong ParseId(FbxElement element)
        {
            if (element.Tokens.Count > 0)
            {
                return ParseId(element.Tokens[0].Text);
            }
            return 0;
        }

        private static ulong ParseId(string value)
        {
            try
            {
                return ulong.Parse(value.Trim('"'));
            }
            catch
            {
                return 0;
            }
        }

        private static List<double> ParseFloatArray(string value)
        {
            var text = value;
            if (text.StartsWith("a:"))
            {
                text = text.Substring(2);
            }

            var result = new List<double>();
            var parts = text.Split(',');
            foreach (var part in parts)
            {
                if (double.TryParse(part.Trim(), out double val))
                {
                    result.Add(val);
                }
            }
            return result;
        }

        private static List<int> ParseIntArray(string value)
        {
            var text = value;
            if (text.StartsWith("a:"))
            {
                text = text.Substring(2);
            }

            var result = new List<int>();
            var parts = text.Split(',');
            foreach (var part in parts)
            {
                if (int.TryParse(part.Trim(), out int val))
                {
                    result.Add(val);
                }
            }
            return result;
        }

        private static float ParseFloat(string value)
        {
            if (float.TryParse(value, out float result))
            {
                return result;
            }
            return 0;
        }

        private static Quaternion FromEulerAngles(float x, float y, float z)
        {
            float cx = (float)Math.Cos(x * 0.5f);
            float cy = (float)Math.Cos(y * 0.5f);
            float cz = (float)Math.Cos(z * 0.5f);
            float sx = (float)Math.Sin(x * 0.5f);
            float sy = (float)Math.Sin(y * 0.5f);
            float sz = (float)Math.Sin(z * 0.5f);

            float w = cx * cy * cz - sx * sy * sz;
            float i = sx * cy * cz - cx * sy * sz;
            float j = cx * sy * cz + sx * cy * sz;
            float k = cx * cy * sz + sx * sy * cz;

            return new Quaternion(i, j, k, w);
        }
    }

    internal enum TokenType
    {
        OPEN_BRACKET = 0,
        CLOSE_BRACKET = 1,
        DATA = 2,
        COMMA = 3,
        KEY = 4
    }

    internal class Token
    {
        private readonly object _value;
        private readonly TokenType _type;

        public object Value => _value;
        public string Text => _value?.ToString();
        public TokenType Type => _type;

        public Token(object value, TokenType type)
        {
            _value = value;
            _type = type;
        }

        public override string ToString()
        {
            return $"Token({_type}, {_value})";
        }
    }
}
