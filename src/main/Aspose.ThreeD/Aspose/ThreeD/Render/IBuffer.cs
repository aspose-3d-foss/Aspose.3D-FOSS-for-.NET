// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// The base interface of all managed buffers used in rendering
/// </summary>
public interface IBuffer : IDisposable
{
    /// <summary>
    /// Size of this buffer in bytes
    /// </summary>
    int Size { get; }

    void LoadData(byte[] data);
}
