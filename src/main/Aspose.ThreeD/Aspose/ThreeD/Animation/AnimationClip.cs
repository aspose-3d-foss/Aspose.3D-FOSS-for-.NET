using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Animation
{
    /// <summary>
    /// The Animation clip is a collection of animations.
    /// The scene can have one or more animation clips.
    /// </summary>
    public class AnimationClip : SceneObject, INamedObject
    {
        private readonly List<AnimationNode> _animations;
        private string? _description;
        private double _start;
        private double _stop;

        /// <summary>
        /// Initializes a new instance of the AnimationClip class.
        /// </summary>
        public AnimationClip()
        {
            _animations = new List<AnimationNode>();
            _description = null;
            _start = 0.0;
            _stop = 0.0;
        }

        /// <summary>
        /// Initializes a new instance of the AnimationClip class.
        /// </summary>
        public AnimationClip(string name) : base(name)
        {
            _animations = new List<AnimationNode>();
            _description = null;
            _start = 0.0;
            _stop = 0.0;
        }

        /// <summary>
        /// Gets the animations contained inside the clip.
        /// </summary>
        public IList<AnimationNode> Animations => _animations;

        /// <summary>
        /// Gets or sets the description of this animation clip.
        /// </summary>
        public string Description
        {
            get => _description ?? string.Empty;
            set => _description = value;
        }

        /// <summary>
        /// Gets or sets the time in seconds of the beginning of the clip.
        /// </summary>
        public double Start
        {
            get => _start;
            set => _start = value;
        }

        /// <summary>
        /// Gets or sets the time in seconds of the end of the clip.
        /// </summary>
        public double Stop
        {
            get => _stop;
            set => _stop = value;
        }

        /// <summary>
        /// A shorthand function to create and register the animation node on current clip.
        /// </summary>
        public AnimationNode CreateAnimationNode(string nodeName)
        {
            var node = new AnimationNode(nodeName);
            _animations.Add(node);
            return node;
        }
    }
}
