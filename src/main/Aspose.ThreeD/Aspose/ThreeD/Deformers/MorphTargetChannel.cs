using System.Collections.Generic;
using Aspose.ThreeD.Entities;

namespace Aspose.ThreeD.Deformers;

/// <summary>
/// A MorphTargetChannel is used by  to organize the target geometries.
/// Some file formats like FBX support multiple channels in parallel.
/// </summary>
public class MorphTargetChannel : A3DObject, INamedObject
{
    private readonly IList<double> weights;
    private double channelWeight;
    private readonly IList<Shape> targets;

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public MorphTargetChannel(string name) : base(name)
    {
        weights = new List<double>();
        targets = new List<Shape>();
    }

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public MorphTargetChannel() : base()
    {
        weights = new List<double>();
        targets = new List<Shape>();
    }

    /// <summary>
    /// Gets the full weight values of target geometries.
    /// </summary>
    public IList<double> Weights => weights;

    /// <summary>
    /// Gets or sets the deformer weight of this channel. 
    /// The weight is between 0.0 and 1.0
    /// </summary>
    public double ChannelWeight
    {
        get => channelWeight;
        set => channelWeight = value;
    }

    /// <summary>
    /// Gets all targets associated with the channel.
    /// </summary>
    public IList<Shape> Targets => targets;

    /// <summary>
    /// Gets or sets the weight at the specified index
    /// </summary>
    public double this[int index]
    {
        get => GetWeight(index);
        set => SetWeight(index, value);
    }

    /// <summary>
    /// Default weight for morph target.
    /// </summary>
    public const double DefaultWeight = 1.0;

    /// <summary>
    /// Gets the weight for the specified target, if the target is not belongs to this channel, default value 0 is returned.
    /// </summary>
    public double GetWeight(Shape target)
    {
        int index = targets.IndexOf(target);
        if (index < 0 || index >= weights.Count)
            return 0.0;
        return weights[index];
    }

    /// <summary>
    /// Sets the weight for the specified target, default value is 1, range should between 0~1
    /// </summary>
    public void SetWeight(Shape target, double weight)
    {
        int index = targets.IndexOf(target);
        if (index < 0)
        {
            targets.Add(target);
            weights.Add(weight);
        }
        else
        {
            weights[index] = weight;
        }
    }

    private double GetWeight(int index)
    {
        if (index < 0 || index >= weights.Count)
            return 0.0;
        return weights[index];
    }

    private void SetWeight(int index, double weight)
    {
        while (weights.Count <= index)
        {
            weights.Add(0.0);
        }
        weights[index] = weight;
    }
}
