using System;
using System.Collections.Generic;
using System.IO;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    internal class StlReader : IImporter
    {
        public Scene Import(Stream stream, LoadOptions options)
        {
            if (options is StlLoadOptions stlOptions)
            {
                return Read(stream, stlOptions);
            }
            throw new ArgumentException("Options must be StlLoadOptions", nameof(options));
        }

        private static Scene Read(Stream stream, StlLoadOptions options)
        {
            var scene = new Scene();
            var node = scene.RootNode.CreateChildNode("STLImport");
            var mesh = new Mesh("STLMesh");

            var buffer = new byte[5];
            using var reader = new BinaryReader(stream);
            buffer = reader.ReadBytes(5);
            stream.Seek(0, SeekOrigin.Begin);

            var header = System.Text.Encoding.ASCII.GetString(buffer);

            if (header.StartsWith("solid"))
            {
                ReadAsciiSTL(stream, mesh);
            }
            else
            {
                ReadBinarySTL(stream, mesh);
            }

            node.AddEntity(mesh);
            return scene;
        }

        private static void ReadAsciiSTL(Stream stream, Mesh mesh)
        {
            using (var reader = new StreamReader(stream))
            {
                string? line;
                var vertices = new List<Vector3>();
                var currentFaceVertices = new List<Vector3>();

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (line.StartsWith("solid", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (line.StartsWith("endsolid", StringComparison.OrdinalIgnoreCase))
                    {
                        if (currentFaceVertices.Count == 3)
                        {
                            AddFace(mesh, currentFaceVertices);
                        }
                        currentFaceVertices.Clear();
                        continue;
                    }

                    if (line.StartsWith("facet normal ", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (line.StartsWith("outer loop", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (line.StartsWith("vertex ", StringComparison.OrdinalIgnoreCase))
                    {
                        var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length >= 4)
                        {
                            var x = float.Parse(parts[1]);
                            var y = float.Parse(parts[2]);
                            var z = float.Parse(parts[3]);
                            currentFaceVertices.Add(new Vector3(x, y, z));
                        }
                    }

                    if (line.StartsWith("endloop", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (line.StartsWith("endfacet", StringComparison.OrdinalIgnoreCase))
                    {
                        if (currentFaceVertices.Count == 3)
                        {
                            AddFace(mesh, currentFaceVertices);
                        }
                        currentFaceVertices.Clear();
                    }
                }
            }
        }

        private static void ReadBinarySTL(Stream stream, Mesh mesh)
        {
            using (var reader = new BinaryReader(stream))
            {
                reader.ReadBytes(80);

                var numTriangles = reader.ReadInt32();

                for (var i = 0; i < numTriangles; i++)
                {
                    var normalX = reader.ReadSingle();
                    var normalY = reader.ReadSingle();
                    var normalZ = reader.ReadSingle();

                    var vertex1X = reader.ReadSingle();
                    var vertex1Y = reader.ReadSingle();
                    var vertex1Z = reader.ReadSingle();

                    var vertex2X = reader.ReadSingle();
                    var vertex2Y = reader.ReadSingle();
                    var vertex2Z = reader.ReadSingle();

                    var vertex3X = reader.ReadSingle();
                    var vertex3Y = reader.ReadSingle();
                    var vertex3Z = reader.ReadSingle();

                    reader.ReadInt16();

                    var v1 = new Vector3(vertex1X, vertex1Y, vertex1Z);
                    var v2 = new Vector3(vertex2X, vertex2Y, vertex2Z);
                    var v3 = new Vector3(vertex3X, vertex3Y, vertex3Z);

                    AddFace(mesh, new List<Vector3> { v1, v2, v3 });
                }
            }
        }

        private static void AddFace(Mesh mesh, List<Vector3> vertices)
        {
            var indices = new int[3];
            for (var i = 0; i < 3; i++)
            {
                var v = vertices[i];
                indices[i] = mesh.ControlPoints.Count;
                mesh.ControlPoints.Add(new Vector4(v.X, v.Y, v.Z, 1.0f));
            }

            mesh.CreatePolygon(indices[0], indices[1], indices[2]);
        }
    }
}
