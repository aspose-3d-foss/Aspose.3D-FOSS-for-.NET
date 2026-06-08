using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Animation
{
    public class KeyframeSequence
    {
        private List<KeyFrame> _keyFrames;
        private string _propertyName;
        private Extrapolation _preExtrapolation;
        private Extrapolation _postExtrapolation;

        public KeyframeSequence()
        {
            _keyFrames = new List<KeyFrame>();
            _propertyName = string.Empty;
            _preExtrapolation = new Extrapolation();
            _postExtrapolation = new Extrapolation();
        }

        public KeyframeSequence(string propertyName)
        {
            _keyFrames = new List<KeyFrame>();
            _propertyName = propertyName;
            _preExtrapolation = new Extrapolation();
            _postExtrapolation = new Extrapolation();
        }

        public string PropertyName
        {
            get => _propertyName;
            set => _propertyName = value;
        }

        public List<KeyFrame> KeyFrames => _keyFrames;

        public Extrapolation PreExtrapolation
        {
            get => _preExtrapolation;
            set => _preExtrapolation = value;
        }

        public Extrapolation PostExtrapolation
        {
            get => _postExtrapolation;
            set => _postExtrapolation = value;
        }

        public KeyFrame GetKeyFrameAtTime(float time)
        {
            foreach (var frame in _keyFrames)
            {
                if (frame.Time == time)
                {
                    return frame;
                }
            }
            return null!;
        }

        public void AddKeyFrame(KeyFrame keyFrame)
        {
            _keyFrames.Add(keyFrame);
            _keyFrames.Sort((a, b) => a.Time.CompareTo(b.Time));
        }

        public void RemoveKeyFrame(KeyFrame keyFrame)
        {
            _keyFrames.Remove(keyFrame);
        }

        public Aspose.ThreeD.Utilities.Vector4 Interpolate(float time)
        {
            if (_keyFrames.Count == 0)
            {
                return new Aspose.ThreeD.Utilities.Vector4(0, 0, 0, 0);
            }

            if (_keyFrames.Count == 1)
            {
                return _keyFrames[0].Value;
            }

            var prevFrame = _keyFrames[0];
            var nextFrame = _keyFrames[_keyFrames.Count - 1];

            foreach (var frame in _keyFrames)
            {
                if (frame.Time <= time && frame.Time >= prevFrame.Time)
                {
                    prevFrame = frame;
                }
                if (frame.Time > time)
                {
                    nextFrame = frame;
                    break;
                }
            }

            if (prevFrame.Time >= time)
            {
                return prevFrame.Value;
            }

            if (nextFrame.Time <= time)
            {
                return nextFrame.Value;
            }

            float t = (time - prevFrame.Time) / (nextFrame.Time - prevFrame.Time);

            switch (prevFrame.Interpolation)
            {
                case Interpolation.CONSTANT:
                    return prevFrame.Value;

                case Interpolation.LINEAR:
                    var v0 = prevFrame.Value;
                    var v1 = nextFrame.Value;
                    var diffX = v1.X - v0.X;
                    var diffY = v1.Y - v0.Y;
                    var diffZ = v1.Z - v0.Z;
                    var diffW = v1.W - v0.W;
                    var result = new Aspose.ThreeD.Utilities.Vector4(
                        v0.X + diffX * t,
                        v0.Y + diffY * t,
                        v0.Z + diffZ * t,
                        v0.W + diffW * t
                    );
                    return result;

                case Interpolation.BEZIER:
                    return InterpolateBezier(prevFrame, nextFrame, t);

                default:
                    return prevFrame.Value;
            }
        }

        private Aspose.ThreeD.Utilities.Vector4 InterpolateBezier(KeyFrame prevFrame, KeyFrame nextFrame, float t)
        {
            float t2 = t * t;
            float t3 = t2 * t;

            float h1 = 2 * t3 - 3 * t2 + 1;
            float h2 = -2 * t3 + 3 * t2;
            float h3 = t3 - 2 * t2 + t;
            float h4 = t3 - t2;

            Aspose.ThreeD.Utilities.Vector4 p0 = prevFrame.Value;
            Aspose.ThreeD.Utilities.Vector4 p3 = nextFrame.Value;

            float duration = nextFrame.Time - prevFrame.Time;
            Aspose.ThreeD.Utilities.Vector4 m0 = new Aspose.ThreeD.Utilities.Vector4(
                prevFrame.TangentOut.X * duration,
                prevFrame.TangentOut.Y * duration,
                prevFrame.TangentOut.Z * duration,
                0
            );
            Aspose.ThreeD.Utilities.Vector4 m1 = new Aspose.ThreeD.Utilities.Vector4(
                nextFrame.TangentIn.X * duration,
                nextFrame.TangentIn.Y * duration,
                nextFrame.TangentIn.Z * duration,
                0
            );

            Aspose.ThreeD.Utilities.Vector4 result = p0 * h1 + m0 * h3 + p3 * h2 + m1 * h4;
            return result;
        }
    }
}
