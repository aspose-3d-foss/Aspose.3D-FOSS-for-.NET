using System;
using System.IO;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Abstract base class for all importers
    /// </summary>
    internal abstract class Importer
    {
        private FileFormat _format;

        /// <summary>
        /// Gets the file format supported by this importer
        /// </summary>
        public FileFormat Format => _format;

        /// <summary>
        /// Initializes a new instance of the Importer class
        /// </summary>
        /// <param name="format">The file format</param>
        protected Importer(FileFormat format)
        {
            _format = format ?? throw new ArgumentNullException(nameof(format));
        }

        /// <summary>
        /// Check if this importer supports the specified format
        /// </summary>
        /// <param name="format">The format to check</param>
        /// <returns>True if supported, false otherwise</returns>
        public abstract bool SupportsFormat(FileFormat format);

        /// <summary>
        /// Imports a scene from the given stream using the specified load options
        /// </summary>
        /// <param name="stream">The stream to read from</param>
        /// <param name="options">The load options</param>
        /// <returns>The imported scene</returns>
        public abstract Scene Import(Stream stream, LoadOptions options);
    }
}
