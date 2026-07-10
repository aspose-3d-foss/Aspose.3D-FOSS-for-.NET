namespace Aspose.ThreeD.Formats
{
    internal class GltfPlugin : Plugin
    {
        private readonly FileFormat _format;
        private readonly IImporter _importer;
        private readonly IExporter _exporter;

        public GltfPlugin()
        {
            _format = FileFormat.GltfFormat;
            _importer = new GltfReader();
            _exporter = new GltfWriter();
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
            return null;
        }

        public override LoadOptions CreateLoadOptions()
        {
            return new GltfLoadOptions();
        }

        public override SaveOptions CreateSaveOptions()
        {
            return new GltfSaveOptions(FileFormat.GLTF);
        }
    }
}
