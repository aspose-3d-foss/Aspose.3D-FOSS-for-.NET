namespace Aspose.ThreeD.Formats
{
    internal class PlyPlugin : Plugin
    {
        private readonly FileFormat _format;
        private readonly IImporter _importer;

        public PlyPlugin()
        {
            _format = FileFormat.PlyFormat;
            _importer = new PlyReader();
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
            return null;
        }

        public override FormatDetector? GetFormatDetector()
        {
            return null;
        }

        public override LoadOptions CreateLoadOptions()
        {
            return new PlyLoadOptions();
        }

        public override SaveOptions CreateSaveOptions()
        {
            return new PlySaveOptions();
        }
    }
}
