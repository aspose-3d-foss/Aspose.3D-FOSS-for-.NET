// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD;

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// The base class of all parameterized profiles.
/// </summary>
public abstract class ParameterizedProfile : Profile, INamedObject
{
    /// <summary>
    /// Protected constructor with no name (defaults to empty string)
    /// </summary>
    protected ParameterizedProfile() : base(null)
    {
    }

    /// <summary>
    /// Protected constructor to allow derived classes to set name
    /// </summary>
    /// <param name="name">The name of the profile</param>
    protected ParameterizedProfile(string name) : base(name)
    {
    }

    /// <summary>
    /// Gets the extent in x and y dimension.
    /// </summary>
    /// <returns></returns>
    public Vector2 GetExtent()
    {
        return new Vector2();
    }
}
