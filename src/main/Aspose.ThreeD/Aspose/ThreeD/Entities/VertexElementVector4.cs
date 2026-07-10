// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities;

/// <summary>
/// A helper class for defining concrete implementations.
/// </summary>
public class VertexElementVector4 : VertexElement, IIndexedVertexElement
{
    internal VertexElementVector4()
    {
    }

    /// <summary>
    /// Gets the vertex data
    /// </summary>
    public IArrayList<Vector4> Data => throw new NotImplementedException();

    /// <summary>
    /// Copies data to specified element
    /// </summary>
    public void CopyTo(VertexElementVector4 target)
    {
        throw new NotImplementedException();
    }

    public void SetData(Vector4[] data)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Removes all elements from the direct and the index arrays.
    /// </summary>
    public void Clear()
    {
        throw new NotImplementedException();
    }
}
