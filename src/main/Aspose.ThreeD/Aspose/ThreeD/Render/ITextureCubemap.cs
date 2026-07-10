// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Cube map texture
/// </summary>
public interface ITextureCubemap : ITextureUnit, IDisposable
{
    public void Load(CubeFaceData<TextureData> data);
    /// <summary>
    /// Load the data into specified face
    /// </summary>
    public void Load(CubeFace face, TextureData data);
    public void LoadFromFiles(CubeFaceData<string> fileNames);
    public void Save(CubeFaceData<string> path, string format);
    public void Save(CubeFaceData<TextureData> bitmap);
    /// <summary>
    /// Save the specified side to memory
    /// </summary>
    public void Save(CubeFace side, TextureData bitmap);
    /// <summary>
    /// Convert the texture unit to  instance
    /// </summary>
    public TextureData ToBitmap(CubeFace side);
}
