namespace Aspose.ThreeD.Formats
{
    internal class TmfPlugin : Plugin
    {
        private readonly FileFormat _format;
        private readonly IImporter _importer;
        private readonly IExporter _exporter;

        public TmfPlugin()
        {
            _format = FileFormat.TmfFormat;
            _importer = new Microsoft3MFReader();
            _exporter = new TmfWriter();
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
            return new TmfLoadOptions();
        }

        public override SaveOptions CreateSaveOptions()
        {
            return new TmfSaveOptions();
        }
    }
}
