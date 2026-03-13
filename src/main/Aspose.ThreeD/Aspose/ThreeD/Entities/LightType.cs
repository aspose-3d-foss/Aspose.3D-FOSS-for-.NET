namespace Aspose.ThreeD.Entities
{
    public class LightType
    {
        public static readonly LightType POINT = new LightType("Point");
        public static readonly LightType SPOT = new LightType("Spot");
        public static readonly LightType DIRECTIONAL = new LightType("Directional");
        public static readonly LightType AMBIENT = new LightType("Ambient");

        private readonly string _name;

        private LightType(string name)
        {
            _name = name;
        }

        public string Name => _name;

        public override string ToString()
        {
            return _name;
        }
    }
}
