namespace Aspose.ThreeD
{
    using System;
    using System.Collections.Generic;
    using Aspose.ThreeD.Utilities;
    using Aspose.ThreeD.Animation;

    /// <summary>
    /// Animation clip
    /// </summary>
    public class AnimationClip : A3DObject
    {
        private List<AnimationNode> _animationNodes;
        private float _duration;

        public AnimationClip() : base()
        {
            _animationNodes = new List<AnimationNode>();
            _duration = 0.0f;
        }

        public AnimationClip(string name) : base(name)
        {
            _animationNodes = new List<AnimationNode>();
            _duration = 0.0f;
        }

        public List<AnimationNode> AnimationNodes => _animationNodes;

        public float Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public void AddNode(AnimationNode node)
        {
            if (node != null)
            {
                _animationNodes.Add(node);
            }
        }

        public AnimationNode GetNode(int index)
        {
            if (index < 0 || index >= _animationNodes.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return _animationNodes[index];
        }

        public AnimationNode? GetNode(string name)
        {
            foreach (var node in _animationNodes)
            {
                if (node.Name == name)
                {
                    return node;
                }
            }
            return null;
        }

        public Vector4 Sample(float time)
        {
            return new Vector4(0, 0, 0, 0);
        }

        public void Apply(Node node)
        {
        }
    }
}
