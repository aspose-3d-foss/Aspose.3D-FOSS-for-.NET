using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Shading
{
    /// <summary>
    /// Material for blinn-phong shading model.
    /// </summary>
    public class PhongMaterial : LambertMaterial
    {
        private Vector3 _specularColor = new Vector3(0.2f, 0.2f, 0.2f);
        private double _specularFactor = 1.0;
        private double _shininess = 20.0;
        private Vector3 _reflectionColor = new Vector3(0, 0, 0);
        private double _reflectionFactor = 0.0;

        /// <summary>
        /// Initializes a new instance of the PhongMaterial class
        /// </summary>
        public PhongMaterial() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PhongMaterial class
        /// </summary>
        /// <param name="name">Material name</param>
        public PhongMaterial(string name) : base(name)
        {
        }

        /// <summary>
        /// Gets or sets the specular color.
        /// </summary>
        public Vector3 SpecularColor
        {
            get => _specularColor;
            set => _specularColor = value;
        }

        /// <summary>
        /// Gets or sets the specular factor. 
        /// The formula of specular:
        ///  SpecularColor * SpecularFactor * (N dot H) ^ Shininess
        /// </summary>
        public double SpecularFactor
        {
            get => _specularFactor;
            set => _specularFactor = value;
        }

        /// <summary>
        /// Gets or sets the shininess, this controls the specular highlight's size.
        /// The formula of specular:
        ///  SpecularColor * SpecularFactor * (N dot H) ^ Shininess
        /// </summary>
        public double Shininess
        {
            get => _shininess;
            set => _shininess = value;
        }

        /// <summary>
        /// Gets or sets the reflection color.
        /// </summary>
        public Vector3 ReflectionColor
        {
            get => _reflectionColor;
            set => _reflectionColor = value;
        }

        /// <summary>
        /// Gets or sets the attenuation of the reflection color.
        /// </summary>
        public double ReflectionFactor
        {
            get => _reflectionFactor;
            set => _reflectionFactor = value;
        }
    }
}
