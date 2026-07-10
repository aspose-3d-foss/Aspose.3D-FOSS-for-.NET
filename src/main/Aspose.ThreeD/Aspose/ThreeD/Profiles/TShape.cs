// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible T-shape defined by parameters.
/// </summary>
public class TShape : ParameterizedProfile, INamedObject
{
    /// <summary>
    /// Constructor of
    /// </summary>
    public TShape()
    {
    }

    /// <summary>
    /// Gets or sets the length of the web.
    /// </summary>
    public double Depth { get; set; }

    /// <summary>
    /// Gets or sets the length of the flange.
    /// </summary>
    public double FlangeWidth { get; set; }

    /// <summary>
    /// Gets or sets the wall thickness of web.
    /// </summary>
    public double WebThickness { get; set; }

    /// <summary>
    /// Gets or sets the wall thickness of flange.
    /// </summary>
    public double FlangeThickness { get; set; }

    /// <summary>
    /// Gets or sets the radius of fillet between web and flange.
    /// </summary>
    public double FilletRadius { get; set; }

    /// <summary>
    /// Gets or sets the flange edge radius.
    /// </summary>
    public double FlangeEdgeRadius { get; set; }

    /// <summary>
    /// Gets or sets the web edge radius.
    /// </summary>
    public double WebEdgeRadius { get; set; }

    /// <summary>
    /// Gets the extent in x and y dimension.
    /// </summary>
    /// <returns></returns>
    public Vector2 GetExtent()
    {
        return new Vector2();
    }
}
