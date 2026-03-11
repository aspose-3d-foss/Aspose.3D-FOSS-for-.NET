using System;
using Aspose.ThreeD;
using Xunit;

namespace Aspose.ThreeD.Tests
{
    /// <summary>
    /// Basic tests for Scene class
    /// </summary>
    public class SceneTests
    {
        [Fact]
        public void Scene_Constructor_InitializesWithRootNode()
        {
            // Arrange & Act
            var scene = new Scene();

            // Assert
            Assert.NotNull(scene.RootNode);
            Assert.Equal("RootNode", scene.RootNode.Name);
        }

        [Fact]
        public void Scene_ConstructorWithName_SetsName()
        {
            // Arrange & Act
            var scene = new Scene();
            scene.Name = "TestScene";

            // Assert
            Assert.Equal("TestScene", scene.Name);
        }

        [Fact]
        public void Scene_Clear_ResetsSceneContent()
        {
            // Arrange
            var scene = new Scene();
            scene.CreateAnimationClip("TestClip");

            // Act
            scene.Clear();

            // Assert
            Assert.Empty(scene.AnimationClips);
        }

        [Fact]
        public void Scene_CreateAnimationClip_AddsToCollection()
        {
            // Arrange
            var scene = new Scene();

            // Act
            var clip = scene.CreateAnimationClip("TestClip");

            // Assert
            Assert.Single(scene.AnimationClips);
            Assert.Equal("TestClip", clip.Name);
        }

        [Fact]
        public void Scene_GetAnimationClip_ReturnsClipIfExists()
        {
            // Arrange
            var scene = new Scene();
            scene.CreateAnimationClip("TestClip");

            // Act
            var clip = scene.GetAnimationClip("TestClip");

            // Assert
            Assert.NotNull(clip);
            Assert.Equal("TestClip", clip.Name);
        }

        [Fact]
        public void Scene_GetAnimationClip_ReturnsNullIfNotExists()
        {
            // Arrange
            var scene = new Scene();

            // Act
            var clip = scene.GetAnimationClip("NonExistent");

            // Assert
            Assert.Null(clip);
        }

        [Fact]
        public void Scene_Render_ThrowsNotImplementedException()
        {
            // Arrange
            var scene = new Scene();

            // Act & Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                scene.Render(null!, "output.png");
            });
        }
    }
}
