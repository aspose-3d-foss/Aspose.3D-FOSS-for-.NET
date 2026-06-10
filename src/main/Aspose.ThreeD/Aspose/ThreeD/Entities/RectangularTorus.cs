using System;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Parameterized rectangular torus.
    /// </summary>
    public class RectangularTorus : Primitive, INamedObject, IMeshConvertible
    {
        private double _innerRadius;
        private double _outerRadius;
        private double _height;
        private double _arc;
        private double _angleStart;
        private int _radialSegments;

        /// <summary>
        /// Constructor of RectangularTorus
        /// </summary>
        public RectangularTorus() : this("RectangularTorus")
        {
        }

        /// <summary>
        /// Constructor of RectangularTorus
        /// </summary>
        /// <param name="name">Entity name</param>
        public RectangularTorus(string name) : base(name)
        {
            _innerRadius = 17;
            _outerRadius = 20;
            _height = 20;
            _arc = Math.PI;
            _angleStart = 0;
            _radialSegments = 10;
        }

        /// <summary>
        /// The inner radius of the rectangular torus. Default value is 17
        /// </summary>
        public double InnerRadius
        {
            get => _innerRadius;
            set => _innerRadius = value;
        }

        /// <summary>
        /// The outer radius of the rectangular torus. Default value is 20
        /// </summary>
        public double OuterRadius
        {
            get => _outerRadius;
            set => _outerRadius = value;
        }

        /// <summary>
        /// The height of the rectangular torus. Default value is 20
        /// </summary>
        public double Height
        {
            get => _height;
            set => _height = value;
        }

        /// <summary>
        /// The total angle of the arc, measured in radian. Default value is PI
        /// </summary>
        public double Arc
        {
            get => _arc;
            set => _arc = value;
        }

        /// <summary>
        /// The start angle of the arc, measured in radian. Default value is 0
        /// </summary>
        public double AngleStart
        {
            get => _angleStart;
            set => _angleStart = value;
        }

        /// <summary>
        /// The radial segments, default value is 10
        /// </summary>
        public int RadialSegments
        {
            get => _radialSegments;
            set => _radialSegments = value;
        }

        /// <summary>
        /// Convert this primitive to mesh
        /// </summary>
        public override Mesh ToMesh()
        {
            throw new NotImplementedException("RectangularTorus to mesh conversion is not yet implemented");
        }

        /// <summary>
        /// Gets the bounding box of current entity in its object space coordinate system.
        /// </summary>
        public override BoundingBox GetBoundingBox()
        {
            throw new NotImplementedException("RectangularTorus bounding box is not yet implemented");
        }

        /// <summary>
        /// Gets the key of the entity renderer registered in the renderer
        /// </summary>
        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("RectangularTorus");
        }
    }
}
