using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Formats;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Image render options
    /// </summary>
    public class ImageRenderOptions : SaveOptions
    {
        private Vector3 _backgroundColor;
        private List<string> _assetDirectories;

        /// <summary>
        /// Initializes a new instance of the ImageRenderOptions class
        /// </summary>
        public ImageRenderOptions()
        {
            _assetDirectories = new List<string>();
        }

        /// <summary>
        /// Gets or sets the background color
        /// </summary>
        public Vector3 BackgroundColor
        {
            get => _backgroundColor;
            set => _backgroundColor = value;
        }

        /// <summary>
        /// Gets the asset directories
        /// </summary>
        public List<string> AssetDirectories => _assetDirectories;

        /// <summary>
        /// Gets or sets a value indicating whether shadows are enabled
        /// </summary>
        public bool EnableShadows { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; } = string.Empty;
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
            _size = new Vector2(1, 1);
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
