using System;
using System.Collections.Generic;
using System.IO;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Adobe's Portable Document Format
    /// </summary>
    public class PdfFormat : FileFormat
    {
        public PdfFormat() : base(
            "pdf",
            new[] { "pdf" },
            new Version(1, 6),
            false,
            true,
            FileContentType.Binary,
            new FileFormatType("pdf"))
        {
        }

        public List<byte[]> Extract(string fileName, byte[] password)
        {
            throw new NotImplementedException("PDF extraction not implemented in FOSS version");
        }

        public List<byte[]> Extract(Stream stream, byte[] password)
        {
            throw new NotImplementedException("PDF extraction not implemented in FOSS version");
        }

        public List<Scene> ExtractScene(string fileName)
        {
            throw new NotImplementedException("PDF scene extraction not implemented in FOSS version");
        }

        public List<Scene> ExtractScene(string fileName, byte[] password)
        {
            throw new NotImplementedException("PDF scene extraction not implemented in FOSS version");
        }

        public List<Scene> ExtractScene(Stream stream, byte[] password)
        {
            throw new NotImplementedException("PDF scene extraction not implemented in FOSS version");
        }
    }
}
