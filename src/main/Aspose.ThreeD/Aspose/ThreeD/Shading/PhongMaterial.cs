using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Shading
{
    public class PhongMaterial : LambertMaterial
    {
        private Vector4 _specular = new Vector4(0.2f, 0.2f, 0.2f, 1.0f);
        private float _shininess = 20.0f;
        private float _specularPower = 20.0f;

        public PhongMaterial() : base()
        {
        }

        public PhongMaterial(string name) : base(name)
        {
        }

        public Vector4 Specular
        {
            get => _specular;
            set => _specular = value;
        }

        public float Shininess
        {
            get => _shininess;
            set => _shininess = value;
        }

        public float SpecularPower
        {
            get => _specularPower;
            set => _specularPower = value;
        }
    }
}
