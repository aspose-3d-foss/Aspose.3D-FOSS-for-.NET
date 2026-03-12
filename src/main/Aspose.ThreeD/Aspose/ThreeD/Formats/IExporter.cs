using System.IO;
using Aspose.ThreeD.Entities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Interface for exporting 3D scene data to a file
    /// </summary>
    public interface IExporter
    {
        /// <summary>
        /// Exports a scene to the given stream using the specified save options
        /// </summary>
        /// <param name="scene">The scene to export</param>
        /// <param name="stream">The stream to write to</param>
        /// <param name="options">The save options</param>
        void Export(Scene scene, Stream stream, SaveOptions options);
    }
}
