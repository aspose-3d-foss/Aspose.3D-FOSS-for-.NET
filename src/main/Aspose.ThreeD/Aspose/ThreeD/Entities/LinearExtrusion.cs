using System;
using Aspose.ThreeD.Profiles;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Linear extrusion takes a 2D shape as input and extends the shape in the 3rd dimension.
    /// </summary>
    public class LinearExtrusion : Entity, INamedObject, IMeshConvertible
    {
        private Profile _shape;
        private Vector3 _direction;
        private double _height;
        private int _slices;
        private bool _center;
        private Vector3 _twistOffset;
        private double _twist;

        /// <summary>
        /// Constructor of instance
        /// </summary>
        public LinearExtrusion() : this("LinearExtrusion")
        {
            _shape = null;
            _direction = Vector3.UnitZ;
            _height = 1.0;
            _slices = 1;
            _center = false;
            _twistOffset = Vector3.Zero;
            _twist = 0;
        }

        /// <summary>
        /// Constructor of instance
        /// </summary>
        /// <param name="shape">The base shape to be extruded</param>
        /// <param name="height">The height of the extruded geometry</param>
        public LinearExtrusion(Profile shape, double height) : this("LinearExtrusion")
        {
            _shape = shape;
            _direction = Vector3.UnitZ;
            _height = height;
            _slices = 1;
            _center = false;
            _twistOffset = Vector3.Zero;
            _twist = 0;
        }

        /// <summary>
        /// Constructor of instance
        /// </summary>
        /// <param name="name">Entity name</param>
        protected LinearExtrusion(string name) : base(name)
        {
            _shape = null;
            _direction = Vector3.UnitZ;
            _height = 1.0;
            _slices = 1;
            _center = false;
            _twistOffset = Vector3.Zero;
            _twist = 0;
        }

        /// <summary>
        /// The base shape to be extruded.
        /// </summary>
        public Profile Shape
        {
            get => _shape;
            set => _shape = value;
        }

        /// <summary>
        /// The direction of extrusion, default value is (0, 0, 1)
        /// </summary>
        public Vector3 Direction
        {
            get => _direction;
            set => _direction = value;
        }

        /// <summary>
        /// The height of the extruded geometry, default value is 1.0
        /// </summary>
        public double Height
        {
            get => _height;
            set => _height = value;
        }

        /// <summary>
        /// The slices of the twisted extruded geometry, default value is 1.
        /// </summary>
        public int Slices
        {
            get => _slices;
            set => _slices = value;
        }

        /// <summary>
        /// If this value is false, the linear extrusion Z range is from 0 to height, otherwise the range is from -height/2 to height/2.
        /// </summary>
        public bool Center
        {
            get => _center;
            set => _center = value;
        }

        /// <summary>
        /// The offset that used in twisting, default value is (0, 0, 0).
        /// </summary>
        public Vector3 TwistOffset
        {
            get => _twistOffset;
            set => _twistOffset = value;
        }

        /// <summary>
        /// The number of degrees of through which the shape is extruded.
        /// </summary>
        public double Twist
        {
            get => _twist;
            set => _twist = value;
        }

        /// <summary>
        /// Convert the extrusion to mesh.
        /// </summary>
        public Mesh ToMesh()
        {
            throw new NotImplementedException("LinearExtrusion to mesh conversion is not yet implemented");
        }
    }
}
