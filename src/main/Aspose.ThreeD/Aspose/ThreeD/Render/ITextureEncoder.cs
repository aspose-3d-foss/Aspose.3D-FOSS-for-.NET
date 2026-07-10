// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;

namespace Aspose.ThreeD.Render;

/// <summary>
/// External texture encoder should implement this interface for encoding.
/// </summary>
public interface ITextureEncoder
{
    /// <summary>
    /// File extension name(without dot) of the this encoder
    /// </summary>
    public string FileExtension { get; }

    /// <summary>
    /// Encode texture data into stream
    /// </summary>
    public void Encode(TextureData texture, Stream stream);
}
