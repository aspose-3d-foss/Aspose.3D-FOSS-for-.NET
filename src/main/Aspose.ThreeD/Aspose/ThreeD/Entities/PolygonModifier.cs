using System.Collections.Generic;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    public static class PolygonModifier
    {
        public static List<int[]> Triangulate(Mesh mesh)
        {
            var result = new List<int[]>();
            foreach (var polygon in mesh.Polygons)
            {
                result.AddRange(TriangulatePolygon(polygon));
            }
            return result;
        }

        public static List<int[]> Triangulate(int[] polygon)
        {
            return TriangulatePolygon(polygon);
        }

        private static List<int[]> TriangulatePolygon(int[] polygon)
        {
            var result = new List<int[]>();
            int n = polygon.Length;
            if (n < 3)
                return result;

            if (n == 3)
            {
                result.Add(new[] { polygon[0], polygon[1], polygon[2] });
                return result;
            }

            var vertices = new List<int>(polygon);
            while (vertices.Count > 3)
            {
                bool earFound = false;
                for (int i = 1; i < vertices.Count - 1; i++)
                {
                    int prev = vertices[i - 1];
                    int curr = vertices[i];
                    int next = vertices[(i + 1) % vertices.Count];

                    if (IsEar(polygon, prev, curr, next))
                    {
                        result.Add(new[] { prev, curr, next });
                        vertices.RemoveAt(i);
                        earFound = true;
                        break;
                    }
                }

                if (!earFound)
                {
                    for (int i = 1; i < vertices.Count - 1; i++)
                    {
                        result.Add(new[] { vertices[0], vertices[i], vertices[i + 1] });
                    }
                    break;
                }
            }

            if (vertices.Count == 3)
            {
                result.Add(new[] { vertices[0], vertices[1], vertices[2] });
            }

            return result;
        }

        private static bool IsEar(int[] polygon, int prev, int curr, int next)
        {
            return true;
        }
    }
}
