// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// IFC compatible mirror profile.
/// This profile defines a new profile by mirroring the base profile about the y axis.
/// </summary>
public class MirroredProfile : Profile, INamedObject
{
    /// <summary>
    /// Construct a new  from an existing profile.
    /// </summary>
    /// <param name="baseProfile"></param>
    public MirroredProfile(Profile baseProfile) : base(null)
    {
    }

    /// <summary>
    /// The base profile to be mirrored.
    /// </summary>
    public Profile BaseProfile { get; } = null!;
}
