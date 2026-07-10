using System;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Load options for Siemens JT
    /// </summary>
    public class JtLoadOptions : LoadOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public JtLoadOptions()
        {
        }

        /// <summary>
        /// Load properties from JT's property table as Aspose.3D properties. 
        /// Default value is false.
        /// </summary>
        public bool LoadProperties { get; set; }

        /// <summary>
        /// Load PMI information from JT file if possible, the data will be saved as property "PMI" of .
        /// Default value is false.
        /// </summary>
        public bool LoadPMI { get; set; }
    }
}
