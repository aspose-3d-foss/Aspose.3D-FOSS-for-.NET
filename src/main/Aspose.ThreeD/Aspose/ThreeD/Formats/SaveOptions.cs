namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Base class of save options
    /// </summary>
    public abstract class SaveOptions : IOConfig
    {
        /// <summary>
        /// Initializes a new instance of the SaveOptions class
        /// </summary>
        protected SaveOptions()
        {
        }

        /// <summary>
        /// Gets or sets the file system used for saving external resources
        /// </summary>
        public Utilities.FileSystem? FileSystem { get; set; }
    }
}
