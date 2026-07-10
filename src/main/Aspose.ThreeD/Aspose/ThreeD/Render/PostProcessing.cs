namespace Aspose.ThreeD.Render;

/// <summary>
/// The post-processing effects
/// </summary>
public abstract class PostProcessing : A3DObject, INamedObject
{
    /// <summary>
    /// Input of this post-processing
    /// </summary>
    public ITextureUnit Input { get; set; }
}
