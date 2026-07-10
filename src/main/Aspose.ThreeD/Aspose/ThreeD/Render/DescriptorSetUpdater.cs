using System;

namespace Aspose.ThreeD.Render;

/// <summary>
/// This class allows to update the  in a chain operation.
/// </summary>
public sealed class DescriptorSetUpdater : IDisposable
{
    internal DescriptorSetUpdater()
    {
    }

    /// <summary>
    /// Dispose the updater and commit the changes to hardware device.
    /// </summary>
    public void Dispose()
    {
    }

    /// <summary>
    /// Bind the buffer to current descriptor set
    /// </summary>
    public DescriptorSetUpdater Bind(IBuffer buffer, int offset, int size)
    {
        return this;
    }

    /// <summary>
    /// Bind the entire buffer to current descriptor
    /// </summary>
    public DescriptorSetUpdater Bind(IBuffer buffer)
    {
        return this;
    }

    /// <summary>
    /// Bind the buffer to current descriptor set at specified binding location.
    /// </summary>
    public DescriptorSetUpdater Bind(int binding, IBuffer buffer)
    {
        return this;
    }

    /// <summary>
    /// Bind the buffer to current descriptor set at specified binding location.
    /// </summary>
    public DescriptorSetUpdater Bind(int binding, IBuffer buffer, int offset, int size)
    {
        return this;
    }

    /// <summary>
    /// Bind the texture unit to current descriptor set
    /// </summary>
    public DescriptorSetUpdater Bind(ITextureUnit texture)
    {
        return this;
    }

    /// <summary>
    /// Bind the texture unit to current descriptor set
    /// </summary>
    public DescriptorSetUpdater Bind(int binding, ITextureUnit texture)
    {
        return this;
    }
}
