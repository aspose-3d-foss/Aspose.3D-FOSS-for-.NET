// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Shading;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Render;

/// <summary>
/// The context about renderer.
/// </summary>
public abstract class Renderer : IDisposable
{
    private bool _disposed;

    /// <summary>
    /// Prevents a default instance of the Renderer class from being created.
    /// </summary>
    protected Renderer()
    {
    }

    /// <summary>
    /// Gets or sets the shader set that used to render the scene
    /// </summary>
    public virtual ShaderSet ShaderSet { get; set; }

    /// <summary>
    /// Access to the internal variables used for rendering
    /// </summary>
    public virtual RendererVariableManager Variables { get; } = null;

    /// <summary>
    /// Gets or sets the preset shader set
    /// </summary>
    public virtual PresetShaders PresetShaders { get; set; }

    /// <summary>
    /// Gets the factory to build render-related objects.
    /// </summary>
    public virtual RenderFactory RenderFactory { get; } = null;

    /// <summary>
    /// Directories that stored external assets
    /// </summary>
    public virtual List<string> AssetDirectories { get; } = null;

    /// <summary>
    /// Active post-processing chain
    /// </summary>
    public virtual IList<PostProcessing> PostProcessings { get; } = null;

    /// <summary>
    /// Gets or sets whether to enable shadows.
    /// </summary>
    public virtual bool EnableShadows { get; set; }

    /// <summary>
    /// Specify the render target that the following render operations will be performed on.
    /// </summary>
    public virtual IRenderTarget RenderTarget { get; } = null;

    /// <summary>
    /// Gets or sets the  instance used to provide world transform matrix.
    /// </summary>
    public virtual Node Node { get; set; }

    /// <summary>
    /// Gets or sets the frustum that used to provide view matrix.
    /// </summary>
    public virtual Frustum Frustum { get; set; }

    /// <summary>
    /// Gets the current render stage.
    /// </summary>
    public virtual RenderStage RenderStage { get; } = RenderStage.Idle;

    /// <summary>
    /// Gets or sets the material that used to provide material information used by shaders.
    /// </summary>
    public virtual Material Material { get; set; }

    /// <summary>
    /// Gets or sets the shader instance used for rendering the geometry.
    /// </summary>
    public virtual ShaderProgram Shader { get; set; }

    /// <summary>
    /// Gets or sets the fallback entity renderer when the entity has no special renderer defined.
    /// </summary>
    public virtual EntityRenderer FallbackEntityRenderer { get; set; }

    /// <summary>
    /// Manually clear the cache.
    /// Aspose.3D will cache some objects like materials/geometries into internal types that compatible with the render pipeline.
    /// This should be manually called when scene has major changes.
    /// </summary>
    public virtual void ClearCache()
    {
    }

    /// <summary>
    /// Gets a built-in post-processor that supported by the renderer.
    /// </summary>
    public virtual PostProcessing GetPostProcessing(string name)
    {
        return null;
    }

    /// <summary>
    /// Execute an post processing on specified render target
    /// </summary>
    public virtual void Execute(PostProcessing postProcessing, IRenderTarget result)
    {
    }

    /// <summary>
    /// Creates a new <see cref="Renderer"/> with default profile.
    /// </summary>
    public static Renderer CreateRenderer()
    {
        return null;
    }

    /// <summary>
    /// Dispose the <see cref="Renderer"/> and all related resources
    /// </summary>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Dispose the <see cref="Renderer"/> and all related resources
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Dispose managed resources
            }
            _disposed = true;
        }
    }

    /// <summary>
    /// Register the entity renderer for specified entity
    /// </summary>
    public virtual void RegisterEntityRenderer(EntityRenderer renderer)
    {
    }

    /// <summary>
    /// Render the specified target
    /// </summary>
    public virtual void Render(IRenderTarget renderTarget)
    {
    }
}
