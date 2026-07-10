using System;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Save options for USD/USDZ formats.
    /// </summary>
    public class UsdSaveOptions : SaveOptions
    {
        /// <summary>
        /// Initialize a new with  format
        /// </summary>
        public UsdSaveOptions()
        {
        }

        /// <summary>
        /// Initialize a new with specified USD/USDZ format.
        /// </summary>
        public UsdSaveOptions(FileFormat fileFormat)
        {
        }

        /// <summary>
        /// Convert the primitive entities to mesh during the export.
        /// Or directly encode the primitives to the output file(will use Aspose's extension definition for unofficial primitives like Dish, Torus)
        /// Default value is true.
        /// </summary>
        public bool PrimitiveToMesh { get; set; }

        /// <summary>
        /// Export node's properties through USD's customData field.
        /// </summary>
        public bool ExportMetaData { get; set; }

        /// <summary>
        /// Custom converter to convert the geometry's material to PBR material
        /// If this is unassigned, USD exporter will automatically convert the standard material to PBR material.
        /// Default value is null
        /// </summary>
        public MaterialConverter MaterialConverter { get; set; }
    }
}
