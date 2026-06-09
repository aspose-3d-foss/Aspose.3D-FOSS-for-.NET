using Aspose.ThreeD.Utilities;
using System;

namespace Aspose.ThreeD.Entities;

/// <summary>
/// Parameterized pyramid.
/// </summary>
public class Pyramid : Primitive, INamedObject, IMeshConvertible
{
    private Vector2 bottomArea = new Vector2(10, 10);
    private Vector2 topArea = new Vector2(5, 5);
    private Vector3 bottomOffset;
    private double height = 5;

    /// <summary>
    /// Construct a new pyramid instance with default bottom area(10, 10) and default height(5)
    /// </summary>
    public Pyramid() : this("Pyramid")
    {
    }

    /// <summary>
    /// Construct a new pyramid instance with default bottom area(10, 10) and default height(5)
    /// </summary>
    public Pyramid(string name) : base(name)
    {
    }

    /// <summary>
    /// Construct a new pyramid instance with specified bottom area
    /// </summary>
    public Pyramid(double xbottom, double ybottom, double height) : this("Pyramid")
    {
        bottomArea = new Vector2(xbottom, ybottom);
        topArea = new Vector2(xbottom / 2, ybottom / 2);
        this.height = height;
    }

    /// <summary>
    /// Construct a new pyramid instance with specified bottom area and top area and height.
    /// </summary>
    public Pyramid(double xbottom, double ybottom, double xtop, double ytop, double height) : this("Pyramid")
    {
        bottomArea = new Vector2(xbottom, ybottom);
        topArea = new Vector2(xtop, ytop);
        this.height = height;
    }

    /// <summary>
    /// Construct a new pyramid instance with specified bottom area and top area and height.
    /// </summary>
    public Pyramid(string name, double xbottom, double ybottom, double xtop, double ytop, double height)
        : base(name)
    {
        bottomArea = new Vector2(xbottom, ybottom);
        topArea = new Vector2(xtop, ytop);
        this.height = height;
    }

    /// <summary>
    /// Area of the bottom cap
    /// </summary>
    public Vector2 BottomArea
    {
        get => bottomArea;
        set => bottomArea = value;
    }

    /// <summary>
    /// Area of the top cap
    /// </summary>
    public Vector2 TopArea
    {
        get => topArea;
        set => topArea = value;
    }

    /// <summary>
    /// Offset for bottom vertices
    /// </summary>
    public Vector3 BottomOffset
    {
        get => bottomOffset;
        set => bottomOffset = value;
    }

    /// <summary>
    /// Height of the pyramid
    /// </summary>
    public double Height
    {
        get => height;
        set => height = value;
    }

    /// <summary>
    /// Convert current object to mesh
    /// </summary>
    public override Mesh ToMesh()
    {
        throw new NotImplementedException();
    }
}
