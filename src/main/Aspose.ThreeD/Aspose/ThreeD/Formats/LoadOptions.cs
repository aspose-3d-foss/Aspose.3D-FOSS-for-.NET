namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Base class of load options
    /// </summary>
    public abstract class LoadOptions : IOConfig
    {
        /// <summary>
        /// Initializes a new instance of the LoadOptions class
        /// </summary>
        protected LoadOptions()
        {
        }

        /// <summary>
        /// Gets or sets the file system used for loading external resources
        /// </summary>
        public Utilities.FileSystem? FileSystem { get; set; }
    }
}
