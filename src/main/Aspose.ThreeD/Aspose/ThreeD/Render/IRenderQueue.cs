// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Entity renderer uses this queue to manage render tasks.
/// </summary>
public interface IRenderQueue : IDisposable
{
    /// <summary>
    /// Add render task to the render queue.
    /// </summary>
    public void Add(RenderQueueGroupId groupId, IPipeline pipeline, object renderableResource, int subEntity);
}
