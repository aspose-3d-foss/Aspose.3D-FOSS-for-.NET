using System;
using System.IO;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Xunit;

namespace Aspose.ThreeD.Tests
{
    public class FileIOTests
    {
        [Fact]
        public void SaveSceneToObj_ShouldCreateValidFile()
        {
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            var node = scene.RootNode.CreateChildNode("BoxNode", box);

            var outputFile = Path.Combine(Path.GetTempPath(), "test_output.obj");
            try
            {
                scene.Save(outputFile);

                Assert.True(File.Exists(outputFile));
                var content = File.ReadAllText(outputFile);
                Assert.Contains("v", content);
                Assert.Contains("f", content);
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
        public void LoadSceneFromObj_ShouldLoadCorrectly()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var testFile = Path.Combine(baseDir, "../../../../../testdata/cube.obj");
            testFile = Path.GetFullPath(testFile);

            if (!File.Exists(testFile))
            {
                testFile = Path.Combine(baseDir, "../../../../../../testdata/cube.obj");
                testFile = Path.GetFullPath(testFile);
            }

            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found. BaseDir: {baseDir}, Tried: {testFile}");
            }

            var scene = new Scene();
            scene.Open(testFile);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
        }

        [Fact]
        public void Sphere_ToMesh_ShouldCreateValidMesh()
        {
            var sphere = new Sphere(1);
            var mesh = sphere.ToMesh();

            Assert.NotNull(mesh);
            Assert.True(mesh.ControlPoints.Count > 0);
            Assert.True(mesh.PolygonCount > 0);
        }

        [Fact]
        public void Cylinder_ToMesh_ShouldCreateValidMesh()
        {
            var cylinder = new Cylinder(1, 1, 2);
            var mesh = cylinder.ToMesh();

            Assert.NotNull(mesh);
            Assert.True(mesh.ControlPoints.Count > 0);
            Assert.True(mesh.PolygonCount > 0);
        }

        [Fact]
        public void SaveSceneToStl_ShouldCreateValidFile()
        {
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            var node = scene.RootNode.CreateChildNode("BoxNode", box);

            var outputFile = Path.Combine(Path.GetTempPath(), "test_output.stl");
            try
            {
                scene.Save(outputFile);

                Assert.True(File.Exists(outputFile));
                var content = File.ReadAllBytes(outputFile);
                Assert.True(content.Length > 84);
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
        public void LoadSceneFromStlAscii_ShouldLoadCorrectly()
        {
            var testFile = Path.Combine("/home/lexchou/workspace/aspose/foss.3d.net/testdata/stl", "stl_ascii.stl");

            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            var scene = new Scene();
            scene.Open(testFile);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);
        }

        [Fact]
        public void LoadSceneFromStlBinary_ShouldLoadCorrectly()
        {
            var testFile = Path.Combine("/home/lexchou/workspace/aspose/foss.3d.net/testdata/stl", "stl_binary.stl");

            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            var scene = new Scene();
            scene.Open(testFile);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);
        }

        [Fact]
        public void LoadSceneFromUnsupportedFormat_ShouldThrowNotSupportedException()
        {
            var testFile = "/home/lexchou/workspace/aspose/foss.3d.net/testdata/fbx7400binary/box.fbx";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            var scene = new Scene();
            Assert.Throws<NotSupportedException>(() => scene.Open(testFile));
        }

        [Fact]
        public void SaveSceneToStreamObj_ShouldCreateValidOutput()
        {
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            scene.RootNode.CreateChildNode("BoxNode", box);

            using var stream = new MemoryStream();
            var options = new Formats.ObjSaveOptions();
            scene.Save(stream, options);

            stream.Seek(0, SeekOrigin.Begin);
            var content = new StreamReader(stream).ReadToEnd();
            
            Assert.Contains("v", content);
            Assert.Contains("f", content);
        }

        [Fact]
        public void SaveSceneToStreamStl_ShouldCreateValidOutput()
        {
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            scene.RootNode.CreateChildNode("BoxNode", box);

            using var stream = new MemoryStream();
            var options = new Formats.StlSaveOptions();
            scene.Save(stream, options);

            stream.Seek(0, SeekOrigin.Begin);
            var content = stream.ToArray();
            
            Assert.True(content.Length > 84);
        }

        [Fact]
        public void LoadSceneFromStreamObj_ShouldLoadCorrectly()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var testFile = Path.Combine(baseDir, "../../../../../testdata/cube.obj");
            testFile = Path.GetFullPath(testFile);

            if (!File.Exists(testFile))
            {
                testFile = Path.Combine(baseDir, "../../../../../../testdata/cube.obj");
                testFile = Path.GetFullPath(testFile);
            }

            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found. BaseDir: {baseDir}, Tried: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            var options = new Formats.ObjLoadOptions();
            scene.Open(stream, options);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
        }

        [Fact]
        public void LoadSceneFromStreamStl_ShouldLoadCorrectly()
        {
            var testFile = Path.Combine("/home/lexchou/workspace/aspose/foss.3d.net/testdata/stl", "stl_ascii.stl");

            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            var options = new Formats.StlLoadOptions();
            scene.Open(stream, options);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);
        }

        [Fact]
        public void SaveSceneToStreamGltf_ShouldCreateValidOutput()
        {
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            scene.RootNode.CreateChildNode("BoxNode", box);

            using var stream = new MemoryStream();
            var options = new Formats.GltfSaveOptions();
            scene.Save(stream, options);

            stream.Seek(0, SeekOrigin.Begin);
            var content = stream.ToArray();
            
            Assert.True(content.Length > 0);
        }

        [Fact]
        public void LoadSceneFromStreamGltf_ShouldLoadCorrectly()
        {
            var testFile = "/home/lexchou/workspace/aspose/foss.3d.net/testdata/gltf/simple_cube.gltf";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            var options = new Formats.GltfLoadOptions();
            scene.Open(stream, options);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);
        }

        [Fact]
        public void LoadSceneFromStreamWithAutoDetection_ShouldWork()
        {
            var testFile = "/home/lexchou/workspace/aspose/foss.3d.net/testdata/cube.obj";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            
            // Use the overload that only takes stream and auto-detects from content
            scene.Open(stream);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);
        }

        [Fact]
        public void LoadSceneFromStreamWithAutoDetectionGltf_ShouldWork()
        {
            var testFile = "/home/lexchou/workspace/aspose/foss.3d.net/testdata/gltf/simple_cube.gltf";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            
            // Auto-detect from stream content
            scene.Open(stream);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);
        }
    }
}
