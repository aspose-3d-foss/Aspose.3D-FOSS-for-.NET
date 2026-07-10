using System;
using System.Collections.Generic;
using System.Text;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// IO config for serialization/deserialization.
    /// User can specify detailed configurations like dependency look-up path
    /// Or format-related configs here
    /// </summary>
    public class IOConfig
    {
        internal IOConfig()
        {
        }

        /// <summary>
        /// Gets or sets the factory class for FileSystem.
        /// The default factory will create FileSystem which is not suitable for server environment.
        /// Use your own FileSystemFactory to improve server side security.
        /// </summary>
        public static FileSystemFactory FileSystemFactory { get; set; }

        /// <summary>
        /// Gets the file format that specified in current Save/Load option.
        /// </summary>
        public FileFormat FileFormat { get; }

        /// <summary>
        /// Gets or sets the default encoding for text-based files.
        /// Default value is null which means the importer/exporter will decide which encoding to use.
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// Allow user to handle how to manage the external dependencies during load/save.
        /// </summary>
        public FileSystem FileSystem { get; set; }

        /// <summary>
        /// Some files like OBJ depends on external file, the lookup paths will allows Aspose.3D to look for external file to load.
        /// </summary>
        public List<string> LookupPaths { get; set; }

        /// <summary>
        /// The file name of the exporting/importing scene.
        /// This is optional, but useful when serialize external assets like OBJ's material.
        /// </summary>
        public string FileName { get; set; }


    }

    /// <summary>
    /// Factory class for FileSystem.
    /// This can be a security issue in server environment.
    /// Use your own FileSystemFactory to create FileSystem to improve server side security.
    /// </summary>
    public delegate FileSystem FileSystemFactory();
}
