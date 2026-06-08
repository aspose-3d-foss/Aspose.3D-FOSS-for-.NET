using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    internal class GltfWriter : IExporter
    {
        public void Export(Scene scene, Stream stream, SaveOptions options)
        {
            if (options is GltfSaveOptions gltfOptions)
            {
                bool isBinary = IsBinaryStream(stream);
                Write(stream, scene, gltfOptions, isBinary);
            }
            else
            {
                throw new ArgumentException("Options must be GltfSaveOptions", nameof(options));
            }
        }

        private static void Write(Stream stream, Scene scene, GltfSaveOptions options)
        {
            bool isBinary = IsBinaryStream(stream);
            Write(stream, scene, options, isBinary);
        }

        private static void Write(Stream stream, Scene scene, GltfSaveOptions options, bool isBinary)
        {
            var gltfData = BuildGltfData(scene, options);
            
            if (isBinary)
            {
                WriteBinaryGltf(stream, gltfData);
            }
            else
            {
                WriteAsciiGltf(stream, gltfData);
            }
        }

        private static bool IsBinaryStream(Stream stream)
        {
            if (stream is FileStream fs)
            {
                return fs.Name.EndsWith(".glb", StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        private static GltfData BuildGltfData(Scene scene, GltfSaveOptions options)
        {
            var gltfData = new GltfData();
            
            var allMeshes = new List<Mesh>();
            var allNodes = new List<Node>();

            var visitedNodes = new HashSet<Node>();
            CollectNodes(scene.RootNode, allNodes, allMeshes, visitedNodes);

            var bufferViews = new List<Dictionary<string, object>>();
            var accessors = new List<Dictionary<string, object>>();
            var meshes = new List<Dictionary<string, object>>();
            var nodes = new List<Dictionary<string, object>>();

            var bufferData = new MemoryStream();
            var binaryWriter = new BinaryWriter(bufferData);

            var meshIndexMap = new Dictionary<Mesh, int>();
            var nodeIndexMap = new Dictionary<Node, int>();

            for (int i = 0; i < allNodes.Count; i++)
            {
                nodeIndexMap[allNodes[i]] = i;
            }

            for (int i = 0; i < allMeshes.Count; i++)
            {
                var mesh = allMeshes[i];
                var meshData = BuildMeshData(mesh, options, binaryWriter, bufferViews, accessors, i);
                meshes.Add(meshData);
                meshIndexMap[mesh] = i;
            }

            for (int i = 0; i < allNodes.Count; i++)
            {
                var node = allNodes[i];
                var nodeData = BuildNodeData(node, meshIndexMap, nodeIndexMap, i);
                nodes.Add(nodeData);
            }

            var root = new Dictionary<string, object>
            {
                { "asset", new Dictionary<string, object>
                    {
                        { "version", "2.0" },
                        { "generator", "Aspose.3D FOSS Implementation" }
                    }
                },
                { "buffers", new List<Dictionary<string, object>>
                    {
                        new Dictionary<string, object>
                        {
                            { "byteLength", bufferData.Length }
                        }
                    }
                },
                { "bufferViews", bufferViews },
                { "accessors", accessors },
                { "meshes", meshes },
                { "nodes", nodes },
                { "scenes", new List<Dictionary<string, object>>
                    {
                        new Dictionary<string, object>
                        {
                            { "nodes", new List<int>() }
                        }
                    }
                },
                { "scene", 0 }
            };

            var firstSceneNodes = root["scenes"] as List<Dictionary<string, object>>;
            if (firstSceneNodes != null && firstSceneNodes.Count > 0)
            {
                var sceneNodes = new List<int>();
                foreach (var child in scene.RootNode.ChildNodes)
                {
                    if (nodeIndexMap.TryGetValue(child, out int nodeIdx))
                    {
                        sceneNodes.Add(nodeIdx);
                    }
                }
                firstSceneNodes[0]["nodes"] = sceneNodes;
            }

            gltfData.JsonData = root;
            gltfData.BinaryData = bufferData.ToArray();

            return gltfData;
        }

        private static void CollectNodes(Node node, List<Node> allNodes, List<Mesh> allMeshes, HashSet<Node> visited)
        {
            if (visited.Contains(node))
                return;
            visited.Add(node);

            allNodes.Add(node);

            foreach (var entity in node.Entities)
            {
                if (entity is Mesh mesh)
                {
                    if (!allMeshes.Contains(mesh))
                    {
                        allMeshes.Add(mesh);
                    }
                }
                else if (entity is Primitive primitive)
                {
                    var primMesh = primitive.ToMesh();
                    if (!allMeshes.Contains(primMesh))
                    {
                        allMeshes.Add(primMesh);
                    }
                }
            }

            foreach (var child in node.ChildNodes)
            {
                CollectNodes(child, allNodes, allMeshes, visited);
            }
        }

        private static Dictionary<string, object> BuildMeshData(Mesh mesh, GltfSaveOptions options, BinaryWriter binaryWriter, List<Dictionary<string, object>> bufferViews, List<Dictionary<string, object>> accessors, int meshIdx)
        {
            var meshData = new Dictionary<string, object>();
            meshData["name"] = mesh.Name ?? $"mesh_{meshIdx}";

            var primitives = new List<Dictionary<string, object>>();

            if (mesh.PolygonCount > 0 && mesh.ControlPoints.Count > 0)
            {
                var positions = new List<float>();
                var indices = new List<ushort>();

                foreach (var cp in mesh.ControlPoints)
                {
                    positions.Add((float)cp.X);
                    positions.Add((float)cp.Y);
                    positions.Add((float)cp.Z);
                }

                var positionBufferOffset = (int)binaryWriter.BaseStream.Position;
                foreach (var p in positions)
                {
                    binaryWriter.Write(p);
                }
                binaryWriter.Flush();

                var positionView = new Dictionary<string, object>
                {
                    { "buffer", 0 },
                    { "byteOffset", positionBufferOffset },
                    { "byteLength", positions.Count * 4 },
                    { "byteStride", 12 },
                    { "target", 34962 }
                };
                bufferViews.Add(positionView);

                var positionAccessorIdx = accessors.Count;
                var positionAccessor = new Dictionary<string, object>
                {
                    { "bufferView", bufferViews.Count - 1 },
                    { "byteOffset", 0 },
                    { "componentType", 5126 },
                    { "count", mesh.ControlPoints.Count },
                    { "type", "VEC3" }
                };
                accessors.Add(positionAccessor);

                int? normalAccessorIdx = null;
                int? tangentAccessorIdx = null;
                int? texcoordAccessorIdx = null;
                int? colorAccessorIdx = null;

                foreach (var element in mesh.VertexElements)
                {
                    if (element.VertexElementType == VertexElementType.Normal)
                    {
                        normalAccessorIdx = WriteVertexElementData(element, binaryWriter, bufferViews, accessors);
                    }
                    else if (element.VertexElementType == VertexElementType.Tangent)
                    {
                        tangentAccessorIdx = WriteVertexElementData(element, binaryWriter, bufferViews, accessors);
                    }
                    else if (element.VertexElementType == VertexElementType.UV)
                    {
                        texcoordAccessorIdx = WriteVertexElementData(element, binaryWriter, bufferViews, accessors);
                    }
                    else if (element.VertexElementType == VertexElementType.VertexColor)
                    {
                        colorAccessorIdx = WriteVertexElementData(element, binaryWriter, bufferViews, accessors);
                    }
                }

                foreach (var polygon in mesh.Polygons)
                {
                    if (polygon.Length == 3)
                    {
                        indices.Add((ushort)polygon[0]);
                        indices.Add((ushort)polygon[1]);
                        indices.Add((ushort)polygon[2]);
                    }
                    else if (polygon.Length == 4)
                    {
                        indices.Add((ushort)polygon[0]);
                        indices.Add((ushort)polygon[1]);
                        indices.Add((ushort)polygon[2]);
                        indices.Add((ushort)polygon[0]);
                        indices.Add((ushort)polygon[2]);
                        indices.Add((ushort)polygon[3]);
                    }
                }

                if (indices.Count > 0)
                {
                    var indexBufferOffset = (int)binaryWriter.BaseStream.Position;
                    foreach (var idx in indices)
                    {
                        binaryWriter.Write(idx);
                    }
                    binaryWriter.Flush();

                    var indexView = new Dictionary<string, object>
                    {
                        { "buffer", 0 },
                        { "byteOffset", indexBufferOffset },
                        { "byteLength", indices.Count * 2 },
                        { "target", 34963 }
                    };
                    bufferViews.Add(indexView);

                    var indexAccessor = new Dictionary<string, object>
                    {
                        { "bufferView", bufferViews.Count - 1 },
                        { "byteOffset", 0 },
                        { "componentType", 5123 },
                        { "count", indices.Count },
                        { "type", "SCALAR" }
                    };
                    accessors.Add(indexAccessor);

                    var primitive = new Dictionary<string, object>
                    {
                        { "mode", 4 },
                        { "attributes", new Dictionary<string, object>
                            {
                                { "POSITION", positionAccessorIdx }
                            }
                        },
                        { "indices", indexAccessor }
                    };

                    primitives.Add(primitive);
                }
            }

            if (primitives.Count > 0)
            {
                meshData["primitives"] = primitives;
            }

            return meshData;
        }

        private static Dictionary<string, object> BuildNodeData(Node node, Dictionary<Mesh, int> meshIndexMap, Dictionary<Node, int> nodeIndexMap, int nodeIdx)
        {
            var nodeData = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(node.Name))
            {
                nodeData["name"] = node.Name;
            }

            foreach (var entity in node.Entities)
            {
                if (entity is Mesh mesh && meshIndexMap.ContainsKey(mesh))
                {
                    nodeData["mesh"] = meshIndexMap[mesh];
                    break;
                }
                else if (entity is Primitive primitive)
                {
                    var primMesh = primitive.ToMesh();
                    if (meshIndexMap.ContainsKey(primMesh))
                    {
                        nodeData["mesh"] = meshIndexMap[primMesh];
                    }
                    break;
                }
            }

            var translation = node.Transform.Translation;
            if (translation.X != 0 || translation.Y != 0 || translation.Z != 0)
            {
                nodeData["translation"] = new[] { translation.X, translation.Y, translation.Z };
            }

            var rotation = node.Transform.Rotation;
            if (rotation.W != 1 || rotation.X != 0 || rotation.Y != 0 || rotation.Z != 0)
            {
                nodeData["rotation"] = new[] { rotation.X, rotation.Y, rotation.Z, rotation.W };
            }

            var scale = node.Transform.Scaling;
            if (scale.X != 1 || scale.Y != 1 || scale.Z != 1)
            {
                nodeData["scale"] = new[] { scale.X, scale.Y, scale.Z };
            }

            if (node.ChildNodes.Count > 0)
            {
                var children = new List<int>();
                foreach (var child in node.ChildNodes)
                {
                    if (nodeIndexMap.TryGetValue(child, out int childIdx))
                    {
                        children.Add(childIdx);
                    }
                }
                if (children.Count > 0)
                {
                    nodeData["children"] = children;
                }
            }

            return nodeData;
        }

        private static void WriteAsciiGltf(Stream stream, GltfData jsonData)
        {
            var json = JsonSerializer.Serialize(jsonData.JsonData, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            using (var writer = new StreamWriter(stream, leaveOpen: true))
            {
                writer.Write(json);
            }
        }

        private static void WriteBinaryGltf(Stream stream, GltfData jsonData)
        {
            var binaryWriter = new BinaryWriter(stream);

            binaryWriter.Write(0x46546C67);
            binaryWriter.Write(2);
            
            var jsonBytes = System.Text.Encoding.UTF8.GetBytes(JsonSerializer.Serialize(jsonData.JsonData, new JsonSerializerOptions
            {
                WriteIndented = false
            }));
            
            var totalSize = 12 + 8 + jsonBytes.Length + 8 + jsonData.BinaryData.Length;
            binaryWriter.Write(totalSize);

            binaryWriter.Write((uint)jsonBytes.Length);
            binaryWriter.Write(0x4E4F534A);
            binaryWriter.Write(jsonBytes);

            binaryWriter.Write((uint)jsonData.BinaryData.Length);
            binaryWriter.Write(0x004E4942);
            binaryWriter.Write(jsonData.BinaryData);
        }


        private static int? WriteVertexElementData(VertexElement element, BinaryWriter binaryWriter, List<Dictionary<string, object>> bufferViews, List<Dictionary<string, object>> accessors)
        {
            string? accessorType = null;
            int componentType = 5126;
            int componentsPerValue = 0;

            if (element.VertexElementType == VertexElementType.UV)
            {
                accessorType = "VEC2";
                componentsPerValue = 2;
            }
            else if (element.VertexElementType == VertexElementType.Normal || element.VertexElementType == VertexElementType.Tangent)
            {
                accessorType = "VEC3";
                componentsPerValue = 3;
            }
            else if (element.VertexElementType == VertexElementType.VertexColor)
            {
                accessorType = "VEC4";
                componentsPerValue = 4;
            }
            else
            {
                return null;
            }

            var data = new List<float>();
            
            if (element is VertexElementUV uvElement)
            {
                foreach (var uv in uvElement.Data)
                {
                    data.Add(uv.X);
                    data.Add(uv.Y);
                }
            }
            else if (element is VertexElementVector vectorElement)
            {
                foreach (var v in vectorElement.Data)
                {
                    data.Add(v.X);
                    data.Add(v.Y);
                    data.Add(v.Z);
                    if (componentsPerValue == 4)
                    {
                        data.Add(v.W);
                    }
                }
            }
            else if (element is VertexElementVertexColor colorElement)
            {
                foreach (var c in colorElement.Data)
                {
                    data.Add(c.X);
                    data.Add(c.Y);
                    data.Add(c.Z);
                    data.Add(c.W);
                }
            }

            if (data.Count == 0)
                return null;

            var bufferOffset = (int)binaryWriter.BaseStream.Position;
            foreach (var d in data)
            {
                binaryWriter.Write(d);
            }
            binaryWriter.Flush();

            var byteStride = componentsPerValue * 4;

            var bufferView = new Dictionary<string, object>
            {
                { "buffer", 0 },
                { "byteOffset", bufferOffset },
                { "byteLength", data.Count * 4 },
                { "byteStride", byteStride },
                { "target", 34962 }
            };
            bufferViews.Add(bufferView);

            var accessorIdx = accessors.Count;
            var accessor = new Dictionary<string, object>
            {
                { "bufferView", bufferViews.Count - 1 },
                { "byteOffset", 0 },
                { "componentType", componentType },
                { "count", data.Count / componentsPerValue },
                { "type", accessorType }
            };
            accessors.Add(accessor);

            return accessorIdx;
        }

        private class GltfData
        {
            public Dictionary<string, object> JsonData { get; set; } = new Dictionary<string, object>();
            public byte[] BinaryData { get; set; } = new byte[0];
        }
    }
}
