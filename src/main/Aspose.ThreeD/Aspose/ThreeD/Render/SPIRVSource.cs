// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// The compiled shader in SPIR-V format.
/// </summary>
public sealed class SPIRVSource : ShaderSource
{
    /// <summary>
    /// Constructor of SPIR-V based shader sources.
    /// </summary>
    public SPIRVSource()
    {
    }

    /// <summary>
    /// Maximum descriptor sets, default value is 10
    /// </summary>
    public int MaximumDescriptorSets { get; set; }

    /// <summary>
    /// Gets or sets the source code of the compute shader.
    /// </summary>
    public byte[] ComputeShader { get; set; }

    /// <summary>
    /// Gets or sets the source code of the geometry shader.
    /// </summary>
    public byte[] GeometryShader { get; set; }

    /// <summary>
    /// Gets or sets the source code of the vertex shader
    /// </summary>
    public byte[] VertexShader { get; set; }

    /// <summary>
    /// Gets or sets the source code of the fragment shader.
    /// </summary>
    public byte[] FragmentShader { get; set; }
}
