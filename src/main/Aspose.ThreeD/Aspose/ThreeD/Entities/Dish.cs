using System;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Parameterized dish.
    /// </summary>
    public class Dish : Primitive, INamedObject, IMeshConvertible
    {
        private double _radius;
        private double _height;
        private int _widthSegments;
        private int _heightSegments;

        /// <summary>
        /// Create a new dish instance with default radius(10) and default height(5)
        /// </summary>
        public Dish() : this("Dish", 10, 5, 32, 16)
        {
        }

        /// <summary>
        /// Create a new dish instance with specified radius and height
        /// </summary>
        /// <param name="radius">Radius of the dish</param>
        /// <param name="height">Height of the dish</param>
        public Dish(double radius, double height) : this("Dish", radius, height, 32, 16)
        {
        }

        /// <summary>
        /// Create a new dish instance with specified radius and height
        /// </summary>
        /// <param name="name">Name of the dish</param>
        /// <param name="radius">Radius of the dish</param>
        /// <param name="height">Height of the dish</param>
        /// <param name="widthSegments">Width segments</param>
        /// <param name="heightSegments">Height segments</param>
        public Dish(string name, double radius, double height, int widthSegments, int heightSegments)
            : base(name)
        {
            _radius = radius;
            _height = height;
            _widthSegments = widthSegments;
            _heightSegments = heightSegments;
        }

        /// <summary>
        /// Radius of the dish
        /// </summary>
        public double Radius
        {
            get => _radius;
            set => _radius = value;
        }

        /// <summary>
        /// Height of the dish
        /// </summary>
        public double Height
        {
            get => _height;
            set => _height = value;
        }

        /// <summary>
        /// Gets or sets the width segments
        /// </summary>
        public int WidthSegments
        {
            get => _widthSegments;
            set => _widthSegments = value;
        }

        /// <summary>
        /// Gets or sets the height segments
        /// </summary>
        public int HeightSegments
        {
            get => _heightSegments;
            set => _heightSegments = value;
        }

        /// <summary>
        /// Convert current object to mesh
        /// </summary>
        public override Mesh ToMesh()
        {
            throw new NotImplementedException("Dish to mesh conversion is not yet implemented");
        }

        /// <summary>
        /// Gets the bounding box of current entity in its object space coordinate system.
        /// </summary>
        public override BoundingBox GetBoundingBox()
        {
            throw new NotImplementedException("Dish bounding box is not yet implemented");
        }

        /// <summary>
        /// Gets the key of the entity renderer registered in the renderer
        /// </summary>
        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("Dish");
        }
    }
}
