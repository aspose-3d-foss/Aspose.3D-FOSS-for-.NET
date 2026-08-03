using System;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Parameterized plane.
    /// </summary>
    public class Plane : Primitive, INamedObject, IMeshConvertible
    {
        /// <summary>
        /// Initializes a new instance of the Plane with default size 1x1.
        /// </summary>
        public Plane() : this(1, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Plane.
        /// </summary>
        /// <param name="length">Length of the plane</param>
        /// <param name="width">Width of the plane</param>
        public Plane(double length, double width) : this("Plane", length, width, 1, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Plane.
        /// </summary>
        /// <param name="name">Name of the plane</param>
        /// <param name="length">Length of the plane</param>
        /// <param name="width">Width of the plane</param>
        /// <param name="lengthSegments">Length segments</param>
        /// <param name="widthSegments">Width segments</param>
        public Plane(string name, double length, double width, int lengthSegments, int widthSegments) : base(name)
        {
            Length = length;
            Width = width;
            LengthSegments = lengthSegments;
            WidthSegments = widthSegments;
            Up = new Vector3(0, 1, 0);
        }

        /// <summary>
        /// Gets or sets the up vector of the plane, default value is (0, 1, 0), this affects the generation of the plane
        /// </summary>
        public Vector3 Up { get; set; }

        /// <summary>
        /// Gets or sets the length of the plane.
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Gets or sets the width of the plane.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets the length segments.
        /// </summary>
        public int LengthSegments { get; set; }

        /// <summary>
        /// Gets or sets the width segments.
        /// </summary>
        public int WidthSegments { get; set; }

        /// <summary>
        /// Convert current object to mesh
        /// </summary>
        public override Mesh ToMesh()
        {
            var mesh = new Mesh(Name);
            
            var halfLength = (float)Length / 2;
            var halfWidth = (float)Width / 2;
            
            // Calculate the plane basis
            var up = Up;
            if (up.Length == 0)
                up = Vector3.UnitY;
            up = up.Normalize();
            
            // Create two orthogonal vectors in the plane
            Vector3 uDir, vDir;
            if (Math.Abs(up.Y) > 0.99f)
            {
                // Up is close to Y-axis, use Z as reference
                uDir = up.Cross(Vector3.UnitZ).Normalize();
            }
            else
            {
                uDir = up.Cross(Vector3.UnitY).Normalize();
            }
            vDir = up.Cross(uDir).Normalize();
            
            // Calculate corner points
            var p0 = up * -halfWidth + uDir * -halfLength;
            var p1 = up * -halfWidth + uDir * halfLength;
            var p2 = up * halfWidth + uDir * halfLength;
            var p3 = up * halfWidth + uDir * -halfLength;
            
            mesh.ControlPoints.Add(new Vector4((float)p1.X, (float)p1.Y, (float)p1.Z, 1));
            mesh.ControlPoints.Add(new Vector4((float)p0.X, (float)p0.Y, (float)p0.Z, 1));
            mesh.ControlPoints.Add(new Vector4((float)p3.X, (float)p3.Y, (float)p3.Z, 1));
            mesh.ControlPoints.Add(new Vector4((float)p2.X, (float)p2.Y, (float)p2.Z, 1));
            
            mesh.CreatePolygon(0, 1, 2, 3);
            
            return mesh;
        }
    }
}
