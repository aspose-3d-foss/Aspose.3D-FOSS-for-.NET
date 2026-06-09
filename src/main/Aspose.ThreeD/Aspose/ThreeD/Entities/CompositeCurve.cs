using System.Collections.Generic;

namespace Aspose.ThreeD.Entities;

/// <summary>
/// A  is consisting of several curve segments.
/// </summary>
public class CompositeCurve : Curve, INamedObject
{
    private readonly List<Segment> segments;

    /// <summary>
    /// Constructor of
    /// </summary>
    public CompositeCurve() : this("CompositeCurve")
    {
    }

    /// <summary>
    /// Constructor of
    /// </summary>
    public CompositeCurve(string name) : base(name)
    {
        segments = new List<Segment>();
    }

    /// <summary>
    /// The segments of the curve.
    /// </summary>
    public List<Segment> Segments => segments;

    /// <summary>
    /// Add a new segment to current curve.
    /// </summary>
    public void AddSegment(Curve curve, bool sameDirection)
    {
        segments.Add(new Segment { Curve = curve, SameDirection = sameDirection });
    }

    /// <summary>
    /// A segment in composite curve.
    /// </summary>
    public class Segment
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public Segment()
        {
        }

        /// <summary>
        /// The curve of the segment.
        /// </summary>
        public Curve Curve { get; set; }

        /// <summary>
        /// Whether the curve has the same direction as the composite curve.
        /// </summary>
        public bool SameDirection { get; set; }
    }
}
