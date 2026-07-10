// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using System.Collections.Generic;

namespace Aspose.ThreeD.Shading;

/// <summary>
/// A shader material allows to describe the material by external rendering engine or shader language.
/// It uses ShaderTechnique to describe the concrete rendering details,
/// and the most suitable one will be used according to the final rendering platform.
/// For example, your ShaderMaterial instance can have two techniques, one is defined by HLSL, and another is defined by GLSL.
/// Under non-window platform the GLSL should be used instead of HLSL.
/// </summary>
public class ShaderMaterial : Material
{
    private readonly List<ShaderTechnique> _techniques = new List<ShaderTechnique>();

    /// <summary>
    /// Initializes a new instance of the ShaderMaterial class.
    /// </summary>
    public ShaderMaterial()
    {
    }

    /// <summary>
    /// Initializes a new instance of the ShaderMaterial class.
    /// </summary>
    public ShaderMaterial(string name) : base(name)
    {
    }

    /// <summary>
    /// Gets all available techniques defined in this material.
    /// </summary>
    public IList<ShaderTechnique> Techniques => _techniques.AsReadOnly();
}
