// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible Z-shape profile that defined by parameters.
/// </summary>
public class ZShape : ParameterizedProfile, INamedObject
{
    /// <summary>
    /// Constructor of
    /// </summary>
    public ZShape()
    {
    }

    /// <summary>
    /// Gets or sets the depth of the profile.
    /// </summary>
    public double Depth { get; set; }

    /// <summary>
    /// Gets or sets the flange width of the profile.
    /// </summary>
    public double FlangeWidth { get; set; }

    /// <summary>
    /// Gets or sets the flange thickness.
    /// </summary>
    public double FlangeThickness { get; set; }

    /// <summary>
    /// Gets or sets the web thickness.
    /// </summary>
    public double WebThickness { get; set; }

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
