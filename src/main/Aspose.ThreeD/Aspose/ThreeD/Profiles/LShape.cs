// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible L-shape profile that defined by parameters.
/// </summary>
public class LShape : ParameterizedProfile, INamedObject
{
    /// <summary>
    /// Constructor of
    /// </summary>
    public LShape()
    {
    }

    /// <summary>
    /// Gets or sets the depth of the profile.
    /// </summary>
    public double Depth { get; set; }

    /// <summary>
    /// Gets or sets the width of the profile.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Gets or sets the thickness of the constant wall.
    /// </summary>
    public double Thickness { get; set; }

    /// <summary>
    /// Gets or sets the radius of the fillet.
    /// </summary>
    public double FilletRadius { get; set; }

    /// <summary>
    /// Gets or sets the radius of the edge.
    /// </summary>
    public double EdgeRadius { get; set; }

    /// <summary>
    /// Gets the extent in x and y dimension.
    /// </summary>
    /// <returns></returns>
    public Vector2 GetExtent()
    {
        return new Vector2();
    }
}
