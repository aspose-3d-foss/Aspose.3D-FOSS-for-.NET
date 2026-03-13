using System;

namespace Aspose.ThreeD.Animation
{
    public class AnimationChannel : KeyframeSequence
    {
        private string _target;
        private object _defaultValue;

        public AnimationChannel() : base()
        {
            _target = string.Empty;
        }

        public AnimationChannel(string target) : base()
        {
            _target = target;
        }

        public string Target
        {
            get => _target;
            set => _target = value;
        }

        public object DefaultValue
        {
            get => _defaultValue;
            set => _defaultValue = value;
        }

        public void Apply(float time)
        {
            var value = Interpolate(time);
        }
    }
}
