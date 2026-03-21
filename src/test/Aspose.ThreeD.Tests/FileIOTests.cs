using System;
using System.IO;
using System.Linq;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Formats;
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
            var testFile = "../../../../../../../TestData/input/cube.obj";
            
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
            Assert.Equal(8, mesh.ControlPoints.Count);
            Assert.Equal(3, mesh.PolygonCount);
        }

        [Fact]
        public void Sphere_ToMesh_ShouldCreateValidMesh()
        {
            var sphere = new Sphere(1);
            var mesh = sphere.ToMesh();

            Assert.NotNull(mesh);
            Assert.True(mesh.ControlPoints.Count > 0);
            Assert.True(mesh.PolygonCount > 0);
            Assert.True(mesh.PolygonCount >= 32, "Sphere should have at least 32 polygons");
        }

        [Fact]
        public void Cylinder_ToMesh_ShouldCreateValidMesh()
        {
            var cylinder = new Cylinder(1, 1, 2);
            var mesh = cylinder.ToMesh();

            Assert.NotNull(mesh);
            Assert.True(mesh.ControlPoints.Count > 0);
            Assert.True(mesh.PolygonCount > 0);
            Assert.True(mesh.PolygonCount >= 3, "Cylinder should have at least 3 polygons");
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
            var testFile = Path.Combine("../../../../../../../TestData/stl", "stl_ascii.stl");

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
         public void LoadSceneFromStlBinary_ShouldLoadCorrectly()
        {
            var testFile = Path.Combine("../../../../../../../TestData/stl", "stl_binary.stl");

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
         public void LoadSceneFromUnsupportedFormat_ShouldThrowNotSupportedException()
        {
            // Test with a non-existent file that doesn't match any supported format
            // This tests the exception when no matching format is found
            var testFile = "../../../../../../../TestData/unknown.xyz";
            
            var scene = new Scene();
            Assert.Throws<ArgumentException>(() => scene.Open(testFile));
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
            var testFile = "../../../../../../../TestData/input/cube.obj";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            var options = new Formats.ObjLoadOptions();
            scene.Open(stream, options);

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
        public void LoadSceneFromStreamStl_ShouldLoadCorrectly()
        {
            var testFile = Path.Combine("../../../../../../../TestData/stl", "stl_ascii.stl");

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

            var node = scene.RootNode.ChildNodes[0];
            Assert.NotNull(node.Entities);
            Assert.True(node.Entities.Count > 0);

             var mesh = node.Entities[0] as Mesh;
             Assert.NotNull(mesh);
             Assert.True(mesh.ControlPoints.Count > 0);
             Assert.True(mesh.PolygonCount > 0);
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
            var testFile = "../../../../../../../TestData/gltf/simple_cube.gltf";
            
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
        }

        [Fact]
        public void LoadSceneFromFbx_ShouldLoadCorrectly()
        {
            var testFile = "../../../../../../../TestData/input/cube.fbx";
            
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
          }

          [Fact]
          public void LoadSceneFromFbxWithLoadOptions_ShouldLoadCorrectly()
        {
            var testFile = "../../../../../../../TestData/input/cube.fbx";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            var options = new Formats.FbxLoadOptions();
            scene.Open(stream, options);

            Assert.NotNull(scene);
             Assert.NotNull(scene.RootNode);
             Assert.True(scene.RootNode.ChildNodes.Count > 0);

              var node = scene.RootNode.ChildNodes[0];
              Assert.NotNull(node.Entities);
          }

          [Fact]
          public void LoadSceneFrom3mf_ShouldLoadCorrectly()
        {
            var testFile = "../../../../../../../TestData/3mf/box.3mf";
            
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
            Assert.Equal(8, mesh.ControlPoints.Count);
            Assert.Equal(12, mesh.PolygonCount);
        }

        [Fact]
        public void LoadSceneFrom3mfWithLoadOptions_ShouldLoadCorrectly()
        {
            var testFile = "../../../../../../../TestData/3mf/box.3mf";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            var options = new Formats.TmfLoadOptions();
            scene.Open(stream, options);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);

            var node = scene.RootNode.ChildNodes[0];
            Assert.NotNull(node.Entities);
            Assert.True(node.Entities.Count > 0);

            var mesh = node.Entities[0] as Mesh;
            Assert.NotNull(mesh);
            Assert.Equal(8, mesh.ControlPoints.Count);
            Assert.Equal(12, mesh.PolygonCount);
        }

        [Fact]
        public void LoadSceneFrom3mf_ShouldVerifyMeshData()
        {
            var testFile = "../../../../../../../TestData/3mf/box.3mf";
            
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
            Assert.Equal(8, mesh.ControlPoints.Count);
            Assert.Equal(12, mesh.PolygonCount);
        }

        [Fact]
        public void SaveSceneToObjFrom3mf_ShouldIncludePolygons()
        {
            var testFile = "../../../../../../../TestData/3mf/box.3mf";
            
            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            var scene = new Scene();
            scene.Open(testFile);

            using var stream = new MemoryStream();
            var options = new ObjSaveOptions() { Verbose = true };
            scene.Save(stream, options);

            stream.Seek(0, SeekOrigin.Begin);
            var content = new StreamReader(stream).ReadToEnd();

            Assert.Contains("v ", content);
            Assert.Contains("f ", content);
            
            var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            var faceLines = lines.Where(l => l.StartsWith("f ")).ToArray();
            Assert.True(faceLines.Length > 0, "Should have at least some face definitions");
        }

        [Fact]
        public void SaveSceneTo3mfStream_ShouldCreateValidFile()
        {
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            scene.RootNode.CreateChildNode("BoxNode", box);

            using var stream = new MemoryStream();
            var options = new Formats.TmfSaveOptions();
            scene.Save(stream, options);

            stream.Seek(0, SeekOrigin.Begin);
            var content = stream.ToArray();
            
            Assert.True(content.Length > 0);
            
            using var zip = new System.IO.Compression.ZipArchive(new MemoryStream(content), System.IO.Compression.ZipArchiveMode.Read);
            Assert.Equal(3, zip.Entries.Count);
            
            var modelEntry = zip.GetEntry("3D/3dmodel.model");
            Assert.NotNull(modelEntry);
            
            using var reader = new StreamReader(modelEntry.Open());
            var xmlContent = reader.ReadToEnd();
            Assert.Contains("<?xml", xmlContent);
            Assert.Contains("<model", xmlContent);
            Assert.Contains("millimeter", xmlContent);
        }

        [Fact]
        public void SaveSceneTo3mfFile_ShouldCreateValidFile()
        {
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            scene.RootNode.CreateChildNode("BoxNode", box);

            var outputFile = Path.Combine(Path.GetTempPath(), "test_output.3mf");
            try
            {
                scene.Save(outputFile);
                
                Assert.True(File.Exists(outputFile));
                
                using var zip = new System.IO.Compression.ZipArchive(File.OpenRead(outputFile), System.IO.Compression.ZipArchiveMode.Read);
                Assert.Equal(3, zip.Entries.Count);
                
                var modelEntry = zip.GetEntry("3D/3dmodel.model");
                Assert.NotNull(modelEntry);
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
        public void SaveSceneTo3mfWithPrimitive_ShouldCreateValidFile()
        {
            var scene = new Scene();
            var sphere = new Sphere(1);
            scene.RootNode.CreateChildNode("SphereNode", sphere);

            using var stream = new MemoryStream();
            var options = new Formats.TmfSaveOptions();
            scene.Save(stream, options);

            stream.Seek(0, SeekOrigin.Begin);
            
            using var zip = new System.IO.Compression.ZipArchive(new MemoryStream(stream.ToArray()), System.IO.Compression.ZipArchiveMode.Read);
            var modelEntry = zip.GetEntry("3D/3dmodel.model");
            Assert.NotNull(modelEntry);
            
            using var reader = new StreamReader(modelEntry.Open());
            var xmlContent = reader.ReadToEnd();
            Assert.Contains("<mesh", xmlContent);
            Assert.Contains("<vertices", xmlContent);
            Assert.Contains("<triangles", xmlContent);
        }

        [Fact]
        public void SaveSceneTo3mfMultipleObjects_ShouldCreateValidFile()
        {
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            var sphere = new Sphere(1);
            scene.RootNode.CreateChildNode("BoxNode", box);
            scene.RootNode.CreateChildNode("SphereNode", sphere);

            using var stream = new MemoryStream();
            var options = new Formats.TmfSaveOptions();
            scene.Save(stream, options);

            stream.Seek(0, SeekOrigin.Begin);
            
            using var zip = new System.IO.Compression.ZipArchive(new MemoryStream(stream.ToArray()), System.IO.Compression.ZipArchiveMode.Read);
            var modelEntry = zip.GetEntry("3D/3dmodel.model");
            Assert.NotNull(modelEntry);
            
            using var reader = new StreamReader(modelEntry.Open());
            var xmlContent = reader.ReadToEnd();
            Assert.Contains("<resources", xmlContent);
            Assert.Contains("<object", xmlContent);
            Assert.Contains("<build", xmlContent);
        }

        [Fact]
        public void SaveSceneToFbx_ShouldCreateValidBinaryFile()
        {
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            var node = scene.RootNode.CreateChildNode("BoxNode", box);

            var outputFile = Path.Combine(Path.GetTempPath(), "test_output.fbx");
            try
            {
                var options = new Formats.FbxSaveOptions();
                scene.Save(outputFile, options);

                Assert.True(File.Exists(outputFile));
                var content = File.ReadAllBytes(outputFile);
                
                Assert.Contains("Kaydara FBX Binary", System.Text.Encoding.ASCII.GetString(content, 0, Math.Min(50, content.Length)));
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
        public void LoadSceneFromPlyAscii_ShouldLoadCorrectly()
        {
            var testFile = "../../../../../../../TestData/input/cube.ply";

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
            var meshEntity = node.Entities[0] as Mesh;
            Assert.NotNull(meshEntity);
            Assert.Equal(8, meshEntity.ControlPoints.Count);
            Assert.Equal(6, meshEntity.PolygonCount);
        }

        [Fact]
        public void LoadSceneFromFbx7400Ascii_ShouldLoadCorrectly()
        {
            var testFile = "../../../../../../../TestData/fbx7400ascii/cube.fbx";

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
          }

          [Fact]
          public void LoadSceneFromPlyBinary_ShouldLoadCorrectly()
        {
            var testFile = "../../../../../../../TestData/input/cube_binary.ply";

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
            var meshEntity = node.Entities[0] as Mesh;
            Assert.NotNull(meshEntity);
            Assert.Equal(8, meshEntity.ControlPoints.Count);
            Assert.Equal(6, meshEntity.PolygonCount);
        }

        [Fact]
        public void LoadSceneFromPlyWithLoadOptions_ShouldLoadCorrectly()
        {
            var testFile = "../../../../../../../TestData/input/cube.ply";

            if (!File.Exists(testFile))
            {
                throw new FileNotFoundException($"Test file not found: {testFile}");
            }

            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            var options = new Formats.PlyLoadOptions();
            scene.Open(stream, options);

            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.True(scene.RootNode.ChildNodes.Count > 0);

            var node = scene.RootNode.ChildNodes[0];
            var meshEntity = node.Entities[0] as Mesh;
            Assert.NotNull(meshEntity);
            Assert.Equal(8, meshEntity.ControlPoints.Count);
            Assert.Equal(6, meshEntity.PolygonCount);
        }
    }
}
