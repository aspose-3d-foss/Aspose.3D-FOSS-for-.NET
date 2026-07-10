using System;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Render;

/// <summary>
/// A utility to provide data to shader through push constant.
/// </summary>
public class PushConstant
{
    /// <summary>
    /// Constructor of the
    /// </summary>
    public PushConstant()
    {
    }

    /// <summary>
    /// Write the matrix to the constant
    /// </summary>
    public PushConstant Write(FMatrix4 mat)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Write a int value to the constant
    /// </summary>
    public PushConstant Write(int n)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Write a float value to the constant
    /// </summary>
    public PushConstant Write(float f)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Write a 4-component vector to the constant
    /// </summary>
    public PushConstant Write(FVector4 vec)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Write a 3-component vector to the constant
    /// </summary>
    public PushConstant Write(FVector3 vec)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Write a 4-component vector to the constant
    /// </summary>
    public PushConstant Write(float x, float y, float z, float w)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Commit prepared data to graphics pipeline.
    /// </summary>
    public PushConstant Commit(ShaderStage stage, ICommandList commandList)
    {
        throw new NotImplementedException();
    }
}
