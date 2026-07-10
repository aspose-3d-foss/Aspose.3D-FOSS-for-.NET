// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Describe the parameters of the render target
/// </summary>
public class RenderParameters
{
    /// <summary>
    /// Initialize an instance of
    /// </summary>
    public RenderParameters(bool doubleBuffering, int colorBits, int depthBits, int stencilBits)
    {
    }

    /// <summary>
    /// Gets or sets whether double buffer is used.
    /// </summary>
    public bool DoubleBuffering { get; set; }

    /// <summary>
    /// Gets or sets how many bits will be used by color buffer.
    /// </summary>
    public int ColorBits { get; set; }

    /// <summary>
    /// Gets or sets how many bits will be used by depth buffer.
    /// </summary>
    public int DepthBits { get; set; }

    /// <summary>
    /// Gets or sets how many bits will be used in stencil buffer.
    /// </summary>
    public int StencilBits { get; set; }
}
