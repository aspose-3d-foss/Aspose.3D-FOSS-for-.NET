using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// represents a infinity space which is split by a plane, this can be used with
    /// </summary>
    public class HalfSpace : Entity, INamedObject
    {
        private Vector3 _normal;
        private Vector3 _position;

        /// <summary>
        /// Constructs a new instance
        /// </summary>
        public HalfSpace() : this("HalfSpace")
        {
            _normal = Vector3.UnitY;
            _position = Vector3.Zero;
        }

        /// <summary>
        /// Constructs a new instance with given normal vector and a position on the cutter plane
        /// </summary>
        /// <param name="normal">Normal vector</param>
        /// <param name="position">Position on the plane</param>
        public HalfSpace(Vector3 normal, Vector3 position) : this("HalfSpace")
        {
            _normal = normal;
            _position = position;
        }

        /// <summary>
        /// Constructs a new instance with given name
        /// </summary>
        /// <param name="name">Entity name</param>
        protected HalfSpace(string name) : base(name)
        {
            _normal = Vector3.UnitY;
            _position = Vector3.Zero;
        }

        /// <summary>
        /// The normal of the split plane, the plane is defined as N * P + D = 0 where N is Normal and P is any point on the plane.
        /// </summary>
        public Vector3 Normal
        {
            get => _normal;
            set => _normal = value;
        }

        /// <summary>
        /// The any point on the split plane, the plane is defined as N * P + D = 0 where N is Normal and P is any point on the plane.
        /// </summary>
        public Vector3 Position
        {
            get => _position;
            set => _position = value;
        }
    }
}
