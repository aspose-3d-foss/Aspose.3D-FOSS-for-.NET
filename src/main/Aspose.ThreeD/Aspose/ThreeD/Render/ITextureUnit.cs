// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Aspose.ThreeD.Shading;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Render;

/// <summary>
/// represents a texture in the memory that shared between GPU and CPU and can be sampled by the shader,
/// where the  only represents a reference to an external file.
/// More details can be found https://en.wikipedia.org/wiki/Texture_mapping_unit
/// </summary>
public interface ITextureUnit : IDisposable
{
    /// <summary>
    /// Gets the type of this texture unit.
    /// </summary>
    public TextureType Type { get; }

    /// <summary>
    /// Gets the width of this texture.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Gets the height of this texture.
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Gets the height of this texture, for none-3D texture it's always 1.
    /// </summary>
    public int Depth { get; }

    /// <summary>
    /// Gets or sets the wrap mode for texture's U coordinate.
    /// </summary>
    public WrapMode UWrap { get; set; }

    /// <summary>
    /// Gets or sets the wrap mode for texture's V coordinate.
    /// </summary>
    public WrapMode VWrap { get; set; }

    /// <summary>
    /// Gets or sets the wrap mode for texture's W coordinate.
    /// </summary>
    public WrapMode WWrap { get; set; }

    /// <summary>
    /// Gets or sets the filter mode for minification.
    /// </summary>
    public TextureFilter Minification { get; set; }

    /// <summary>
    /// Gets or sets the filter mode for magnification.
    /// </summary>
    public TextureFilter Magnification { get; set; }

    /// <summary>
    /// Gets or sets the filter mode for mipmap.
    /// </summary>
    public TextureFilter Mipmap { get; set; }

    /// <summary>
    /// Gets or sets the scroll of the UV coordinate.
    /// </summary>
    public Vector2 Scroll { get; set; }

    /// <summary>
    /// Gets or sets the scale of the UV coordinate.
    /// </summary>
    public Vector2 Scale { get; set; }
}
