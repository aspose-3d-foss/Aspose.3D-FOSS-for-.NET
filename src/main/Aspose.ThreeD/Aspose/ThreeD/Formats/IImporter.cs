using System.IO;
using Aspose.ThreeD.Entities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Interface for importing 3D scene data from a file
    /// </summary>
    public interface IImporter
    {
        /// <summary>
        /// Imports a scene from the given stream using the specified load options
        /// </summary>
        /// <param name="stream">The stream to read from</param>
        /// <param name="options">The load options</param>
        /// <returns>The imported scene</returns>
        Scene Import(Stream stream, LoadOptions options);
    }
}
