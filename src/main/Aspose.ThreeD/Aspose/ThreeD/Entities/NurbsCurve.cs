using System;
using System.Collections.Generic;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// NURBS curve is a curve represented by NURBS(Non-uniform rational basis spline),
    /// A NURBS curve is defined by its , a set of weighted  and a 
    /// The w component in control point is used as control point's weight, whatever it is a  or
    /// </summary>
    public class NurbsCurve : Curve, INamedObject
    {
        private readonly IList<Vector4> _controlPoints;
        private readonly IList<int> _multiplicity;
        private readonly IList<double> _knotVectors;
        private int _order;
        private NurbsType _curveType;
        private CurveDimension _dimension;
        private bool _rational;

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        public NurbsCurve() : this("NurbsCurve")
        {
        }

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name="name">The name of the NurbsCurve</param>
        public NurbsCurve(string name) : base(name)
        {
            _controlPoints = new List<Vector4>();
            _multiplicity = new List<int>();
            _knotVectors = new List<double>();
            _order = 2;
            _dimension = CurveDimension.ThreeDimensional;
            _curveType = NurbsType.Open;
            _rational = false;
        }

        /// <summary>
        /// Gets all control points
        /// </summary>
        public IList<Vector4> ControlPoints => _controlPoints;

        /// <summary>
        /// Gets the multiplicity.
        /// </summary>
        public IList<int> Multiplicity => _multiplicity;
        /// <summary>
        /// Gets or sets the order of a NURBS curve, it defines the number of nearby control points that influence any given point on the curve.
        /// </summary>
        public int Order
        {
            get => _order;
            set => _order = value;
        }

        /// <summary>
        /// Gets or sets the degree of a NURBS curve, the degree are defined as Order - 1
        /// </summary>
        public int Degree
        {
            get => _order - 1;
            set => _order = value + 1;
        }

        /// <summary>
        /// Gets or sets the curve's dimension.
        /// </summary>
        public CurveDimension Dimension
        {
            get => _dimension;
            set => _dimension = value;
        }

        /// <summary>
        /// Gets or sets the type of the curve.
        /// </summary>
        public NurbsType CurveType
        {
            get => _curveType;
            set => _curveType = value;
        }
        /// <summary>
        /// Gets the knot vector, it is a sequence of parameter values that determines where and how the control points affect the NURBS curve.
        /// </summary>
        public IList<double> KnotVectors => _knotVectors;
        /// <summary>
        /// Gets or sets whether it is rational, this value indicates whether this  is rational spline or non-rational spline.
        /// Non-rational B-spline is a special case of rational B-splines.
        /// </summary>
        public bool Rational
        {
            get => _rational;
            set => _rational = value;
        }

        /// <summary>
        /// Evaluate the NURBS curve
        /// </summary>
        public Vector4[] Evaluate(int steps)
        {
            throw new NotImplementedException("NURBS curve evaluation is not implemented");
        }

        /// <summary>
        /// Evaluate the curve's point at specified position
        /// </summary>
        public Vector4 EvaluateAt(double u)
        {
            throw new NotImplementedException("NURBS curve evaluation is not implemented");
        }
    }
}
