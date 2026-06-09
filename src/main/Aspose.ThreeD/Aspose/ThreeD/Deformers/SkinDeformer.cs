using System.Collections.Generic;

namespace Aspose.ThreeD.Deformers;

/// <summary>
/// A skin deformer contains multiple bones to work, each bone blends a part of the geometry by control point's weights.
/// </summary>
public class SkinDeformer : Deformer, INamedObject
{
    private readonly IList<Bone> bones;

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public SkinDeformer(string name) : base(name)
    {
        bones = new List<Bone>();
    }

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public SkinDeformer() : base("SkinDeformer")
    {
        bones = new List<Bone>();
    }

    /// <summary>
    /// Gets all bones that the skin deformer contains
    /// </summary>
    public IList<Bone> Bones => bones;
}
