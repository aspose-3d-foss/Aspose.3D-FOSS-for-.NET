namespace Aspose.ThreeD.Animation
{
    public class Extrapolation
    {
        private ExtrapolationType _type;
        private int _repeatCount;

        public Extrapolation()
        {
            _type = ExtrapolationType.Constant;
            _repeatCount = 0;
        }

        public ExtrapolationType Type
        {
            get => _type;
            set => _type = value;
        }

        public int RepeatCount
        {
            get => _repeatCount;
            set => _repeatCount = value;
        }
    }
}