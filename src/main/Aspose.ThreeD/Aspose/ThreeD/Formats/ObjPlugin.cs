namespace Aspose.ThreeD.Formats
{
    internal class ObjPlugin : Plugin
    {
        private readonly FileFormat _format;
        private readonly IImporter _importer;
        private readonly IExporter? _exporter;

        public ObjPlugin()
        {
            _format = FileFormat.ObjFormat;
            _importer = new ObjReader();
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
            return new ObjLoadOptions();
        }

        public override SaveOptions CreateSaveOptions()
        {
            return new ObjSaveOptions();
        }
    }
}
