using System;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Save options for Aveva PDMS RVM file.
    /// </summary>
    public class RvmSaveOptions : SaveOptions
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public RvmSaveOptions()
        {
        }

        /// <summary>
        /// Constructor of
        /// </summary>
        public RvmSaveOptions(FileContentType contentType)
        {
        }

        /// <summary>
        /// File note in the file header.
        /// </summary>
        public string FileNote { get; set; }

        /// <summary>
        /// Author information, default value is '3d@aspose'
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// The timestamp that exported this file, default value is current time
        /// </summary>
        public string CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the prefix of which attributes that will be exported, the exported property will contains no prefix, custom properties with different prefix will not be exported, default value is 'rvm:'.
        /// For example if a property is rvm:Refno=345, the exported attribute will be Refno = 345, the prefix is stripped.
        /// </summary>
        public string AttributePrefix { get; set; }

        /// <summary>
        /// Gets or sets the file name of attribute list file, exporter will generate a name based on the .rvm file name when this property is undefined, default value is null.
        /// </summary>
        public string AttributeListFile { get; set; }

        /// <summary>
        /// Gets or sets whether to export the attribute list to an external .att file, default value is false.
        /// </summary>
        public bool ExportAttributes { get; set; }
    }
}
