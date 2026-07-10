namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Save options for A3DW format.
    /// </summary>
    public class A3dwSaveOptions : SaveOptions
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public A3dwSaveOptions()
        {
        }

        /// <summary>
        /// Export meta data associated with Scene/Node to client
        /// Default value is true
        /// </summary>
        public bool ExportMetaData { get; set; }

        /// <summary>
        /// If this property is non-null, only the properties of Scene/Node that start with this prefix will be exported, and the prefix will be removed.
        /// </summary>
        public string MetaDataPrefix { get; set; }
    }
}
