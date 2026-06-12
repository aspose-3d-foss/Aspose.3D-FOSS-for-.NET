using System;
using Vector2 = Aspose.ThreeD.Utilities.Vector2;
using Vector3 = Aspose.ThreeD.Utilities.Vector3;
using Vector4 = Aspose.ThreeD.Utilities.Vector4;
using Aspose.ThreeD.Render;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Parameterized Cylinder.
    /// It can also be used to represent a cone when one of radiusTop/radiusBottom is zero.
    /// </summary>
    public class Cylinder : Primitive
    {
        private double _radiusTop;
        private double _radiusBottom;
        private double _height;
        private int _radialSegments;
        private int _heightSegments;
        private bool _openEnded;
        private double _thetaStart;
        private double _thetaLength;
        private bool _generateFanCylinder;
        private Vector2 _shearTop;
        private Vector2 _shearBottom;
        private Vector3 _offsetTop;
        private Vector3 _offsetBottom;

        /// <summary>
        /// Initializes a new instance of Cylinder class.
        /// </summary>
        public Cylinder() : this("Cylinder", 1, 1, 1, 32, 1, false, 0, Math.PI * 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of Cylinder class.
        /// </summary>
        public Cylinder(double radius, double height)
            : this("Cylinder", radius, radius, height, 32, 1, false, 0, Math.PI * 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of Cylinder class.
        /// </summary>
        public Cylinder(double radiusTop, double radiusBottom, double height)
            : this("Cylinder", radiusTop, radiusBottom, height, 32, 1, false, 0, Math.PI * 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of Cylinder class.
        /// </summary>
        public Cylinder(double radiusTop, double radiusBottom, double height, int radialSegments, int heightSegments, bool openEnded)
            : this("Cylinder", radiusTop, radiusBottom, height, radialSegments, heightSegments, openEnded, 0, Math.PI * 2)
        {
        }

        /// <summary>
        /// Initializes a new instance of Cylinder class.
        /// </summary>
        public Cylinder(string name, double radiusTop, double radiusBottom, double height, int radialSegments, int heightSegments, bool openEnded, double thetaStart, double thetaLength)
            : base(name)
        {
            _radiusTop = radiusTop;
            _radiusBottom = radiusBottom;
            _height = height;
            _radialSegments = radialSegments;
            _heightSegments = heightSegments;
            _openEnded = openEnded;
            _thetaStart = thetaStart;
            _thetaLength = thetaLength;
            _generateFanCylinder = false;
            _shearTop = new Vector2(0, 0);
            _shearBottom = new Vector2(0, 0);
            _offsetTop = new Vector3(0, 0, 0);
            _offsetBottom = new Vector3(0, 0, 0);
        }

        /// <summary>
        /// Gets or sets the vertices transformation offset of the bottom side.
        /// </summary>
        public Vector3 OffsetBottom
        {
            get => _offsetBottom;
            set => _offsetBottom = value;
        }

        /// <summary>
        /// Gets or sets the vertices transformation offset of the top side.
        /// </summary>
        public Vector3 OffsetTop
        {
            get => _offsetTop;
            set => _offsetTop = value;
        }

        /// <summary>
        /// Gets or sets whether to generate fan-style cylinder when ThetaLength is less than 2*PI, otherwise the model will not be cut.
        /// </summary>
        public bool GenerateFanCylinder
        {
            get => _generateFanCylinder;
            set => _generateFanCylinder = value;
        }

        /// <summary>
        /// Gets or sets shear transform of the bottom side, vector stores the (x-axis, z-axis) shear value that measured in radian, default value is (0, 0)
        /// </summary>
        public Vector2 ShearBottom
        {
            get => _shearBottom;
            set => _shearBottom = value;
        }

        /// <summary>
        /// Gets or sets shear transform of the top side, vector stores the (x-axis, z-axis) shear value that measured in radian, default value is (0, 0)
        /// </summary>
        public Vector2 ShearTop
        {
            get => _shearTop;
            set => _shearTop = value;
        }

        /// <summary>
        /// Gets or sets radius of cylinder's top cap.
        /// </summary>
        public double RadiusTop
        {
            get => _radiusTop;
            set => _radiusTop = value;
        }

        /// <summary>
        /// Gets or sets radius of cylinder's bottom cap.
        /// </summary>
        public double RadiusBottom
        {
            get => _radiusBottom;
            set => _radiusBottom = value;
        }

        /// <summary>
        /// Gets or sets height of the cylinder.
        /// </summary>
        public double Height
        {
            get => _height;
            set => _height = value;
        }

        /// <summary>
        /// Gets or sets radial segments.
        /// </summary>
        public int RadialSegments
        {
            get => _radialSegments;
            set => _radialSegments = value;
        }

        /// <summary>
        /// Gets or sets height segments.
        /// </summary>
        public int HeightSegments
        {
            get => _heightSegments;
            set => _heightSegments = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this cylinder is open ended.
        /// The default value is false.
        /// </summary>
        public bool OpenEnded
        {
            get => _openEnded;
            set => _openEnded = value;
        }

        /// <summary>
        /// Gets or sets theta start.
        /// The default value is 0.
        /// </summary>
        public double ThetaStart
        {
            get => _thetaStart;
            set => _thetaStart = value;
        }

        /// <summary>
        /// Gets or sets length of theta.
        /// The default value is 2π.
        /// </summary>
        public double ThetaLength
        {
            get => _thetaLength;
            set => _thetaLength = value;
        }

        /// <summary>
        /// Convert current object to mesh
        /// </summary>
        public override Mesh ToMesh()
        {
            var mesh = new Mesh(Name);
            var radiusTop = (float)_radiusTop;
            var radiusBottom = (float)_radiusBottom;
            var height = (float)_height;
            var halfHeight = height / 2;

            var topCenter = new Vector4(_offsetTop.X, halfHeight + _offsetTop.Y, _offsetTop.Z, 1);
            var bottomCenter = new Vector4(_offsetBottom.X, -halfHeight + _offsetBottom.Y, _offsetBottom.Z, 1);

            for (int i = 0; i <= _radialSegments; i++)
            {
                var angle = _thetaStart + _thetaLength * i / _radialSegments;
                var sinAngle = Math.Sin(angle);
                var cosAngle = Math.Cos(angle);

                var x = (float)(radiusTop * cosAngle);
                var z = (float)(radiusTop * sinAngle);
                mesh.ControlPoints.Add(new Vector4(x, halfHeight, z, 1));
            }

            for (int i = 0; i <= _radialSegments; i++)
            {
                var angle = _thetaStart + _thetaLength * i / _radialSegments;
                var sinAngle = Math.Sin(angle);
                var cosAngle = Math.Cos(angle);

                var x = (float)(radiusBottom * cosAngle);
                var z = (float)(radiusBottom * sinAngle);
                mesh.ControlPoints.Add(new Vector4(x, -halfHeight, z, 1));
            }

            for (int i = 0; i < _radialSegments; i++)
            {
                mesh.CreatePolygon(i, i + 1, _radialSegments + i + 2, _radialSegments + i + 1);
            }

            if (!_openEnded && radiusTop > 0)
            {
                var topIndex = mesh.ControlPoints.Count;
                mesh.ControlPoints.Add(topCenter);
                for (int i = 0; i < _radialSegments; i++)
                {
                    mesh.CreatePolygon(topIndex, i, i + 1);
                }
            }

            if (!_openEnded && radiusBottom > 0)
            {
                var bottomIndex = mesh.ControlPoints.Count;
                mesh.ControlPoints.Add(bottomCenter);
                var bottomStart = _radialSegments + 1;
                for (int i = 0; i < _radialSegments; i++)
                {
                    mesh.CreatePolygon(bottomIndex, bottomStart + i + 1, bottomStart + i);
                }
            }
             return mesh;
        }
    }
}