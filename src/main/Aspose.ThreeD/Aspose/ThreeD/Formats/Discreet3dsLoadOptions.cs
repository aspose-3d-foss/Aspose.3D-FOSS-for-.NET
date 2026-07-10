using System;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Load options for 3DS file.
    /// </summary>
    public class Discreet3dsLoadOptions : LoadOptions
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public Discreet3dsLoadOptions()
        {
        }

        /// <summary>
        /// A 3ds file may contains original color and gamma corrected color for same attribute,
        /// Setting this to true will use the gamma corrected color if possible, 
        /// otherwise the Aspose.3D will try to use the original color.
        /// </summary>
        public bool GammaCorrectedColor { get; set; }

        /// <summary>
        /// Gets or sets flip coordinate system of control points/normal during importing/exporting.
        /// </summary>
        public bool FlipCoordinateSystem { get; set; }

        /// <summary>
        /// Gets or sets whether to use the transformation defined in the first frame of animation track.
        /// </summary>
        public bool ApplyAnimationTransform { get; set; }
    }
}
