using System.Collections.Generic;

namespace Aspose.ThreeD.Animation
{
    public class KeyframeSequence : A3DObject
    {
        private readonly List<KeyFrame> _keyFrames;

        public KeyframeSequence()
        {
            _keyFrames = new List<KeyFrame>();
        }

        public KeyframeSequence(string name) : base(name)
        {
            _keyFrames = new List<KeyFrame>();
        }

        public BindPoint BindPoint
        {
            get;
        }

        public IList<KeyFrame> KeyFrames => _keyFrames;

        public Extrapolation PostBehavior
        {
            get;
        }

        public Extrapolation PreBehavior
        {
            get;
        }

        public void Add(double time, float value)
        {
            var frame = new KeyFrame(this, time);
            frame.Value = value;
            _keyFrames.Add(frame);
        }

        public void Add(double time, float value, Interpolation interpolation)
        {
            var frame = new KeyFrame(this, time);
            frame.Value = value;
            frame.Interpolation = interpolation;
            _keyFrames.Add(frame);
        }

        public void Reset()
        {
            _keyFrames.Clear();
        }

        public IEnumerator<KeyFrame> GetEnumerator()
        {
            return _keyFrames.GetEnumerator();
        }
    }
}
