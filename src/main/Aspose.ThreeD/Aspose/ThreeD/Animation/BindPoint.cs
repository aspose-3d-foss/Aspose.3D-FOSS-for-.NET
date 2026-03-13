using System;

namespace Aspose.ThreeD.Animation
{
    public class BindPoint
    {
        private string _target;
        private string _propertyName;
        private AnimationChannel[] _channels;

        public BindPoint(string target, string propertyName)
        {
            _target = target;
            _propertyName = propertyName;
            _channels = new AnimationChannel[0];
        }

        public string Target
        {
            get => _target;
            set => _target = value;
        }

        public string PropertyName
        {
            get => _propertyName;
            set => _propertyName = value;
        }

        public AnimationChannel[] Channels
        {
            get => _channels;
            set => _channels = value;
        }

        public object GetProperty()
        {
            return null;
        }
    }
}
