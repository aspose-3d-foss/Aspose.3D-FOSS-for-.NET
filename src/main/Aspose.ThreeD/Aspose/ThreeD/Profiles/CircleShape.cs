// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible circle profile, which can be used to construct a mesh through
/// </summary>
public class CircleShape : ParameterizedProfile, INamedObject
{
    /// <summary>
    /// Construct a  profile with default radius(5).
    /// </summary>
    public CircleShape()
    {
    }

    /// <summary>
    /// Construct a  profile with specified radius.
    /// </summary>
    /// <param name="radius"></param>
    public CircleShape(double radius)
    {
    }

    /// <summary>
    /// Gets or sets the radius of the circle.
    /// </summary>
    public double Radius { get; set; }

    /// <summary>
    /// Gets the extent in x and y dimension.
    /// </summary>
    /// <returns></returns>
    public Vector2 GetExtent()
    {
        return new Vector2();
    }
}
