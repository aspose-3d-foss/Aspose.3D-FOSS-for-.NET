using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Animation
{
    public class KeyFrame
    {
        public KeyFrame(KeyframeSequence curve, double time)
        {
        }

        public double Time { get; set; }

        public float Value { get; set; }

        public Interpolation Interpolation { get; set; }

        public WeightedMode TangentWeightMode { get; set; }

        public StepMode StepMode { get; set; }

        public Vector2 NextInTangent { get; set; }

        public Vector2 OutTangent { get; set; }

        public float OutWeight { get; set; }

        public float NextInWeight { get; set; }

        public float Tension { get; set; }

        public float Continuity { get; set; }

        public float Bias { get; set; }

        public bool IndependentTangent { get; set; }

        public bool Flat { get; set; }

        public bool TimeIndependentTangent { get; set; }

        public string ToString()
        {
            return $"KeyFrame: Time={Time}, Value={Value}";
        }
    }
}
