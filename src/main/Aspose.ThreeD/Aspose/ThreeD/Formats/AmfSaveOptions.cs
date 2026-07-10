namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Save options for AMF
    /// </summary>
    public class AmfSaveOptions : SaveOptions
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public AmfSaveOptions()
        {
        }

        /// <summary>
        /// Whether to use compression to reduce the final file size, default value is true
        /// </summary>
        public bool EnableCompression { get; set; }
    }
}
