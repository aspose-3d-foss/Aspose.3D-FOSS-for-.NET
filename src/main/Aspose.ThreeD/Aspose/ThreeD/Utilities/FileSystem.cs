using System;
using System.IO;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// Abstract file system
    /// </summary>
    public abstract class FileSystem
    {
        /// <summary>
        /// Opens a file for reading
        /// </summary>
        public abstract Stream ReadFile(string fileName);

        /// <summary>
        /// Opens a file for writing
        /// </summary>
        public abstract Stream WriteFile(string fileName);
    }
}
