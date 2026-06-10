using System;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// The end point to trim the curve, can be a parameter value or a Cartesian point.
    /// </summary>
    public struct EndPoint
    {
        private readonly Vector3 _point;
        private readonly double _value;
        private readonly bool _isCartesianPoint;

        /// <summary>
        /// Construct a EndPoint from a Cartesian point.
        /// </summary>
        /// <param name="point">Cartesian point</param>
        public EndPoint(Vector3 point)
        {
            _point = point;
            _value = 0;
            _isCartesianPoint = true;
        }

        /// <summary>
        /// Construct a EndPoint from a real parameter.
        /// </summary>
        /// <param name="v">Parameter value</param>
        public EndPoint(double v)
        {
            _point = Vector3.Zero;
            _value = v;
            _isCartesianPoint = false;
        }

        /// <summary>
        /// Is the end point a Cartesian point?
        /// </summary>
        public bool IsCartesianPoint => _isCartesianPoint;

        /// <summary>
        /// Gets the end point as Cartesian point, or thrown an exception.
        /// </summary>
        public Vector3 AsPoint
        {
            get
            {
                if (!_isCartesianPoint)
                    throw new InvalidOperationException("This end point is not a Cartesian point");
                return _point;
            }
        }

        /// <summary>
        /// Gets the end point as a real parameter, or throw an exception.
        /// </summary>
        public double AsValue
        {
            get
            {
                if (_isCartesianPoint)
                    throw new InvalidOperationException("This end point is not a parameter value");
                return _value;
            }
        }

        /// <summary>
        /// Create an end point measured in degree.
        /// </summary>
        /// <param name="degree">Degree value</param>
        /// <returns>End point</returns>
        public static EndPoint FromDegree(double degree)
        {
            return new EndPoint(degree * Math.PI / 180.0);
        }

        /// <summary>
        /// Create an end point measured in radian.
        /// </summary>
        /// <param name="radian">Radian value</param>
        /// <returns>End point</returns>
        public static EndPoint FromRadian(double radian)
        {
            return new EndPoint(radian);
        }

        /// <summary>
        /// Returns a string representation of the current end point.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return _isCartesianPoint ? $"EndPoint(Point: {_point})" : $"EndPoint(Value: {_value})";
        }
    }
}
