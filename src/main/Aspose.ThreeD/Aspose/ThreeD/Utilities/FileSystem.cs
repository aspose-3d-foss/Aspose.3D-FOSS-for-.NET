using System;
using System.Collections.Generic;
using System.IO;
using Aspose.ThreeD.Formats;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// File system encapsulation.
    /// Aspose.3D will use this to read/write dependencies.
    /// </summary>
    public abstract class FileSystem : IDisposable
    {
        private bool _disposed = false;

        /// <summary>
        /// Dispose the File system and release its resources.
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                Dispose(true);
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose the File system and release its resources.
        /// </summary>
        /// <param name="disposing">Whether Dispose is being called explicitly</param>
        protected virtual void Dispose(bool disposing)
        {
        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~FileSystem()
        {
            if (!_disposed)
            {
                Dispose(false);
            }
        }

        /// <summary>
        /// Create a stream for reading dependencies.
        /// </summary>
        /// <param name="fileName">The file name to read</param>
        /// <param name="options">The IO configuration</param>
        /// <returns>A stream for reading the file</returns>
        public abstract Stream ReadFile(string fileName, IOConfig options);

        /// <summary>
        /// Create a stream for writing dependencies.
        /// </summary>
        /// <param name="fileName">The file name to write</param>
        /// <param name="options">The IO configuration</param>
        /// <returns>A stream for writing the file</returns>
        public abstract Stream WriteFile(string fileName, IOConfig options);

        /// <summary>
        /// Initialize a new FileSystem that only access local directory.
        /// All file read/write on this FileSystem instance will be mapped to specified directory.
        /// </summary>
        /// <param name="directory">The directory to access</param>
        /// <returns>A local file system</returns>
        public static FileSystem CreateLocalFileSystem(string directory)
        {
            return new LocalFileSystem(directory);
        }

        /// <summary>
        /// Initialize a new FileSystem from a dictionary of memory streams.
        /// </summary>
        /// <param name="files">Dictionary of file names to memory streams</param>
        /// <returns>A memory file system</returns>
        public static FileSystem CreateMemoryFileSystem(Dictionary<string, MemoryStream> files)
        {
            return new MemoryFileSystem(files);
        }

        /// <summary>
        /// Create a dummy file system, read/write operations are dummy operations.
        /// </summary>
        /// <returns>A dummy file system</returns>
        public static FileSystem CreateDummyFileSystem()
        {
            return new DummyFileSystem();
        }

        /// <summary>
        /// Create a file system to provide to the read-only access to specified zip file or zip stream.
        /// File system will be disposed after the open/save operation.
        /// </summary>
        /// <param name="stream">The zip stream</param>
        /// <param name="baseDir">The base directory within the zip</param>
        /// <returns>A zip file system</returns>
        public static FileSystem CreateZipFileSystem(Stream stream, string baseDir)
        {
            return new ZipFileSystem(stream, baseDir);
        }

        /// <summary>
        /// Create a file system to provide to the read-only access to specified zip file or zip stream.
        /// File system will be disposed after the open/save operation.
        /// </summary>
        /// <param name="fileName">The zip file name</param>
        /// <returns>A zip file system</returns>
        public static FileSystem CreateZipFileSystem(string fileName)
        {
            return new ZipFileSystem(fileName);
        }

        private class LocalFileSystem : FileSystem
        {
            private readonly string _directory;

            public LocalFileSystem(string directory)
            {
                _directory = directory;
            }

            public override Stream ReadFile(string fileName, IOConfig options)
            {
                var fullPath = Path.Combine(_directory, fileName);
                return File.OpenRead(fullPath);
            }

            public override Stream WriteFile(string fileName, IOConfig options)
            {
                var fullPath = Path.Combine(_directory, fileName);
                var dir = Path.GetDirectoryName(fullPath);
                if (dir != null && !Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                return File.Create(fullPath);
            }
        }

        private class MemoryFileSystem : FileSystem
        {
            private readonly Dictionary<string, MemoryStream> _files;

            public MemoryFileSystem(Dictionary<string, MemoryStream> files)
            {
                _files = files ?? new Dictionary<string, MemoryStream>();
            }

            public override Stream ReadFile(string fileName, IOConfig options)
            {
                if (_files.TryGetValue(fileName, out var stream))
                {
                    stream.Position = 0;
                    return stream;
                }
                return new MemoryStream();
            }

            public override Stream WriteFile(string fileName, IOConfig options)
            {
                var stream = new MemoryStream();
                _files[fileName] = stream;
                return stream;
            }
        }

        private class DummyFileSystem : FileSystem
        {
            public override Stream ReadFile(string fileName, IOConfig options)
            {
                return new MemoryStream();
            }

            public override Stream WriteFile(string fileName, IOConfig options)
            {
                return new MemoryStream();
            }
        }

        private class ZipFileSystem : FileSystem
        {
            private readonly string _fileName;
            private readonly Stream _stream;
            private bool _disposed = false;

            public ZipFileSystem(string fileName)
            {
                _fileName = fileName;
            }

            public ZipFileSystem(Stream stream, string baseDir)
            {
                _stream = stream;
            }

            protected override void Dispose(bool disposing)
            {
                if (!_disposed && _stream != null)
                {
                    _stream.Dispose();
                }
                base.Dispose(disposing);
            }

            public override Stream ReadFile(string fileName, IOConfig options)
            {
                throw new NotImplementedException("Zip file system read not implemented in FOSS version");
            }

            public override Stream WriteFile(string fileName, IOConfig options)
            {
                throw new NotImplementedException("Zip file system write not implemented in FOSS version");
            }
        }
    }
}
