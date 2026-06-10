using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Animation
{
    /// <summary>
    /// Aspose.3D's supports animation hierarchy, each animation can be composed by several animations and animation's key-frame definition.
    /// </summary>
    public class AnimationNode : A3DObject
    {
        private List<BindPoint> _bindPoints;
        private List<AnimationNode> _subAnimations;

        /// <summary>
        /// Initializes a new instance of the AnimationNode class.
        /// </summary>
        public AnimationNode()
        {
            _bindPoints = new List<BindPoint>();
            _subAnimations = new List<AnimationNode>();
        }

        /// <summary>
        /// Initializes a new instance of the AnimationNode class.
        /// </summary>
        /// <param name="name">The name of the animation node.</param>
        public AnimationNode(string name) : base(name)
        {
            _bindPoints = new List<BindPoint>();
            _subAnimations = new List<AnimationNode>();
        }

        /// <summary>
        /// Gets the current property bind points.
        /// </summary>
        public IList<BindPoint> BindPoints => _bindPoints;

        /// <summary>
        /// Gets the sub-animation nodes under current animations.
        /// </summary>
        public IList<AnimationNode> SubAnimations => _subAnimations;

        /// <summary>
        /// Finds the bind point by target and name.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="name">The name of the bind point.</param>
        /// <returns>The found bind point, or null if not found.</returns>
        public BindPoint FindBindPoint(A3DObject target, string name)
        {
            return null!;
        }

        /// <summary>
        /// Gets the animation bind point on given property.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="propName">The property name.</param>
        /// <param name="create">Whether to create the bind point if not exists.</param>
        /// <returns>The bind point.</returns>
        public BindPoint GetBindPoint(A3DObject target, string propName, bool create)
        {
            return null!;
        }

        /// <summary>
        /// Gets the keyframe sequence on given property and channel.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="propName">The property name.</param>
        /// <param name="channelName">The channel name.</param>
        /// <param name="create">Whether to create the sequence if not exists.</param>
        /// <returns>The keyframe sequence.</returns>
        public KeyframeSequence GetKeyframeSequence(A3DObject target, string propName, string channelName, bool create)
        {
            return null!;
        }

        /// <summary>
        /// Gets the keyframe sequence on given property.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="propName">The property name.</param>
        /// <param name="create">Whether to create the sequence if not exists.</param>
        /// <returns>The keyframe sequence.</returns>
        public KeyframeSequence GetKeyframeSequence(A3DObject target, string propName, bool create)
        {
            return null!;
        }

        /// <summary>
        /// Creates a BindPoint based on the property data type.
        /// </summary>
        /// <param name="obj">The target object.</param>
        /// <param name="propName">The property name.</param>
        /// <returns>The created bind point.</returns>
        public BindPoint CreateBindPoint(A3DObject obj, string propName)
        {
            return null!;
        }
    }
}
