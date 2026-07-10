// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// Font file contains definitions for glyphs, this is used to create text profile.
/// </summary>
public abstract class FontFile : A3DObject, INamedObject
{
    /// <summary>
    /// Load FontFile from file name
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static FontFile FromFile(string fileName)
    {
        throw new System.NotImplementedException();
    }

    public static FontFile Parse(byte[] bytes)
    {
        throw new System.NotImplementedException();
    }
}
