// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible rectangular shape with rounding corners.
/// </summary>
public class RectangleShape : ParameterizedProfile, INamedObject
{
    /// <summary>
    /// Constructor of
    /// </summary>
    public RectangleShape()
    {
    }

    /// <summary>
    /// Constructor of  with specified dimension on x and y axis.
    /// </summary>
    /// <param name="xdim"></param>
    /// <param name="ydim"></param>
    public RectangleShape(double xdim, double ydim)
    {
    }

    /// <summary>
    /// Gets or sets the radius of the circular arcs of all four corners, measured in degrees.
    /// Default value is 0.0
    /// </summary>
    public double RoundingRadius { get; set; }

    /// <summary>
    /// Gets or sets the extent of the rectangle in the direction of x-axis
    /// Default value is 2.0
    /// </summary>
    public double XDim { get; set; }

    /// <summary>
    /// Gets or sets the extent of the rectangle in the direction of y-axis
    /// Default value is 2.0
    /// </summary>
    public double YDim { get; set; }

    /// <summary>
    /// Gets the extent in x and y dimension.
    /// </summary>
    /// <returns></returns>
    public Vector2 GetExtent()
    {
        return new Vector2();
    }
}
