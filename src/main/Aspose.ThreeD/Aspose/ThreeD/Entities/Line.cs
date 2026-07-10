using System.Collections.Generic;
using System.Collections;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities;

/// <summary>
/// A polyline is a path defined by a set of points with segments, and connected by edges,
/// which means it can also be a set of connected line segments.
/// The line is usually a linear object, which means it cannot be used to represent a curve, in order to represent a curve, uses NurbsCurve.
/// </summary>
public class Line : Curve, INamedObject
{
    private readonly List<Vector4> controlPoints;
    private bool visible = true;

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public Line() : this("Line")
    {
    }

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public Line(string name) : base(name)
    {
        controlPoints = new List<Vector4>();
    }

    /// <summary>
    /// Gets all control points
    /// </summary>
    public IArrayList<Vector4> ControlPoints => new ArrayListAdapter<Vector4>(controlPoints);

    /// <summary>
    /// Gets or sets if the geometry is visible
    /// </summary>
    public bool Visible
    {
        get => visible;
        set => visible = value;
    }

    /// <summary>
    /// Gets the segments of the line
    /// </summary>
    public IList<int[]> Segments
    {
        get
        {
            // Return a single segment connecting all points
            if (controlPoints.Count < 2)
                return new List<int[]>();

            var segments = new List<int[]>();
            for (int i = 0; i < controlPoints.Count - 1; i++)
            {
                segments.Add(new int[] { i, i + 1 });
            }
            return segments;
        }
    }

    /// <summary>
    /// Generate the sequence 0,1,2,3.....Length-1 to  so the ControlPoints can be used as a single line
    /// </summary>
    public void MakeDefaultIndices()
    {
        // In a real implementation, this would set up default indices
    }

    /// <summary>
    /// Creates a line from points
    /// </summary>
    public static Line FromPoints(Vector3[] points)
    {
        var line = new Line();
        foreach (var point in points)
        {
            line.ControlPoints.Add(new Vector4(point.X, point.Y, point.Z, 1.0));
        }
        return line;
    }
}
