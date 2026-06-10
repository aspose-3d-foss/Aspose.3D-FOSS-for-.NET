using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Animation
{
    public class KeyFrame
    {
        private float _time;
        private Aspose.ThreeD.Utilities.Vector4 _value;
        private Interpolation _interpolation;
        private Aspose.ThreeD.Utilities.Vector3 _tangentIn;
        private Aspose.ThreeD.Utilities.Vector3 _tangentOut;
        private WeightedMode _tangentWeightMode;
        private StepMode _stepMode;

        public KeyFrame()
        {
            _time = 0.0f;
            _value = new Aspose.ThreeD.Utilities.Vector4(0, 0, 0, 0);
            _interpolation = Interpolation.Linear;
            _tangentIn = new Aspose.ThreeD.Utilities.Vector3(0, 0, 0);
            _tangentOut = new Aspose.ThreeD.Utilities.Vector3(0, 0, 0);
            _tangentWeightMode = WeightedMode.NONE;
            _stepMode = StepMode.PREVIOUS_VALUE;
        }

        public KeyFrame(float time, Aspose.ThreeD.Utilities.Vector4 value)
        {
            _time = time;
            _value = value;
            _interpolation = Interpolation.Linear;
            _tangentIn = new Aspose.ThreeD.Utilities.Vector3(0, 0, 0);
            _tangentOut = new Aspose.ThreeD.Utilities.Vector3(0, 0, 0);
            _tangentWeightMode = WeightedMode.NONE;
            _stepMode = StepMode.PREVIOUS_VALUE;
        }

        public float Time
        {
            get => _time;
            set => _time = value;
        }

        public Aspose.ThreeD.Utilities.Vector4 Value
        {
            get => _value;
            set => _value = value;
        }

        public Interpolation Interpolation
        {
            get => _interpolation;
            set => _interpolation = value;
        }

        public Aspose.ThreeD.Utilities.Vector3 TangentIn
        {
            get => _tangentIn;
            set => _tangentIn = value;
        }

        public Aspose.ThreeD.Utilities.Vector3 TangentOut
        {
            get => _tangentOut;
            set => _tangentOut = value;
        }

        public WeightedMode TangentWeightMode
        {
            get => _tangentWeightMode;
            set => _tangentWeightMode = value;
        }

        public StepMode StepMode
        {
            get => _stepMode;
            set => _stepMode = value;
        }
    }
}