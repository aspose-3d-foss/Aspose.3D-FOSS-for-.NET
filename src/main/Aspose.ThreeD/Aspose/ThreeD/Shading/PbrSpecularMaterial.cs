// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Shading;

/// <summary>
/// Material for physically based rendering based on diffuse color/specular/glossiness
/// </summary>
public class PbrSpecularMaterial : Material
{
    /// <summary>
    /// Constructor of the
    /// </summary>
    public PbrSpecularMaterial()
    {
    }

    /// <summary>
    /// Gets or sets the transparency factor.
    /// The factor should be ranged between 0(0%, fully opaque) and 1(100%, fully transparent)
    /// Any invalid factor value will be clamped.
    /// </summary>
    public double Transparency { get; set; }

    /// <summary>
    /// Gets or sets the texture of normal mapping
    /// </summary>
    public TextureBase NormalTexture { get; set; }

    /// <summary>
    /// Gets or sets the texture for specular color, channel RGB stores the specular color and channel A stores the glossiness.
    /// </summary>
    public TextureBase SpecularGlossinessTexture { get; set; }

    /// <summary>
    /// Gets or sets the glossiness(smoothness) of the material, 1 means perfectly smooth and 0 means perfectly rough, default value is 1, range is [0, 1]
    /// </summary>
    public double GlossinessFactor { get; set; }

    /// <summary>
    /// Gets or sets the specular color of the material, default value is (1, 1, 1).
    /// </summary>
    public Vector3 Specular { get; set; }

    /// <summary>
    /// Gets or sets the texture for diffuse color.
    /// </summary>
    public TextureBase DiffuseTexture { get; set; }

    /// <summary>
    /// Gets or sets the diffuse color of the material, default value is (1, 1, 1).
    /// </summary>
    public Vector3 Diffuse { get; set; }

    /// <summary>
    /// Gets or sets the texture for emissive color.
    /// </summary>
    public TextureBase EmissiveTexture { get; set; }

    /// <summary>
    /// Gets or sets the emissive color, default value is (0, 0, 0).
    /// </summary>
    public Vector3 EmissiveColor { get; set; }

    /// <summary>
    /// Used in GetTexture/SetTexture to assign a specular glossiness texture mapping.
    /// </summary>
    public const string MapSpecularGlossiness = "SpecularGlossiness";
}
