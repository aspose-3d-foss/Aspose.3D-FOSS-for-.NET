using System;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// The base class to configure options in file saving for different types
    /// </summary>
    public class SaveOptions : IOConfig
    {
        internal SaveOptions()
        {
        }

        internal SaveOptions(FileFormat format)
        {
        }

        /// <summary>
        /// Try to copy textures used in scene to output directory.
        /// </summary>
        public bool ExportTextures { get; set; }
    }
}
