using System;
using Aspose.ThreeD;
using Aspose.ThreeD.Formats;

namespace Aspose.ThreeD.Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: aspose-3d-converter <input_file> <output_file>");
                Console.WriteLine("Available formats: OBJ, STL, FBX, GLTF, PLY, Collada, 3DS");
                return;
            }

            string inputFile = args[0];
            string outputFile = args[1];

            try
            {
                Console.WriteLine($"Loading {inputFile}...");
                var scene = new Scene();
                scene.Open(inputFile);

                Console.WriteLine($"Saving as {outputFile}...");
                var format = FileFormat.Detect(outputFile);
                if (format == null)
                {
                    var ext = System.IO.Path.GetExtension(outputFile);
                    format = FileFormat.GetFormatByExtension(ext);
                }

                scene.Save(outputFile, format.CreateSaveOptions());
                
                Console.WriteLine("Conversion successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Environment.Exit(1);
            }
        }
    }
}
