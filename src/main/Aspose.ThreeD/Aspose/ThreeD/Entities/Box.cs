using System;
using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Render;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Box.
    /// </summary>
    public class Box : Primitive
    {
        private double _length;
        private double _width;
        private double _height;
        private int _lengthSegments;
        private int _widthSegments;
        private int _heightSegments;

        /// <summary>
        /// Initializes a new instance of Box class.
        /// </summary>
        public Box() : this("Box", 1, 1, 1, 1, 1, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of Box class.
        /// </summary>
        public Box(double length, double width, double height) : this("Box", length, width, height, 1, 1, 1)
        {
        }

        /// <summary>
        /// Initializes a new instance of Box class.
        /// </summary>
        public Box(string name, double length, double width, double height, int lengthSegments, int widthSegments, int heightSegments)
            : base(name)
        {
            _length = length;
            _width = width;
            _height = height;
            _lengthSegments = lengthSegments;
            _widthSegments = widthSegments;
            _heightSegments = heightSegments;
        }

        /// <summary>
        /// Gets or sets length segments.
        /// </summary>
        public int LengthSegments
        {
            get => _lengthSegments;
            set => _lengthSegments = value;
        }

        /// <summary>
        /// Gets or sets width segments
        /// </summary>
        public int WidthSegments
        {
            get => _widthSegments;
            set => _widthSegments = value;
        }

        /// <summary>
        /// gets or sets height segments.
        /// </summary>
        public int HeightSegments
        {
            get => _heightSegments;
            set => _heightSegments = value;
        }

        /// <summary>
        /// Gets or sets length of box aligned in z-axis.
        /// </summary>
        public double Length
        {
            get => _length;
            set => _length = value;
        }

        /// <summary>
        /// Gets or sets width of box aligned in x-axis.
        /// </summary>
        public double Width
        {
            get => _width;
            set => _width = value;
        }

        /// <summary>
        /// Gets or sets height of box aligned in y-axis.
        /// </summary>
        public double Height
        {
            get => _height;
            set => _height = value;
        }

        /// <summary>
        /// Convert current object to mesh
        /// </summary>
        public override Mesh ToMesh()
        {
            var mesh = new Mesh(Name);
            var halfLength = (float)_length / 2;
            var halfWidth = (float)_width / 2;
            var halfHeight = (float)_height / 2;

            mesh.ControlPoints.Add(new Vector4(-halfWidth, -halfHeight, -halfLength, 1));
            mesh.ControlPoints.Add(new Vector4(halfWidth, -halfHeight, -halfLength, 1));
            mesh.ControlPoints.Add(new Vector4(halfWidth, halfHeight, -halfLength, 1));
            mesh.ControlPoints.Add(new Vector4(-halfWidth, halfHeight, -halfLength, 1));
            mesh.ControlPoints.Add(new Vector4(-halfWidth, -halfHeight, halfLength, 1));
            mesh.ControlPoints.Add(new Vector4(halfWidth, -halfHeight, halfLength, 1));
            mesh.ControlPoints.Add(new Vector4(halfWidth, halfHeight, halfLength, 1));
            mesh.ControlPoints.Add(new Vector4(-halfWidth, halfHeight, halfLength, 1));

            mesh.CreatePolygon(0, 1, 2, 3);
            mesh.CreatePolygon(4, 5, 6, 7);
            mesh.CreatePolygon(0, 4, 7, 3);
            mesh.CreatePolygon(1, 5, 6, 2);
            mesh.CreatePolygon(0, 1, 5, 4);
            mesh.CreatePolygon(3, 2, 6, 7);

            return mesh;
        }

        /// <summary>
        /// Gets the bounding box of current entity in its object space coordinate system.
        /// </summary>
        public override BoundingBox GetBoundingBox()
        {
            var halfLength = (float)_length / 2;
            var halfWidth = (float)_width / 2;
            var halfHeight = (float)_height / 2;

            var min = new FVector3(-halfWidth, -halfHeight, -halfLength);
            var max = new FVector3(halfWidth, halfHeight, halfLength);

            return new BoundingBox(min, max);
        }

        /// <summary>
        /// Gets the key of the entity renderer registered in the renderer
        /// </summary>
        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("Box");
        }
    }
}
