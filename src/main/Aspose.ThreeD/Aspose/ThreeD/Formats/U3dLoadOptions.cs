using System;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Load options for universal 3d
    /// </summary>
    public class U3dLoadOptions : LoadOptions
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public U3dLoadOptions()
        {
        }

        /// <summary>
        /// Gets or sets whether flip coordinate system of control points/normal during importing/exporting.
        /// </summary>
        public bool FlipCoordinateSystem { get; set; }
    }
}
