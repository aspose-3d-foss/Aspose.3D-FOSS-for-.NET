// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Render;

/// <summary>
/// The vertex buffer holds the polygon vertex data that will be sent to rendering pipeline
/// </summary>
public interface IVertexBuffer : IBuffer, IDisposable
{
    /// <summary>
    /// Gets the vertex declaration
    /// </summary>
    public VertexDeclaration VertexDeclaration { get; }

    /// <summary>
    /// Load vertex data from
    /// </summary>
    public void LoadData(TriMesh mesh);

    /// <summary>
    /// Load data from given position
    /// </summary>
    public void LoadData(IntPtr data, int size);

    /// <summary>
    /// Load data from array
    /// </summary>
    public void LoadData(Array array);
}
