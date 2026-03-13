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
        private readonly Formats.IImporter? _importer;
        private readonly Formats.IExporter? _exporter;

        internal static FileFormat ObjFormat { get;	private set; } = null!;
        internal static FileFormat StlFormat { get;	private set; } = null!;
        internal static FileFormat GltfFormat { get;	private set; } = null!;
        internal static FileFormat FbxFormat { get;	private set; } = null!;
        internal static FileFormat TmfFormat { get;	private set; } = null!;
        internal static FileFormat ColladaFormat { get;	private set; } = null!;

        static FileFormat()
        {
            InitializeFormats();
        }

        /// <summary>
        /// Initializes a new instance of the FileFormat class
        /// </summary>
        protected FileFormat(string extension, string[] extensions, Version version, bool canExport, bool canImport, FileContentType contentType, FileFormatType fileFormatType, Formats.IImporter? importer = null, Formats.IExporter? exporter = null)
        {
            _extension = extension;
            _extensions = extensions;
            _version = version;
            _canExport = canExport;
            _canImport = canImport;
            _contentType = contentType;
            _fileFormatType = fileFormatType;
            _importer = importer;
            _exporter = exporter;
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
        /// Checks if this format can detect the file from the given stream and optional filename
        /// </summary>
        /// <param name="stream">The stream to check</param>
        /// <param name="fileName">Optional filename for extension-based detection</param>
        /// <returns>True if this format can handle the file</returns>
        public virtual bool CanDetect(Stream stream, string? fileName)
        {
            return false;
        }

        /// <summary>
        /// Gets importer for this file format
        /// </summary>
        public Formats.IImporter? Importer => _importer;

        /// <summary>
        /// Gets exporter for this file format
        /// </summary>
        public Formats.IExporter? Exporter => _exporter;

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
        /// Detects file format from file name, file must be readable so Aspose.3D can detect file format through file header.
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
            ObjFormat = new ObjFormat();
            StlFormat = new StlFormat();
            GltfFormat = new GltfFormat();
            FbxFormat = new FbxFormat();
            TmfFormat = new TmfFormat();
            ColladaFormat = new ColladaFormat();

            _formats.Add(ObjFormat);
            _formats.Add(StlFormat);
            _formats.Add(GltfFormat);
            _formats.Add(FbxFormat);
            _formats.Add(TmfFormat);
            _formats.Add(ColladaFormat);
        }
    }

    internal class ObjFormat : FileFormat
    {
        public ObjFormat() : base(".obj", new[] { ".obj" }, new Version(1, 0), true, true, FileContentType.ASCII, new FileFormatType(".obj"), new Formats.ObjReader(), new Formats.ObjWriter())
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

        public override bool CanDetect(Stream stream, string? fileName)
        {
            if (fileName != null)
            {
                var ext = Path.GetExtension(fileName).ToLower();
                if (ext == ".obj")
                    return true;
            }

            try
            {
                stream.Seek(0, SeekOrigin.Begin);
                
                var buffer = new byte[Math.Min(500, (int)stream.Length)];
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                
                if (bytesRead > 0)
                {
                    var header = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead).ToLower();
                    if (header.Contains("# obj") || header.Contains("v "))
                        return true;
                }
            }
            catch
            {
            }

            return false;
        }
    }

    internal class StlFormat : FileFormat
    {
        public StlFormat() : base(".stl", new[] { ".stl" }, new Version(1, 0), true, true, FileContentType.Binary, new FileFormatType(".stl"), new Formats.StlReader(), new Formats.StlWriter())
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

        public override bool CanDetect(Stream stream, string? fileName)
        {
            if (fileName != null)
            {
                var ext = Path.GetExtension(fileName).ToLower();
                if (ext == ".stl")
                    return true;
            }

            try
            {
                stream.Seek(0, SeekOrigin.Begin);
                
                var headerBuffer = new byte[5];
                var bytesRead = stream.Read(headerBuffer, 0, 5);
                
                var header = System.Text.Encoding.ASCII.GetString(headerBuffer, 0, bytesRead);
                
                if (bytesRead >= 5 && header.ToLower().StartsWith("solid"))
                    return true;

                stream.Seek(0, SeekOrigin.Begin);
                var firstByteBuffer = new byte[1];
                stream.Read(firstByteBuffer, 0, 1);
                var firstByte = firstByteBuffer[0];
                
                if (firstByte == 's' || firstByte == '0' || firstByte == '1' || firstByte == '2' || firstByte == '3' || firstByte == '4' || firstByte == '5' || firstByte == '6' || firstByte == '7' || firstByte == '8' || firstByte == '9')
                {
                    stream.Seek(80, SeekOrigin.Begin);
                    var countBuffer = new byte[4];
                    var countBytesRead = stream.Read(countBuffer, 0, 4);
                    
                    if (countBytesRead == 4)
                    {
                        var count = BitConverter.ToInt32(countBuffer, 0);
                        if (count > 0 && count < 1000000)
                            return true;
                    }
                }
            }
            catch
            {
            }

            return false;
        }
    }

    internal class GltfFormat : FileFormat
    {
        public GltfFormat() : base(".gltf", new[] { ".gltf", ".glb" }, new Version(2, 0), true, true, FileContentType.ASCII, new FileFormatType(".gltf"), new Formats.GltfReader(), new Formats.GltfWriter())
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

        public override bool CanDetect(Stream stream, string? fileName)
        {
            if (fileName != null)
            {
                var ext = Path.GetExtension(fileName).ToLower();
                if (ext == ".gltf" || ext == ".glb")
                    return true;
            }

            if (!stream.CanRead || !stream.CanSeek)
                return false;

            try
            {
                stream.Seek(0, SeekOrigin.Begin);
                
                var contentBuffer = new byte[Math.Min(1024, (int)stream.Length)];
                var bytesRead = stream.Read(contentBuffer, 0, contentBuffer.Length);
                
                var content = System.Text.Encoding.UTF8.GetString(contentBuffer, 0, bytesRead);
                
                var header = content.Length >= 4 ? content.Substring(0, 4) : content;
                if (header == "glTF")
                    return true;
                
                if (content.StartsWith("{") && (content.Contains("\"asset\"") || content.Contains("\"scene\"") || content.Contains("\"nodes\"")))
                {
                    return true;
                }
            }
            catch
            {
            }

            return false;
        }
    }

    internal class FbxFormat : FileFormat
    {
        public FbxFormat() : base(".fbx", new[] { ".fbx" }, new Version(7, 4), true, true, FileContentType.Binary, new FileFormatType(".fbx"), new Formats.FbxReader(), new Formats.FbxWriter())
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

        public override bool CanDetect(Stream stream, string? fileName)
        {
            if (fileName != null)
            {
                var ext = Path.GetExtension(fileName).ToLower();
                if (ext == ".fbx")
                    return true;
            }

            if (!stream.CanRead || !stream.CanSeek)
                return false;

            try
            {
                stream.Seek(0, SeekOrigin.Begin);
                
                var headerBuffer = new byte[18];
                var bytesRead = stream.Read(headerBuffer, 0, 18);
                
                if (bytesRead >= 18)
                {
                    var header = System.Text.Encoding.ASCII.GetString(headerBuffer, 0, bytesRead);
                    if (header.Contains("Kaydara FBX Binary"))
                        return true;
                }
            }
            catch
            {
            }

            return false;
        }
    }

    internal class TmfFormat : FileFormat
    {
        public TmfFormat() : base(".3mf", new[] { ".3mf" }, new Version(1, 0), true, true, FileContentType.Binary, new FileFormatType(".3mf"), new Formats.Microsoft3MFReader(), new Formats.TmfWriter())
        {
        }

        public override Formats.LoadOptions CreateLoadOptions()
        {
            return new Formats.TmfLoadOptions();
        }

        public override Formats.SaveOptions CreateSaveOptions()
        {
            return new Formats.TmfSaveOptions();
        }

        public override bool CanDetect(Stream stream, string? fileName)
        {
            if (fileName != null)
            {
                var ext = Path.GetExtension(fileName).ToLower();
                if (ext == ".3mf")
                    return true;
            }

            if (!stream.CanRead || !stream.CanSeek)
                return false;

            try
            {
                stream.Seek(0, SeekOrigin.Begin);
                var buffer = new byte[4];
                var bytesRead = stream.Read(buffer, 0, 4);
                if (bytesRead >= 4)
                {
                    var signature = BitConverter.ToUInt32(buffer, 0);
                    if (signature == 0x30464D33)
                        return true;
                }
            }
            catch
            {
            }

            return false;
        }
    }

    internal class ColladaFormat : FileFormat
    {
        public ColladaFormat() : base(".dae", new[] { ".dae" }, new Version(1, 4), true, true, FileContentType.ASCII, new FileFormatType(".dae"), new Formats.ColladaReader(), new Formats.ColladaWriter())
        {
        }

        public override Formats.LoadOptions CreateLoadOptions()
        {
            return new Formats.ColladaLoadOptions();
        }

        public override Formats.SaveOptions CreateSaveOptions()
        {
            return new Formats.ColladaSaveOptions();
        }

        public override bool CanDetect(Stream stream, string? fileName)
        {
            if (fileName != null)
            {
                var ext = Path.GetExtension(fileName).ToLower();
                if (ext == ".dae")
                    return true;
            }

            try
            {
                stream.Seek(0, SeekOrigin.Begin);
                
                var buffer = new byte[Math.Min(100, (int)stream.Length)];
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                
                if (bytesRead > 0)
                {
                    var header = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead).ToLower();
                    if (header.Contains("<collada") || header.Contains("< COLLADA"))
                        return true;
                }
            }
            catch
            {
            }

            return false;
        }
    }

}
