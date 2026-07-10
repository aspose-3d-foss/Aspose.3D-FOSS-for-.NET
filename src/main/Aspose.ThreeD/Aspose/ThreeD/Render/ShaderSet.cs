// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Shader programs for each kind of materials
/// </summary>
public class ShaderSet : IDisposable
{
    /// <summary>
    /// Construct the instance of
    /// </summary>
    public ShaderSet()
    {
    }

    /// <summary>
    /// Gets or sets the shader that used to render the lambert material
    /// </summary>
    public ShaderProgram Lambert { get; set; }

    /// <summary>
    /// Gets or sets the shader that used to render the phong material
    /// </summary>
    public ShaderProgram Phong { get; set; }

    /// <summary>
    /// Gets or sets the shader that used to render the PBR material
    /// </summary>
    public ShaderProgram Pbr { get; set; }

    /// <summary>
    /// Gets or sets the fallback shader when required shader is unavailable
    /// </summary>
    public ShaderProgram Fallback { get; set; }

    /// <summary>
    /// Dispose this instance and release all shader programs.
    /// </summary>
    public void Dispose()
    {
    }
}
