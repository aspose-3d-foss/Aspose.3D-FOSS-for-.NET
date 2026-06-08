using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Render;

namespace Aspose.ThreeD.Entities
{
    public class Light : Entity
    {
        private readonly LightType _type;
        private Vector3 _color;
        private float _intensity;
        private float _range;

        public Light() : this(LightType.POINT)
        {
        }

        public Light(LightType type) : this(type, "Light")
        {
        }

        public Light(LightType type, string name) : base(name)
        {
            _type = type;
            _color = Vector3.One;
            _intensity = 1.0f;
            _range = 1.0f;
        }

        public LightType Type => _type;

        public Vector3 Color
        {
            get => _color;
            set => _color = value;
        }

        public float Intensity
        {
            get => _intensity;
            set => _intensity = value;
        }

        public float Range
        {
            get => _range;
            set => _range = value;
        }

        public override BoundingBox GetBoundingBox()
        {
            return new BoundingBox();
        }

        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("Light");
        }
    }
}
