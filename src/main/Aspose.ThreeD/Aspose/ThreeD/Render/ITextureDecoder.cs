// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;

namespace Aspose.ThreeD.Render;

/// <summary>
/// External texture decoder should implement this interface for decoding.
/// </summary>
public interface ITextureDecoder
{
    /// <summary>
    /// Decode texture from stream, return null if failed to decode.
    /// </summary>
    public TextureData Decode(Stream stream, bool reverseY);
}
