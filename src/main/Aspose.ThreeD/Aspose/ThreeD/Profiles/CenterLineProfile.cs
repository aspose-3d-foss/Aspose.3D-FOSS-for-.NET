// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible center line profile
/// </summary>
public class CenterLineProfile : Profile, INamedObject
{
    /// <summary>
    /// Constructs a new  with specified curve as center line.
    /// </summary>
    /// <param name="curve"></param>
    /// <param name="thickness"></param>
    public CenterLineProfile(Curve curve, double thickness) : base(null)
    {
    }

    /// <summary>
    /// Thickness applied along the center line
    /// </summary>
    public double Thickness { get; set; }

    /// <summary>
    /// The center line curve of the profile
    /// </summary>
    public Curve Curve { get; set; }
}
