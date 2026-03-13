namespace Aspose.ThreeD.Formats
{
    internal class StlPlugin : Plugin
    {
        private readonly FileFormat _format;
        private readonly IImporter _importer;
        private readonly IExporter _exporter;

        public StlPlugin()
        {
            _format = FileFormat.StlFormat;
            _importer = new StlReader();
            _exporter = new StlWriter();
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
            return new StlLoadOptions();
        }

        public override SaveOptions CreateSaveOptions()
        {
            return new StlSaveOptions();
        }
    }
}
