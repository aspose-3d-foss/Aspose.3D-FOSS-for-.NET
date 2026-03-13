namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Abstract base class for all plugin implementations
    /// </summary>
    public abstract class Plugin
    {
        /// <summary>
        /// Gets the file format supported by this plugin
        /// </summary>
        public abstract FileFormat GetFileFormat();

        /// <summary>
        /// Gets the importer for this plugin
        /// </summary>
        public abstract IImporter? GetImporter();

        /// <summary>
        /// Gets the exporter for this plugin
        /// </summary>
        public abstract IExporter? GetExporter();

        /// <summary>
        /// Gets the format detector for this plugin
        /// </summary>
        public abstract FormatDetector? GetFormatDetector();

        /// <summary>
        /// Creates a new instance of load options for this format
        /// </summary>
        public abstract LoadOptions CreateLoadOptions();

        /// <summary>
        /// Creates a new instance of save options for this format
        /// </summary>
        public abstract SaveOptions CreateSaveOptions();
    }
}
