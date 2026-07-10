// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Data for each face of the cube map texture.
/// </summary>
public struct CubeFaceData<T>
{
    /// <summary>
    /// Gets or sets the data for +X(Right) face
    /// </summary>
    public T PositiveX { get; set; }

    /// <summary>
    /// Gets or sets the data for +X(Right) face
    /// </summary>
    public T Right { get; set; }

    /// <summary>
    /// Gets or sets the data for +X(Left) face
    /// </summary>
    public T NegativeX { get; set; }

    /// <summary>
    /// Gets or sets the data for +X(Left) face
    /// </summary>
    public T Left { get; set; }

    /// <summary>
    /// Gets or sets the data for +Y(Top) face
    /// </summary>
    public T PositiveY { get; set; }

    /// <summary>
    /// Gets or sets the data for +Y(Top) face
    /// </summary>
    public T Top { get; set; }

    /// <summary>
    /// Gets or sets the data for -Y(Bottom) face
    /// </summary>
    public T NegativeY { get; set; }

    /// <summary>
    /// Gets or sets the data for -Y(Bottom) face
    /// </summary>
    public T Bottom { get; set; }

    /// <summary>
    /// Gets or sets the data for +Z(Back) face
    /// </summary>
    public T PositiveZ { get; set; }

    /// <summary>
    /// Gets or sets the data for +Z(Back) face
    /// </summary>
    public T Back { get; set; }

    /// <summary>
    /// Gets or sets the data for -Z(Front) face
    /// </summary>
    public T NegativeZ { get; set; }

    /// <summary>
    /// Gets or sets the data for -Z(Front) face
    /// </summary>
    public T Front { get; set; }

    public T Item { get; set; }
}
