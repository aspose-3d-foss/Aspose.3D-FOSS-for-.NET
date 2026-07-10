// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// Encodes a sequence of commands which will be sent to GPU to render.
/// </summary>
public interface ICommandList : IDisposable
{
    /// <summary>
    /// Bind the pipeline instance for rendering
    /// </summary>
    void BindPipeline(IPipeline pipeline);

    /// <summary>
    /// Bind the vertex buffer for rendering
    /// </summary>
    void BindVertexBuffer(IVertexBuffer vertexBuffer);

    /// <summary>
    /// Bind the index buffer for rendering
    /// </summary>
    void BindIndexBuffer(IIndexBuffer indexBuffer);

    /// <summary>
    /// Bind the descriptor set to current pipeline
    /// </summary>
    void BindDescriptorSet(IDescriptorSet descriptorSet);

    /// <summary>
    /// Draw without index buffer
    /// </summary>
    void Draw(int start, int count);

    /// <summary>
    /// Draw without index buffer
    /// </summary>
    void Draw();

    /// <summary>
    /// Issue an indexed draw into a command list
    /// </summary>
    void DrawIndex();

    /// <summary>
    /// Issue an indexed draw into a command list
    /// </summary>
    void DrawIndex(int start, int count);

    void PushConstants(ShaderStage stage, byte[] data);

    void PushConstants(ShaderStage stage, byte[] data, int size);
}
