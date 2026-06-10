using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// An Ellipse defines a set of points that form the shape of ellipse.
    /// </summary>
    public class Ellipse : Curve, INamedObject
    {
        private double _semiAxis1;
        private double _semiAxis2;

        /// <summary>
        /// Constructor of Ellipse
        /// </summary>
        public Ellipse() : base("Ellipse")
        {
            _semiAxis1 = 10;
            _semiAxis2 = 5;
        }

        /// <summary>
        /// Constructor of Ellipse
        /// </summary>
        /// <param name="semiAxis1">Radius on X-axis</param>
        /// <param name="semiAxis2">Radius on Y-axis</param>
        public Ellipse(double semiAxis1, double semiAxis2) : base("Ellipse")
        {
            _semiAxis1 = semiAxis1;
            _semiAxis2 = semiAxis2;
        }

        /// <summary>
        /// Radius on X-axis
        /// </summary>
        public double SemiAxis1
        {
            get => _semiAxis1;
            set => _semiAxis1 = value;
        }

        /// <summary>
        /// Radius on Y-axis
        /// </summary>
        public double SemiAxis2
        {
            get => _semiAxis2;
            set => _semiAxis2 = value;
        }
    }
}
