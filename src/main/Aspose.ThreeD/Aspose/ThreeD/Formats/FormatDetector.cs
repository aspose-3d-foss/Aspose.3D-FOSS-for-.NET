using System.IO;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Abstract base class for format detection
    /// </summary>
    public abstract class FormatDetector
    {
        /// <summary>
        /// Detects the file format from the given stream and optional file name
        /// </summary>
        /// <param name="stream">The stream to detect from</param>
        /// <param name="fileName">Optional file name for extension-based detection</param>
        /// <returns>True if the format matches, false otherwise</returns>
        public abstract bool Detect(Stream stream, string? fileName);
    }
}
