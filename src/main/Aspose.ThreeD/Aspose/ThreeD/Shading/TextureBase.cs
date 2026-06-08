using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Shading
{
    /// <summary>
    /// Base class for all concrete textures.
    /// Texture defines the look and feel of a geometry surface.
    /// </summary>
    public class TextureBase : A3DObject, INamedObject
    {
        private double _alpha = 1.0;
        private AlphaSource _alphaSource = AlphaSource.None;
        private WrapMode _wrapModeU = WrapMode.Wrap;
        private WrapMode _wrapModeV = WrapMode.Wrap;
        private WrapMode _wrapModeW = WrapMode.Wrap;
        private TextureFilter _minFilter = TextureFilter.None;
        private TextureFilter _magFilter = TextureFilter.None;
        private TextureFilter _mipFilter = TextureFilter.None;
        private Vector3 _uvRotation = new Vector3(0, 0, 0);
        private Vector2 _uvScale = new Vector2(1, 1);
        private Vector2 _uvTranslation = new Vector2(0, 0);

        /// <summary>
        /// Initializes a new instance of the TextureBase class.
        /// </summary>
        public TextureBase(string name) : base(name)
        {
        }

        /// <summary>
        /// Gets or sets the default alpha value of the texture.
        /// This is valid when the AlphaSource is FixedValue.
        /// Default value is 1.0, valid value range is between 0 and 1.
        /// </summary>
        public double Alpha
        {
            get => _alpha;
            set => _alpha = value;
        }

        /// <summary>
        /// Gets or sets whether the texture defines the alpha channel.
        /// Default value is PixelAlpha.
        /// </summary>
        public AlphaSource AlphaSource
        {
            get => _alphaSource;
            set => _alphaSource = value;
        }

        /// <summary>
        /// Gets or sets the texture wrap modes in U.
        /// </summary>
        public WrapMode WrapModeU
        {
            get => _wrapModeU;
            set => _wrapModeU = value;
        }

        /// <summary>
        /// Gets or sets the texture wrap modes in V.
        /// </summary>
        public WrapMode WrapModeV
        {
            get => _wrapModeV;
            set => _wrapModeV = value;
        }

        /// <summary>
        /// Gets or sets the texture wrap modes in W.
        /// </summary>
        public WrapMode WrapModeW
        {
            get => _wrapModeW;
            set => _wrapModeW = value;
        }

        /// <summary>
        /// Gets or sets the filter for minification.
        /// </summary>
        public TextureFilter MinFilter
        {
            get => _minFilter;
            set => _minFilter = value;
        }

        /// <summary>
        /// Gets or sets the filter for magnification.
        /// </summary>
        public TextureFilter MagFilter
        {
            get => _magFilter;
            set => _magFilter = value;
        }

        /// <summary>
        /// Gets or sets the filter for mip-level sampling.
        /// </summary>
        public TextureFilter MipFilter
        {
            get => _mipFilter;
            set => _mipFilter = value;
        }

        /// <summary>
        /// Gets or sets the rotation of the texture.
        /// </summary>
        public Vector3 UVRotation
        {
            get => _uvRotation;
            set => _uvRotation = value;
        }

        /// <summary>
        /// Gets or sets the UV scale.
        /// </summary>
        public Vector2 UVScale
        {
            get => _uvScale;
            set => _uvScale = value;
        }

        /// <summary>
        /// Gets or sets the UV translation.
        /// </summary>
        public Vector2 UVTranslation
        {
            get => _uvTranslation;
            set => _uvTranslation = value;
        }

        /// <summary>
        /// Sets the UV translation.
        /// </summary>
        public void SetTranslation(double u, double v)
        {
            _uvTranslation = new Vector2(u, v);
        }

        /// <summary>
        /// Sets the UV scale.
        /// </summary>
        public void SetScale(double u, double v)
        {
            _uvScale = new Vector2(u, v);
        }

        /// <summary>
        /// Sets the UV rotation.
        /// </summary>
        public void SetRotation(double u, double v)
        {
            _uvRotation = new Vector3(u, v, 0);
        }
    }
}
