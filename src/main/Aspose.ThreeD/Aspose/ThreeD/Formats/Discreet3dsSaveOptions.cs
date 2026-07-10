using System;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Save options for 3DS file.
    /// </summary>
    public class Discreet3dsSaveOptions : SaveOptions
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public Discreet3dsSaveOptions()
        {
        }

        /// <summary>
        /// Gets or sets whether export all lights in the scene.
        /// </summary>
        public bool ExportLight { get; set; }

        /// <summary>
        /// Gets or sets whether export all cameras in the scene.
        /// </summary>
        public bool ExportCamera { get; set; }

        /// <summary>
        /// The separator between object's name and the duplicated counter, default value is "_".
        /// 
        /// When scene contains objects that use the same name, Aspose.3D 3DS exporter will generate a different name for the object.
        /// For example there's two nodes named "Box", the first node will have a name "Box",
        /// and the second node will get a new name "Box_2" using the default configuration.
        /// </summary>
        public string DuplicatedNameSeparator { get; set; }

        /// <summary>
        /// The counter used by generating new name for duplicated names, default value is 2.
        /// </summary>
        public int DuplicatedNameCounterBase { get; set; }

        /// <summary>
        /// The format of the duplicated counter, default value is empty string.
        /// </summary>
        public string DuplicatedNameCounterFormat { get; set; }

        /// <summary>
        /// Gets or sets the master scale used in exporting.
        /// </summary>
        public double MasterScale { get; set; }

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
        /// If this is true, the generated 3ds file will use high precise color, means each channel of red/green/blue are in 32bit float.
        /// Otherwise the generated file will use 24bit color, each channel use 8bit byte.
        /// The default value is false, because not all applications supports the high-precise color.
        /// </summary>
        public bool HighPreciseColor { get; set; }
    }
}
