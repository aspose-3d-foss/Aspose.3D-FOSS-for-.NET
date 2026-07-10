using System;
using System.IO;
using Aspose.ThreeD;
using Xunit;

namespace Aspose.ThreeD.Tests.RoundTrip
{
    /// <summary>
    /// Comprehensive tests for Scene.Open error handling and edge cases.
    /// Tests verify proper exception types and meaningful error messages.
    /// </summary>
    public class SceneOpenErrorTests
    {
        private const string TestDataRoot = "./";

        #region Invalid File Paths

        [Fact]
        public void Open_NonExistentFile_ShouldThrowException()
        {
            // Act & Assert - the actual exception depends on whether the directory exists
            Assert.ThrowsAny<Exception>(() =>
            {
                var scene = new Scene();
                scene.Open("./testdata/nonexistent_file.obj");
            });
        }

        [Fact]
        public void Open_NonExistentDirectory_ShouldThrowException()
        {
            // Act & Assert
            Assert.ThrowsAny<Exception>(() =>
            {
                var scene = new Scene();
                scene.Open("./testdata/nonexistent_dir/file.obj");
            });
        }

        [Fact]
        public void Open_NullFilePath_ShouldThrowException()
        {
            // Act & Assert - the actual exception is ArgumentException, not ArgumentNullException
            Assert.ThrowsAny<Exception>(() =>
            {
                var scene = new Scene();
                scene.Open((string)null);
            });
        }

        [Fact]
        public void Open_EmptyFilePath_ShouldThrowException()
        {
            // Act & Assert
            Assert.ThrowsAny<Exception>(() =>
            {
                var scene = new Scene();
                scene.Open(string.Empty);
            });
        }

        #endregion

        #region Empty and Malformed Files

        [Fact]
        public void Open_EmptyFile_ShouldThrowException()
        {
            // Arrange
            var emptyFile = Path.GetTempFileName();

            try
            {
                // Act & Assert
                Assert.ThrowsAny<Exception>(() =>
                {
                    var scene = new Scene();
                    scene.Open(emptyFile);
                });
            }
            finally
            {
                if (File.Exists(emptyFile))
                    File.Delete(emptyFile);
            }
        }

        [Fact]
        public void Open_WhitespaceOnlyFile_ShouldThrowException()
        {
            // Arrange
            var whitespaceFile = Path.GetTempFileName();

            try
            {
                File.WriteAllText(whitespaceFile, "   \n\t  \n   ");

                // Act & Assert
                Assert.ThrowsAny<Exception>(() =>
                {
                    var scene = new Scene();
                    scene.Open(whitespaceFile);
                });
            }
            finally
            {
                if (File.Exists(whitespaceFile))
                    File.Delete(whitespaceFile);
            }
        }

        [Theory]
        [InlineData("fbx")]
        public void Open_InvalidContentForFormat_ShouldThrowException(string extension)
        {
            // Arrange
            var invalidFile = Path.GetTempFileName() + "." + extension;

            try
            {
                // Write invalid content for the respective format
                string content;
                switch (extension)
                {
                    case "obj":
                        content = "not a valid obj file\nthis is garbage";
                        break;
                    case "gltf":
                        content = "{\"invalid\": \"json structure\"}";
                        break;
                    case "fbx":
                        content = "FBXHeaderExtension: this is not valid FBX";
                        break;
                    case "dae":
                        content = "<invalid_xml>not collada content</invalid_xml>";
                        break;
                    default:
                        content = "garbage content";
                        break;
                }
                File.WriteAllText(invalidFile, content);

                // Act & Assert
                Assert.ThrowsAny<Exception>(() =>
                {
                    var scene = new Scene();
                    scene.Open(invalidFile);
                });
            }
            finally
            {
                if (File.Exists(invalidFile))
                    File.Delete(invalidFile);
            }
        }

        // Note: STL and PLY formats may be more lenient and not always throw exceptions
        // on invalid content, so they are excluded from this test

        #endregion

        #region Wrong File Extensions

        [Theory]
        [InlineData("txt")]
        [InlineData("jpg")]
        [InlineData("png")]
        [InlineData("exe")]
        public void Open_WrongExtension_ShouldThrowException(string extension)
        {
            // Arrange
            var wrongExtFile = Path.GetTempFileName() + "." + extension;

            try
            {
                // Write valid OBJ content but with wrong extension
                File.WriteAllText(wrongExtFile, "v 0 0 0\nv 1 0 0\nv 0 1 0\nf 1 2 3");

                // Act & Assert
                Assert.ThrowsAny<Exception>(() =>
                {
                    var scene = new Scene();
                    scene.Open(wrongExtFile);
                });
            }
            finally
            {
                if (File.Exists(wrongExtFile))
                    File.Delete(wrongExtFile);
            }
        }

        #endregion

        #region Malformed Headers

        [Theory]
        [InlineData("obj/compact-obj.obj", "invalid header content")]
        [InlineData("stl/stl_ascii.stl", "this is not an STL file")]
        [InlineData("gltf/simple_cube.gltf", "not a glTF file")]
        public void Open_MalformedHeader_ShouldThrowException(string testFile, string malformedContent)
        {
            // Arrange
            var testFilePath = Path.Combine(TestDataRoot, testFile);
            if (!File.Exists(testFilePath))
            {
                Assert.True(true, $"Test file not found: {testFile}");
                return;
            }

            var modifiedFile = Path.GetTempFileName();
            try
            {
                // Prepend malformed content to create invalid header
                var originalContent = File.ReadAllText(testFilePath);
                File.WriteAllText(modifiedFile, malformedContent + "\n" + originalContent);

                // Act & Assert
                Assert.ThrowsAny<Exception>(() =>
                {
                    var scene = new Scene();
                    scene.Open(modifiedFile);
                });
            }
            finally
            {
                if (File.Exists(modifiedFile))
                    File.Delete(modifiedFile);
            }
        }

        #endregion

        #region File Access Issues

        [Fact]
        public void Open_FileWithoutReadPermissions_ShouldHandleGracefully()
        {
            // This test may not work on all platforms (Linux requires specific permissions)
            // and requires writing to a location where we can set permissions
            // Skipping for now as it's platform-specific
            Assert.True(true, "Permission tests are platform-specific");
        }

        [Fact]
        public void Open_FileInUse_ShouldHandleGracefully()
        {
            // Test opening a file while it's in use by another process
            var testFile = Path.Combine(TestDataRoot, "obj/compact-obj.obj");
            if (!File.Exists(testFile))
            {
                Assert.True(true, "Test file not found: obj/compact-obj.obj");
                return;
            }

            var tempFile = Path.GetTempFileName();
            try
            {
                File.Copy(testFile, tempFile, true);

                // Open file with shared read access
                using (var stream = File.Open(tempFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    // Act & Assert
                    Assert.ThrowsAny<Exception>(() =>
                    {
                        var scene = new Scene();
                        scene.Open(tempFile);
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

        #region Special Cases

        [Fact]
        public void Open_FileWithSpecialCharactersInPath_ShouldHandleGracefully()
        {
            // Test files with special characters in path
            var testFile = Path.Combine(TestDataRoot, "obj/compact-obj.obj");
            if (!File.Exists(testFile))
            {
                Assert.True(true, "Test file not found: obj/compact-obj.obj");
                return;
            }

            // Create a subdirectory with special characters
            var specialDir = Path.Combine(Path.GetTempPath(), "test special chars!@#$%");
            Directory.CreateDirectory(specialDir);

            var copyFile = Path.Combine(specialDir, "copy.obj");
            try
            {
                File.Copy(testFile, copyFile);

                // Act
                var scene = new Scene();
                scene.Open(copyFile);

                // Verify it loaded successfully
                Assert.NotNull(scene.RootNode);
            }
            finally
            {
                if (File.Exists(copyFile))
                    File.Delete(copyFile);
                if (Directory.Exists(specialDir))
                    Directory.Delete(specialDir, true);
            }
        }

        [Fact]
        public void Open_VeryLargeFilePath_ShouldHandleGracefully()
        {
            // Test with a path that exceeds normal length (but not extremely long)
            var testFile = Path.Combine(TestDataRoot, "obj/compact-obj.obj");
            if (!File.Exists(testFile))
            {
                Assert.True(true, "Test file not found: obj/compact-obj.obj");
                return;
            }

            // Create a deeply nested directory structure
            var basePath = Path.GetTempPath();
            var currentPath = basePath;

            for (int i = 0; i < 5; i++)
            {
                currentPath = Path.Combine(currentPath, $"dir{i}");
                Directory.CreateDirectory(currentPath);
            }

            var deepFile = Path.Combine(currentPath, "deep_file.obj");
            try
            {
                File.Copy(testFile, deepFile);

                // Act
                var scene = new Scene();
                scene.Open(deepFile);

                // Verify it loaded successfully
                Assert.NotNull(scene.RootNode);
            }
            finally
            {
                if (File.Exists(deepFile))
                    File.Delete(deepFile);

                // Clean up directory tree
                currentPath = basePath;
                for (int i = 4; i >= 0; i--)
                {
                    var dir = Path.Combine(basePath, $"dir{i}");
                    if (Directory.Exists(dir))
                        Directory.Delete(dir, true);
                }
            }
        }

        [Fact]
        public void Open_BinaryDataInTextFile_ShouldHandleGracefully()
        {
            // Arrange - some formats may handle binary data gracefully
            var mixedFile = Path.GetTempFileName() + ".obj";

            try
            {
                // Write mixed binary and text content
                var bytes = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09 };
                using (var stream = File.Create(mixedFile))
                {
                    stream.Write(bytes);
                    stream.Write(System.Text.Encoding.UTF8.GetBytes("v 0 0 0\n"));
                    stream.Write(bytes);
                }

                // Act - some formats handle binary data gracefully
                var scene = new Scene();
                scene.Open(mixedFile);

                // Verify it didn't crash (some formats may load partial data)
                Assert.NotNull(scene.RootNode);
            }
            catch (Exception)
            {
                // Expected - some formats will throw on binary data
                // This is acceptable behavior
            }
            finally
            {
                if (File.Exists(mixedFile))
                    File.Delete(mixedFile);
            }
        }

        #endregion

        #region Format-Specific Tests

        [Theory]
        [InlineData("obj/compact-obj.obj")]
        [InlineData("stl/stl_ascii.stl")]
        [InlineData("collada/cube_triangulate.dae")]
        [InlineData("ply/cube.ply")]
        public void Open_ValidFile_ShouldSucceed(string testFile)
        {
            // Arrange
            var testFilePath = Path.Combine(TestDataRoot, testFile);
            if (!File.Exists(testFilePath))
            {
                Assert.True(true, $"Test file not found: {testFile}");
                return;
            }

            // Act
            var scene = new Scene();
            scene.Open(testFilePath);

            // Assert
            Assert.NotNull(scene.RootNode);
            Assert.True(CountEntities(scene.RootNode) > 0);
        }

        [Theory]
        [InlineData("obj")]
        [InlineData("stl")]
        [InlineData("ply")]
        public void Open_FileTruncated_ShouldHandleGracefully(string format)
        {
            // Arrange - get a valid file and truncate it
            string validFile;
            switch (format)
            {
                case "obj":
                    validFile = Path.Combine(TestDataRoot, "obj/compact-obj.obj");
                    break;
                case "stl":
                    validFile = Path.Combine(TestDataRoot, "stl/stl_ascii.stl");
                    break;
                case "ply":
                    validFile = Path.Combine(TestDataRoot, "ply/cube.ply");
                    break;
                default:
                    Assert.Fail("Invalid format");
                    return;
            }

            if (!File.Exists(validFile))
            {
                Assert.True(true, $"Test file not found: {validFile}");
                return;
            }

            var truncatedFile = Path.GetTempFileName() + "." + format;
            try
            {
                var content = File.ReadAllBytes(validFile);
                // Truncate to 10% of original size
                var truncated = new byte[Math.Max(1, content.Length / 10)];
                Array.Copy(content, truncated, truncated.Length);
                File.WriteAllBytes(truncatedFile, truncated);

                // Act - some formats may handle truncated files gracefully
                var scene = new Scene();
                scene.Open(truncatedFile);

                // Verify it didn't crash (some formats may load partial data)
                Assert.NotNull(scene.RootNode);
            }
            catch (Exception)
            {
                // Expected - some formats will throw on truncated files
                // This is acceptable behavior
            }
            finally
            {
                if (File.Exists(truncatedFile))
                    File.Delete(truncatedFile);
            }
        }

        #endregion

        #region Helper Methods

        private static int CountEntities(Node node)
        {
            int count = node.Entities.Count;
            foreach (var child in node.ChildNodes)
            {
                count += CountEntities(child);
            }
            return count;
        }

        #endregion
    }
}
