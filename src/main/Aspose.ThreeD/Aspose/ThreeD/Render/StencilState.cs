using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Stencil states per face.
/// </summary>
public class StencilState
{
    internal StencilState()
    {
    }

    /// <summary>
    /// Gets or sets the compare function used in stencil test
    /// </summary>
    public CompareFunction Compare { get; set; }

    /// <summary>
    /// Gets or sets the stencil action when stencil test fails.
    /// </summary>
    public StencilAction FailAction { get; set; }

    /// <summary>
    /// Gets or sets the stencil action when stencil test pass but depth test fails.
    /// </summary>
    public StencilAction DepthFailAction { get; set; }

    /// <summary>
    /// Gets or sets the stencil action when both stencil test and depth test passes.
    /// </summary>
    public StencilAction PassAction { get; set; }

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
}
