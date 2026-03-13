namespace Aspose.ThreeD.Formats
{
    internal class FbxPlugin : Plugin
    {
        private readonly FileFormat _format;
        private readonly IImporter _importer;
        private readonly IExporter? _exporter;

        public FbxPlugin()
        {
            _format = FileFormat.FbxFormat;
            _importer = new FbxReader();
            _exporter = new FbxWriter();
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
            return new FbxLoadOptions();
        }

        public override SaveOptions CreateSaveOptions()
        {
            return new FbxSaveOptions();
        }
    }
}
