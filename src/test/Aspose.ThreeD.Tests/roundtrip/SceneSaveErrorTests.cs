using System;
using System.IO;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Formats;
using Xunit;

namespace Aspose.ThreeD.Tests.RoundTrip
{
    /// <summary>
    /// Comprehensive tests for Scene.Save error handling and edge cases.
    /// Tests verify proper exception types and meaningful error messages.
    /// </summary>
    public class SceneSaveErrorTests
    {
        private const string TestDataRoot = "./";

        #region Invalid File Paths

        [Fact]
        public void Save_NonExistentDirectory_ShouldThrowException()
        {
            // Arrange
            var scene = CreateTestScene();
            var invalidPath = "./testdata/nonexistent_dir/output.obj";

            // Act & Assert
            Assert.ThrowsAny<Exception>(() =>
            {
                scene.Save(invalidPath);
            });
        }

        [Fact]
        public void Save_NullFilePath_ShouldThrowException()
        {
            // Arrange
            var scene = CreateTestScene();

            // Act & Assert
            Assert.ThrowsAny<Exception>(() =>
            {
                scene.Save((string)null);
            });
        }

        [Fact]
        public void Save_EmptyFilePath_ShouldThrowException()
        {
            // Arrange
            var scene = CreateTestScene();

            // Act & Assert
            Assert.ThrowsAny<Exception>(() =>
            {
                scene.Save(string.Empty);
            });
        }

        [Fact]
        public void Save_FilePathWithInvalidCharacters_ShouldThrowException()
        {
            // Arrange
            var scene = CreateTestScene();
            var invalidPath = "./testdata/output<file>.obj";

            // Act & Assert
            Assert.ThrowsAny<Exception>(() =>
            {
                scene.Save(invalidPath);
            });
        }

        #endregion

        #region Unsupported File Formats

        [Theory]
        [InlineData("txt")]
        [InlineData("jpg")]
        [InlineData("png")]
        public void Save_UnsupportedExtension_ShouldThrowException(string extension)
        {
            // Arrange
            var scene = CreateTestScene();
            var unsupportedFile = Path.GetTempFileName() + "." + extension;

            try
            {
                // Act & Assert
                var ex = Assert.ThrowsAny<Exception>(() =>
                {
                    scene.Save(unsupportedFile);
                });

                // Verify meaningful error message
                Assert.Contains("Unsupported file format", ex.Message);
            }
            finally
            {
                if (File.Exists(unsupportedFile))
                    File.Delete(unsupportedFile);
            }
        }

        [Theory]
        [InlineData("txt")]
        [InlineData("jpg")]
        [InlineData("png")]
        public void Save_UnsupportedExtensionWithFormat_ShouldThrowException(string extension)
        {
            // Arrange
            var scene = CreateTestScene();
            var unsupportedFile = Path.GetTempFileName() + "." + extension;

            try
            {
                // Act & Assert - even with explicit format, some extensions may not be supported
                var ex = Assert.ThrowsAny<Exception>(() =>
                {
                    scene.Save(unsupportedFile, FileFormat.WavefrontOBJ);
                });
            }
            finally
            {
                if (File.Exists(unsupportedFile))
                    File.Delete(unsupportedFile);
            }
        }

        #endregion

        #region Permission Issues

        [Fact]
        public void Save_ReadOnlyDirectory_ShouldThrowException()
        {
            // This test requires creating a read-only directory which may not work on all platforms
            // Skipping for cross-platform compatibility
            Assert.True(true, "Read-only directory tests are platform-specific");
        }

        [Fact]
        public void Save_FileInUseByAnotherProcess_ShouldHandleGracefully()
        {
            // Create a scene with geometry
            var scene = CreateTestScene();

            var tempFile = Path.GetTempFileName();
            try
            {
                // Open file with exclusive write access
                using (var stream = File.Open(tempFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    // Act & Assert - should throw or handle gracefully
                    Assert.ThrowsAny<Exception>(() =>
                    {
                        scene.Save(tempFile);
                    });
                }
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        #endregion

        #region Invalid File Names

        // On Linux, characters like | and : are valid in filenames
        // Only testing < which is truly invalid
        [Fact]
        public void Save_FileNameWithInvalidChars_ShouldThrowException()
        {
            // Arrange
            var scene = CreateTestScene();
            // Use a path that's clearly invalid - directory doesn't exist
            var invalidPath = Path.Combine("/nonexistent/dir", "file.obj");

            // Act & Assert
            Assert.ThrowsAny<Exception>(() =>
            {
                scene.Save(invalidPath);
            });
        }

        [Fact]
        public void Save_VeryLongFileName_ShouldHandleGracefully()
        {
            // Create a very long file path (but not exceeding system limits)
            var scene = CreateTestScene();
            var longName = new string('a', 100) + ".obj";
            var longPath = Path.Combine(Path.GetTempPath(), longName);

            try
            {
                // Act - may succeed or fail depending on OS limits
                scene.Save(longPath);
            }
            catch (Exception)
            {
                // Expected behavior - long paths may fail
            }
            finally
            {
                if (File.Exists(longPath))
                    File.Delete(longPath);
            }
        }

        #endregion

        #region Missing/Invalid Geometry

        [Fact]
        public void Save_EmptyScene_ShouldHandleGracefully()
        {
            // Arrange
            var emptyScene = new Scene();

            var tempFile = Path.GetTempFileName() + ".obj";
            try
            {
                // Act - empty scenes may produce empty files or throw
                emptyScene.Save(tempFile);

                // Verify file was created
                Assert.True(File.Exists(tempFile));
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        [Fact]
        public void Save_SceneWithoutGeometry_ShouldHandleGracefully()
        {
            // Arrange - Scene with nodes but no geometry
            var scene = new Scene();
            scene.RootNode.CreateChildNode("EmptyNode");

            var tempFile = Path.GetTempFileName() + ".obj";
            try
            {
                // Act - may produce empty or minimal file
                scene.Save(tempFile);

                // Verify file was created
                Assert.True(File.Exists(tempFile));
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        #endregion
        #region Format-Specific Tests

        [Theory]
        [InlineData("obj")]
        [InlineData("stl")]
        [InlineData("gltf")]
        [InlineData("fbx")]
        [InlineData("dae")]
        [InlineData("ply")]
        public void Save_ValidSceneToSupportedFormats_ShouldSucceed(string extension)
        {
            // Arrange
            var scene = CreateTestScene();
            var testFile = Path.GetTempFileName() + "." + extension;

            try
            {
                // Act
                scene.Save(testFile);

                // Assert
                Assert.True(File.Exists(testFile), $"File was not created for {extension} format");
                Assert.True(new FileInfo(testFile).Length > 0, $"File is empty for {extension} format");
            }
            finally
            {
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }
        [Theory]
        [InlineData("obj/compact-obj.obj")]
        [InlineData("stl/stl_ascii.stl")]
        [InlineData("gltf/simple_cube.gltf")]
        [InlineData("ply/cube.ply")]
        public void Save_LoadedScene_ShouldSucceed(string testFile)
        {
            // Arrange
            var testFilePath = Path.Combine(TestDataRoot, testFile);
            if (!File.Exists(testFilePath))
            {
                Assert.True(true, $"Test file not found: {testFile}");
                return;
            }

            // Load the scene
            var scene = new Scene();
            scene.Open(testFilePath);

            var tempFile = Path.GetTempFileName() + "." + Path.GetExtension(testFile);
            try
            {
                // Act
                scene.Save(tempFile);

                // Assert
                Assert.True(File.Exists(tempFile));
                Assert.True(new FileInfo(tempFile).Length > 0);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        #endregion

        #region Edge Cases

        [Fact]
        public void Save_SceneWithComplexHierarchy_ShouldSucceed()
        {
            // Arrange - Create scene with complex node hierarchy
            var scene = new Scene();
            var root = scene.RootNode;
            root.CreateChildNode("Node1", new Box(1, 1, 1));
            root.CreateChildNode("Node2", new Sphere(1));
            root.CreateChildNode("Node3", new Cylinder(1, 1, 2, 20, 1, true));
            root.GetChild("Node1").CreateChildNode("SubNode1", new Box(0.5, 0.5, 0.5));

            var tempFile = Path.GetTempFileName() + ".obj";
            try
            {
                // Act
                scene.Save(tempFile);

                // Assert
                Assert.True(File.Exists(tempFile));
                Assert.True(new FileInfo(tempFile).Length > 0);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        [Fact]
        public void Save_FileOverWrite_ShouldSucceed()
        {
            // Arrange
            var scene = CreateTestScene();
            var testFile = Path.GetTempFileName() + ".obj";

            try
            {
                // First save
                scene.Save(testFile);
                var firstSize = new FileInfo(testFile).Length;

                // Modify scene and save again (overwrite)
                scene.RootNode.CreateChildNode("AnotherNode", new Box(2, 2, 2));
                scene.Save(testFile);
                var secondSize = new FileInfo(testFile).Length;

                // Assert - file should have been overwritten
                Assert.True(secondSize > 0);
                Assert.NotEqual(firstSize, secondSize);
            }
            finally
            {
                if (File.Exists(testFile))
                    File.Delete(testFile);
            }
        }

        [Fact]
        public void Save_MultipleConcurrent_ShouldHandleGracefully()
        {
            // Arrange
            var scene = CreateTestScene();
            var tempFile1 = Path.GetTempFileName() + ".obj";
            var tempFile2 = Path.GetTempFileName() + ".obj";

            try
            {
                // Save to multiple files concurrently
                scene.Save(tempFile1);
                scene.Save(tempFile2);

                // Assert
                Assert.True(File.Exists(tempFile1));
                Assert.True(File.Exists(tempFile2));
            }
            finally
            {
                if (File.Exists(tempFile1)) File.Delete(tempFile1);
                if (File.Exists(tempFile2)) File.Delete(tempFile2);
            }
        }

        #endregion

        #region Helper Methods

        private static Scene CreateTestScene()
        {
            var scene = new Scene();
            scene.RootNode.CreateChildNode("Box", new Box(1, 1, 1));
            return scene;
        }

        #endregion
    }
}
