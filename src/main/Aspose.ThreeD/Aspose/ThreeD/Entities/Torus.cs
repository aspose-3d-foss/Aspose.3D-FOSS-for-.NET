using System;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Parameterized torus.
    /// </summary>
    public class Torus : Primitive, INamedObject, IMeshConvertible
    {
        private double _radius;
        private double _tube;
        private int _radialSegments;
        private int _tubularSegments;
        private double _arc;

        /// <summary>
        /// Initializes a new instance of the Torus class.
        /// </summary>
        public Torus() : this(1, 0.25, Math.PI * 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Torus class.
        /// </summary>
        /// <param name="radius">Radius of the torus</param>
        /// <param name="tube">Radius of the tube</param>
        public Torus(double radius, double tube) : this(radius, tube, Math.PI * 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Torus class.
        /// </summary>
        /// <param name="radius">Radius of the torus</param>
        /// <param name="tube">Radius of the tube</param>
        /// <param name="arc">Arc angle</param>
        public Torus(double radius, double tube, double arc) : this("Torus", radius, tube, 32, 16, arc)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Torus class.
        /// </summary>
        /// <param name="name">Entity name</param>
        /// <param name="radius">Radius of the torus</param>
        /// <param name="tube">Radius of the tube</param>
        /// <param name="radialSegments">Radial segments</param>
        /// <param name="tubularSegments">Tubular segments</param>
        /// <param name="arc">Arc angle</param>
        public Torus(string name, double radius, double tube, int radialSegments, int tubularSegments, double arc)
            : base(name)
        {
            _radius = radius;
            _tube = tube;
            _radialSegments = radialSegments;
            _tubularSegments = tubularSegments;
            _arc = arc;
        }

        /// <summary>
        /// Gets or sets the radius of the torus.
        /// </summary>
        public double Radius
        {
            get => _radius;
            set => _radius = value;
        }

        /// <summary>
        /// Gets or sets the radius of the tube.
        /// </summary>
        public double Tube
        {
            get => _tube;
            set => _tube = value;
        }

        /// <summary>
        /// Gets or sets the radial segments.
        /// </summary>
        public int RadialSegments
        {
            get => _radialSegments;
            set => _radialSegments = value;
        }

        /// <summary>
        /// Gets or sets the tubular segments.
        /// </summary>
        public int TubularSegments
        {
            get => _tubularSegments;
            set => _tubularSegments = value;
        }

        /// <summary>
        /// Gets or sets the arc.
        /// </summary>
        public double Arc
        {
            get => _arc;
            set => _arc = value;
        }

        /// <summary>
        /// Convert current object to mesh
        /// </summary>
        public override Mesh ToMesh()
        {
            throw new NotImplementedException("Torus to mesh conversion is not yet implemented");
        }

        /// <summary>
        /// Gets the bounding box of current entity in its object space coordinate system.
        /// </summary>
        public override BoundingBox GetBoundingBox()
        {
            throw new NotImplementedException("Torus bounding box is not yet implemented");
        }

        /// <summary>
        /// Gets the key of the entity renderer registered in the renderer
        /// </summary>
        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("Torus");
        }
    }
}
