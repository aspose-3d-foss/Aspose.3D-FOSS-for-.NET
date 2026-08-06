using System;
using System.IO;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Xunit;

namespace Aspose.ThreeD.Tests.Formats
{
    public class Test3DSImport
    {
        private static string GetTestDataPath()
        {
            var assemblyDir = Path.GetDirectoryName(typeof(Test3DSImport).Assembly.Location);
            // Go up 8 levels from bin/Debug/net10.0/ to get to workspace root
            // then use the TestData folder (symlinked from foss.3d.net)
            var testDataPath = Path.Combine(assemblyDir, "..", "..", "..", "..", "..", "..", "..", "..", "TestData");
            return Path.GetFullPath(testDataPath);
        }
        
        [Fact]
        public void Load3DSFile_ShouldLoadScene()
        {
            var testDataPath = GetTestDataPath();
            var testFile = Path.Combine(testDataPath, "3ds", "test.3DS");
            
            Assert.True(File.Exists(testFile), $"Test file not found: {testFile}");
            
            var scene = new Scene();
            scene.Open(testFile);
            
            Assert.NotNull(scene);
            Assert.NotNull(scene.RootNode);
            Assert.NotNull(scene.RootNode.ChildNodes);
            
            Console.WriteLine($"Scene loaded. Root nodes: {scene.RootNode.ChildNodes.Count}");
            
            foreach (var node in scene.RootNode.ChildNodes)
            {
                Console.WriteLine($"  Node: {node.Name}, Entities: {node.Entities.Count}");
                foreach (var entity in node.Entities)
                {
                    Console.WriteLine($"    Entity: {entity.GetType().Name}");
                }
            }
            
            Assert.True(scene.RootNode.ChildNodes.Count > 0, "Scene should have at least one child node");
        }
        
        [Fact]
        public void Load3DSFile_ShouldLoadMesh()
        {
            var testDataPath = GetTestDataPath();
            var testFile = Path.Combine(testDataPath, "3ds", "cube.3DS");
            
            var scene = new Scene();
            scene.Open(testFile);
            
            // Check that we have at least one node with a mesh
            Mesh? foundMesh = null;
            foreach (var node in scene.RootNode.ChildNodes)
            {
                Console.WriteLine($"Node: {node.Name}, Entities: {node.Entities.Count}");
                foreach (var entity in node.Entities)
                {
                    Console.WriteLine($"  Entity: {entity.GetType().Name}");
                    if (entity is Mesh m)
                    {
                        foundMesh = m;
                        break;
                    }
                }
                if (foundMesh != null) break;
            }
            
            Assert.NotNull(foundMesh);
            Assert.True(foundMesh != null, "Should have at least one node with a Mesh entity");
            Assert.True(foundMesh.ControlPoints.Count > 0, "Mesh should have control points");
            Assert.True(foundMesh.PolygonCount > 0, "Mesh should have faces");
        }
    }
}
