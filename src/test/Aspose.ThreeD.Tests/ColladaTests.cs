using System;
using System.IO;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Fmt = Aspose.ThreeD.Formats;
using Xunit;

namespace Aspose.ThreeD.Tests
{
    public class ColladaTests
    {
        [Fact]
        public void SaveSceneToCollada_ShouldCreateValidFile()
        {
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            var node = scene.RootNode.CreateChildNode("BoxNode", box);
            
            var outputFile = Path.Combine(Path.GetTempPath(), "test_output.dae");
            try
            {
                scene.Save(outputFile);

                Assert.True(File.Exists(outputFile));
                var content = File.ReadAllText(outputFile);
                Assert.Contains("COLLADA", content);
                Assert.Contains("<geometry", content);
                Assert.Contains("<node", content);
            }
            finally
            {
                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }
            }
        }

        [Fact]
        public void SaveSceneToColladaStream_ShouldCreateValidOutput()
        {
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            scene.RootNode.CreateChildNode("BoxNode", box);

            using var stream = new MemoryStream();
            var options = new Fmt.ColladaSaveOptions();
            scene.Save(stream, options);

            stream.Seek(0, SeekOrigin.Begin);
            var content = new StreamReader(stream).ReadToEnd();
            
            Assert.Contains("COLLADA", content);
            Assert.Contains("<geometry", content);
        }

        [Fact]
        public void LoadSceneFromCollada_ShouldLoadCorrectly()
        {
            var testFile = "../../../../../../../TestData/collada/sphere.dae";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            var scene = new Scene();
            scene.Open(testFile);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);

            var node = scene.RootNode.ChildNodes[0];
            Assert.NotNull(node.Entities);
            Assert.True(node.Entities.Count > 0);

            var mesh = node.Entities[0] as Mesh;
            Assert.NotNull(mesh);
            Assert.True(mesh.ControlPoints.Count > 0);
            Assert.True(mesh.PolygonCount > 0);
        }

        [Fact]
        public void ColladaFormat_ShouldBeRegistered()
        {var format = FileFormat.GetFormatByExtension("dae");

            Assert.NotNull(format);
            Assert.Equal(".dae", format.Extension);            Assert.True(format.CanImport);
            Assert.True(format.CanExport);
        }

        [Fact]
        public void ColladaSaveOptions_HasRequiredProperties()
        {
            var options = new Fmt.ColladaSaveOptions();
            
            Assert.NotNull(options);
            Assert.False(options.Indented);
            Assert.Equal(Fmt.ColladaTransformStyle.Components, options.TransformStyle);
        }
    }
}
