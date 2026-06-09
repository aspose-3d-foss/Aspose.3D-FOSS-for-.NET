using System;

namespace Aspose.ThreeD.Entities;

/// <summary>
/// A helper class to build polygon for
/// </summary>
public sealed class PolygonBuilder
{
    private readonly Mesh mesh;
    private int[]? currentPolygon;

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public PolygonBuilder(Mesh mesh)
    {
        this.mesh = mesh;
    }

    /// <summary>
    /// Begins to add a new polygon
    /// </summary>
    public void Begin()
    {
        currentPolygon = new int[0];
    }

    /// <summary>
    /// Adds a vertex index to the polygon
    /// </summary>
    public void AddVertex(int index)
    {
        if (currentPolygon == null)
            throw new InvalidOperationException("Call Begin() first");

        var newPolygon = new int[currentPolygon.Length + 1];
        Array.Copy(currentPolygon, newPolygon, currentPolygon.Length);
        newPolygon[currentPolygon.Length] = index;
        currentPolygon = newPolygon;
    }

    /// <summary>
    /// Finishes the polygon creation
    /// </summary>
    public void End()
    {
        if (currentPolygon == null)
            throw new InvalidOperationException("Call Begin() first");

        // Add the polygon to the mesh
        // In a real implementation, this would add the polygon to the mesh's polygon list
        currentPolygon = null;
    }
}
