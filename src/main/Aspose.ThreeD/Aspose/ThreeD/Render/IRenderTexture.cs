// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;

namespace Aspose.ThreeD.Render;

/// <summary>
/// The interface of render texture
/// </summary>
public interface IRenderTexture : IRenderTarget, IDisposable
{
    /// <summary>
    /// Color output targets.
    /// </summary>
    public IList<ITextureUnit> Targets { get; }

    /// <summary>
    /// Depth buffer texture
    /// </summary>
    public ITextureUnit DepthTexture { get; }
}
