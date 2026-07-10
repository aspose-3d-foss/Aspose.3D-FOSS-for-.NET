// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible hollow circle profile.
/// </summary>
public class HollowCircleShape : CircleShape, INamedObject
{
    public HollowCircleShape()
    {
    }

    /// <summary>
    /// Gets or sets the difference between the outer and inner radius.
    /// </summary>
    public double WallThickness { get; set; }
}
