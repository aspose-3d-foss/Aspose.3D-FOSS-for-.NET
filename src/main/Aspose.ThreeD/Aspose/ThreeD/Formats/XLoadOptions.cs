using System;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// The Load options for DirectX X files.
    /// </summary>
    public class XLoadOptions : LoadOptions
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public XLoadOptions(FileContentType contentType)
        {
        }

        /// <summary>
        /// Flip the coordinate system, this is true by default
        /// </summary>
        public bool FlipCoordinateSystem { get; set; }
    }
}
