// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Render;

/// <summary>
/// This class manages variables used in rendering
/// </summary>
public abstract class RendererVariableManager
{
    /// <summary>
    /// Prevents a default instance of the RendererVariableManager class from being created.
    /// </summary>
    protected RendererVariableManager()
    {
    }

    /// <summary>
    /// Time in seconds
    /// </summary>
    public virtual float WorldTime { get; } = 0f;

    /// <summary>
    /// Position of shadow caster in world coordinate system
    /// </summary>
    public virtual FVector3 ShadowCaster { get; set; }

    /// <summary>
    /// The depth texture used for shadow mapping
    /// </summary>
    public virtual ITextureUnit Shadowmap { get; set; }

    /// <summary>
    /// Matrix for light space transformation
    /// </summary>
    public virtual FMatrix4 MatrixLightSpace { get; set; } = FMatrix4.Identity;

    /// <summary>
    /// Matrix for view and projection transformation.
    /// </summary>
    public virtual FMatrix4 MatrixViewProjection { get; } = FMatrix4.Identity;

    /// <summary>
    /// Matrix for world view and projection transformation
    /// </summary>
    public virtual FMatrix4 MatrixWorldViewProjection { get; } = FMatrix4.Identity;

    /// <summary>
    /// Matrix for world transformation
    /// </summary>
    public virtual FMatrix4 MatrixWorld { get; } = FMatrix4.Identity;

    /// <summary>
    /// Matrix for converting normal from object to world space.
    /// </summary>
    public virtual FMatrix4 MatrixWorldNormal { get; } = FMatrix4.Identity;

    /// <summary>
    /// Matrix for projection transformation
    /// </summary>
    public virtual FMatrix4 MatrixProjection { get; set; } = FMatrix4.Identity;

    /// <summary>
    /// Matrix for view transformation
    /// </summary>
    public virtual FMatrix4 MatrixView { get; set; } = FMatrix4.Identity;

    /// <summary>
    /// Camera's position in world coordinate system
    /// </summary>
    public virtual FVector3 CameraPosition { get; set; }

    /// <summary>
    /// Depth bias for shadow mapping, default value is 0.001
    /// </summary>
    public virtual float DepthBias { get; set; } = 0.001f;

    /// <summary>
    /// Size of viewport, measured in pixel
    /// </summary>
    public virtual FVector2 ViewportSize { get; }

    /// <summary>
    /// Ambient color defined in viewport.
    /// </summary>
    public virtual FVector3 WorldAmbient { get; }
}
