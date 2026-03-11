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
    }
}
