// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible C-shape profile that defined by parameters.
/// The center position of the profile is in the center of the bounding box.
/// </summary>
public class CShape : ParameterizedProfile, INamedObject
{
    /// <summary>
    /// Constructor of
    /// </summary>
    public CShape()
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
    /// Gets or sets the length of girth.
    /// </summary>
    public double Girth { get; set; }

    /// <summary>
    /// Gets or sets the thickness of the wall.
    /// </summary>
    public double WallThickness { get; set; }

    /// <summary>
    /// Gets or sets the internal fillet radius.
    /// </summary>
    public double InternalFilletRadius { get; set; }

    /// <summary>
    /// Gets the extent in x and y dimension.
    /// </summary>
    /// <returns></returns>
    public Vector2 GetExtent()
    {
        return new Vector2();
    }
}
