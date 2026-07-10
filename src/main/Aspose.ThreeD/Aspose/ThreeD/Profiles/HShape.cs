// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// The  provides the defining parameters of an 'H' or 'I' shape.
/// </summary>
public class HShape : ParameterizedProfile, INamedObject
{
    /// <summary>
    /// Constructor of
    /// </summary>
    public HShape()
    {
    }

    /// <summary>
    /// Gets or sets the extent of the depth.
    /// </summary>
    public double OverallDepth { get; set; }

    /// <summary>
    /// Gets or sets the extent of the width.
    /// </summary>
    public double BottomFlangeWidth { get; set; }

    /// <summary>
    /// Gets or sets the width of the top flange.
    /// </summary>
    public double TopFlangeWidth { get; set; }

    /// <summary>
    /// Gets or sets the thickness of the top flange.
    /// </summary>
    public double TopFlangeThickness { get; set; }

    /// <summary>
    /// Gets or sets the radius of the lower edges of the top flange.
    /// </summary>
    public double TopFlangeEdgeRadius { get; set; }

    /// <summary>
    /// Gets or sets the bottom flange edge radius.
    /// </summary>
    public double BottomFlangeEdgeRadius { get; set; }

    /// <summary>
    /// Gets or sets the bottom flange fillet radius.
    /// </summary>
    public double BottomFlangeFilletRadius { get; set; }

    /// <summary>
    /// Gets or sets the bottom flange thickness.
    /// </summary>
    public double BottomFlangeThickness { get; set; }

    /// <summary>
    /// Gets or sets the top flange fillet radius.
    /// </summary>
    public double TopFlangeFilletRadius { get; set; }

    /// <summary>
    /// Gets or sets the web thickness.
    /// </summary>
    public double WebThickness { get; set; }

    /// <summary>
    /// Gets the extent in x and y dimension.
    /// </summary>
    /// <returns></returns>
    public Vector2 GetExtent()
    {
        return new Vector2();
    }
}
