using System;

namespace Aspose.ThreeD.Animation
{
    public class AnimationChannel : KeyframeSequence
    {
        private object? _defaultValue;

        public object? DefaultValue
        {
            get;
            set;
        }

        public KeyframeSequence KeyframeSequence
        {
            get;
            set;
        }

        public Type ComponentType
        {
            get;
        }
    }
}
