// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.IO;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Class to manage encoders and decoders for textures.
/// </summary>
public class TextureCodec
{
    public TextureCodec()
    {
    }

    /// <summary>
    /// Gets all supported encoder formats
    /// </summary>
    public static string[] GetSupportedEncoderFormats()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Register a set of texture encoders and decoders
    /// </summary>
    public static void RegisterCodec(ITextureCodec codec)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Encode texture data into stream using specified format
    /// </summary>
    public static void Encode(TextureData texture, Stream stream, string format)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Decode texture data from stream
    /// </summary>
    public static TextureData Decode(Stream stream, bool reverseY)
    {
        throw new NotImplementedException();
    }
}
