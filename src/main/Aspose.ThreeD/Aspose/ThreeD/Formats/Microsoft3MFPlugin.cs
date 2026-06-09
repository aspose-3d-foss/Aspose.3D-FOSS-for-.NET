namespace Aspose.ThreeD.Formats
{
    internal class Microsoft3MFPlugin : Plugin
    {
        private readonly FileFormat _format;
        private readonly IImporter _importer;
        private readonly IExporter _exporter;

        public Microsoft3MFPlugin()
        {
            _format = FileFormat.Microsoft3MFFormat;
            _importer = new Microsoft3MFReader();
            _exporter = new Microsoft3MFWriter();
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
            return new Microsoft3MFLoadOptions();
        }

        public override SaveOptions CreateSaveOptions()
        {
            return new Microsoft3MFSaveOptions();
        }
    }
}
