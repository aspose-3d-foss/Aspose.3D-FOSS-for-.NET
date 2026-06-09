using System;
using System.IO;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Xunit;

namespace Aspose.ThreeD.Tests
{
    public class FormatDetectionTests
    {
        [Fact]
        public void DetectObjFormatFromStream_ShouldReturnObjFormat()
        {
            var testFile = "../../../../../../testdata/input/cube.obj";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }
using var stream = File.OpenRead(testFile);
             var format = FileFormat.Detect(stream, null);
            Assert.Equal(".obj", format.Extension);
        }

        [Fact]
        public void DetectStlFormatFromStream_ShouldReturnStlFormat()
        {
            var testFile = Path.Combine("../../../../../../testdata/stl", "stl_ascii.stl");

            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var format = FileFormat.Detect(stream, null);

            Assert.Equal(".stl", format.Extension);
        }

        [Fact]
        public void DetectGltfFormatFromStream_ShouldReturnGltfFormat()
        {
            var testFile = "../../../../../../testdata/gltf/simple_cube.gltf";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var format = FileFormat.Detect(stream, "test.gltf");

            Assert.Equal(".gltf", format.Extension);
        }

        [Fact]
        public void OpenStreamWithAutoDetectionObj_ShouldLoadCorrectly()
        {
            var testFile = "../../../../../../testdata/input/cube.obj";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            scene.Open(stream);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);

            var node = scene.RootNode.ChildNodes[0];
            Assert.NotNull(node.Entities);
            Assert.True(node.Entities.Count > 0);

            var mesh = node.Entities[0] as Mesh;
            Assert.NotNull(mesh);
            Assert.Equal(8, mesh.ControlPoints.Count);
            Assert.Equal(3, mesh.PolygonCount);
        }

        [Fact]
        public void OpenStreamWithAutoDetectionStl_ShouldLoadCorrectly()
        {
            var testFile = Path.Combine("../../../../../../testdata/stl", "stl_ascii.stl");

            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            scene.Open(stream);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);

            var node = scene.RootNode.ChildNodes[0];
            Assert.NotNull(node.Entities);
            Assert.True(node.Entities.Count > 0);

            var mesh = node.Entities[0] as Mesh;
            Assert.NotNull(mesh);
            Assert.Equal(3, mesh.ControlPoints.Count);
            Assert.Equal(1, mesh.PolygonCount);
        }

        [Fact]
        public void OpenStreamWithAutoDetectionGltf_ShouldLoadCorrectly()
        {
            var testFile = "../../../../../../testdata/gltf/simple_cube.gltf";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            scene.Open(stream, "simple_cube.gltf");

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
        }

        [Fact]
        public void OpenStreamWithFilename_ShouldDetectFormatFromFilename()
        {
            var testFile = "../../../../../../testdata/input/cube.obj";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            scene.Open(stream, "cube.obj");

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);

            var node = scene.RootNode.ChildNodes[0];
            Assert.NotNull(node.Entities);
            Assert.True(node.Entities.Count > 0);

            var mesh = node.Entities[0] as Mesh;
            Assert.NotNull(mesh);
            Assert.Equal(8, mesh.ControlPoints.Count);
            Assert.Equal(3, mesh.PolygonCount);
        }

        [Fact]
        public void DetectObjFormatFromStreamWithFilename_ShouldReturnObjFormat()
        {
            var testFile = "../../../../../../testdata/input/cube.obj";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }using var stream = File.OpenRead(testFile);
             var format = FileFormat.Detect(stream, "test.obj");
             Assert.Equal(".obj", format.Extension);
         }

         [Fact]
         public void DetectStlFormatFromStreamWithFilename_ShouldReturnStlFormat()
         {
             var testFile = Path.Combine("../../../../../../testdata/stl", "stl_ascii.stl");

             if (!File.Exists(testFile))
             {
                 throw new FileNotFoundException($"Test file not found: {testFile}");
             }
using var stream = File.OpenRead(testFile);
             var format = FileFormat.Detect(stream, "test.");            Assert.Equal(".stl", format.Extension);
        }

        [Fact]
        public void DetectGltfFormatFromStreamWithFilename_ShouldReturnGltfFormat()
        {
            var testFile = "../../../../../../testdata/gltf/simple_cube.gltf";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var format = FileFormat.Detect(stream, "test.gltf");

            Assert.Equal(".gltf", format.Extension);
        }
    }
}
