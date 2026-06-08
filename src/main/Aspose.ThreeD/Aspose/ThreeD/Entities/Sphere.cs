using System;
using Vector4 = Aspose.ThreeD.Vector4;
using Aspose.ThreeD.Render;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Parameterized sphere.
    /// </summary>
    public class Sphere : Primitive
    {
        private double _radius;
        private int _widthSegments;
        private int _heightSegments;
        private double _phiStart;
        private double _phiLength;
        private double _thetaStart;
        private double _thetaLength;

        /// <summary>
        /// Initializes a new instance of Sphere with default radius 1.
        /// </summary>
        public Sphere() : this(1)
        {
        }

        /// <summary>
        /// Initializes a new instance of Sphere class with specified radius.
        /// </summary>
        public Sphere(double radius) : this("Sphere", radius, 16, 16, 0, Math.PI * 2, 0, Math.PI * 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of Sphere class with specified radius, width segments and height segments.
        /// </summary>
        public Sphere(double radius, int widthSegments, int heightSegments)
            : this("Sphere", radius, widthSegments, heightSegments, 0, Math.PI * 2, 0, Math.PI * 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of Sphere class.
        /// </summary>
        public Sphere(string name, double radius, int widthSegments, int heightSegments, double phiStart, double phiLength, double thetaStart, double thetaLength)
            : base(name)
        {
            _radius = radius;
            _widthSegments = widthSegments;
            _heightSegments = heightSegments;
            _phiStart = phiStart;
            _phiLength = phiLength;
            _thetaStart = thetaStart;
            _thetaLength = thetaLength;
        }

        /// <summary>
        /// Gets or sets the width segments.
        /// </summary>
        public int WidthSegments
        {
            get => _widthSegments;
            set => _widthSegments = value;
        }

        /// <summary>
        /// Gets or sets the height segments.
        /// </summary>
        public int HeightSegments
        {
            get => _heightSegments;
            set => _heightSegments = value;
        }

        /// <summary>
        /// Gets or sets the phi start.
        /// </summary>
        public double PhiStart
        {
            get => _phiStart;
            set => _phiStart = value;
        }

        /// <summary>
        /// Gets or sets the length of phi.
        /// </summary>
        public double PhiLength
        {
            get => _phiLength;
            set => _phiLength = value;
        }

        /// <summary>
        /// Gets or sets the theta start.
        /// </summary>
        public double ThetaStart
        {
            get => _thetaStart;
            set => _thetaStart = value;
        }

        /// <summary>
        /// Gets or sets the length of theta.
        /// </summary>
        public double ThetaLength
        {
            get => _thetaLength;
            set => _thetaLength = value;
        }

        /// <summary>
        /// Gets or sets radius of the sphere.
        /// </summary>
        public double Radius
        {
            get => _radius;
            set => _radius = value;
        }

        /// <summary>
        /// Convert current object to mesh
        /// </summary>
        public override Mesh ToMesh()
        {
            var mesh = new Mesh(Name);
            var radius = (float)_radius;

            for (int lat = 0; lat <= _heightSegments; lat++)
            {
                var theta = _thetaStart + _thetaLength * lat / _heightSegments;
                var sinTheta = Math.Sin(theta);
                var cosTheta = Math.Cos(theta);

                for (int lon = 0; lon <= _widthSegments; lon++)
                {
                    var phi = _phiStart + _phiLength * lon / _widthSegments;
                    var sinPhi = Math.Sin(phi);
                    var cosPhi = Math.Cos(phi);

                    var x = (float)(radius * cosPhi * sinTheta);
                    var y = (float)(radius * cosTheta);
                    var z = (float)(radius * sinPhi * sinTheta);

                    mesh.ControlPoints.Add(new Vector4(x, y, z, 1));
                }
            }

            for (int lat = 0; lat < _heightSegments; lat++)
            {
                for (int lon = 0; lon < _widthSegments; lon++)
                {
                    var first = lat * (_widthSegments + 1) + lon;
                    var second = first + _widthSegments + 1;

                    mesh.CreatePolygon(first, second, second + 1, first + 1);
                }
            }

            return mesh;
        }

        /// <summary>
        /// Gets the bounding box of current entity in its object space coordinate system.
        /// </summary>
        public override Utilities.BoundingBox GetBoundingBox()
        {
            var radius = (float)_radius;
            var min = new Utilities.FVector3(-radius, -radius, -radius);
            var max = new Utilities.FVector3(radius, radius, radius);

            return new Utilities.BoundingBox(min, max);
        }

        /// <summary>
        /// Gets the key of the entity renderer registered in the renderer
        /// </summary>
        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("Sphere");
        }
    }
}
