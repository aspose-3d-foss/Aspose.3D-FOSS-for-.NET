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
            // TODO: Implement mesh conversion
            return new Mesh();
        }

        /// <summary>
        /// Gets the bounding box of current entity in its object space coordinate system.
        /// </summary>
        public override BoundingBox GetBoundingBox()
        {
            var halfLength = (float)Length / 2;
            var halfWidth = (float)Width / 2;

            var min = new FVector3(-halfWidth, 0, -halfLength);
            var max = new FVector3(halfWidth, 0, halfLength);

            return new BoundingBox(min, max);
        }

        /// <summary>
        /// Gets the key of the entity renderer registered in the renderer
        /// </summary>
        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("Plane");
        }
    }
}
