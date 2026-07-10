// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible Trapezium shape defined by parameters.
/// </summary>
public class TrapeziumShape : ParameterizedProfile, INamedObject
{
    /// <summary>
    /// Constructor of
    /// </summary>
    public TrapeziumShape()
    {
    }

    /// <summary>
    /// Gets or sets the extent of the bottom line measured along the x-axis.
    /// </summary>
    public double BottomXDim { get; set; }

    /// <summary>
    /// Gets or sets the extent of the top line measured along the x-axis.
    /// </summary>
    public double TopXDim { get; set; }

    /// <summary>
    /// Gets or sets the distance between the top and bottom lines measured along the y-axis.
    /// </summary>
    public double YDim { get; set; }

    /// <summary>
    /// Gets or sets the offset from the beginning of the top line to the bottom line.
    /// </summary>
    public double TopXOffset { get; set; }

    /// <summary>
    /// Gets the extent in x and y dimension.
    /// </summary>
    /// <returns></returns>
    public Vector2 GetExtent()
    {
        return new Vector2();
    }
}
