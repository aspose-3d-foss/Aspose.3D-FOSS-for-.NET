using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A TransformedCurve gives a curve a placement by using a transformation matrix.
    /// This allows to perform a transformation inside a Scene or Node.
    /// </summary>
    public class TransformedCurve : Curve, INamedObject
    {
        private Curve _basisCurve;
        private Matrix4 _transformMatrix;

        /// <summary>
        /// The constructor of TransformedCurve
        /// </summary>
        public TransformedCurve() : base("TransformedCurve")
        {
            _basisCurve = null;
            _transformMatrix = Matrix4.Identity;
        }

        /// <summary>
        /// The constructor of TransformedCurve
        /// </summary>
        /// <param name="basisCurve">The basis curve</param>
        /// <param name="transformation">The transformation matrix</param>
        public TransformedCurve(Curve basisCurve, Matrix4 transformation) : base("TransformedCurve")
        {
            _basisCurve = basisCurve;
            _transformMatrix = transformation;
        }

        /// <summary>
        /// The transformation matrix.
        /// </summary>
        public Matrix4 TransformMatrix
        {
            get => _transformMatrix;
            set => _transformMatrix = value;
        }

        /// <summary>
        /// The basis curve.
        /// </summary>
        public Curve BasisCurve
        {
            get => _basisCurve;
            set => _basisCurve = value;
        }
    }
}
