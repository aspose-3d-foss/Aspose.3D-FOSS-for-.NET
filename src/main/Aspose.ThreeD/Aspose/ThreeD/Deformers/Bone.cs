using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Deformers;

/// <summary>
/// A bone defines the subset of the geometry's control point, and defined blend weight for each control point.
/// The  object cannot be used directly, a  instance is used to deform the geometry, and  comes with a set of bones, each bone linked to a node.
/// NOTE: A control point of a geometry can be bounded to more than one Bones.
/// </summary>
public class Bone : A3DObject, INamedObject
{
    private BoneLinkMode linkMode;
    private readonly IList<double> weights;
    private Matrix4 transform = Matrix4.Identity;
    private Matrix4 boneTransform = Matrix4.Identity;
    private Node? node;

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public Bone(string name) : base(name)
    {
        weights = new List<double>();
    }

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public Bone() : base()
    {
        weights = new List<double>();
    }

    /// <summary>
    /// A bone's link mode refers to the way in which a bone is connected or linked to its parent bone within a hierarchical structure.
    /// </summary>
    public BoneLinkMode LinkMode
    {
        get => linkMode;
        set => linkMode = value;
    }

    /// <summary>
    /// Gets or sets the weight at the specified index
    /// </summary>
    public double this[int index]
    {
        get => GetWeight(index);
        set => SetWeight(index, value);
    }

    /// <summary>
    /// Gets the count of weight, this is automatically extended by
    /// </summary>
    public int WeightCount => weights.Count;

    /// <summary>
    /// Gets or sets the transform matrix of the node containing the bone.
    /// </summary>
    public Matrix4 Transform
    {
        get => transform;
        set => transform = value;
    }

    /// <summary>
    /// Gets or sets the transform matrix of the bone.
    /// </summary>
    public Matrix4 BoneTransform
    {
        get => boneTransform;
        set => boneTransform = value;
    }

    /// <summary>
    /// Gets or sets the node. The bone node is the bone which skin attached to, the  will use bone node to influence the displacement of the control points.
    /// Bone node usually has a  attached, but it's not required.
    /// Attached  is usually used by DCC software to show skeleton to user.
    /// </summary>
    public Node Node
    {
        get => node ?? throw new InvalidOperationException("Node is not set");
        set => node = value;
    }

    /// <summary>
    /// Gets the weight for control point specified by index
    /// </summary>
    public double GetWeight(int index)
    {
        if (index < 0 || index >= weights.Count)
            return 0.0;
        return weights[index];
    }

    /// <summary>
    /// Sets the weight for control point specified by index
    /// </summary>
    public void SetWeight(int index, double weight)
    {
        while (weights.Count <= index)
        {
            weights.Add(0.0);
        }
        weights[index] = weight;
    }
}
