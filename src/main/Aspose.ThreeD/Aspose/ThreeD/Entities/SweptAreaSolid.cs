using System;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A SweptAreaSolid constructs a geometry by sweeping a profile along a directrix.
    /// </summary>
    public class SweptAreaSolid : Entity, INamedObject, IMeshConvertible
    {
        private object _shape;
        private object _directrix;
        private EndPoint _startPoint;
        private EndPoint _endPoint;

        /// <summary>
        /// Constructor of SweptAreaSolid
        /// </summary>
        public SweptAreaSolid() : this("SweptAreaSolid")
        {
        }

        /// <summary>
        /// Constructor of SweptAreaSolid
        /// </summary>
        /// <param name="name">Entity name</param>
        protected SweptAreaSolid(string name) : base(name)
        {
            _shape = null;
            _directrix = null;
            _startPoint = new EndPoint(0);
            _endPoint = new EndPoint(1);
        }

        /// <summary>
        /// The base profile to construct the geometry.
        /// </summary>
        public object Shape
        {
            get => _shape;
            set => _shape = value;
        }

        /// <summary>
        /// The directrix that the swept area sweeping along with.
        /// </summary>
        public object Directrix
        {
            get => _directrix;
            set => _directrix = value;
        }

        /// <summary>
        /// The start point of the directrix.
        /// </summary>
        public EndPoint StartPoint
        {
            get => _startPoint;
            set => _startPoint = value;
        }

        /// <summary>
        /// The end point of the directrix.
        /// </summary>
        public EndPoint EndPoint
        {
            get => _endPoint;
            set => _endPoint = value;
        }

        /// <summary>
        /// Convert current object to mesh
        /// </summary>
        public Mesh ToMesh()
        {
            throw new NotImplementedException("SweptAreaSolid to mesh conversion is not yet implemented");
        }
    }
}
