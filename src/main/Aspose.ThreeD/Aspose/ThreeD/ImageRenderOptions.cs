using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Formats;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Options for  and
    /// </summary>
    public class ImageRenderOptions : A3DObject, INamedObject
    {
        private Vector3 _backgroundColor;
        private List<string> _assetDirectories;

        /// <summary>
        /// Initialize an instance of
        /// </summary>
        public ImageRenderOptions()
        {
            _assetDirectories = new List<string>();
        }

        /// <summary>
        /// The background color of the render result.
        /// </summary>
        public Vector3 BackgroundColor
        {
            get => _backgroundColor;
            set => _backgroundColor = value;
        }

        /// <summary>
        /// Directories that stored external assets(like textures)
        /// </summary>
        public List<string> AssetDirectories
        {
            get => _assetDirectories;
            set => _assetDirectories = value;
        }

        /// <summary>
        /// Gets or sets whether to render shadows.
        /// </summary>
        public bool EnableShadows { get; set; }
    }
}