using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Render;

/// <summary>
/// A  contains at least one viewport for rendering the scene.
/// </summary>
public class Viewport
{
    internal Viewport()
    {
    }

    /// <summary>
    /// Gets or sets the camera of this
    /// </summary>
    public Frustum Frustum { get; set; }

    /// <summary>
    /// Enable or disable this viewport.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets the render target that created this viewport.
    /// </summary>
    public IRenderTarget RenderTarget { get; }

    /// <summary>
    /// Gets or sets the area of the viewport in render target.
    /// </summary>
    public RelativeRectangle Area { get; set; }

    /// <summary>
    /// Gets or sets the Z-order of the viewport.
    /// </summary>
    public int ZOrder { get; set; }

    /// <summary>
    /// Gets or sets the background color of the viewport.
    /// </summary>
    public Vector3 BackgroundColor { get; set; }

    /// <summary>
    /// Gets or sets the depth value used when clear the viewport with depth buffer bit set.
    /// </summary>
    public float DepthClear { get; set; }
}
