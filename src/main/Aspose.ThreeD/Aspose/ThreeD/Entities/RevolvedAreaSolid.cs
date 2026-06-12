using System;
using Aspose.ThreeD.Profiles;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// This class represents a solid model by revolving a cross section provided by a profile about an axis.
    /// </summary>
    public class RevolvedAreaSolid : Entity, INamedObject, IMeshConvertible
    {
        private Profile _shape;
        private Vector3 _axis;
        private Vector3 _origin;
        private double _angleStart;
        private double _angleEnd;

        /// <summary>
        /// Constructor of RevolvedAreaSolid
        /// </summary>
        public RevolvedAreaSolid() : this("RevolvedAreaSolid")
        {
        }

        /// <summary>
        /// Constructor of RevolvedAreaSolid
        /// </summary>
        /// <param name="name">Entity name</param>
        protected RevolvedAreaSolid(string name) : base(name)
        {
            _shape = null;
            _axis = Vector3.UnitY;
            _origin = Vector3.Zero;
            _angleStart = 0;
            _angleEnd = Math.PI;
        }

        /// <summary>
        /// Gets or sets the starting angle of the revolving procedure, measured in radian, default value is 0.
        /// </summary>
        public double AngleStart
        {
            get => _angleStart;
            set => _angleStart = value;
        }

        /// <summary>
        /// Gets or sets the ending angle of the revolving procedure, measured in radian, default value is pi.
        /// </summary>
        public double AngleEnd
        {
            get => _angleEnd;
            set => _angleEnd = value;
        }

        /// <summary>
        /// Gets or sets the axis direction, default value is (0, 1, 0).
        /// </summary>
        public Vector3 Axis
        {
            get => _axis;
            set => _axis = value;
        }

        /// <summary>
        /// Gets or sets the origin point of the revolving, default value is (0, 0, 0).
        /// </summary>
        public Vector3 Origin
        {
            get => _origin;
            set => _origin = value;
        }

        /// <summary>
        /// Gets or sets the base profile used to revolve.
        /// </summary>
        public Profile Shape
        {
            get => _shape;
            set => _shape = value;
        }

        /// <summary>
        /// Convert the RevolvedAreaSolid into a mesh.
        /// </summary>
        public Mesh ToMesh()
        {
            throw new NotImplementedException("RevolvedAreaSolid to mesh conversion is not yet implemented");
        }
    }
}
