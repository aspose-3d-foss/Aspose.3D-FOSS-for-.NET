using System;
using System.Collections.Generic;
using System.IO;
using Aspose.ThreeD.Entities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Google Draco format
    /// </summary>
    public class DracoFormat : FileFormat
    {
        internal DracoFormat() : base(
            "draco",
            new[] { "draco" },
            new Version(1, 0),
            true,
            true,
            FileContentType.Binary,
            new FileFormatType("draco"))
        {
        }

        /// <summary>
        /// Decode the point cloud or mesh from specified file name
        /// </summary>
        public Geometry Decode(string fileName)
        {
            throw new NotImplementedException("Draco decoding not implemented in FOSS version");
        }

        public Geometry Decode(byte[] data)
        {
            throw new NotImplementedException("Draco decoding not implemented in FOSS version");
        }

        /// <summary>
        /// Encode the entity to specified stream
        /// </summary>
        public void Encode(Entity entity, Stream stream, DracoSaveOptions options)
        {
            throw new NotImplementedException("Draco encoding not implemented in FOSS version");
        }

        /// <summary>
        /// Encode the entity to specified file
        /// </summary>
        public void Encode(Entity entity, string fileName, DracoSaveOptions options)
        {
            throw new NotImplementedException("Draco encoding not implemented in FOSS version");
        }

        /// <summary>
        /// Encode the entity to Draco raw data
        /// </summary>
        public byte[] Encode(Entity entity, DracoSaveOptions options)
        {
            throw new NotImplementedException("Draco encoding not implemented in FOSS version");
        }
    }
}
