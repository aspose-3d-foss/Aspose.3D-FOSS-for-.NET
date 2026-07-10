// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Codec for textures
/// </summary>
public interface ITextureCodec
{
    /// <summary>
    /// Gets supported texture decoders.
    /// </summary>
    public ITextureDecoder[] GetDecoders();

    /// <summary>
    /// Gets supported texture encoders.
    /// </summary>
    public ITextureEncoder[] GetEncoders();
}
