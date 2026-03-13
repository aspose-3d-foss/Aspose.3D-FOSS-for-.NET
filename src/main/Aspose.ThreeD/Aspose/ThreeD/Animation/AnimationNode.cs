using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Animation
{
    public class AnimationNode
    {
        private List<AnimationNode> _children;
        private List<AnimationChannel> _channels;
        private string _name;
        private Matrix4 _localMatrix;
        private Matrix4 _worldMatrix;

        public AnimationNode()
        {
            _children = new List<AnimationNode>();
            _channels = new List<AnimationChannel>();
            _name = string.Empty;
            _localMatrix = Matrix4.Identity;
            _worldMatrix = Matrix4.Identity;
        }

        public AnimationNode(string name)
        {
            _children = new List<AnimationNode>();
            _channels = new List<AnimationChannel>();
            _name = name;
            _localMatrix = Matrix4.Identity;
            _worldMatrix = Matrix4.Identity;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public List<AnimationNode> Children => _children;

        public List<AnimationChannel> Channels => _channels;

        public void AddChild(AnimationNode node)
        {
            if (node != null)
            {
                _children.Add(node);
            }
        }

        public void AddChannel(AnimationChannel channel)
        {
            if (channel != null)
            {
                _channels.Add(channel);
            }
        }

        public Matrix4 GetLocalMatrix()
        {
            return _localMatrix;
        }

        public Matrix4 GetWorldMatrix()
        {
            return _worldMatrix;
        }
    }
}
