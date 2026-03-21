using System;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Base class of save options
    /// </summary>
    public abstract class SaveOptions : IOConfig
    {
        /// <summary>
        /// Try to copy textures used in scene to output directory.
        /// </summary>
        public bool ExportTextures { get; set; }
    }
}
