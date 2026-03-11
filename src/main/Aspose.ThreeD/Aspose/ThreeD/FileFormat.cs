using System;
using System.Collections.Generic;
using System.IO;

namespace Aspose.ThreeD
{
    /// <summary>
    /// File format definition
    /// </summary>
    public class FileFormat
    {
        private static readonly List<FileFormat> _formats = new List<FileFormat>();
        private readonly string _extension;
        private readonly string[] _extensions;
        private readonly Version _version;
        private readonly bool _canExport;
        private readonly bool _canImport;
        private readonly FileContentType _contentType;
        private readonly FileFormatType _fileFormatType;

        static FileFormat()
        {
            InitializeFormats();
        }

        /// <summary>
        /// Initializes a new instance of the FileFormat class
        /// </summary>
        protected FileFormat(string extension, string[] extensions, Version version, bool canExport, bool canImport, FileContentType contentType, FileFormatType fileFormatType)
        {
            _extension = extension;
            _extensions = extensions;
            _version = version;
            _canExport = canExport;
            _canImport = canImport;
            _contentType = contentType;
            _fileFormatType = fileFormatType;
        }

        /// <summary>
        /// Access to all supported formats
        /// </summary>
        public static IList<FileFormat> Formats => _formats;

        /// <summary>
        /// Gets file format version
        /// </summary>
        public Version Version => _version;

        /// <summary>
        /// Gets whether Aspose.3D supports export scene to current file format.
        /// </summary>
        public bool CanExport => _canExport;

        /// <summary>
        /// Gets whether Aspose.3D supports import scene from current file format.
        /// </summary>
        public bool CanImport => _canImport;

        /// <summary>
        /// Gets the extension name of this type.
        /// </summary>
        public string Extension => _extension;

        /// <summary>
        /// Gets the extension names of this type.
        /// </summary>
        public string[] Extensions => _extensions;

        /// <summary>
        /// Gets file format content type
        /// </summary>
        public FileContentType ContentType => _contentType;

        /// <summary>
        /// Gets file format type
        /// </summary>
        public FileFormatType FileFormatType => _fileFormatType;

        /// <summary>
        /// Gets the preferred file format from the file extension name
        /// The extension name should starts with a dot('.').
        /// </summary>
        public static FileFormat GetFormatByExtension(string extensionName)
        {
            foreach (var format in _formats)
            {
                foreach (var ext in format._extensions)
                {
                    if (ext.Equals(extensionName, StringComparison.OrdinalIgnoreCase))
                        return format;
                }
            }
            throw new ArgumentException($"Unsupported file format: {extensionName}");
        }

        /// <summary>
        /// Detect the file format from data stream, file name is optional for guessing types that has no magic header.
        /// </summary>
        public static FileFormat Detect(Stream stream, string? fileName)
        {
            if (fileName != null)
            {
                var ext = Path.GetExtension(fileName);
                return GetFormatByExtension(ext);
            }

            throw new ArgumentException("Cannot detect file format without file name");
        }

        /// <summary>
        /// Detect the file format from file name, file must be readable so Aspose.3D can detect the file format through file header.
        /// </summary>
        public static FileFormat Detect(string fileName)
        {
            var ext = Path.GetExtension(fileName);
            return GetFormatByExtension(ext);
        }

        /// <summary>
        /// Create a default load options for this file format
        /// </summary>
        public virtual Formats.LoadOptions CreateLoadOptions()
        {
            throw new NotImplementedException($"Load options not implemented for {Extension}");
        }

        /// <summary>
        /// Create a default save options for this file format
        /// </summary>
        public virtual Formats.SaveOptions CreateSaveOptions()
        {
            throw new NotImplementedException($"Save options not implemented for {Extension}");
        }

        /// <summary>
        /// Formats to string
        /// </summary>
        public override string ToString()
        {
            return _extension;
        }

        private static void InitializeFormats()
        {
            var objFormat = new ObjFormat();
            var stlFormat = new StlFormat();
            var gltfFormat = new GltfFormat();
            var fbxFormat = new FbxFormat();

            _formats.Add(objFormat);
            _formats.Add(stlFormat);
            _formats.Add(gltfFormat);
            _formats.Add(fbxFormat);
        }
    }

    internal class ObjFormat : FileFormat
    {
        public ObjFormat() : base(".obj", new[] { ".obj" }, new Version(1, 0), true, true, FileContentType.ASCII, new FileFormatType(".obj"))
        {
        }

        public override Formats.LoadOptions CreateLoadOptions()
        {
            return new Formats.ObjLoadOptions();
        }

        public override Formats.SaveOptions CreateSaveOptions()
        {
            return new Formats.ObjSaveOptions();
        }
    }

    internal class StlFormat : FileFormat
    {
        public StlFormat() : base(".stl", new[] { ".stl" }, new Version(1, 0), true, true, FileContentType.Binary, new FileFormatType(".stl"))
        {
        }

        public override Formats.LoadOptions CreateLoadOptions()
        {
            return new Formats.StlLoadOptions();
        }

        public override Formats.SaveOptions CreateSaveOptions()
        {
            return new Formats.StlSaveOptions();
        }
    }

    internal class GltfFormat : FileFormat
    {
        public GltfFormat() : base(".gltf", new[] { ".gltf", ".glb" }, new Version(2, 0), true, true, FileContentType.ASCII, new FileFormatType(".gltf"))
        {
        }

        public override Formats.LoadOptions CreateLoadOptions()
        {
            return new Formats.GltfLoadOptions();
        }

        public override Formats.SaveOptions CreateSaveOptions()
        {
            return new Formats.GltfSaveOptions();
        }
    }

    internal class FbxFormat : FileFormat
    {
        public FbxFormat() : base(".fbx", new[] { ".fbx" }, new Version(7, 4), true, true, FileContentType.Binary, new FileFormatType(".fbx"))
        {
        }

        public override Formats.LoadOptions CreateLoadOptions()
        {
            return new Formats.FbxLoadOptions();
        }

        public override Formats.SaveOptions CreateSaveOptions()
        {
            return new Formats.FbxSaveOptions();
        }
    }
}
