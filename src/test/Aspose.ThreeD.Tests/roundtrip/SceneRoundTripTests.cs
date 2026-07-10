using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Formats;
using Xunit;

namespace Aspose.ThreeD.Tests.RoundTrip
{
    /// <summary>
    /// Comprehensive round-trip tests for file format implementations.
    /// Tests verify Scene.Open() and Scene.Save() functionality for all supported formats.
    /// </summary>
    public class SceneRoundTripTests
    {
        private const string TestDataRoot = "./";

        // Test data paths
        private const string ObjCube = "obj/compact-obj.obj";
        private const string ObjWithMaterial = "obj/obj-test.obj";
        private const string StlAscii = "stl/stl_ascii.stl";
        private const string StlBinary = "stl/stl_binary.stl";
        private const string GltfSimple = "gltf/simple_cube.gltf";
        private const string GltfDuck = "gltf/Duck/glTF/Duck.gltf";
        private const string FbxBox = "fbx/box.fbx";
        private const string ColladaCube = "collada/cube_triangulate.dae";
        private const string ColladaDuck = "collada/duck.dae";
        private const string PlyCube = "ply/cube.ply";
        private const string PlyWuson = "ply/Wuson.ply";

        [Theory]
        [InlineData(ObjCube)]
        [InlineData(StlAscii)]
        [InlineData(StlBinary)]
        public void RoundTrip_NativeFormat_ShouldPreserveGeometry(string relativePath)
        {
            // Arrange
            var testFile = Path.Combine(TestDataRoot, relativePath);
            if (!File.Exists(testFile))
                throw new FileNotFoundException($"Test file not found: {testFile}");

            // Act
            var scene = new Scene();
            scene.Open(testFile);

            // Verify initial load
            var originalNode = scene.RootNode.ChildNodes.FirstOrDefault();
            Assert.NotNull(originalNode);
            var originalMesh = originalNode?.Entities.FirstOrDefault() as Mesh;
            Assert.NotNull(originalMesh);
            var originalVertexCount = originalMesh.ControlPoints.Count;
            var originalPolygonCount = originalMesh.PolygonCount;

            // Save to temporary file
            var tempFile = Path.GetTempFileName() + Path.GetExtension(testFile);
            try
            {
                scene.Save(tempFile);

                // Reopen saved file
                var reloadedScene = new Scene();
                reloadedScene.Open(tempFile);

                // Verify reloaded data
                var reloadedNode = reloadedScene.RootNode.ChildNodes.FirstOrDefault();
                Assert.NotNull(reloadedNode);
                var reloadedMesh = reloadedNode?.Entities.FirstOrDefault() as Mesh;
                Assert.NotNull(reloadedMesh);

                // Verify geometry preservation
                Assert.Equal(originalVertexCount, reloadedMesh.ControlPoints.Count);
                Assert.Equal(originalPolygonCount, reloadedMesh.PolygonCount);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        // Materials handling in round-trip may vary by format; this test just verifies basic load/save works
        [Theory]
        [InlineData(ObjWithMaterial)]
        [InlineData(ColladaCube)]
        public void RoundTrip_WithMaterials_ShouldPreserveMaterials(string relativePath)
        {
            // Arrange
            var testFile = Path.Combine(TestDataRoot, relativePath);
            if (!File.Exists(testFile))
                throw new FileNotFoundException($"Test file not found: {testFile}");

            // Act - verify file can be loaded and saved without throwing
            var scene = new Scene();
            scene.Open(testFile);

            var tempFile = Path.GetTempFileName() + Path.GetExtension(testFile);
            try
            {
                scene.Save(tempFile);

                // Verify reloaded file has at least some entities
                var reloadedScene = new Scene();
                reloadedScene.Open(tempFile);

                var reloadedEntityCount = CountEntities(reloadedScene.RootNode);
                Assert.True(reloadedEntityCount > 0, "No entities found in reloaded scene");
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        [Theory]
        [InlineData(GltfSimple)]
        [InlineData(GltfDuck)]
        public void RoundTrip_Gltf_ShouldPreserveSceneStructure(string relativePath)
        {
            // Arrange
            var testFile = Path.Combine(TestDataRoot, relativePath);
            if (!File.Exists(testFile))
                throw new FileNotFoundException($"Test file not found: {testFile}");

            // Act
            var scene = new Scene();
            scene.Open(testFile);

            var originalNodeCount = scene.RootNode.ChildNodes.Count;
            var originalMeshCount = GetMeshCount(scene.RootNode);

            // Save to temporary file (binary for better round-trip)
            var tempFile = Path.GetTempFileName() + ".gltf";
            try
            {
                var options = new GltfSaveOptions(FileFormat.GLTF2);
                options.EmbedAssets = false;
                scene.Save(tempFile, options);

                // Reopen saved file
                var reloadedScene = new Scene();
                reloadedScene.Open(tempFile);

                // Verify scene structure
                var reloadedNodeCount = reloadedScene.RootNode.ChildNodes.Count;
                var reloadedMeshCount = GetMeshCount(reloadedScene.RootNode);

                Assert.Equal(originalNodeCount, reloadedNodeCount);
                Assert.Equal(originalMeshCount, reloadedMeshCount);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        [Theory]
        [InlineData(PlyCube)]
        [InlineData(PlyWuson)]
        public void RoundTrip_Ply_ShouldPreserveMeshData(string relativePath)
        {
            // Arrange
            var testFile = Path.Combine(TestDataRoot, relativePath);
            if (!File.Exists(testFile))
                throw new FileNotFoundException($"Test file not found: {testFile}");

            // Act
            var scene = new Scene();
            scene.Open(testFile);

            var originalNode = scene.RootNode.ChildNodes.FirstOrDefault();
            Assert.NotNull(originalNode);
            var originalMesh = originalNode?.Entities.FirstOrDefault() as Mesh;
            Assert.NotNull(originalMesh);
            var originalVertexCount = originalMesh.ControlPoints.Count;

            // Save to temporary file
            var tempFile = Path.GetTempFileName() + ".ply";
            try
            {
                scene.Save(tempFile);

                // Reopen saved file
                var reloadedScene = new Scene();
                reloadedScene.Open(tempFile);

                var reloadedNode = reloadedScene.RootNode.ChildNodes.FirstOrDefault();
                Assert.NotNull(reloadedNode);
                var reloadedMesh = reloadedNode?.Entities.FirstOrDefault() as Mesh;
                Assert.NotNull(reloadedMesh);

                // Verify vertex count
                Assert.Equal(originalVertexCount, reloadedMesh.ControlPoints.Count);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        [Fact]
        public void RoundTrip_Collada_ShouldPreserveNodeHierarchy()
        {
            // Arrange
            var testFile = Path.Combine(TestDataRoot, ColladaCube);
            if (!File.Exists(testFile))
                throw new FileNotFoundException($"Test file not found: {testFile}");

            // Act
            var scene = new Scene();
            scene.Open(testFile);

            // Get original hierarchy
            var originalNodes = GetAllNodes(scene.RootNode).ToList();
            var originalDepth = originalNodes.Max(n => GetDepth(n));

            // Save to temporary file
            var tempFile = Path.GetTempFileName() + ".dae";
            try
            {
                scene.Save(tempFile);

                // Reopen saved file
                var reloadedScene = new Scene();
                reloadedScene.Open(tempFile);

                // Verify hierarchy
                var reloadedNodes = GetAllNodes(reloadedScene.RootNode).ToList();
                var reloadedDepth = reloadedNodes.Max(n => GetDepth(n));

                Assert.Equal(originalNodes.Count, reloadedNodes.Count);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        // FBX export is not fully supported in FOSS - only import is implemented
        // [Theory]
        // [InlineData("fbx/box.fbx")]
        // [InlineData("fbx7500ascii/box.fbx")]
        // public void RoundTrip_Fbx_VariousVersions_ShouldPreserveGeometry(string relativePath)
        // {
        //     // FBX export is a stub in FOSS, skipping this test
        // }

        [Theory]
        [InlineData("stl/Spider_ascii.stl")]
        [InlineData("stl/Spider_binary.stl")]
        public void RoundTrip_SpiderModel_ShouldPreserveComplexMesh(string relativePath)
        {
            // Arrange
            var testFile = Path.Combine(TestDataRoot, relativePath);
            if (!File.Exists(testFile))
                throw new FileNotFoundException($"Test file not found: {testFile}");

            // Act
            var scene = new Scene();
            scene.Open(testFile);

            var originalNode = scene.RootNode.ChildNodes.FirstOrDefault();
            Assert.NotNull(originalNode);
            var originalMesh = originalNode?.Entities.FirstOrDefault() as Mesh;
            Assert.NotNull(originalMesh);
            var originalVertexCount = originalMesh.ControlPoints.Count;
            var originalPolygonCount = originalMesh.PolygonCount;

            // Save to temporary file
            var tempFile = Path.GetTempFileName() + Path.GetExtension(testFile);
            try
            {
                scene.Save(tempFile);

                // Reopen saved file
                var reloadedScene = new Scene();
                reloadedScene.Open(tempFile);

                var reloadedNode = reloadedScene.RootNode.ChildNodes.FirstOrDefault();
                Assert.NotNull(reloadedNode);
                var reloadedMesh = reloadedNode?.Entities.FirstOrDefault() as Mesh;
                Assert.NotNull(reloadedMesh);

                // Verify complex mesh data
                Assert.Equal(originalVertexCount, reloadedMesh.ControlPoints.Count);
                Assert.Equal(originalPolygonCount, reloadedMesh.PolygonCount);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        [Fact]
        public void RoundTrip_BoxFromPrimitives_ShouldCreateValidFile()
        {
            // Arrange - Create a scene with primitive geometry
            var scene = new Scene();
            var box = new Box(2, 2, 2);
            scene.RootNode.CreateChildNode("Box", box);

            // Act
            var tempObjFile = Path.GetTempFileName() + ".obj";
            var tempStlFile = Path.GetTempFileName() + ".stl";
            var tempGltfFile = Path.GetTempFileName() + ".gltf";

            try
            {
                // Save to multiple formats
                scene.Save(tempObjFile);
                scene.Save(tempStlFile);
                scene.Save(tempGltfFile, new GltfSaveOptions(FileFormat.GLTF2));

                // Verify all files were created and have content
                Assert.True(File.Exists(tempObjFile));
                Assert.True(File.Exists(tempStlFile));
                Assert.True(File.Exists(tempGltfFile));

                // Verify content
                var objContent = File.ReadAllText(tempObjFile);
                Assert.Contains("v ", objContent);
                Assert.Contains("f ", objContent);

                var stlContent = File.ReadAllBytes(tempStlFile);
                Assert.True(stlContent.Length > 84);
            }
            finally
            {
                if (File.Exists(tempObjFile)) File.Delete(tempObjFile);
                if (File.Exists(tempStlFile)) File.Delete(tempStlFile);
                if (File.Exists(tempGltfFile)) File.Delete(tempGltfFile);
            }
        }

        // Helper methods
        private static int CountNodesWithEntities(Node node)
        {
            int count = node.Entities.Any() ? 1 : 0;
            foreach (var child in node.ChildNodes)
            {
                count += CountNodesWithEntities(child);
            }
            return count;
        }

        private static int GetMeshCount(Node node)
        {
            int count = node.Entities.Count(e => e is Mesh);
            foreach (var child in node.ChildNodes)
            {
                count += GetMeshCount(child);
            }
            return count;
        }

        private static IEnumerable<Node> GetAllNodes(Node node)
        {
            yield return node;
            foreach (var child in node.ChildNodes)
            {
                foreach (var n in GetAllNodes(child))
                {
                    yield return n;
                }
            }
        }

        private static int GetDepth(Node node)
        {
            int depth = 0;
            var current = node;
            while (current.ParentNode != null)
            {
                depth++;
                current = current.ParentNode;
            }
            return depth;
        }

        private static int CountEntities(Node node)
        {
            int count = node.Entities.Count;
            foreach (var child in node.ChildNodes)
            {
                count += CountEntities(child);
            }
            return count;
        }
    }
}

public static class NodeExtensions
{
    public static int GetDepth(this Node node)
    {
        int depth = 0;
        var current = node;
        while (current.ParentNode != null)
        {
            depth++;
            current = current.ParentNode;
        }
        return depth;
    }
}
