using System;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Load options for AVEVA Plant Design Management System's RVM file.
    /// </summary>
    public class RvmLoadOptions : LoadOptions
    {
        /// <summary>
        /// Construct a  instance
        /// </summary>
        public RvmLoadOptions(FileContentType contentType)
        {
        }

        /// <summary>
        /// Construct a  instance
        /// </summary>
        public RvmLoadOptions()
        {
        }

        /// <summary>
        /// Generate materials with random colors for each objects in the scene if color table is not exported within the RVM file.
        /// Default value is true
        /// </summary>
        public bool GenerateMaterials { get; set; }

        /// <summary>
        /// Gets or sets the number of cylinder's radial segments, default value is 16
        /// </summary>
        public int CylinderRadialSegments { get; set; }

        /// <summary>
        /// Gets or sets the number of dish' longitude segments, default value is 12
        /// </summary>
        public int DishLongitudeSegments { get; set; }

        /// <summary>
        /// Gets or sets the number of dish' latitude segments, default value is 8
        /// </summary>
        public int DishLatitudeSegments { get; set; }

        /// <summary>
        /// Gets or sets the number of torus' tubular segments, default value is 20
        /// </summary>
        public int TorusTubularSegments { get; set; }

        /// <summary>
        /// Gets or sets the number of rectangular torus' radial segments, default value is 20
        /// </summary>
        public int RectangularTorusSegments { get; set; }

        /// <summary>
        /// Center the scene after it's loaded.
        /// </summary>
        public bool CenterScene { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the attributes that were defined in external attribute files,
        /// The prefix are used to avoid name conflicts, default value is "rvm:"
        /// </summary>
        public string AttributePrefix { get; set; }

        /// <summary>
        /// Gets or sets whether to load attributes from external attribute list file(.att/.attrib/.txt), default value is true.
        /// </summary>
        public bool LookupAttributes { get; set; }
    }
}
