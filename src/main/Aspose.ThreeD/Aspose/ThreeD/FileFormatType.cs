namespace Aspose.ThreeD
{
    /// <summary>
    /// File format type
    /// </summary>
    public sealed class FileFormatType
    {
        private readonly string _extension;

        /// <summary>
        /// Initializes a new instance of the FileFormatType class
        /// </summary>
        internal FileFormatType(string extension)
        {
            _extension = extension;
        }

        /// <summary>
        /// The extension name of this file format, started with .
        /// </summary>
        public string Extension => _extension;

        /// <summary>
        /// Get the name of this file format type
        /// </summary>
        public override string ToString()
        {
            return _extension;
        }
    }
}
