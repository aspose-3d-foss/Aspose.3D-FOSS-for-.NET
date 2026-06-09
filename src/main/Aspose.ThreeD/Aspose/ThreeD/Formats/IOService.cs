using System;
using System.IO;
using System.Linq;

namespace Aspose.ThreeD.Formats;

/// <summary>
/// IO service for importing and exporting files.
/// This is a stub implementation for FOSS version.
/// </summary>
internal class IOService
{
    private static IOService? _instance;

    /// <summary>
    /// Gets the singleton instance of IOService.
    /// </summary>
    public static IOService Instance => _instance ??= new IOService();

    /// <summary>
    /// Detects the format of a file from a stream.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="fileName">The file name.</param>
    /// <returns>The detected file format.</returns>
    public static FileFormat DetectFormat(Stream stream, string? fileName)
    {
        if (stream.CanRead && stream.CanSeek)
        {
            var position = stream.Position;
            try
            {
                foreach (var format in FileFormat.Formats)
                {
                    if (format.CanDetect(stream, fileName))
                    {
                        return format;
                    }
                }
            }
            finally
            {
                stream.Position = position;
            }
        }

        if (fileName != null)
        {
            var ext = Path.GetExtension(fileName);
            return FileFormat.GetFormatByExtension(ext);
        }

        throw new ArgumentException("Cannot detect file format without file name or stream data");
    }

    /// <summary>
    /// Gets the file format by file name extension.
    /// </summary>
    /// <param name="fileName">The file name.</param>
    /// <returns>The file format.</returns>
    public static FileFormat GetFormatByFileName(string fileName)
    {
        var ext = Path.GetExtension(fileName);
        return FileFormat.GetFormatByExtension(ext);
    }

    /// <summary>
    /// Creates an importer for the specified file format.
    /// </summary>
    /// <param name="format">The file format.</param>
    /// <returns>The importer.</returns>
    internal IImporter CreateImporter(FileFormat format)
    {
        return format switch
        {
            FileFormat f when f == FileFormat.ObjFormat => new ObjReader(),
            FileFormat f when f == FileFormat.StlFormat => new StlReader(),
            FileFormat f when f == FileFormat.GltfFormat => new GltfReader(),
            FileFormat f when f == FileFormat.FbxFormat => new FbxReader(),
            FileFormat f when f == FileFormat.Microsoft3MFFormat => new Microsoft3MFReader(),
            FileFormat f when f == FileFormat.ColladaFormat => new ColladaReader(),
            FileFormat f when f == FileFormat.PlyFormat => new PlyReader(),
            _ => throw new NotSupportedException($"Import not supported for {format.Extension}")
        };
    }

    /// <summary>
    /// Creates an exporter for the specified file format.
    /// </summary>
    /// <param name="format">The file format.</param>
    /// <returns>The exporter.</returns>
    internal IExporter CreateExporter(FileFormat format)
    {
        return format switch
        {
            FileFormat f when f == FileFormat.ObjFormat => new ObjWriter(),
            FileFormat f when f == FileFormat.StlFormat => new StlWriter(),
            FileFormat f when f == FileFormat.GltfFormat => new GltfWriter(),
            FileFormat f when f == FileFormat.FbxFormat => new FbxWriter(),
            FileFormat f when f == FileFormat.Microsoft3MFFormat => new Microsoft3MFWriter(),
            FileFormat f when f == FileFormat.ColladaFormat => new ColladaWriter(),
            FileFormat f when f == FileFormat.PlyFormat => new PlyWriter(),
            _ => throw new NotSupportedException($"Export not supported for {format.Extension}")
        };
    }
}
