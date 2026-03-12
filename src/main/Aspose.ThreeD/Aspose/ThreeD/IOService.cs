using System;
using System.IO;
using System.Linq;
using Aspose.ThreeD.Formats;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Centralized service for managing file format registration and detection
    /// </summary>
    public static class IOService
    {
        private static readonly FileFormat[] _registeredFormats;

        static IOService()
        {
            _registeredFormats = FileFormat.Formats.ToArray();
        }

        /// <summary>
        /// Detects file format from data stream and optional file name
        /// </summary>
        public static FileFormat DetectFormat(Stream stream, string? fileName)
        {
            if (stream.CanRead && stream.CanSeek)
            {
                var position = stream.Position;
                try
                {
                    foreach (var format in _registeredFormats)
                    {
                        if (format.CanDetect(stream, fileName))
                        {
                            return format;
                        }
                    }
                }
                finally
                {
                    stream.Position = position;
                }
            }

            if (fileName != null)
            {
                var ext = Path.GetExtension(fileName);
                return FileFormat.GetFormatByExtension(ext);
            }

            throw new ArgumentException("Cannot detect file format without file name or stream data");
        }

        /// <summary>
        /// Gets file format by file name
        /// </summary>
        public static FileFormat GetFormatByFileName(string fileName)
        {
            var ext = Path.GetExtension(fileName);
            return FileFormat.GetFormatByExtension(ext);
        }
    }
}
