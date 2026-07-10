// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Render;

/// <summary>
/// RenderFactory creates all resources that represented in rendering pipeline.
/// </summary>
public abstract class RenderFactory
{
    /// <summary>
    /// Prevents a default instance of the RenderFactory class from being created.
    /// </summary>
    protected RenderFactory()
    {
    }

    /// <summary>
    /// Create a render target that renders to the texture
    /// </summary>
    public virtual IRenderTexture CreateRenderTexture(RenderParameters parameters, int targets, int width, int height)
    {
        return null;
    }

    /// <summary>
    /// Create a render target contains 1 targets that renders to the texture
    /// </summary>
    public virtual IRenderTexture CreateRenderTexture(RenderParameters parameters, int width, int height)
    {
        return null;
    }

    /// <summary>
    /// Create the descriptor set for specified shader program.
    /// </summary>
    public virtual IDescriptorSet CreateDescriptorSet(ShaderProgram shader)
    {
        return null;
    }

    /// <summary>
    /// Create a render target contains 1 cube texture
    /// </summary>
    public virtual IRenderTexture CreateCubeRenderTexture(RenderParameters parameters, int width, int height)
    {
        return null;
    }

    /// <summary>
    /// Create a render target that renders to the native window.
    /// </summary>
    public virtual IRenderWindow CreateRenderWindow(RenderParameters parameters, WindowHandle handle)
    {
        return null;
    }

    /// <summary>
    /// Create an <see cref="IVertexBuffer"/> instance to store polygon's vertex information.
    /// </summary>
    public virtual IVertexBuffer CreateVertexBuffer(VertexDeclaration declaration)
    {
        return null;
    }

    /// <summary>
    /// Create an <see cref="IIndexBuffer"/> instance to store polygon's face information.
    /// </summary>
    public virtual IIndexBuffer CreateIndexBuffer()
    {
        return null;
    }

    /// <summary>
    /// Create a texture unit that can be accessed by shader.
    /// </summary>
    public virtual ITextureUnit CreateTextureUnit(TextureType textureType)
    {
        return null;
    }

    /// <summary>
    /// Create a 2D texture unit that can be accessed by shader.
    /// </summary>
    public virtual ITextureUnit CreateTextureUnit()
    {
        return null;
    }

    /// <summary>
    /// Create a <see cref="ShaderProgram"/> object
    /// </summary>
    public virtual ShaderProgram CreateShaderProgram(ShaderSource shaderSource)
    {
        return null;
    }

    /// <summary>
    /// Create a preconfigured graphics pipeline with preconfigured shader/render state/vertex declaration and draw operations.
    /// </summary>
    public virtual IPipeline CreatePipeline(ShaderProgram shader, RenderState renderState, VertexDeclaration vertexDeclaration, DrawOperation drawOperation)
    {
        return null;
    }

    /// <summary>
    /// Create a new uniform buffer in GPU side with pre-allocated size.
    /// </summary>
    public virtual IBuffer CreateUniformBuffer(int size)
    {
        return null;
    }
}
