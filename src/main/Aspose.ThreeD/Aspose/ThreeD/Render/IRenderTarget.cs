// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Render;

/// <summary>
/// The base interface of render target
/// </summary>
public interface IRenderTarget : IDisposable
{
    /// <summary>
    /// Gets or sets the size of the render target.
    /// </summary>
    public Vector2 Size { get; set; }

    /// <summary>
    /// Gets all viewports that associated with this render target.
    /// </summary>
    public IList<Viewport> Viewports { get; }

    /// <summary>
    /// Create a viewport with specified background color and position/size in specified camera perspective.
    /// </summary>
    public Viewport CreateViewport(Camera camera, Vector3 backgroundColor, RelativeRectangle rect);

    /// <summary>
    /// Create a viewport with position/size in specified camera perspective.
    /// </summary>
    public Viewport CreateViewport(Camera camera, RelativeRectangle rect);

    /// <summary>
    /// Create a viewport in specified camera perspective.
    /// </summary>
    public Viewport CreateViewport(Camera camera);
}
