using System;
using System.IO;
using Aspose.ThreeD.Entities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Abstract base class for all exporters
    /// </summary>
    public abstract class Exporter
    {
        private FileFormat _format;

        /// <summary>
        /// Gets the file format supported by this exporter
        /// </summary>
        public FileFormat Format => _format;

        /// <summary>
        /// Initializes a new instance of the Exporter class
        /// </summary>
        /// <param name="format">The file format</param>
        protected Exporter(FileFormat format)
        {
            _format = format ?? throw new ArgumentNullException(nameof(format));
        }

        /// <summary>
        /// Check if this exporter supports the specified format
        /// </summary>
        /// <param name="format">The format to check</param>
        /// <returns>True if supported, false otherwise</returns>
        public abstract bool SupportsFormat(FileFormat format);

        /// <summary>
        /// Exports a scene to the given stream using the specified save options
        /// </summary>
        /// <param name="scene">The scene to export</param>
        /// <param name="stream">The stream to write to</param>
        /// <param name="options">The save options</param>
        public abstract void Export(Scene scene, Stream stream, SaveOptions options);
    }
}
