using System;
using System.Collections.Generic;
using System.IO;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// singleton service registry for format plugins
    /// </summary>
    internal sealed class IOService
    {
        private static readonly IOService _instance = new IOService();
        private readonly List<Plugin> _plugins;
        private readonly Dictionary<FileFormat, Plugin> _formatToPlugin;
        private readonly Dictionary<string, Plugin> _extensionToPlugin;

        private IOService()
        {
            _plugins = new List<Plugin>();
            _formatToPlugin = new Dictionary<FileFormat, Plugin>();
            _extensionToPlugin = new Dictionary<string, Plugin>(StringComparer.OrdinalIgnoreCase);

            RegisterPlugin(new GltfPlugin());
            RegisterPlugin(new StlPlugin());
            RegisterPlugin(new FbxPlugin());
            RegisterPlugin(new ColladaPlugin());
            RegisterPlugin(new ObjPlugin());
            RegisterPlugin(new TmfPlugin());
            RegisterPlugin(new PlyPlugin());
        }

        /// <summary>
        /// Gets the singleton instance of the IOService
        /// </summary>
        public static IOService Instance => _instance;

        /// <summary>
        /// Registers an importer with the service
        /// </summary>
        /// <param name="importer">The importer to register</param>
        public void RegisterImporter(IImporter importer)
        {
            var format = GetFormatFromImporter(importer);
            var plugin = new SimplePlugin(importer, null, null, format);
            _plugins.Add(plugin);
            _formatToPlugin[format] = plugin;
            foreach (var ext in format.Extensions)
            {
                _extensionToPlugin[ext] = plugin;
            }
        }

        /// <summary>
        /// Registers an exporter with the service
        /// </summary>
        /// <param name="exporter">The exporter to register</param>
        public void RegisterExporter(IExporter exporter)
        {
            var format = GetFormatFromExporter(exporter);
            var plugin = new SimplePlugin(null, exporter, null, format);
            _plugins.Add(plugin);
            _formatToPlugin[format] = plugin;
            foreach (var ext in format.Extensions)
            {
                _extensionToPlugin[ext] = plugin;
            }
        }

        /// <summary>
        /// Registers a format detector with the service
        /// </summary>
        /// <param name="detector">The detector to register</param>
        /// <param name="format">The format this detector handles</param>
        public void RegisterDetector(FormatDetector detector, FileFormat format)
        {
            var plugin = new SimplePlugin(null, null, detector, format);
            _plugins.Add(plugin);
            _formatToPlugin[format] = plugin;
            foreach (var ext in format.Extensions)
            {
                _extensionToPlugin[ext] = plugin;
            }
        }

        /// <summary>
        /// Registers a plugin with the service
        /// </summary>
        /// <param name="plugin">The plugin to register</param>
        public void RegisterPlugin(Plugin plugin)
        {
            _plugins.Add(plugin);
            var format = plugin.GetFileFormat();
            _formatToPlugin[format] = plugin;
            foreach (var ext in format.Extensions)
            {
                _extensionToPlugin[ext] = plugin;
            }
        }

        private static FileFormat GetFormatFromImporter(IImporter importer)
        {
            if (importer is Importer baseImporter)
            {
                return baseImporter.Format;
            }
            throw new InvalidOperationException($"Importer must extend the {typeof(Importer).FullName} base class");
        }

        private static FileFormat GetFormatFromExporter(IExporter exporter)
        {
            if (exporter is Exporter baseExporter)
            {
                return baseExporter.Format;
            }
            throw new InvalidOperationException($"Exporter must extend the {typeof(Exporter).FullName} base class");
        }

        /// <summary>
        /// Detects the file format from the given stream and optional file name
        /// </summary>
        /// <param name="stream">The stream to detect from</param>
        /// <param name="fileName">Optional file name for extension-based detection</param>
        /// <returns>The detected file format, or null if unable to detect</returns>
        public FileFormat? DetectFormat(Stream stream, string? fileName)
        {
            foreach (var plugin in _plugins)
            {
                var detector = plugin.GetFormatDetector();
                if (detector != null && detector.Detect(stream, fileName))
                {
                    return plugin.GetFileFormat();
                }
            }

            if (!string.IsNullOrEmpty(fileName))
            {
                var ext = Path.GetExtension(fileName);
                if (_extensionToPlugin.TryGetValue(ext, out var plugin))
                {
                    return plugin.GetFileFormat();
                }
            }

            return null;
        }

        /// <summary>
        /// Creates an importer for the specified file format
        /// </summary>
        /// <param name="format">The file format</param>
        /// <returns>The importer, or null if not available</returns>
        public IImporter? CreateImporter(FileFormat format)
        {
            if (_formatToPlugin.TryGetValue(format, out var plugin))
            {
                return plugin.GetImporter();
            }
            return null;
        }

        /// <summary>
        /// Creates an exporter for the specified file format
        /// </summary>
        /// <param name="format">The file format</param>
        /// <returns>The exporter, or null if not available</returns>
        public IExporter? CreateExporter(FileFormat format)
        {
            if (_formatToPlugin.TryGetValue(format, out var plugin))
            {
                return plugin.GetExporter();
            }
            return null;
        }

        /// <summary>
        /// Gets the plugin for the specified file format
        /// </summary>
        /// <param name="format">The file format</param>
        /// <returns>The plugin, or null if not found</returns>
        public Plugin? GetPluginForFormat(FileFormat format)
        {
            return _formatToPlugin.TryGetValue(format, out var plugin) ? plugin : null;
        }

        /// <summary>
        /// Gets the plugin for the specified file extension
        /// </summary>
        /// <param name="extension">The file extension (with or without dot)</param>
        /// <returns>The plugin, or null if not found</returns>
        public Plugin? GetPluginForExtension(string extension)
        {
            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }
            return _extensionToPlugin.TryGetValue(extension, out var plugin) ? plugin : null;
        }

        private class SimplePlugin : Plugin
        {
            private readonly IImporter? _importer;
            private readonly IExporter? _exporter;
            private readonly FormatDetector? _detector;
            private readonly FileFormat _format;

            public SimplePlugin(IImporter? importer, IExporter? exporter, FormatDetector? detector, FileFormat format)
            {
                _importer = importer;
                _exporter = exporter;
                _detector = detector;
                _format = format;
            }

            public override FileFormat GetFileFormat()
            {
                return _format;
            }

            public override IImporter? GetImporter()
            {
                return _importer;
            }

            public override IExporter? GetExporter()
            {
                return _exporter;
            }

            public override FormatDetector? GetFormatDetector()
            {
                return _detector;
            }

            public override LoadOptions CreateLoadOptions()
            {
                return _format.CreateLoadOptions();
            }

            public override SaveOptions CreateSaveOptions()
            {
                var options = _format.CreateSaveOptions();
                options.FileFormat = _format;
                return options;
            }
        }
    }
}
