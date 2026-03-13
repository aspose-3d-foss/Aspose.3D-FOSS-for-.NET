namespace Aspose.ThreeD.Formats
{
    internal class ColladaPlugin : Plugin
    {
        private readonly FileFormat _format;
        private readonly IImporter _importer;
        private readonly IExporter? _exporter;

        public ColladaPlugin()
        {
            _format = FileFormat.ColladaFormat;
            _importer = new ColladaReader();
            _exporter = null;
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
            return new ColladaLoadOptions();
        }

        public override SaveOptions CreateSaveOptions()
        {
            return new ColladaSaveOptions();
        }
    }
}
