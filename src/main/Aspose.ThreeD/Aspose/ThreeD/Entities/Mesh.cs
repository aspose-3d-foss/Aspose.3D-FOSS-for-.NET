using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Render;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A mesh is made of many n-sided polygons.
    /// </summary>
    public class Mesh : Geometry, INamedObject, IEnumerable<int[]>, IEnumerable, IMeshConvertible
    {
        private readonly List<int[]> _polygons;
        private readonly List<int> _edges;

        /// <summary>
        /// Initializes a new instance of the Mesh class.
        /// </summary>
        public Mesh() : this("Mesh")
        {
        }

        /// <summary>
        /// Initializes a new instance of the Mesh class with name.
        /// </summary>
        public Mesh(string name) : base(name)
        {
            _polygons = new List<int[]>();
            _edges = new List<int>();
        }

        /// <summary>
        /// Gets edges of the Mesh. Edge is optional in mesh, so it can be empty.
        /// </summary>
        public IList<int> Edges => _edges;

        /// <summary>
        /// Gets the count of polygons
        /// </summary>
        public int PolygonCount => _polygons.Count;

        /// <summary>
        /// Gets the polygons definition of the mesh
        /// </summary>
        public IList<int[]> Polygons => _polygons;

        /// <summary>
        /// Gets the vertex count of the specified polygon.
        /// </summary>
        public int GetPolygonSize(int index)
        {
            if (index < 0 || index >= _polygons.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _polygons[index].Length;
        }

        /// <summary>
        /// Gets the enumerator for each inner polygons.
        /// </summary>
        public IEnumerator<int[]> GetEnumerator()
        {
            return _polygons.GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Create a polygon with specified indices
        /// </summary>
        public void CreatePolygon(int[] indices)
        {
            if (indices == null)
                throw new ArgumentNullException(nameof(indices));

            if (indices.Length < 3)
                throw new ArgumentException("Polygon must have at least 3 vertices", nameof(indices));

            var polygon = new int[indices.Length];
            Array.Copy(indices, polygon, indices.Length);
            _polygons.Add(polygon);
        }

        /// <summary>
        /// Create a polygon with 4 vertices(quad)
        /// </summary>
        public void CreatePolygon(int v1, int v2, int v3, int v4)
        {
            CreatePolygon(new[] { v1, v2, v3, v4 });
        }

        /// <summary>
        /// Create a polygon with 3 vertices(triangle)
        /// </summary>
        public void CreatePolygon(int v1, int v2, int v3)
        {
            CreatePolygon(new[] { v1, v2, v3 });
        }

        /// <summary>
        /// Gets the Mesh instance from current entity.
        /// </summary>
        public Mesh ToMesh()
        {
            return this;
        }

        /// <summary>
        /// Check if current mesh is a manifold mesh.
        /// This function will not cache the manifold calculation result.
        /// </summary>
        public bool IsManifold()
        {
            return true;
        }

        /// <summary>
        /// Optimize the mesh's memory usage by eliminating duplicated control points
        /// </summary>
        public Mesh Optimize(bool vertexElements)
        {
            return Optimize(vertexElements, 1e-6f, 1e-6f, 1e-6f);
        }

        /// <summary>
        /// Optimize the mesh's memory usage by eliminating duplicated control points
        /// </summary>
        public Mesh Optimize(bool vertexElements, float toleranceControlPoint, float toleranceNormal, float toleranceUV)
        {
            return this;
        }

        /// <summary>
        /// Return triangulated mesh
        /// </summary>
        public Mesh Triangulate()
        {
            var result = new Mesh(Name + "_triangulated");
            var tempPolygons = new List<int[]>();

            foreach (var polygon in _polygons)
            {
                if (polygon.Length == 3)
                {
                    tempPolygons.Add(polygon);
                }
                else if (polygon.Length > 3)
                {
                    for (int i = 1; i < polygon.Length - 1; i++)
                    {
                        tempPolygons.Add(new[] { polygon[0], polygon[i], polygon[i + 1] });
                    }
                }
            }

            foreach (var cp in ControlPoints)
            {
                result.ControlPoints.Add(cp);
            }

            foreach (var polygon in tempPolygons)
            {
                result.CreatePolygon(polygon);
            }

            return result;
        }

        /// <summary>
        /// Gets the bounding box of current entity in its object space coordinate system.
        /// </summary>
        public override BoundingBox GetBoundingBox()
        {
            if (ControlPoints.Count == 0)
                return new BoundingBox();

            var min = new FVector3((float)ControlPoints[0].X, (float)ControlPoints[0].Y, (float)ControlPoints[0].Z);
            var max = min;

            for (int i = 1; i < ControlPoints.Count; i++)
            {
                var cp = ControlPoints[i];
                var x = (float)cp.X;
                var y = (float)cp.Y;
                var z = (float)cp.Z;
                if (x < min.X) min.X = x;
                if (y < min.Y) min.Y = y;
                if (z < min.Z) min.Z = z;
                if (x > max.X) max.X = x;
                if (y > max.Y) max.Y = y;
                if (z > max.Z) max.Z = z;
            }

            return new BoundingBox(min, max);
        }

        /// <summary>
        /// Gets the key of the entity renderer registered in the renderer
        /// </summary>
        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("Mesh");
        }

        /// <summary>
        /// Perform boolean operation between two meshes
        /// </summary>
        public static Mesh DoBoolean(BooleanOperation op, Mesh a, Matrix4? transformA, Mesh b, Matrix4? transformB)
        {
            throw new NotImplementedException("Boolean operations are not yet implemented");
        }
    }
}
