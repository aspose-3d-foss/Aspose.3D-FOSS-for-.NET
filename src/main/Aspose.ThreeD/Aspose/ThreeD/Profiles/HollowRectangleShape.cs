// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible hollow rectangular shape with both inner/outer rounding corners.
/// </summary>
public class HollowRectangleShape : RectangleShape, INamedObject
{
    public HollowRectangleShape()
    {
    }

    /// <summary>
    /// The thickness between the boundary of the rectangle and the inner hole
    /// </summary>
    public double WallThickness { get; set; }

    /// <summary>
    /// The inner fillet radius of the inner rectangle.
    /// </summary>
    public double InnerFilletRadius { get; set; }
}
