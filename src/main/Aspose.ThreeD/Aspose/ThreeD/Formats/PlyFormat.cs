using System;
using System.Collections.Generic;
using System.IO;
using Aspose.ThreeD.Entities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// The PLY format.
    /// </summary>
    public class PlyFormat : FileFormat
    {
        internal PlyFormat() : base(
            "ply",
            new[] { "ply" },
            new Version(1, 0),
            true,
            true,
            FileContentType.ASCII,
            new FileFormatType("ply"))
        {
        }

        /// <summary>
        /// Encode the entity and save the result into the stream.
        /// </summary>
        public void Encode(Entity entity, Stream stream)
        {
            throw new NotImplementedException("PLY encoding not implemented in FOSS version");
        }

        /// <summary>
        /// Encode the entity and save the result into the stream.
        /// </summary>
        public void Encode(Entity entity, Stream stream, PlySaveOptions opt)
        {
            throw new NotImplementedException("PLY encoding not implemented in FOSS version");
        }

        /// <summary>
        /// Encode the entity and save the result into an external file.
        /// </summary>
        public void Encode(Entity entity, string fileName)
        {
            throw new NotImplementedException("PLY encoding not implemented in FOSS version");
        }

        /// <summary>
        /// Encode the entity and save the result into an external file.
        /// </summary>
        public void Encode(Entity entity, string fileName, PlySaveOptions opt)
        {
            throw new NotImplementedException("PLY encoding not implemented in FOSS version");
        }

        /// <summary>
        /// Decode a point cloud or mesh from the specified stream.
        /// </summary>
        public Geometry Decode(string fileName)
        {
            throw new NotImplementedException("PLY decoding not implemented in FOSS version");
        }

        /// <summary>
        /// Decode a point cloud or mesh from the specified stream.
        /// </summary>
        public Geometry Decode(string fileName, PlyLoadOptions opt)
        {
            throw new NotImplementedException("PLY decoding not implemented in FOSS version");
        }

        /// <summary>
        /// Decode a point cloud or mesh from the specified stream.
        /// </summary>
        public Geometry Decode(Stream stream)
        {
            throw new NotImplementedException("PLY decoding not implemented in FOSS version");
        }

        /// <summary>
        /// Decode a point cloud or mesh from the specified stream.
        /// </summary>
        public Geometry Decode(Stream stream, PlyLoadOptions opt)
        {
            throw new NotImplementedException("PLY decoding not implemented in FOSS version");
        }
    }
}
