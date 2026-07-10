// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Render;

/// <summary>
/// The index buffer describes the geometry used in rendering pipeline.
/// </summary>
public interface IIndexBuffer : IBuffer, IDisposable
{
    /// <summary>
    /// Gets the data type of each element.
    /// </summary>
    public IndexDataType IndexDataType { get; }

    /// <summary>
    /// Gets the number of index in this buffer.
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// Load indice data from
    /// </summary>
    public void LoadData(TriMesh mesh);
    public void LoadData(int[] indices);
    public void LoadData(uint[] indices);
    public void LoadData(short[] indices);
}
