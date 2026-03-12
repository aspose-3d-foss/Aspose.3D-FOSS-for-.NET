using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    internal class StlWriter : IExporter
    {
        public void Export(Scene scene, Stream stream, SaveOptions options)
        {
            if (options is StlSaveOptions stlOptions)
            {
                Write(stream, scene, stlOptions);
            }
            else
            {
                throw new ArgumentException("Options must be StlSaveOptions", nameof(options));
            }
        }

        private static void Write(Stream stream, Scene scene, StlSaveOptions options)
        {
            WriteBinarySTL(stream, scene);
        }

        private static void WriteBinarySTL(Stream stream, Scene scene)
        {
            var writer = new BinaryWriter(stream, Encoding.ASCII);

            writer.Write(new byte[80]);

            var triangleCount = CountTriangles(scene);
            writer.Write(triangleCount);

            WriteNodes(writer, scene.RootNode);
        }

        private static void WriteNodes(BinaryWriter writer, Node node)
        {
            foreach (var entity in node.Entities)
            {
                if (entity is Mesh entityMesh)
                {
                    WriteMesh(writer, entityMesh);
                }
                else if (entity is Primitive primitive)
                {
                    var mesh = primitive.ToMesh();
                    WriteMesh(writer, mesh);
                }
            }

            foreach (var childNode in node.ChildNodes)
            {
                WriteNodes(writer, childNode);
            }
        }

        private static void WriteMesh(BinaryWriter writer, Mesh meshToWrite)
        {
            foreach (var polygon in meshToWrite.Polygons)
            {
                if (polygon.Length < 3)
                {
                    continue;
                }

                if (polygon.Length == 3)
                {
                    WriteTriangle(writer, meshToWrite, polygon[0], polygon[1], polygon[2]);
                }
                else if (polygon.Length == 4)
                {
                    var p0 = polygon[0];
                    var p1 = polygon[1];
                    var p2 = polygon[2];
                    var p3 = polygon[3];
                    WriteTriangle(writer, meshToWrite, p0, p1, p2);
                    WriteTriangle(writer, meshToWrite, p0, p2, p3);
                }
                else
                {
                    var p0 = polygon[0];
                    for (var i = 1; i < polygon.Length - 1; i++)
                    {
                        WriteTriangle(writer, meshToWrite, p0, polygon[i], polygon[i + 1]);
                    }
                }
            }
        }

        private static void WriteTriangle(BinaryWriter writer, Mesh meshToWrite, int p0, int p1, int p2)
        {
            var v1 = meshToWrite.ControlPoints[p0];
            var v2 = meshToWrite.ControlPoints[p1];
            var v3 = meshToWrite.ControlPoints[p2];

            var normal = CalculateNormal(v1, v2, v3);

            writer.Write(normal.X);
            writer.Write(normal.Y);
            writer.Write(normal.Z);

            writer.Write((float)v1.X);
            writer.Write((float)v1.Y);
            writer.Write((float)v1.Z);

            writer.Write((float)v2.X);
            writer.Write((float)v2.Y);
            writer.Write((float)v2.Z);

            writer.Write((float)v3.X);
            writer.Write((float)v3.Y);
            writer.Write((float)v3.Z);

            writer.Write((short)0);
        }

        private static Vector3 CalculateNormal(Vector4 p1, Vector4 p2, Vector4 p3)
        {
            var v1 = new Vector3((float)p2.X - (float)p1.X, (float)p2.Y - (float)p1.Y, (float)p2.Z - (float)p1.Z);
            var v2 = new Vector3((float)p3.X - (float)p1.X, (float)p3.Y - (float)p1.Y, (float)p3.Z - (float)p1.Z);

            var cross = new Vector3(
                v1.Y * v2.Z - v1.Z * v2.Y,
                v1.Z * v2.X - v1.X * v2.Z,
                v1.X * v2.Y - v1.Y * v2.X
            );

            var length = Math.Sqrt(cross.X * cross.X + cross.Y * cross.Y + cross.Z * cross.Z);
            if (length > 0)
            {
                return new Vector3((float)(cross.X / length), (float)(cross.Y / length), (float)(cross.Z / length));
            }

            return new Vector3(0, 1, 0);
        }

        private static int CountTriangles(Scene scene)
        {
            var count = 0;
            CountTrianglesRecursive(scene.RootNode, ref count);
            return count;
        }

        private static void CountTrianglesRecursive(Node node, ref int count)
        {
            foreach (var entity in node.Entities)
            {
                if (entity is Mesh meshEntity)
                {
                    count += CountTrianglesInMesh(meshEntity);
                }
                else if (entity is Primitive prim)
                {
                    var primMesh = prim.ToMesh();
                    count += CountTrianglesInMesh(primMesh);
                }
            }

            foreach (var childNode in node.ChildNodes)
            {
                CountTrianglesRecursive(childNode, ref count);
            }
        }

        private static int CountTrianglesInMesh(Mesh mesh)
        {
            var count = 0;
            foreach (var polygon in mesh.Polygons)
            {
                if (polygon.Length == 3)
                {
                    count++;
                }
                else if (polygon.Length == 4)
                {
                    count += 2;
                }
                else if (polygon.Length > 4)
                {
                    count += polygon.Length - 2;
                }
            }
            return count;
        }
    }
}
