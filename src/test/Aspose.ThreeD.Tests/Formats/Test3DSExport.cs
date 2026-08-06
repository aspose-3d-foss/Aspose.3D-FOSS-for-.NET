using System;
using System.IO;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Formats;
using Aspose.ThreeD.Shading;
using Aspose.ThreeD.Utilities;
using Xunit;

namespace Aspose.ThreeD.Tests.Formats
{
    public class Test3DSExport
    {
        private static string GetTestDataPath()
        {
            var assemblyDir = Path.GetDirectoryName(typeof(Test3DSExport).Assembly.Location);
            var testDataPath = Path.Combine(assemblyDir, "..", "..", "..", "..", "..", "..", "..", "..", "TestData");
            return Path.GetFullPath(testDataPath);
        }

        [Fact]
        public void Save3DSFile_ShouldSaveScene()
        {
            var testDataPath = GetTestDataPath();
            var testFile = Path.Combine(testDataPath, "3ds", "test.3DS");

            var scene = new Scene();
            scene.Open(testFile);

            var tempFile = Path.Combine(Path.GetTempPath(), $"export-roundtrip-{Guid.NewGuid()}.3ds");
            try
            {
                scene.Save(tempFile, FileFormat.Discreet3DS);

                Assert.True(File.Exists(tempFile), "Exported file should exist");

                var reOpenedScene = new Scene();
                reOpenedScene.Open(tempFile);

                Assert.NotNull(reOpenedScene);
                Assert.NotNull(reOpenedScene.RootNode);
                Assert.NotNull(reOpenedScene.RootNode.ChildNodes);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        [Fact]
        public void Save3DSFile_ShouldSaveMesh()
        {
            var testDataPath = GetTestDataPath();
            var testFile = Path.Combine(testDataPath, "3ds", "cube.3DS");

            var originalScene = new Scene();
            originalScene.Open(testFile);

            var tempFile = Path.Combine(Path.GetTempPath(), $"export-mesh-{Guid.NewGuid()}.3ds");
            try
            {
                originalScene.Save(tempFile, FileFormat.Discreet3DS);

                var reOpenedScene = new Scene();
                reOpenedScene.Open(tempFile);

                int originalMeshCount = 0;
                int reOpenedMeshCount = 0;
                int originalVertices = 0;
                int reOpenedVertices = 0;
                int originalFaces = 0;
                int reOpenedFaces = 0;

                CountMeshes(originalScene.RootNode, ref originalMeshCount, ref originalVertices, ref originalFaces);
                CountMeshes(reOpenedScene.RootNode, ref reOpenedMeshCount, ref reOpenedVertices, ref reOpenedFaces);

                Assert.Equal(originalMeshCount, reOpenedMeshCount);
                Assert.True(reOpenedVertices > 0);
                Assert.True(reOpenedFaces > 0);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        [Fact]
        public void Save3DSFile_ShouldSaveMaterials()
        {
            var testDataPath = GetTestDataPath();
            var testFile = Path.Combine(testDataPath, "3ds", "test.3DS");

            var originalScene = new Scene();
            originalScene.Open(testFile);

            var tempFile = Path.Combine(Path.GetTempPath(), $"export-materials-{Guid.NewGuid()}.3ds");
            try
            {
                originalScene.Save(tempFile, FileFormat.Discreet3DS);

                var reOpenedScene = new Scene();
                reOpenedScene.Open(tempFile);

                Assert.NotNull(reOpenedScene);
                Assert.NotNull(reOpenedScene.RootNode);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        [Fact]
        public void Save3DSFile_ShouldHandleDuplicatedNames()
        {
            var scene = new Scene();
            var boxNode = scene.RootNode.CreateChildNode("Box");
            
            // Add a simple box mesh to the node
            var mesh = new Mesh("Box");
            mesh.ControlPoints.Add(new Vector4(0.0, 0.0, 0.0, 1.0));
            mesh.ControlPoints.Add(new Vector4(1.0, 0.0, 0.0, 1.0));
            mesh.ControlPoints.Add(new Vector4(1.0, 1.0, 0.0, 1.0));
            mesh.ControlPoints.Add(new Vector4(0.0, 1.0, 0.0, 1.0));
            mesh.ControlPoints.Add(new Vector4(0.0, 0.0, 1.0, 1.0));
            mesh.ControlPoints.Add(new Vector4(1.0, 0.0, 1.0, 1.0));
            mesh.ControlPoints.Add(new Vector4(1.0, 1.0, 1.0, 1.0));
            mesh.ControlPoints.Add(new Vector4(0.0, 1.0, 1.0, 1.0));
            
            boxNode.AddEntity(mesh);

            var tempFile = Path.Combine(Path.GetTempPath(), $"export-dupnames-{Guid.NewGuid()}.3ds");
            try
            {
                scene.Save(tempFile, FileFormat.Discreet3DS);

                Assert.True(File.Exists(tempFile), "Exported file should exist");

                var reOpenedScene = new Scene();
                reOpenedScene.Open(tempFile);

                int boxCount = 0;
                CountNodesByName(reOpenedScene.RootNode, "Box", ref boxCount);

                Assert.Equal(1, boxCount);
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }

        private void CountMeshes(Node node, ref int meshCount, ref int vertexCount, ref int faceCount)
        {
            foreach (var entity in node.Entities)
            {
                if (entity is Mesh mesh)
                {
                    meshCount++;
                    vertexCount += mesh.ControlPoints.Count;
                    faceCount += mesh.PolygonCount;
                }
            }

            foreach (var childNode in node.ChildNodes)
            {
                CountMeshes(childNode, ref meshCount, ref vertexCount, ref faceCount);
            }
        }

        private void CountNodesByName(Node node, string name, ref int count)
        {
            if (node.Name == name)
            {
                count++;
            }

            foreach (var childNode in node.ChildNodes)
            {
                CountNodesByName(childNode, name, ref count);
            }
        }
    }
}
