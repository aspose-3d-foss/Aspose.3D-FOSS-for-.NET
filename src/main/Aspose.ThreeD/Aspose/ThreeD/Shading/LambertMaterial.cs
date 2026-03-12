using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Shading
{
    /// <summary>
    /// Lambert material with diffuse lighting
    /// </summary>
    public class LambertMaterial : Material
    {
        private Vector4 _ambient = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
        private Vector4 _diffuse = new Vector4(0.5f, 0.5f, 0.5f, 1.0f);
        private Vector4 _emissive = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);
        private Vector4 _reflective = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        private float _reflectivity = 0.0f;
        private float _transparency = 0.0f;
        private float _indexOfRefraction = 0.0f;
        private string _texture = string.Empty;

        /// <summary>
        /// Initializes a new instance of the LambertMaterial class
        /// </summary>
        public LambertMaterial() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the LambertMaterial class
        /// </summary>
        /// <param name="name">Material name</param>
        public LambertMaterial(string name) : base(name)
        {
        }

        /// <summary>
        /// Gets or sets the ambient color
        /// </summary>
        public Vector4 Ambient
        {
            get => _ambient;
            set => _ambient = value;
        }

        /// <summary>
        /// Gets or sets the diffuse color
        /// </summary>
        public Vector4 Diffuse
        {
            get => _diffuse;
            set => _diffuse = value;
        }

        /// <summary>
        /// Gets or sets the emissive color
        /// </summary>
        public Vector4 Emissive
        {
            get => _emissive;
            set => _emissive = value;
        }

        /// <summary>
        /// Gets or sets the reflective color
        /// </summary>
        public Vector4 Reflective
        {
            get => _reflective;
            set => _reflective = value;
        }

        /// <summary>
        /// Gets or sets the reflectivity factor (0-1)
        /// </summary>
        public float Reflectivity
        {
            get => _reflectivity;
            set => _reflectivity = value;
        }

        /// <summary>
        /// Gets or sets the transparency factor (0-1)
        /// </summary>
        public float Transparency
        {
            get => _transparency;
            set => _transparency = value;
        }

        /// <summary>
        /// Gets or sets the index of refraction
        /// </summary>
        public float IndexOfRefraction
        {
            get => _indexOfRefraction;
            set => _indexOfRefraction = value;
        }

        /// <summary>
        /// Gets or sets the texture URL
        /// </summary>
        public string Texture
        {
            get => _texture;
            set => _texture = value;
        }
    }
}
