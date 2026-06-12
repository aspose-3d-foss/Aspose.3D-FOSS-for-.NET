using System;
using System.Collections.Generic;
using System.IO;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// The RVM Format
    /// </summary>
    public class RvmFormat : FileFormat
    {
        public RvmFormat() : base(
            "rvm",
            new[] { "rvm" },
            new Version(1, 0),
            true,
            true,
            FileContentType.ASCII,
            new FileFormatType("rvm"))
        {
        }

        /// <summary>
        /// Load the attributes from specified file name
        /// </summary>
        public void LoadAttributes(Scene scene, string fileName, string prefix)
        {
            throw new NotImplementedException("RVM attributes loading not implemented in FOSS version");
        }

        /// <summary>
        /// Load the attributes from specified stream
        /// </summary>
        public void LoadAttributes(Scene scene, Stream stream, string prefix)
        {
            throw new NotImplementedException("RVM attributes loading not implemented in FOSS version");
        }
    }
}
