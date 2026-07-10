// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Subclass this to implement rendering for different kind of entities.
/// </summary>
public abstract class EntityRenderer
{
    /// <summary>
    /// Constructor of
    /// </summary>
    public EntityRenderer(string key, EntityRendererFeatures features)
    {
    }

    /// <summary>
    /// Constructor of
    /// </summary>
    public EntityRenderer(string key)
    {
    }

    /// <summary>
    /// Initialize the entity renderer
    /// </summary>
    public void Initialize(Renderer renderer)
    {
    }

    /// <summary>
    /// The scene has changed or removed, need to dispose scene-level render resources in this
    /// </summary>
    public void ResetSceneCache()
    {
    }

    /// <summary>
    /// Begin rendering a frame
    /// </summary>
    public void FrameBegin(Renderer renderer, IRenderQueue renderQueue)
    {
    }

    /// <summary>
    /// Ends rendering a frame
    /// </summary>
    public void FrameEnd(Renderer renderer, IRenderQueue renderQueue)
    {
    }

    /// <summary>
    /// Prepare rendering commands for specified node/entity pair.
    /// </summary>
    public void PrepareRenderQueue(Renderer renderer, IRenderQueue queue, Node node, Entity entity)
    {
    }

    /// <summary>
    /// Each render task pushed to the  will have a corresponding RenderEntity call
    /// to perform the concrete rendering job.
    /// </summary>
    public void RenderEntity(Renderer renderer, ICommandList commandList, Node node, object renderableResource, int subEntity)
    {
    }

    /// <summary>
    /// The entity renderer is being disposed, release shared resources.
    /// </summary>
    public void Dispose()
    {
    }
}
