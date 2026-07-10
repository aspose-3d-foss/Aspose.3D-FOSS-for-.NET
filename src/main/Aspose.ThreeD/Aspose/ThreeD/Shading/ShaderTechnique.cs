// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace Aspose.ThreeD.Shading;

/// <summary>
/// A shader technique represents a concrete rendering implementation.
/// </summary>
public class ShaderTechnique
{
    private readonly Dictionary<string, string> _shaderParameters = new Dictionary<string, string>();

    /// <summary>
    /// Initializes a new instance of the ShaderTechnique class.
    /// </summary>
    public ShaderTechnique()
    {
    }

    /// <summary>
    /// Gets or sets the description of this technique.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the shader language used by this technique.
    /// </summary>
    public string ShaderLanguage { get; set; }

    /// <summary>
    /// Gets or sets the shader version used by this technique.
    /// </summary>
    public string ShaderVersion { get; set; }

    /// <summary>
    /// Gets or sets the file name of the external shader file.
    /// </summary>
    public string ShaderFile { get; set; }

    /// <summary>
    /// Gets or sets the content of an embedded shader script.
    /// It could be HLSL/GLSL shader source file.
    /// </summary>
    public byte[] ShaderContent { get; set; }

    /// <summary>
    /// Gets or sets the entry point of the shader.
    /// Some shader like HLSL can have customized shader entries.
    /// </summary>
    public string ShaderEntry { get; set; }

    /// <summary>
    /// Gets or sets the rendering API used by this technique.
    /// </summary>
    public string RenderAPI { get; set; }

    /// <summary>
    /// Gets or sets the version of the rendering API.
    /// </summary>
    public string RenderAPIVersion { get; set; }

    /// <summary>
    /// Gets the shader parameter definition.
    /// The key is the name of the dynamic property, and value is the shader parameter name that the property connected to.
    /// </summary>
    public IDictionary<string, string> ShaderParameters => _shaderParameters;

    /// <summary>
    /// Binds the dynamic property to shader parameter.
    /// </summary>
    public void AddBinding(string property, string shaderParameter)
    {
        _shaderParameters[property] = shaderParameter;
    }
}
