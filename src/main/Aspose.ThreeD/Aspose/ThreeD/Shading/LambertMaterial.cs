using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Shading
{
    /// <summary>
    /// Material for lambert shading model
    /// </summary>
    public class LambertMaterial : Material
    {
        private Vector3 _emissiveColor = new Vector3(0, 0, 0);
        private Vector3 _ambientColor = new Vector3(0, 0, 0);
        private Vector3 _diffuseColor = new Vector3(0.5f, 0.5f, 0.5f);
        private Vector3 _transparentColor = new Vector3(0, 0, 0);
        private double _transparency = 0.0;

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
        /// Gets or sets the emissive color
        /// </summary>
        public Vector3 EmissiveColor
        {
            get => _emissiveColor;
            set => _emissiveColor = value;
        }

        /// <summary>
        /// Gets or sets the ambient color
        /// </summary>
        public Vector3 AmbientColor
        {
            get => _ambientColor;
            set => _ambientColor = value;
        }

        /// <summary>
        /// Gets or sets the diffuse color
        /// </summary>
        public Vector3 DiffuseColor
        {
            get => _diffuseColor;
            set => _diffuseColor = value;
        }

        /// <summary>
        /// Gets or sets the transparent color.
        /// The factor should be ranged between 0(0%, fully opaque) and 1(100%, fully transparent)
        /// Any invalid factor value will be clamped.
        /// </summary>
        public Vector3 TransparentColor
        {
            get => _transparentColor;
            set => _transparentColor = value;
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
    }
}
