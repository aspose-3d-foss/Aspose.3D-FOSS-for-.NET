using System;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Render state for building the pipeline
/// The changes made on render state will not affect the created pipeline instances.
/// </summary>
public class RenderState : IDisposable, IComparable<RenderState>
{
    /// <summary>
    /// Constructor of
    /// </summary>
    public RenderState()
    {
    }

    /// <summary>
    /// Enable or disable the fragment blending.
    /// </summary>
    public bool Blend { get; set; }

    /// <summary>
    /// Gets or sets the blend color where used in
    /// </summary>
    public FVector4 BlendColor { get; set; }

    /// <summary>
    /// Gets or sets how the color is blended.
    /// </summary>
    public BlendFactor SourceBlendFactor { get; set; }

    /// <summary>
    /// Gets or sets how the color is blended.
    /// </summary>
    public BlendFactor DestinationBlendFactor { get; set; }

    /// <summary>
    /// Enable or disable cull face
    /// </summary>
    public bool CullFace { get; set; }

    /// <summary>
    /// Gets or sets which face will be culled.
    /// </summary>
    public CullFaceMode CullFaceMode { get; set; }

    /// <summary>
    /// Gets or sets which order is front face.
    /// </summary>
    public FrontFace FrontFace { get; set; }

    /// <summary>
    /// Enable or disable the depth test.
    /// </summary>
    public bool DepthTest { get; set; }

    /// <summary>
    /// Enable or disable the depth writing.
    /// </summary>
    public bool DepthMask { get; set; }

    /// <summary>
    /// Gets or sets the compare function used in depth test
    /// </summary>
    public CompareFunction DepthFunction { get; set; }

    /// <summary>
    /// Enable or disable the stencil test.
    /// </summary>
    public bool StencilTest { get; set; }

    /// <summary>
    /// Gets or sets the reference value for the stencil test.
    /// </summary>
    public int StencilReference { get; set; }

    /// <summary>
    /// Gets or sets the mask that is ANDed with the both reference and stored stencil value when test is done.
    /// </summary>
    public uint StencilMask { get; set; }

    /// <summary>
    /// Gets the stencil state for front face.
    /// </summary>
    public StencilState StencilFrontFace { get; } = new StencilState();

    /// <summary>
    /// Gets the stencil state for back face.
    /// </summary>
    public StencilState StencilBackFace { get; } = new StencilState();

    /// <summary>
    /// Enable or disable scissor test
    /// </summary>
    public bool ScissorTest { get; set; }

    /// <summary>
    /// Gets or sets the polygon's render mode.
    /// </summary>
    public PolygonMode PolygonMode { get; set; }

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    public bool Equals(object obj)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public int GetHashCode()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Dispose the  and release all internal resources.
    /// </summary>
    public void Dispose()
    {
    }

    /// <summary>
    /// Compare the render state with another instance
    /// </summary>
    public int CompareTo(RenderState other)
    {
        throw new NotImplementedException();
    }
}
