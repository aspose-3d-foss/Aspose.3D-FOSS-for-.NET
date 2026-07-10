// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Aspose.ThreeD.Profiles;

/// <summary>
/// Text profile, this profile describes contours using font and text.
/// </summary>
public class Text : Profile, INamedObject
{
    public Text() : base(null)
    {
    }

    /// <summary>
    /// Content of the text
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// The font of the text.
    /// </summary>
    public FontFile Font { get; set; }

    /// <summary>
    /// Font size scale.
    /// </summary>
    public float FontSize { get; set; }
}
