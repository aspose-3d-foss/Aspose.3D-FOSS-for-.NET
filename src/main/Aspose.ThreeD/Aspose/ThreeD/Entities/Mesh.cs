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
        private List<int> _edges;

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
        /// Construct a mesh using specified height map, 
        /// if the height map's pixel format contains multiple components, the first(usually the red) component will be used as the height value(z)
        /// The control point's x and y components are normalized pixel coordinate.
        /// </summary>
        public Mesh(TextureData heightMap) : this("Mesh")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Construct a mesh using specified height map, 
        /// if the height map's pixel format contains multiple components, the first(usually the red) component will be used as the height value(z)
        /// The control point's x and y components are normalized pixel coordinate.
        /// </summary>
        public Mesh(TextureData heightMap, Matrix4 transform) : this("Mesh")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Construct a mesh using specified height map, 
        /// if the height map's pixel format contains multiple components, the first(usually the red) component will be used as the height value(z)
        /// The control point's x and y components are normalized pixel coordinate.
        /// </summary>
        public Mesh(TextureData heightMap, bool triMesh, Matrix4 transform) : this("Mesh")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets edges of the Mesh. Edge is optional in mesh, so it can be empty.
        /// </summary>
        public IArrayList<int> Edges => new ArrayListAdapter<int>(_edges);

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
        /// Create a polygon with specified indices
        /// </summary>
        public void CreatePolygon(int[] indices, int offset, int length)
        {
            if (indices == null)
                throw new ArgumentNullException(nameof(indices));

            if (offset < 0 || offset >= indices.Length)
                throw new ArgumentOutOfRangeException(nameof(offset));

            if (length < 3)
                throw new ArgumentException("Polygon must have at least 3 vertices", nameof(length));

            if (offset + length > indices.Length)
                throw new ArgumentException("Offset + length exceeds array bounds", nameof(length));

            var polygon = new int[length];
            Array.Copy(indices, offset, polygon, 0, length);
            _polygons.Add(polygon);
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
         /// Calculate the union of two meshes
         /// </summary>
         public static Mesh operator |(Mesh a, Mesh b)
         {
             throw new NotImplementedException();
         }

         /// <summary>
         /// Calculate the difference of two meshes
         /// </summary>
         public static Mesh operator -(Mesh a, Mesh b)
         {
             throw new NotImplementedException();
         }

         /// <summary>
         /// Calculate the intersection of two meshes
         /// </summary>
         public static Mesh operator &(Mesh a, Mesh b)
         {
             throw new NotImplementedException();
         }

         /// <summary>
         /// Performs boolean operations on meshes
         /// </summary>
         public static Mesh DoBoolean(BooleanOperation op, Mesh a, Nullable<Matrix4> transformA, Mesh b, Nullable<Matrix4> transformB)
         {
             throw new NotImplementedException();
         }
     }
 }