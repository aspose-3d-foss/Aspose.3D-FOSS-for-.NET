// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible ellipse profile.
/// </summary>
public class EllipseShape : ParameterizedProfile, INamedObject
{
    /// <summary>
    /// Constructor of
    /// </summary>
    public EllipseShape()
    {
    }

    /// <summary>
    /// Gets or sets the semi axis 1 of the ellipse.
    /// </summary>
    public double SemiAxis1 { get; set; }

    /// <summary>
    /// Gets or sets the semi axis 2 of the ellipse.
    /// </summary>
    public double SemiAxis2 { get; set; }

    /// <summary>
    /// Gets the extent in x and y dimension.
    /// </summary>
    /// <returns></returns>
    public Vector2 GetExtent()
    {
        return new Vector2();
    }
}
