using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities;

/// <summary>
/// A 3D  has two direction, the  and , the  defines data for each direction.
/// A direction is actually a NURBS curve, that means it's also defined by its , a , and a set of weighted control points(defined in ).
/// </summary>
public class NurbsDirection
{
    private readonly IList<double> knotVectors;
    private readonly IList<int> multiplicity;
    private int order = 3;
    private int degree = 2;
    private int divisions = 10;
    private NurbsType type = NurbsType.Open;
    private int count = 4;

    /// <summary>
    /// Construct a new instance of
    /// </summary>
    public NurbsDirection()
    {
        knotVectors = new List<double>();
        multiplicity = new List<int>();
    }

    /// <summary>
    /// Gets the knot vector, it is a sequence of parameter values that determines where and how the control points affect the NURBS curve.
    /// </summary>
    public IList<double> KnotVectors => knotVectors;

    /// <summary>
    /// Gets the multiplicity.
    /// </summary>
    public IList<int> Multiplicity => multiplicity;

    /// <summary>
    /// Gets or sets the order of a NURBS curve, it defines the number of nearby control points that influence any given point on the curve.
    /// </summary>
    public int Order
    {
        get => order;
        set => order = value;
    }

    /// <summary>
    /// Gets or sets the degree of a NURBS curve, the degree are defined as Order - 1
    /// </summary>
    public int Degree
    {
        get => degree;
        set => degree = value;
    }

    /// <summary>
    /// Gets or sets the number of divisions between adjacent control points in current direction.
    /// </summary>
    public int Divisions
    {
        get => divisions;
        set => divisions = value;
    }

    /// <summary>
    /// Gets or sets the type of the current direction.
    /// </summary>
    public NurbsType Type
    {
        get => type;
        set => type = value;
    }

    /// <summary>
    /// Gets or sets the count of control points in current direction.
    /// </summary>
    public int Count
    {
        get => count;
        set => count = value;
    }
}
