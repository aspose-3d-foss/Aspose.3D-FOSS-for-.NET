using System;
using System.IO;
using Aspose.ThreeD;

namespace DebugTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var testFile = "/home/lexchou/workspace/aspose/foss.3d.net/testdata/gltf/simple_cube.gltf";
            
            if (!File.Exists(testFile))
            {
                Console.WriteLine($"File not found: {testFile}");
                return;
            }
            
            using var stream = File.OpenRead(testFile);
            Console.WriteLine($"Stream length: {stream.Length}");
            Console.WriteLine($"Stream CanRead: {stream.CanRead}");
            Console.WriteLine($"Stream CanSeek: {stream.CanSeek}");
            
            stream.Seek(0, SeekOrigin.Begin);
            var header = new byte[20];
            stream.Read(header, 0, 20);
            Console.WriteLine($"First 20 bytes: {System.Text.Encoding.ASCII.GetString(header)}");
            
            stream.Seek(0, SeekOrigin.Begin);
            var detectedFormat = FileFormat.Detect(stream, null);
            Console.WriteLine($"Detected format: {detectedFormat.Extension}");
            Console.WriteLine($"Expected: .gltf");
        }
    }
}
