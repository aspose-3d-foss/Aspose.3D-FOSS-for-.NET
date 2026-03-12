using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    internal class GltfReader : IImporter
    {
        public Scene Import(Stream stream, LoadOptions options)
        {
            if (options is GltfLoadOptions gltfOptions)
            {
                return Read(stream, gltfOptions);
            }
            throw new ArgumentException("Options must be GltfLoadOptions", nameof(options));
        }

        private static Scene Read(Stream stream, GltfLoadOptions options)
        {
            var scene = new Scene();
            
            var buffer = new byte[12];
            using var reader = new BinaryReader(stream);
            buffer = reader.ReadBytes(12);
            stream.Seek(0, SeekOrigin.Begin);

            bool isBinary = buffer.Length >= 4 && 
                            buffer[0] == 0x67 && 
                            buffer[1] == 0x6C && 
                            buffer[2] == 0x54 && 
                            buffer[3] == 0x46;

            if (isBinary)
            {
                return ReadBinaryGltf(stream, options);
            }
            else
            {
                return ReadAsciiGltf(stream, options);
            }
        }

        private static Scene ReadAsciiGltf(Stream stream, GltfLoadOptions options)
        {
            var scene = new Scene();
            string jsonString;
            using (var reader = new StreamReader(stream))
            {
                jsonString = reader.ReadToEnd();
            }

            var doc = JsonDocument.Parse(jsonString);
            var root = doc.RootElement;

            var buffers = LoadBuffers(root, Path.GetDirectoryName(stream is FileStream fs ? fs.Name : string.Empty) ?? string.Empty);
            
            var bufferViews = new JsonElement();
            var accessors = new JsonElement();
            
            root.TryGetProperty("bufferViews", out bufferViews);
            root.TryGetProperty("accessors", out accessors);

            var meshesElement = new JsonElement();
            var nodesElement = new JsonElement();
            
            root.TryGetProperty("meshes", out meshesElement);
            root.TryGetProperty("nodes", out nodesElement);

            var meshObjects = new Dictionary<int, Mesh>();
            var nodeObjects = new Dictionary<int, Node>();

            ParseMeshes(meshesElement, accessors, bufferViews, buffers, options, scene, meshObjects);
            ParseNodes(nodesElement, meshObjects, options, nodeObjects);
            ParseNodeHierarchy(nodesElement, nodeObjects, scene);
            ParseScene(root, nodesElement, nodeObjects, scene);

            return scene;
        }

        private static Scene ReadBinaryGltf(Stream stream, GltfLoadOptions options)
        {
            var scene = new Scene();
            using var reader = new BinaryReader(stream);

            var magic = reader.ReadUInt32();
            if (magic != 0x46546C67)
                throw new InvalidOperationException("Invalid glTF binary file");

            var version = reader.ReadUInt32();
            var length = reader.ReadUInt32();

            uint chunkOffset = 12;
            byte[]? jsonChunk = null;
            byte[]? binaryChunk = null;

            while (chunkOffset < length)
            {
                if (chunkOffset + 8 > stream.Length)
                    break;

                var chunkLength = reader.ReadUInt32();
                var chunkType = reader.ReadUInt32();

                var chunkData = reader.ReadBytes((int)chunkLength);

                if (chunkType == 0x4E4F534A)
                {
                    jsonChunk = chunkData;
                }
                else if (chunkType == 0x004E4942)
                {
                    binaryChunk = chunkData;
                }

                chunkOffset += 8 + chunkLength;
            }

            if (jsonChunk == null)
                throw new InvalidOperationException("Missing JSON chunk in glTF binary file");

            var jsonString = System.Text.Encoding.UTF8.GetString(jsonChunk);
            var doc = JsonDocument.Parse(jsonString);
            var root = doc.RootElement;

            var buffers = LoadBuffers(root, Path.GetDirectoryName(stream is FileStream fs ? fs.Name : string.Empty) ?? string.Empty);
            
            var bufferViews = new JsonElement();
            var accessors = new JsonElement();
            
            root.TryGetProperty("bufferViews", out bufferViews);
            root.TryGetProperty("accessors", out accessors);

            var meshesElement = new JsonElement();
            var nodesElement = new JsonElement();
            
            root.TryGetProperty("meshes", out meshesElement);
            root.TryGetProperty("nodes", out nodesElement);

            var meshObjects = new Dictionary<int, Mesh>();
            var nodeObjects = new Dictionary<int, Node>();

            ParseMeshes(meshesElement, accessors, bufferViews, buffers, options, scene, meshObjects);
            ParseNodes(nodesElement, meshObjects, options, nodeObjects);
            ParseNodeHierarchy(nodesElement, nodeObjects, scene);
            ParseScene(root, nodesElement, nodeObjects, scene);

            return scene;
        }

        private static void ParseMeshes(JsonElement meshesElement, JsonElement accessors, JsonElement bufferViews, List<byte[]> buffers, GltfLoadOptions options, Scene scene, Dictionary<int, Mesh> meshObjects)
        {
            if (meshesElement.ValueKind != JsonValueKind.Array)
                return;

            int meshIdx = 0;
            foreach (JsonElement meshElement in meshesElement.EnumerateArray())
            {
                var mesh = ParseMesh(meshElement, accessors, bufferViews, buffers, meshIdx, options);
                if (mesh != null && mesh.PolygonCount > 0)
                {
                    var meshNode = scene.RootNode.CreateChildNode(mesh.Name, mesh);
                    meshObjects[meshIdx] = mesh;
                }
                meshIdx++;
            }
        }

        private static void ParseNodes(JsonElement nodesElement, Dictionary<int, Mesh> meshObjects, GltfLoadOptions options, Dictionary<int, Node> nodeObjects)
        {
            if (nodesElement.ValueKind != JsonValueKind.Array)
                return;

            int nodeIdx = 0;
            foreach (JsonElement nodeElement in nodesElement.EnumerateArray())
            {
                var node = ParseNode(nodeElement, meshObjects, nodeIdx, options);
                nodeObjects[nodeIdx] = node;
                nodeIdx++;
            }
        }

        private static void ParseNodeHierarchy(JsonElement nodesElement, Dictionary<int, Node> nodeObjects, Scene scene)
        {
            if (nodesElement.ValueKind != JsonValueKind.Array)
                return;

            int nodeIdx = 0;
            foreach (JsonElement nodeElement in nodesElement.EnumerateArray())
            {
                if (nodeElement.TryGetProperty("children", out var childrenElement) && childrenElement.ValueKind == JsonValueKind.Array)
                {
                    if (nodeObjects.TryGetValue(nodeIdx, out var parentNode))
                    {
                        foreach (JsonElement childIndex in childrenElement.EnumerateArray())
                        {
                            if (childIndex.TryGetInt32(out int childIdx) && nodeObjects.TryGetValue(childIdx, out var childNode))
                            {
                                childNode.ParentNode = parentNode;
                            }
                        }
                    }
                }
                nodeIdx++;
            }
        }

        private static void ParseScene(JsonElement root, JsonElement nodesElement, Dictionary<int, Node> nodeObjects, Scene scene)
        {
            if (!root.TryGetProperty("scene", out var sceneElement) || sceneElement.ValueKind != JsonValueKind.Number)
                return;

            int sceneIdx = sceneElement.GetInt32();
            
            if (!root.TryGetProperty("scenes", out var scenesElement) || scenesElement.ValueKind != JsonValueKind.Array)
                return;

            int idx = 0;
            foreach (JsonElement sceneDesc in scenesElement.EnumerateArray())
            {
                if (idx == sceneIdx && sceneDesc.TryGetProperty("nodes", out var sceneNodesElement))
                {
                    foreach (JsonElement nodeIdxElement in sceneNodesElement.EnumerateArray())
                    {
                        if (nodeIdxElement.TryGetInt32(out int nodeIdx) && nodeObjects.TryGetValue(nodeIdx, out var node))
                        {
                            scene.RootNode.AddChildNode(node);
                        }
                    }
                }
                idx++;
            }
        }

        private static List<byte[]> LoadBuffers(JsonElement root, string basePath)
        {
            var buffers = new List<byte[]>();

            if (!root.TryGetProperty("buffers", out var buffersElement) || buffersElement.ValueKind != JsonValueKind.Array)
            {
                return buffers;
            }

            foreach (JsonElement bufferElement in buffersElement.EnumerateArray())
            {
                string? uri = null;
                
                if (bufferElement.TryGetProperty("uri", out var uriElement))
                {
                    uri = uriElement.GetString();
                }

                if (uri == null)
                {
                    buffers.Add(new byte[0]);
                }
                else if (uri.StartsWith("data:"))
                {
                    var commaIndex = uri.IndexOf(',');
                    if (commaIndex > 0)
                    {
                        var base64Data = uri.Substring(commaIndex + 1);
                        buffers.Add(Convert.FromBase64String(base64Data));
                    }
                    else
                    {
                        buffers.Add(new byte[0]);
                    }
                }
                else
                {
                    var bufferPath = uri;
                    if (!Path.IsPathRooted(bufferPath) && !string.IsNullOrEmpty(basePath))
                    {
                        bufferPath = Path.Combine(basePath, bufferPath);
                    }
                    try
                    {
                        buffers.Add(File.ReadAllBytes(bufferPath));
                    }
                    catch
                    {
                        buffers.Add(new byte[0]);
                    }
                }
            }

            return buffers;
        }

        private static Mesh? ParseMesh(JsonElement meshElement, JsonElement accessors, JsonElement bufferViews, List<byte[]> buffers, int meshIdx, GltfLoadOptions options)
        {
            string? meshName = null;
            if (meshElement.TryGetProperty("name", out var nameElement))
            {
                meshName = nameElement.GetString();
            }
            meshName ??= $"mesh_{meshIdx}";

            var mesh = new Mesh(meshName);

            if (!meshElement.TryGetProperty("primitives", out var primitivesElement) || primitivesElement.ValueKind != JsonValueKind.Array)
            {
                return null;
            }

            foreach (JsonElement primitiveElement in primitivesElement.EnumerateArray())
            {
                ParsePrimitive(mesh, primitiveElement, accessors, bufferViews, buffers, options);
            }

            if (mesh.ControlPoints.Count == 0)
            {
                return null;
            }

            return mesh;
        }

        private static void ParsePrimitive(Mesh mesh, JsonElement primitiveElement, JsonElement accessors, JsonElement bufferViews, List<byte[]> buffers, GltfLoadOptions options)
        {
            if (!primitiveElement.TryGetProperty("attributes", out var attributesElement) || attributesElement.ValueKind != JsonValueKind.Object)
            {
                return;
            }

            int? positionAccessorIdx = null;
            int? normalAccessorIdx = null;
            int? texcoordAccessorIdx = null;
            int? colorAccessorIdx = null;

            foreach (JsonProperty attrProperty in attributesElement.EnumerateObject())
            {
                if (attrProperty.Name == "POSITION")
                {
                    positionAccessorIdx = attrProperty.Value.GetInt32();
                }
                else if (attrProperty.Name == "NORMAL")
                {
                    normalAccessorIdx = attrProperty.Value.GetInt32();
                }
                else if (attrProperty.Name.StartsWith("TEXCOORD_"))
                {
                    texcoordAccessorIdx = attrProperty.Value.GetInt32();
                }
                else if (attrProperty.Name.StartsWith("COLOR_"))
                {
                    colorAccessorIdx = attrProperty.Value.GetInt32();
                }
            }

            if (positionAccessorIdx == null)
                return;

            var positionAccessor = GetAccessor(accessors, positionAccessorIdx.Value);
            var positions = ReadAccessorData(positionAccessor, bufferViews, buffers, "VEC3");

            int baseVertexIndex = mesh.ControlPoints.Count;
            foreach (var pos in positions)
            {
                mesh.ControlPoints.Add(new Vector4(pos[0], pos[1], pos[2], 1.0f));
            }

            if (normalAccessorIdx.HasValue)
            {
                var normalAccessor = GetAccessor(accessors, normalAccessorIdx.Value);
                var normals = ReadAccessorData(normalAccessor, bufferViews, buffers, "VEC3");
                if (normals.Count >= positions.Count)
                {
                    var normalElement = new VertexElementVector(VertexElementType.Normal, MappingMode.ControlPoint, ReferenceMode.Direct);
                    mesh.AddElement(normalElement);
                }
            }

            if (texcoordAccessorIdx.HasValue)
            {
                var texcoordAccessor = GetAccessor(accessors, texcoordAccessorIdx.Value);
                var uvs = ReadAccessorData(texcoordAccessor, bufferViews, buffers, "VEC2");
                if (uvs.Count >= positions.Count)
                {
                    var uvElement = new VertexElementUV(TextureMapping.Diffuse, MappingMode.ControlPoint, ReferenceMode.Direct);
                    mesh.AddElement(uvElement);
                }
            }

            if (colorAccessorIdx.HasValue)
            {
                var colorAccessor = GetAccessor(accessors, colorAccessorIdx.Value);
                var colors = ReadAccessorData(colorAccessor, bufferViews, buffers, "VEC3");
                if (colors.Count < positions.Count)
                {
                    colors = ReadAccessorData(colorAccessor, bufferViews, buffers, "VEC4");
                }
                if (colors.Count >= positions.Count)
                {
                    var colorElement = new VertexElementVertexColor(MappingMode.ControlPoint, ReferenceMode.Direct);
                    mesh.AddElement(colorElement);
                }
            }

            int[]? indices = null;
            if (primitiveElement.TryGetProperty("indices", out var indicesElement))
            {
                int indicesAccessorIdx = indicesElement.GetInt32();
                var indicesAccessor = GetAccessor(accessors, indicesAccessorIdx);
                indices = ReadIndices(indicesAccessor, bufferViews, buffers);
            }

            if (indices != null)
            {
                for (int i = 0; i < indices.Length; i += 3)
                {
                    if (i + 2 < indices.Length)
                    {
                        mesh.CreatePolygon(
                            baseVertexIndex + indices[i],
                            baseVertexIndex + indices[i + 1],
                            baseVertexIndex + indices[i + 2]);
                    }
                }
            }
            else
            {
                int vertexCount = positions.Count;
                for (int i = 0; i < vertexCount; i += 3)
                {
                    if (i + 2 < vertexCount)
                    {
                        mesh.CreatePolygon(
                            baseVertexIndex + i,
                            baseVertexIndex + i + 1,
                            baseVertexIndex + i + 2);
                    }
                }
            }
        }

        private static JsonElement GetAccessor(JsonElement accessors, int index)
        {
            if (accessors.ValueKind != JsonValueKind.Array)
                return new JsonElement();

            int i = 0;
            foreach (JsonElement accessor in accessors.EnumerateArray())
            {
                if (i == index)
                    return accessor;
                i++;
            }
            return new JsonElement();
        }

        private static List<float[]> ReadAccessorData(JsonElement accessor, JsonElement bufferViews, List<byte[]> buffers, string expectedType)
        {
            if (!accessor.TryGetProperty("bufferView", out var bufferViewElement))
                return new List<float[]>();

            int bufferViewIdx = bufferViewElement.GetInt32();
            
            if (bufferViews.ValueKind != JsonValueKind.Array)
                return new List<float[]>();

            int bufferViewCount = 0;
            foreach (var _ in bufferViews.EnumerateArray()) bufferViewCount++;
            
            if (bufferViewIdx >= bufferViewCount)
                return new List<float[]>();

            int i = 0;
            JsonElement bufferView = new JsonElement();
            foreach (JsonElement bv in bufferViews.EnumerateArray())
            {
                if (i == bufferViewIdx)
                {
                    bufferView = bv;
                    break;
                }
                i++;
            }

            if (bufferView.ValueKind != JsonValueKind.Object)
                return new List<float[]>();

            int bufferIdx = 0;
            if (bufferView.TryGetProperty("buffer", out var bufferElement))
            {
                bufferIdx = bufferElement.GetInt32();
            }

            int byteOffset = 0;
            if (accessor.TryGetProperty("byteOffset", out var offsetElement))
            {
                byteOffset = offsetElement.GetInt32();
            }
            if (bufferView.TryGetProperty("byteOffset", out var viewOffsetElement))
            {
                byteOffset += viewOffsetElement.GetInt32();
            }

            int count = 0;
            if (accessor.TryGetProperty("count", out var countElement))
            {
                count = countElement.GetInt32();
            }
            
            string accessorType = "SCALAR";
            if (accessor.TryGetProperty("type", out var typeElement))
            {
                accessorType = typeElement.GetString() ?? "SCALAR";
            }

            byte[]? bufferData = null;
            if (bufferIdx < buffers.Count)
            {
                bufferData = buffers[bufferIdx];
            }

            if (bufferData == null)
                return new List<float[]>();

            int componentType = 0;
            if (accessor.TryGetProperty("componentType", out var componentTypeElement))
            {
                componentType = componentTypeElement.GetInt32();
            }

            int componentsPerValue = 1;
            if (accessorType == "VEC2")
                componentsPerValue = 2;
            else if (accessorType == "VEC3")
                componentsPerValue = 3;
            else if (accessorType == "VEC4")
                componentsPerValue = 4;

            int totalComponents = count * componentsPerValue;
            var result = new List<float[]>();

            if (componentType == 5126)
            {
                int bytesPerComponent = 4;
                int totalBytes = totalComponents * bytesPerComponent;
                if (byteOffset + totalBytes > bufferData.Length)
                    return result;

                for (int k = 0; k < totalComponents; k += componentsPerValue)
                {
                    float[] values = new float[componentsPerValue];
                    for (int j = 0; j < componentsPerValue; j++)
                    {
                        values[j] = BitConverter.ToSingle(bufferData, byteOffset + k * bytesPerComponent + j * bytesPerComponent);
                    }
                    result.Add(values);
                }
            }
            else if (componentType == 5123)
            {
                int bytesPerComponent = 2;
                int totalBytes = totalComponents * bytesPerComponent;
                if (byteOffset + totalBytes > bufferData.Length)
                    return result;

                for (int k = 0; k < totalComponents; k += componentsPerValue)
                {
                    float[] values = new float[componentsPerValue];
                    for (int j = 0; j < componentsPerValue; j++)
                    {
                        values[j] = BitConverter.ToUInt16(bufferData, byteOffset + k * bytesPerComponent + j * bytesPerComponent);
                    }
                    result.Add(values);
                }
            }
            else if (componentType == 5125)
            {
                int bytesPerComponent = 4;
                int totalBytes = totalComponents * bytesPerComponent;
                if (byteOffset + totalBytes > bufferData.Length)
                    return result;

                for (int k = 0; k < totalComponents; k += componentsPerValue)
                {
                    float[] values = new float[componentsPerValue];
                    for (int j = 0; j < componentsPerValue; j++)
                    {
                        values[j] = BitConverter.ToInt32(bufferData, byteOffset + k * bytesPerComponent + j * bytesPerComponent);
                    }
                    result.Add(values);
                }
            }
            else if (componentType == 5120)
            {
                int bytesPerComponent = 1;
                int totalBytes = totalComponents * bytesPerComponent;
                if (byteOffset + totalBytes > bufferData.Length)
                    return result;

                for (int k = 0; k < totalComponents; k += componentsPerValue)
                {
                    float[] values = new float[componentsPerValue];
                    for (int j = 0; j < componentsPerValue; j++)
                    {
                        values[j] = bufferData[byteOffset + k * bytesPerComponent + j * bytesPerComponent];
                    }
                    result.Add(values);
                }
            }
            else if (componentType == 5121)
            {
                int bytesPerComponent = 1;
                int totalBytes = totalComponents * bytesPerComponent;
                if (byteOffset + totalBytes > bufferData.Length)
                    return result;

                for (int k = 0; k < totalComponents; k += componentsPerValue)
                {
                    float[] values = new float[componentsPerValue];
                    for (int j = 0; j < componentsPerValue; j++)
                    {
                        values[j] = bufferData[byteOffset + k * bytesPerComponent + j * bytesPerComponent];
                    }
                    result.Add(values);
                }
            }

            return result;
        }

        private static int[] ReadIndices(JsonElement accessor, JsonElement bufferViews, List<byte[]> buffers)
        {
            if (!accessor.TryGetProperty("bufferView", out var bufferViewElement))
                return new int[0];

            int bufferViewIdx = bufferViewElement.GetInt32();
            
            if (bufferViews.ValueKind != JsonValueKind.Array)
                return new int[0];

            int bufferViewCount = 0;
            foreach (var _ in bufferViews.EnumerateArray()) bufferViewCount++;
            
            if (bufferViewIdx >= bufferViewCount)
                return new int[0];

            int i = 0;
            JsonElement bufferView = new JsonElement();
            foreach (JsonElement bv in bufferViews.EnumerateArray())
            {
                if (i == bufferViewIdx)
                {
                    bufferView = bv;
                    break;
                }
                i++;
            }

            if (bufferView.ValueKind != JsonValueKind.Object)
                return new int[0];

            int bufferIdx = 0;
            if (bufferView.TryGetProperty("buffer", out var bufferElement))
            {
                bufferIdx = bufferElement.GetInt32();
            }

            int byteOffset = 0;
            if (accessor.TryGetProperty("byteOffset", out var offsetElement))
            {
                byteOffset = offsetElement.GetInt32();
            }
            if (bufferView.TryGetProperty("byteOffset", out var viewOffsetElement))
            {
                byteOffset += viewOffsetElement.GetInt32();
            }

            int count = 0;
            if (accessor.TryGetProperty("count", out var countElement))
            {
                count = countElement.GetInt32();
            }
            
            int componentType = 0;
            if (accessor.TryGetProperty("componentType", out var componentTypeElement))
            {
                componentType = componentTypeElement.GetInt32();
            }

            byte[]? bufferData = null;
            if (bufferIdx < buffers.Count)
            {
                bufferData = buffers[bufferIdx];
            }

            if (bufferData == null)
                return new int[0];

            var result = new List<int>();

            if (componentType == 5123)
            {
                int bytesPerComponent = 2;
                int totalBytes = count * bytesPerComponent;
                if (byteOffset + totalBytes > bufferData.Length)
                    return result.ToArray();

                for (int k = 0; k < count; k++)
                {
                    result.Add(BitConverter.ToUInt16(bufferData, byteOffset + k * bytesPerComponent));
                }
            }
            else if (componentType == 5125)
            {
                int bytesPerComponent = 4;
                int totalBytes = count * bytesPerComponent;
                if (byteOffset + totalBytes > bufferData.Length)
                    return result.ToArray();

                for (int k = 0; k < count; k++)
                {
                    result.Add(BitConverter.ToInt32(bufferData, byteOffset + k * bytesPerComponent));
                }
            }
            else if (componentType == 5126)
            {
                int bytesPerComponent = 4;
                int totalBytes = count * bytesPerComponent;
                if (byteOffset + totalBytes > bufferData.Length)
                    return result.ToArray();

                for (int k = 0; k < count; k++)
                {
                    result.Add((int)BitConverter.ToDouble(bufferData, byteOffset + k * bytesPerComponent));
                }
            }

            return result.ToArray();
        }

        private static Node ParseNode(JsonElement nodeElement, Dictionary<int, Mesh> meshObjects, int nodeIdx, GltfLoadOptions options)
        {
            string? nodeName = null;
            if (nodeElement.TryGetProperty("name", out var nameElement))
            {
                nodeName = nameElement.GetString();
            }
            nodeName ??= $"node_{nodeIdx}";

            var node = new Node(nodeName);

            if (nodeElement.TryGetProperty("mesh", out var meshElement))
            {
                int meshIdx = meshElement.GetInt32();
                if (meshObjects.TryGetValue(meshIdx, out var mesh))
                {
                    node.AddEntity(mesh);
                }
            }

            if (nodeElement.TryGetProperty("translation", out var translationElement) && translationElement.ValueKind == JsonValueKind.Array)
            {
                int idx = 0;
                float x = 0, y = 0, z = 0;
                foreach (JsonElement val in translationElement.EnumerateArray())
                {
                    if (idx == 0) x = val.GetSingle();
                    else if (idx == 1) y = val.GetSingle();
                    else if (idx == 2) z = val.GetSingle();
                    idx++;
                }
                node.Transform.Translation = new FVector3(x, y, z);
            }

            if (nodeElement.TryGetProperty("rotation", out var rotationElement) && rotationElement.ValueKind == JsonValueKind.Array)
            {
                int idx = 0;
                float x = 0, y = 0, z = 0, w = 1;
                foreach (JsonElement val in rotationElement.EnumerateArray())
                {
                    if (idx == 0) x = val.GetSingle();
                    else if (idx == 1) y = val.GetSingle();
                    else if (idx == 2) z = val.GetSingle();
                    else if (idx == 3) w = val.GetSingle();
                    idx++;
                }
                node.Transform.Rotation = new Quaternion(x, y, z, w);
            }

            if (nodeElement.TryGetProperty("scale", out var scaleElement) && scaleElement.ValueKind == JsonValueKind.Array)
            {
                int idx = 0;
                float x = 1, y = 1, z = 1;
                foreach (JsonElement val in scaleElement.EnumerateArray())
                {
                    if (idx == 0) x = val.GetSingle();
                    else if (idx == 1) y = val.GetSingle();
                    else if (idx == 2) z = val.GetSingle();
                    idx++;
                }
                node.Transform.Scale = new FVector3(x, y, z);
            }

            return node;
        }
    }
}
