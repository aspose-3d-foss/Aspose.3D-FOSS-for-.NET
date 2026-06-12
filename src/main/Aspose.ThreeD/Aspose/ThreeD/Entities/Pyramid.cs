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
    public Pyramid() : this("Pyramid", 10, 10, 5, 5, 5)
    {
    }

    /// <summary>
    /// Construct a new pyramid instance with specified bottom area
    /// </summary>
    public Pyramid(double xbottom, double ybottom, double height) : this("Pyramid", xbottom, ybottom, xbottom / 2, ybottom / 2, height)
    {
    }

    /// <summary>
    /// Construct a new pyramid instance with specified bottom area and top area and height.
    /// </summary>
    public Pyramid(double xbottom, double ybottom, double xtop, double ytop, double height) : this("Pyramid", xbottom, ybottom, xtop, ytop, height)
    {
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
        var mesh = new Mesh(Name);
        var bottomWidth = (float)bottomArea.X;
        var bottomHeight = (float)bottomArea.Y;
        var topWidth = (float)topArea.X;
        var topHeight = (float)topArea.Y;
        var pyramidHeight = (float)height;
        var bottomOffsetX = (float)bottomOffset.X;
        var bottomOffsetY = (float)bottomOffset.Y;

        // Generate vertices for the pyramid
        // A pyramid has a rectangular bottom and a rectangular top (which may be a point)
        // The sides connect corresponding corners of bottom and top

        // Bottom face vertices (clockwise)
        // Bottom-left
        mesh.ControlPoints.Add(new Vector4(-bottomWidth / 2 + bottomOffsetX, -bottomHeight / 2 + bottomOffsetY, 0, 1));
        // Bottom-right
        mesh.ControlPoints.Add(new Vector4(bottomWidth / 2 + bottomOffsetX, -bottomHeight / 2 + bottomOffsetY, 0, 1));
        // Bottom-right-back (or back-right depending on orientation)
        mesh.ControlPoints.Add(new Vector4(bottomWidth / 2 + bottomOffsetX, bottomHeight / 2 + bottomOffsetY, 0, 1));
        // Bottom-left-back (or back-left)
        mesh.ControlPoints.Add(new Vector4(-bottomWidth / 2 + bottomOffsetX, bottomHeight / 2 + bottomOffsetY, 0, 1));

        // Top face vertices (clockwise, centered)
        // Top-left
        mesh.ControlPoints.Add(new Vector4(-topWidth / 2, -topHeight / 2, pyramidHeight, 1));
        // Top-right
        mesh.ControlPoints.Add(new Vector4(topWidth / 2, -topHeight / 2, pyramidHeight, 1));
        // Top-right-back
        mesh.ControlPoints.Add(new Vector4(topWidth / 2, topHeight / 2, pyramidHeight, 1));
        // Top-left-back
        mesh.ControlPoints.Add(new Vector4(-topWidth / 2, topHeight / 2, pyramidHeight, 1));

        // Create polygons for the faces
        // Bottom face
        mesh.CreatePolygon(0, 3, 2, 1);
        // Top face
        mesh.CreatePolygon(4, 5, 6, 7);

        // Side faces (connecting bottom to top)
        // Front face
        mesh.CreatePolygon(1, 2, 6, 5);
        // Back face
        mesh.CreatePolygon(0, 3, 7, 4);
        // Left face
        mesh.CreatePolygon(0, 1, 5, 4);
        // Right face
        mesh.CreatePolygon(2, 3, 7, 6);

        return mesh;
    }
}
