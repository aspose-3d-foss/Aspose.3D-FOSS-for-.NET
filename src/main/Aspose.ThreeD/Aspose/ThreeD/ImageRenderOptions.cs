using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Image render options
    /// </summary>
    public class ImageRenderOptions
    {
        /// <summary>
        /// Initializes a new instance of the ImageRenderOptions class
        /// </summary>
        public ImageRenderOptions()
        {
        }
    }

    /// <summary>
    /// Texture data
    /// </summary>
    public class TextureData
    {
        private Vector2 _size;

        /// <summary>
        /// Initializes a new instance of the TextureData class
        /// </summary>
        public TextureData()
        {
            _size = Vector2.One;
        }

        /// <summary>
        /// Gets or sets the size
        /// </summary>
        public Vector2 Size
        {
            get => _size;
            set => _size = value;
        }
    }
}
