using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A bounded curve that trimmed the basis curve at both ends.
    /// </summary>
    public class TrimmedCurve : Curve, INamedObject
    {
        private Curve _basisCurve;
        private EndPoint _first;
        private EndPoint _second;
        private bool _sameDirection;

        /// <summary>
        /// Constructor of TrimmedCurve
        /// </summary>
        public TrimmedCurve() : base("TrimmedCurve")
        {
            _basisCurve = null;
            _first = new EndPoint(0);
            _second = new EndPoint(1);
            _sameDirection = true;
        }

        /// <summary>
        /// The basis curve to be trimmed.
        /// </summary>
        public Curve BasisCurve
        {
            get => _basisCurve;
            set => _basisCurve = value;
        }

        /// <summary>
        /// The first end point to trim, can be a Cartesian point or a real parameter.
        /// </summary>
        public EndPoint First
        {
            get => _first;
            set => _first = value;
        }

        /// <summary>
        /// The second end point to trim, can be a Cartesian point or a real parameter.
        /// </summary>
        public EndPoint Second
        {
            get => _second;
            set => _second = value;
        }

        /// <summary>
        /// Gets or sets whether the trimmed result uses the same direction of the basis curve.
        /// </summary>
        public bool SameDirection
        {
            get => _sameDirection;
            set => _sameDirection = value;
        }
    }
}
