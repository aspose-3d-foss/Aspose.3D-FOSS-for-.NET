using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    internal class PlyWriter : IExporter
    {
        public void Export(Scene scene, Stream stream, SaveOptions options)
        {
            if (options is PlySaveOptions plyOptions)
            {
                Write(stream, scene, plyOptions);
            }
            else
            {
                throw new ArgumentException("Options must be PlySaveOptions", nameof(options));
            }
        }

        private static void Write(Stream stream, Scene scene, PlySaveOptions options)
        {
            // Write ASCII PLY format as a basic implementation
            var writer = new StreamWriter(stream, Encoding.ASCII);

            writer.WriteLine("ply");
            writer.WriteLine("format ascii 1.0");
            writer.WriteLine("element vertex " + CountVertices(scene));
            writer.WriteLine("property float x");
            writer.WriteLine("property float y");
            writer.WriteLine("property float z");
            writer.WriteLine("element face " + CountFaces(scene));
            writer.WriteLine("property list uchar int vertex_indices");
            writer.WriteLine("end_header");

            WriteVertices(writer, scene);
            WriteFaces(writer, scene);

            writer.Flush();
        }

        private static void WriteVertices(StreamWriter writer, Scene scene)
        {
            var vertexMap = new Dictionary<int, Vector4>();
            CollectVertices(scene.RootNode, vertexMap);

            foreach (var vertex in vertexMap.Values)
            {
                writer.WriteLine($"{vertex.X} {vertex.Y} {vertex.Z}");
            }
        }

        private static void WriteFaces(StreamWriter writer, Scene scene)
        {
            var faceIndex = 0;
            WriteFacesRecursive(writer, scene.RootNode, ref faceIndex);
        }

        private static void WriteFacesRecursive(StreamWriter writer, Node node, ref int faceIndex)
        {
            foreach (var entity in node.Entities)
            {
                if (entity is Mesh meshEntity)
                {
                    foreach (var polygon in meshEntity.Polygons)
                    {
                        if (polygon.Length >= 3)
                        {
                            var indices = string.Join(" ", polygon);
                            writer.WriteLine($"{polygon.Length} {indices}");
                            faceIndex++;
                        }
                    }
                }
            }

            foreach (var childNode in node.ChildNodes)
            {
                WriteFacesRecursive(writer, childNode, ref faceIndex);
            }
        }

        private static void CollectVertices(Node node, Dictionary<int, Vector4> vertexMap)
        {
            foreach (var entity in node.Entities)
            {
                if (entity is Mesh meshEntity)
                {
                    for (int i = 0; i < meshEntity.ControlPoints.Count; i++)
                    {
                        if (!vertexMap.ContainsKey(i))
                        {
                            vertexMap[i] = meshEntity.ControlPoints[i];
                        }
                    }
                }
            }

            foreach (var childNode in node.ChildNodes)
            {
                CollectVertices(childNode, vertexMap);
            }
        }

        private static int CountVertices(Scene scene)
        {
            var count = 0;
            var vertexMap = new Dictionary<int, Vector4>();
            CountVerticesRecursive(scene.RootNode, vertexMap);
            return vertexMap.Count;
        }

        private static void CountVerticesRecursive(Node node, Dictionary<int, Vector4> vertexMap)
        {
            foreach (var entity in node.Entities)
            {
                if (entity is Mesh meshEntity)
                {
                    for (int i = 0; i < meshEntity.ControlPoints.Count; i++)
                    {
                        if (!vertexMap.ContainsKey(i))
                        {
                            vertexMap[i] = meshEntity.ControlPoints[i];
                        }
                    }
                }
            }

            foreach (var childNode in node.ChildNodes)
            {
                CountVerticesRecursive(childNode, vertexMap);
            }
        }

        private static int CountFaces(Scene scene)
        {
            var count = 0;
            CountFacesRecursive(scene.RootNode, ref count);
            return count;
        }

        private static void CountFacesRecursive(Node node, ref int count)
        {
            foreach (var entity in node.Entities)
            {
                if (entity is Mesh meshEntity)
                {
                    foreach (var polygon in meshEntity.Polygons)
                    {
                        if (polygon.Length >= 3)
                        {
                            count++;
                        }
                    }
                }
            }

            foreach (var childNode in node.ChildNodes)
            {
                CountFacesRecursive(childNode, ref count);
            }
        }
    }
}
