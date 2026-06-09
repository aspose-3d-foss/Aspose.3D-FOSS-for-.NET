namespace Aspose.ThreeD.Entities;

/// <summary>
/// Patch's U and V direction.
/// </summary>
public class PatchDirection
{
    private PatchDirectionType type;
    private int divisions;
    private int controlPoints;
    private bool closed;

    public PatchDirection()
    {
    }

    /// <summary>
    /// Gets or sets the patch's type.
    /// </summary>
    public PatchDirectionType Type
    {
        get => type;
        set => type = value;
    }

    /// <summary>
    /// Gets or sets the number of divisions between adjacent control points.
    /// </summary>
    public int Divisions
    {
        get => divisions;
        set => divisions = value;
    }

    /// <summary>
    /// Gets or sets the count of control points in current direction.
    /// </summary>
    public int ControlPoints
    {
        get => controlPoints;
        set => controlPoints = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether this  is a closed curve.
    /// </summary>
    public bool Closed
    {
        get => closed;
        set => closed = value;
    }
}
