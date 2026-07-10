using System;

namespace Aspose.ThreeD.Render
{
    /// <summary>
    /// 
    /// </summary>
    public class PixelMapping : IDisposable
    {
        internal PixelMapping()
        {
        }

        /// <summary>
        /// Bytes of pixels in a row.
        /// </summary>
        public int Stride { get; }

        /// <summary>
        /// Rows of the pixels
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Columns of the pixels
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The mapped bytes of pixels.
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// Dispose the mapping instance
        /// </summary>
        public void Dispose()
        {
            // Stub
        }
    }
}
