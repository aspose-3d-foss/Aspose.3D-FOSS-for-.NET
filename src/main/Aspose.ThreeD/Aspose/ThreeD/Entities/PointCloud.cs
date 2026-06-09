using System;
using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Render;

namespace Aspose.ThreeD.Entities;

/// <summary>
/// The point cloud contains no topology information but only the control points and the vertex elements.
/// </summary>
public class PointCloud : Geometry, INamedObject
{
    private Vector2? dimension;

    /// <summary>
    /// Constructor of
    /// </summary>
    public PointCloud() : this("PointCloud")
    {
    }

    /// <summary>
    /// Constructor of
    /// </summary>
    public PointCloud(string name) : base(name)
    {
    }

    /// <summary>
    /// If a dimension value is present for the point cloud, it indicates an organized point cloud. Without a specified size, it is considered an unorganized point cloud.
    /// Organized point cloud means it has an image-like structure.
    /// </summary>
    public Vector2? Dimension
    {
        get => dimension;
        set => dimension = value;
    }

    /// <summary>
    /// Gets the key of the entity renderer registered in the renderer
    /// </summary>
    public override EntityRendererKey GetEntityRendererKey()
    {
        return new EntityRendererKey("PointCloud");
    }

    /// <summary>
    /// Create a new PointCloud instance from a geometry object
    /// </summary>
    public static PointCloud FromGeometry(Geometry g)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Create a new point cloud instance from a geometry object.
    /// Density is the number of points per unit triangle(Unit triangle are the triangle with maximum surface area from the mesh)
    /// </summary>
    public static PointCloud FromGeometry(Geometry g, int density)
    {
        throw new NotImplementedException();
    }
}
