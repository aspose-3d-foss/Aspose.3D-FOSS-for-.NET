// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// 1D texture
/// </summary>
public interface ITexture1D : ITextureUnit, IDisposable
{
    /// <summary>
    /// Load texture content from specified Bitmap
    /// </summary>
    public void Load(TextureData bitmap);

    /// <summary>
    /// Save the texture content to external file.
    /// </summary>
    public void Save(string path, string format);

    /// <summary>
    /// Save the texture content to external file.
    /// </summary>
    public void Save(TextureData bitmap);

    /// <summary>
    /// Convert the texture unit to  instance
    /// </summary>
    public TextureData ToBitmap();
}
