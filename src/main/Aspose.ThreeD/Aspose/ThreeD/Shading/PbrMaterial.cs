using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Shading
{
    public class PbrMaterial : Material
    {
        private Vector4 _baseColor = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        private float _metallic = 0.0f;
        private float _roughness = 0.5f;
        private float _occlusion = 1.0f;
        private string _emissiveTexture = string.Empty;
        private string _metallicRoughnessTexture = string.Empty;
        private string _occlusionTexture = string.Empty;
        private string _normalTexture = string.Empty;
        private string _baseColorTexture = string.Empty;

        public PbrMaterial() : base()
        {
        }

        public PbrMaterial(string name) : base(name)
        {
        }

        public Vector4 BaseColor
        {
            get => _baseColor;
            set => _baseColor = value;
        }

        public float Metallic
        {
            get => _metallic;
            set => _metallic = value;
        }

        public float Roughness
        {
            get => _roughness;
            set => _roughness = value;
        }

        public float Occlusion
        {
            get => _occlusion;
            set => _occlusion = value;
        }

        public string EmissiveTexture
        {
            get => _emissiveTexture;
            set => _emissiveTexture = value;
        }

        public string MetallicRoughnessTexture
        {
            get => _metallicRoughnessTexture;
            set => _metallicRoughnessTexture = value;
        }

        public string OcclusionTexture
        {
            get => _occlusionTexture;
            set => _occlusionTexture = value;
        }

        public string NormalTexture
        {
            get => _normalTexture;
            set => _normalTexture = value;
        }

        public string BaseColorTexture
        {
            get => _baseColorTexture;
            set => _baseColorTexture = value;
        }
    }
}
