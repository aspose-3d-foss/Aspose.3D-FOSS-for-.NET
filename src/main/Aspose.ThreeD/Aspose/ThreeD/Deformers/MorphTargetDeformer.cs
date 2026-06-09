using System.Collections.Generic;

namespace Aspose.ThreeD.Deformers;

/// <summary>
/// MorphTargetDeformer provides per-vertex animation.
/// MorphTargetDeformer organize all targets via , each channel can organize multiple targets.
/// A common use of morph target deformer is to apply facial expression to a character.
/// More details can be found at https://en.wikipedia.org/wiki/Morph_target_animation
/// </summary>
public class MorphTargetDeformer : Deformer, INamedObject
{
    private readonly IList<MorphTargetChannel> channels;

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public MorphTargetDeformer(string name) : base(name)
    {
        channels = new List<MorphTargetChannel>();
    }

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public MorphTargetDeformer() : base("MorphTargetDeformer")
    {
        channels = new List<MorphTargetChannel>();
    }

    /// <summary>
    /// Gets or sets the weight at the specified index
    /// </summary>
    public double this[int index]
    {
        get => channels.Count > index ? channels[index].ChannelWeight : 0.0;
        set
        {
            while (channels.Count <= index)
            {
                channels.Add(new MorphTargetChannel());
            }
            channels[index].ChannelWeight = value;
        }
    }

    /// <summary>
    /// Gets all channels contained in this deformer
    /// </summary>
    public IList<MorphTargetChannel> Channels => channels;
}
