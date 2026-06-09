using System;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A  curve consists of a set of points in the edge of the circle shape.
    /// </summary>
    public class Circle : Curve, INamedObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Circle() : base("Circle")
        {
            Radius = 10;
        }

        /// <summary>
        /// Constructor with radius
        /// </summary>
        /// <param name="radius">The radius of the circle</param>
        public Circle(double radius) : base("Circle")
        {
            Radius = radius;
        }

        /// <summary>
        /// The radius of the circle curve, default value is 10
        /// </summary>
        public double Radius { get; set; }
    }
}
