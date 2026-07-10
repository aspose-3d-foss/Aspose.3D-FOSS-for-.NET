// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// The source code of shaders in GLSL
/// </summary>
public sealed class GLSLSource : ShaderSource
{
    /// <summary>
    /// GLSL source
    /// </summary>
    public GLSLSource()
    {
    }

    /// <summary>
    /// Gets or sets the source code of the compute shader.
    /// </summary>
    public string ComputeShader { get; set; }

    /// <summary>
    /// Gets or sets the source code of the geometry shader.
    /// </summary>
    public string GeometryShader { get; set; }

    /// <summary>
    /// Gets or sets the source code of the vertex shader
    /// </summary>
    public string VertexShader { get; set; }

    /// <summary>
    /// Gets or sets the source code of the fragment shader.
    /// </summary>
    public string FragmentShader { get; set; }

    /// <summary>
    /// Define virtual file for #include in GLSL source code
    /// </summary>
    public void DefineInclude(string fileName, string content)
    {
        throw new NotImplementedException();
    }
}
