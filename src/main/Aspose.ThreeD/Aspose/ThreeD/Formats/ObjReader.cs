using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.ThreeD.Entities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// OBJ format reader
    /// </summary>
    internal class ObjReader
    {
        public static Scene Read(string fileName, ObjLoadOptions options)
        {
            var scene = new Scene();
            var currentNode = scene.RootNode.CreateChildNode("RootEntity");
            var currentMesh = new Mesh("DefaultMesh");
            var materials = new Dictionary<int, string>();

            var vertices = new List<Vector4>();
            var normals = new List<Vector4>();
            var uvs = new List<Vector4>();
            var faces = new List<List<int>>();

            int currentMaterialIndex = -1;
            var objectCount = 0;

            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line) || line.StartsWith("#"))
                        continue;

                    var parts = Regex.Split(line, @"\s+");
                    if (parts.Length == 0)
                        continue;

                    switch (parts[0])
                    {
                        case "v":
                            if (parts.Length >= 4)
                            {
                                var x = double.Parse(parts[1]);
                                var y = double.Parse(parts[2]);
                                var z = double.Parse(parts[3]);
                                var w = parts.Length > 4 ? double.Parse(parts[4]) : 1.0;

                                if (options.FlipCoordinateSystem)
                                {
                                    y = -y;
                                }

                                if (options.Scale != 1.0)
                                {
                                    x *= options.Scale;
                                    y *= options.Scale;
                                    z *= options.Scale;
                                }

                                vertices.Add(new Vector4((float)x, (float)y, (float)z, (float)w));
                            }
                            break;

                        case "vn":
                            if (parts.Length >= 4)
                            {
                                var x = float.Parse(parts[1]);
                                var y = float.Parse(parts[2]);
                                var z = float.Parse(parts[3]);

                                if (options.NormalizeNormal)
                                {
                                    var length = Math.Sqrt(x * x + y * y + z * z);
                                    if (length > 0)
                                    {
                                        x /= (float)length;
                                        y /= (float)length;
                                        z /= (float)length;
                                    }
                                }

                                if (options.FlipCoordinateSystem)
                                {
                                    y = -y;
                                }

                                normals.Add(new Vector4(x, y, z, 0));
                            }
                            break;

                        case "vt":
                            if (parts.Length >= 3)
                            {
                                var u = float.Parse(parts[1]);
                                var v = float.Parse(parts[2]);
                                uvs.Add(new Vector4(u, v, 0, 0));
                            }
                            break;

                        case "f":
                            if (parts.Length >= 4)
                            {
                                var face = new List<int>();
                                for (int i = 1; i < parts.Length; i++)
                                {
                                    var indices = parts[i].Split('/');
                                    int vertexIndex = int.Parse(indices[0]);
                                    if (vertexIndex < 0)
                                        vertexIndex = vertices.Count + vertexIndex + 1;
                                    face.Add(vertexIndex - 1);
                                }
                                faces.Add(face);
                            }
                            break;

                        case "o":
                        case "g":
                            if (faces.Count > 0)
                            {
                                AddMeshToNode(currentNode, currentMesh, vertices, faces, options.FlipCoordinateSystem);
                                vertices = new List<Vector4>();
                                faces = new List<List<int>>();
                            }
                            objectCount++;
                            currentMesh = new Mesh(parts.Length > 1 ? parts[1] : $"Object_{objectCount}");
                            break;

                        case "usemtl":
                            if (parts.Length > 1)
                            {
                                currentMaterialIndex++;
                                materials[currentMaterialIndex] = parts[1];
                            }
                            break;
                    }
                }
            }

            if (faces.Count > 0)
            {
                AddMeshToNode(currentNode, currentMesh, vertices, faces, options.FlipCoordinateSystem);
            }

            return scene;
        }

        private static void AddMeshToNode(Node node, Mesh mesh, List<Vector4> vertices, List<List<int>> faces, bool flipCoordinate)
        {
            foreach (var v in vertices)
            {
                var y = flipCoordinate ? -v.Y : v.Y;
                mesh.ControlPoints.Add(new Vector4(v.X, y, v.Z, v.W));
            }

            foreach (var face in faces)
            {
                if (face.Count == 3)
                {
                    mesh.CreatePolygon(face[0], face[1], face[2]);
                }
                else if (face.Count == 4)
                {
                    mesh.CreatePolygon(face[0], face[1], face[2], face[3]);
                }
                else if (face.Count > 4)
                {
                    mesh.CreatePolygon(face.ToArray());
                }
            }

            if (mesh.PolygonCount > 0)
            {
                node.AddEntity(mesh);
            }
        }

        private static Vector4 ParseVector(string[] parts, int startIndex, bool flipCoordinate)
        {
            var x = float.Parse(parts[startIndex]);
            var y = float.Parse(parts[startIndex + 1]);
            var z = float.Parse(parts[startIndex + 2]);

            if (flipCoordinate)
            {
                y = -y;
            }

            return new Vector4(x, y, z, 0);
        }
    }
}
