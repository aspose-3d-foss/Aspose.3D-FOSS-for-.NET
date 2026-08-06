using System;
using System.Collections.Generic;
using System.IO;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Helper class with 3DS chunk constants and utilities.
    /// </summary>
    internal static class ChunkConstants
    {
        // Main chunks
        public const ushort CHUNK_MAIN = 0x4D4D;
        public const ushort CHUNK_OBJMESH = 0x3D3D;
        public const ushort CHUNK_MLI = 0x3DAA;
        public const ushort CHUNK_PRJ = 0x8000;

        // Editor sub-chunks
        public const ushort CHUNK_3DEDITOR = 0x3D3E;
        public const ushort CHUNK_OBJBLOCK = 0x4000;

        // Object sub-chunks
        public const ushort CHUNK_TRIMESH = 0x4100;
        public const ushort CHUNK_LIGHT = 0x4600;
        public const ushort CHUNK_CAMERA = 0x4700;

        // Mesh sub-chunks
        public const ushort CHUNK_VERTLIST = 0x4110;
        public const ushort CHUNK_FACELIST = 0x4120;
        public const ushort CHUNK_TRMATRIX = 0x4130;
        public const ushort CHUNK_MAPLIST = 0x4140;
        public const ushort CHUNK_SMOOLIST = 0x4160;
        public const ushort CHUNK_FACEMAT = 0x4150;

        // Material chunks
        public const ushort CHUNK_MTL = 0xAFFF;
        public const ushort CHUNK_MTL_NAME = 0xA000;
        public const ushort CHUNK_MTL_AMBIENT = 0xA010;
        public const ushort CHUNK_MTL_DIFFUSE = 0xA020;
        public const ushort CHUNK_MTL_SPECULAR = 0xA030;
        public const ushort CHUNK_MTL_SHININESS = 0xA040;
        public const ushort CHUNK_MTL_TRANSPARENCY = 0xA050;
        public const ushort CHUNK_MTL_SHADING = 0xA100;
        public const ushort CHUNK_MTL_MAP = 0xA200;
        public const ushort CHUNK_MTL_MAPFILE = 0xA300;
    }

    /// <summary>
    /// Helper methods for 3DS file parsing.
    /// </summary>
    internal static class ChunkHelper
    {
        /// <summary>
        /// Reads a color from the stream (3 floats: R, G, B).
        /// </summary>
        public static Vector3 ReadColor(BinaryReader reader)
        {
            var r = reader.ReadSingle();
            var g = reader.ReadSingle();
            var b = reader.ReadSingle();
            return new Vector3((double)r, (double)g, (double)b);
        }

        /// <summary>
        /// Reads a percentage value from the stream (1 float).
        /// </summary>
        public static float ReadPercentage(BinaryReader reader)
        {
            return reader.ReadSingle();
        }

        /// <summary>
        /// Reads a null-terminated ASCII string from the stream.
        /// </summary>
        public static string ReadString(BinaryReader reader)
        {
            var bytes = new List<byte>();
            byte b;
            while ((b = reader.ReadByte()) != 0)
            {
                bytes.Add(b);
            }
            return System.Text.Encoding.ASCII.GetString(bytes.ToArray());
        }

        /// <summary>
        /// Skips a chunk by seeking past its data.
        /// </summary>
        public static void SkipChunk(BinaryReader reader, Chunk chunk)
        {
            reader.BaseStream.Seek(chunk.Size - 6, SeekOrigin.Current);
        }

        /// <summary>
        /// Reads a chunk header from the stream.
        /// </summary>
        public static Chunk ReadChunk(BinaryReader reader)
        {
            var id = reader.ReadUInt16();
            var size = reader.ReadUInt32();
            return new Chunk(id, size);
        }

        /// <summary>
        /// Represents a 3DS chunk header.
        /// </summary>
        public struct Chunk
        {
            public ushort Id { get; }
            public uint Size { get; }

            public Chunk(ushort id, uint size)
            {
                Id = id;
                Size = size;
            }
        }
    }
}
