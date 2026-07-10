// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// This class allows you to construct a 2D profile directly from arbitrary curve.
/// </summary>
public class ArbitraryProfile : Profile, INamedObject
{
    /// <summary>
    /// Constructor of
    /// </summary>
    public ArbitraryProfile() : base(null)
    {
    }

    /// <summary>
    /// Constructor of  with an initial curve.
    /// </summary>
    /// <param name="curve"></param>
    public ArbitraryProfile(Curve curve) : base(null)
    {
    }

    /// <summary>
    /// The Curve used to construct the profile
    /// </summary>
    public Curve Curve { get; set; }

    /// <summary>
    /// Holes of the profile, also represented as curve
    /// </summary>
    public List<Curve> Holes { get; } = new List<Curve>();
}
