using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    internal class PlyReader : IImporter
    {
        public Scene Import(Stream stream, LoadOptions options)
        {
            if (options is PlyLoadOptions plyOptions)
            {
                return Read(stream, plyOptions);
            }
            throw new ArgumentException("Options must be PlyLoadOptions", nameof(options));
        }

        private static Scene Read(Stream stream, PlyLoadOptions options)
        {
            var scene = new Scene();
            var node = scene.RootNode.CreateChildNode("PlyImport");
            var mesh = new Mesh("PlyMesh");

            using var reader = new StreamReader(stream, Encoding.UTF8, true, 1024, true);
            var content = reader.ReadToEnd();
            
            // Get the header lines
            var allLines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var header = ReadHeader(allLines);

            // Get data start position
            var dataStart = 0;
            for (var i = 0; i <= header.HeaderEndIndex; i++)
            {
                dataStart += allLines[i].Length + 1;
            }

            if (header.Format == PlyFormatType.Ascii)
            {
                ReadAsciiPly(allLines, mesh, header);
            }
            else
            {
                // For binary, seek to data start and read
                stream.Seek(dataStart, SeekOrigin.Begin);
                using var binReader = new BinaryReader(stream, Encoding.UTF8, leaveOpen: true);
                ReadBinaryPly(binReader, mesh, header);
            }

            node.AddEntity(mesh);
            return scene;
        }

        private static PlyHeader ReadHeader(string[] lines)
        {
            var header = new PlyHeader();
            var headerEndIndex = -1;

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Trim();
                if (string.IsNullOrEmpty(line))
                    continue;

                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0)
                    continue;

                switch (parts[0].ToLower())
                {
                    case "ply":
                        continue;
                    case "format":
                        if (parts.Length >= 3)
                        {
                            var formatStr = parts[1].ToLower();
                            if (formatStr == "ascii")
                                header.Format = PlyFormatType.Ascii;
                            else if (formatStr == "binary_little_endian")
                                header.Format = PlyFormatType.BinaryLittleEndian;
                            else if (formatStr == "binary_big_endian")
                                header.Format = PlyFormatType.BinaryBigEndian;
                        }
                        continue;
                    case "comment":
                        header.Comments.Add(line.Substring(8));
                        continue;
                    case "element":
                        if (parts.Length >= 3)
                        {
                            var elementName = parts[1];
                            var count = int.Parse(parts[2]);
                            header.Elements.Add(new PlyElement(elementName, count));
                        }
                        continue;
                    case "property":
                        if (header.Elements.Count > 0)
                        {
                            var element = header.Elements[header.Elements.Count - 1];
                            if (parts.Length >= 3)
                            {
                                var propType = parts[1].ToLower();
                                var propName = propType == "list" ? parts[4] : parts[2];

                                if (propType == "list")
                                {
                                    var indexType = parts[2].ToLower();
                                    var elemType = parts[3].ToLower();
                                    element.Properties.Add(new PlyProperty(propName, GetPropertyDataType(elemType), true, GetPropertyDataType(indexType), indexType));
                                }
                                else
                                {
                                    element.Properties.Add(new PlyProperty(propName, GetPropertyDataType(propType), false, null));
                                }
                            }
                        }
                        continue;
                    case "end_header":
                        headerEndIndex = i;
                        break;
                }

                if (headerEndIndex >= 0)
                    break;
            }

            header.HeaderEndIndex = headerEndIndex;
            return header;
        }

        private static void ReadAsciiPly(string[] lines, Mesh mesh, PlyHeader header)
        {
            var vertexElements = new List<PlyElement>();
            var faceElements = new List<PlyElement>();

            foreach (var elem in header.Elements)
            {
                if (elem.Name == "vertex")
                    vertexElements.Add(elem);
                else if (elem.Name == "face")
                    faceElements.Add(elem);
            }

            // First pass: read all vertices
            var totalVertices = 0;
            foreach (var elem in vertexElements)
            {
                totalVertices += elem.Count;
            }

            var vertexLineIndex = header.HeaderEndIndex + 1;
            for (var i = 0; i < totalVertices && vertexLineIndex < lines.Length; i++)
            {
                var line = lines[vertexLineIndex++];
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 3)
                    continue;

                var x = 0.0f;
                var y = 0.0f;
                var z = 0.0f;

                var propIndex = 0;
                foreach (var prop in vertexElements[0].Properties)
                {
                    if (propIndex >= parts.Length)
                        break;

                    var value = parts[propIndex];

                    switch (prop.Name.ToLower())
                    {
                        case "x":
                            x = ParseFloat(value);
                            break;
                        case "y":
                            y = ParseFloat(value);
                            break;
                        case "z":
                            z = ParseFloat(value);
                            break;
                    }
                    propIndex++;
                }

                mesh.ControlPoints.Add(new Vector4(x, y, z, 1.0f));
            }

            // Second pass: read all faces
            var totalFaces = 0;
            foreach (var elem in faceElements)
            {
                totalFaces += elem.Count;
            }

            for (var i = 0; i < totalFaces && vertexLineIndex < lines.Length; i++)
            {
                var line = lines[vertexLineIndex++];
                var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 4)
                    continue;

                var vertexCount = int.Parse(parts[0]);
                if (vertexCount < 3 || vertexCount + 1 > parts.Length)
                    continue;

                var indices = new int[vertexCount];
                for (var j = 0; j < vertexCount; j++)
                {
                    indices[j] = int.Parse(parts[j + 1]);
                }

                mesh.CreatePolygon(indices);
            }
        }

        private static void ReadBinaryPly(BinaryReader reader, Mesh mesh, PlyHeader header)
        {
            var vertexElements = new List<PlyElement>();
            var faceElements = new List<PlyElement>();

            foreach (var elem in header.Elements)
            {
                if (elem.Name == "vertex")
                    vertexElements.Add(elem);
                else if (elem.Name == "face")
                    faceElements.Add(elem);
            }

            var isLittleEndian = header.Format == PlyFormatType.BinaryLittleEndian;

            foreach (var elem in vertexElements)
            {
                for (var i = 0; i < elem.Count; i++)
                {
                    var x = 0.0f;
                    var y = 0.0f;
                    var z = 0.0f;

                    foreach (var prop in elem.Properties)
                    {
                        switch (prop.Name.ToLower())
                        {
                            case "x":
                                x = ReadFloat(reader, isLittleEndian);
                                break;
                            case "y":
                                y = ReadFloat(reader, isLittleEndian);
                                break;
                            case "z":
                                z = ReadFloat(reader, isLittleEndian);
                                break;
                        }
                    }

                    mesh.ControlPoints.Add(new Vector4(x, y, z, 1.0f));
                }
            }

            foreach (var elem in faceElements)
            {
                for (var i = 0; i < elem.Count; i++)
                {
                    int vertexCount;
                    var faceProp = FindFaceProperty(elem);
                    if (faceProp != null && faceProp.IsList && !string.IsNullOrEmpty(faceProp.ListIndexTypeName))
                    {
                        vertexCount = ReadListCount(reader, faceProp.ListIndexTypeName, isLittleEndian);
                    }
                    else
                    {
                        vertexCount = ReadUByte(reader);
                    }
                    var indices = new int[vertexCount];

                    for (var j = 0; j < vertexCount; j++)
                    {
                        indices[j] = ReadInt(reader, isLittleEndian);
                    }

                    mesh.CreatePolygon(indices);
                }
            }
        }

        private static PlyProperty? FindFaceProperty(PlyElement elem)
        {
            foreach (var prop in elem.Properties)
            {
                if (prop.Name.ToLower() == "vertex_indices" || prop.Name.ToLower() == "vertex")
                {
                    return prop;
                }
            }
            return null;
        }

        private static int ReadListCount(BinaryReader reader, string indexTypeName, bool isLittleEndian)
        {
            var typeLower = indexTypeName.ToLower();
            switch (typeLower)
            {
                case "uchar":
                case "byte":
                case "uint8":
                    return reader.ReadByte();
                case "short":
                case "int16":
                case "ushort":
                case "uint16":
                    var bytes2 = reader.ReadBytes(2);
                    if (!isLittleEndian)
                    {
                        Array.Reverse(bytes2);
                    }
                    return BitConverter.ToInt16(bytes2, 0);
                default:
                    var bytes4 = reader.ReadBytes(4);
                    if (!isLittleEndian)
                    {
                        Array.Reverse(bytes4);
                    }
                    return BitConverter.ToInt32(bytes4, 0);
            }
        }

        private static float ReadFloat(BinaryReader reader, bool isLittleEndian)
        {
            var bytes = reader.ReadBytes(4);
            if (!isLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return BitConverter.ToSingle(bytes, 0);
        }

        private static int ReadInt(BinaryReader reader, bool isLittleEndian)
        {
            var bytes = reader.ReadBytes(4);
            if (!isLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return BitConverter.ToInt32(bytes, 0);
        }

        private static byte ReadUByte(BinaryReader reader)
        {
            return reader.ReadByte();
        }

        private static float ParseFloat(string value)
        {
            return float.Parse(value);
        }

        private static VertexFieldDataType GetPropertyDataType(string type)
        {
            return type.ToLower() switch
            {
                "int" or "int8" or "int16" or "int32" or "uchar" or "uint" or "uint8" or "uint16" or "uint32" => VertexFieldDataType.Int32,
                "float" or "float32" or "float64" or "double" => VertexFieldDataType.Float,
                "char" or "short" or "byte" => VertexFieldDataType.Int16,
                "uchar" or "ubyte" or "ushort" or "uint" => VertexFieldDataType.Int32,
                _ => VertexFieldDataType.Float
            };
        }
    }

    internal class PlyHeader
    {
        public PlyFormatType Format { get; set; }
        public List<PlyElement> Elements { get; } = new List<PlyElement>();
        public List<string> Comments { get; } = new List<string>();
        public int HeaderEndIndex { get; set; }
    }

    internal class PlyElement
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public List<PlyProperty> Properties { get; } = new List<PlyProperty>();

        public PlyElement(string name, int count)
        {
            Name = name;
            Count = count;
        }
    }

    internal class PlyProperty
    {
        public string Name { get; set; }
        public VertexFieldDataType DataType { get; set; }
        public bool IsList { get; set; }
        public VertexFieldDataType ListIndexType { get; set; }
        public string ListIndexTypeName { get; set; }

        public PlyProperty(string name, VertexFieldDataType dataType, bool isList, VertexFieldDataType? listIndexType)
        {
            Name = name;
            DataType = dataType;
            IsList = isList;
            ListIndexType = listIndexType ?? VertexFieldDataType.Int32;
        }

        public PlyProperty(string name, VertexFieldDataType dataType, bool isList, VertexFieldDataType? listIndexType, string listIndexTypeName)
        {
            Name = name;
            DataType = dataType;
            IsList = isList;
            ListIndexType = listIndexType ?? VertexFieldDataType.Int32;
            ListIndexTypeName = listIndexTypeName;
        }
    }

    internal enum PlyFormatType
    {
        Ascii,
        BinaryLittleEndian,
        BinaryBigEndian
    }
}
