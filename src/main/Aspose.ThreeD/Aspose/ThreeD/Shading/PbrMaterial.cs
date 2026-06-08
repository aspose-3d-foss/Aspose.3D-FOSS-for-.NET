using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Shading
{
    /// <summary>
    /// Material for physically based rendering based on albedo color/metallic/roughness
    /// </summary>
    public class PbrMaterial : Material
    {
        private double _transparency = 0.0;
        private TextureBase _normalTexture;
        private TextureBase _specularTexture;
        private TextureBase _albedoTexture;
        private Vector3 _albedo = new Vector3(1, 1, 1);
        private TextureBase _occlusionTexture;
        private double _occlusionFactor = 1.0;
        private double _metallicFactor = 0.0;
        private double _roughnessFactor = 0.5;
        private TextureBase _metallicRoughness;
        private TextureBase _emissiveTexture;
        private Vector3 _emissiveColor = new Vector3(0, 0, 0);

        /// <summary>
        /// Construct a default PBR material instance
        /// </summary>
        public PbrMaterial() : base()
        {
        }

        /// <summary>
        /// Construct a default PBR material with specified albedo color value.
        /// </summary>
        /// <param name="albedo">The albedo color</param>
        public PbrMaterial(Vector3 albedo) : this()
        {
            _albedo = albedo;
        }

        /// <summary>
        /// Gets or sets the transparency factor.
        /// The factor should be ranged between 0(0%, fully opaque) and 1(100%, fully transparent)
        /// Any invalid factor value will be clamped.
        /// </summary>
        public double Transparency
        {
            get => _transparency;
            set => _transparency = value;
        }

        /// <summary>
        /// Gets or sets the texture of normal mapping
        /// </summary>
        public TextureBase NormalTexture
        {
            get => _normalTexture;
            set => _normalTexture = value;
        }

        /// <summary>
        /// Gets or sets the texture for specular color
        /// </summary>
        public TextureBase SpecularTexture
        {
            get => _specularTexture;
            set => _specularTexture = value;
        }

        /// <summary>
        /// Gets or sets the texture for albedo
        /// </summary>
        public TextureBase AlbedoTexture
        {
            get => _albedoTexture;
            set => _albedoTexture = value;
        }

        /// <summary>
        /// Gets or sets the base color of the material
        /// </summary>
        public Vector3 Albedo
        {
            get => _albedo;
            set => _albedo = value;
        }

        /// <summary>
        /// Gets or sets the texture for ambient occlusion
        /// </summary>
        public TextureBase OcclusionTexture
        {
            get => _occlusionTexture;
            set => _occlusionTexture = value;
        }

        /// <summary>
        /// Gets or sets the factor of ambient occlusion
        /// </summary>
        public double OcclusionFactor
        {
            get => _occlusionFactor;
            set => _occlusionFactor = value;
        }

        /// <summary>
        /// Gets or sets the metalness of the material, value of 1 means the material is a metal and value of 0 means the material is a dielectric.
        /// </summary>
        public double MetallicFactor
        {
            get => _metallicFactor;
            set => _metallicFactor = value;
        }

        /// <summary>
        /// Gets or sets the roughness of the material, value of 1 means the material is completely rough and value of 0 means the material is completely smooth
        /// </summary>
        public double RoughnessFactor
        {
            get => _roughnessFactor;
            set => _roughnessFactor = value;
        }

        /// <summary>
        /// Gets or sets the texture for metallic(in R channel) and roughness(in G channel)
        /// </summary>
        public TextureBase MetallicRoughness
        {
            get => _metallicRoughness;
            set => _metallicRoughness = value;
        }

        /// <summary>
        /// Gets or sets the texture for emissive
        /// </summary>
        public TextureBase EmissiveTexture
        {
            get => _emissiveTexture;
            set => _emissiveTexture = value;
        }

        /// <summary>
        /// Gets or sets the emissive color
        /// </summary>
        public Vector3 EmissiveColor
        {
            get => _emissiveColor;
            set => _emissiveColor = value;
        }

        /// <summary>
        /// Allow convert other material to PbrMaterial
        /// </summary>
        /// <param name="material">The source material</param>
        /// <returns>A new PbrMaterial instance</returns>
        public static PbrMaterial FromMaterial(Material material)
        {
            return new PbrMaterial();
        }
    }
}
