// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// The descriptor sets describes different resources that can be used to bind to the render pipeline like buffers, textures
/// </summary>
public interface IDescriptorSet : IDisposable
{
    /// <summary>
    /// Begin to update the descriptor set
    /// </summary>
    public DescriptorSetUpdater BeginUpdate();
}
