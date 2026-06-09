namespace Aspose.ThreeD.Shading
{
    /// <summary>
    /// This class defines the texture from an external file.
    /// </summary>
    public class Texture : TextureBase, INamedObject
    {
        private bool _enableMipMap;
        private byte[] _content;
        private string _fileName;

        /// <summary>
        /// Initializes a new instance of the Texture class.
        /// </summary>
        public Texture() : base("Texture")
        {
        }

        /// <summary>
        /// Initializes a new instance of the Texture class.
        /// </summary>
        public Texture(string name) : base(name)
        {
        }

        /// <summary>
        /// Gets or sets if the mipmap is enabled for this texture
        /// </summary>
        public bool EnableMipMap
        {
            get => _enableMipMap;
            set => _enableMipMap = value;
        }

        /// <summary>
        /// Gets or sets the binary content of the texture.
        /// The embedded texture content is optional, user should load texture from external file if this is missing.
        /// </summary>
        public byte[] Content
        {
            get => _content;
            set => _content = value;
        }

        /// <summary>
        /// Gets or sets the associated texture file.
        /// </summary>
        public string FileName
        {
            get => _fileName;
            set => _fileName = value;
        }
    }
}
