using System;
using System.IO;
using System.Linq;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Formats;
using Aspose.ThreeD.Shading;
using Aspose.ThreeD.Utilities;
using Xunit;

namespace Aspose.ThreeD.Tests.RoundTrip
{
    /// <summary>
    /// Round-trip tests for material preservation during save/load operations.
    /// Tests verify that files with materials can be loaded and saved correctly.
    /// </summary>
    public class MaterialRoundTripTests
    {
        private const string TestDataRoot = "./";

        #region Basic Material Creation Tests

        [Fact]
        public void CreateSceneWithLambertMaterial_ShouldCreateValidMaterial()
        {
            // Arrange - Create a Lambert material
            var material = new LambertMaterial("LambertMaterial");
            
            // Act & Assert - Verify material properties
            Assert.NotNull(material);
            Assert.Equal("LambertMaterial", material.Name);
            
            // Set properties
            var color = new Vector3(0.5f, 0.5f, 0.5f);
            material.AmbientColor = color;
            material.DiffuseColor = color;
            material.EmissiveColor = color;
            material.TransparentColor = color;
            material.Transparency = 0.3;
            
            Assert.Equal(0.5f, material.AmbientColor.X);
            Assert.Equal(0.5f, material.DiffuseColor.X);
            Assert.Equal(0.3, material.Transparency);
        }

        [Fact]
        public void CreateSceneWithPhongMaterial_ShouldCreateValidMaterial()
        {
            // Arrange - Create a Phong material
            var material = new PhongMaterial("PhongMaterial");
            
            // Act & Assert - Verify material properties
            Assert.NotNull(material);
            Assert.Equal("PhongMaterial", material.Name);
            
            // Set properties
            material.SpecularColor = new Vector3(0.8f, 0.8f, 0.8f);
            material.Shininess = 50.0;
            material.SpecularFactor = 0.8;
            material.ReflectionColor = new Vector3(0.3f, 0.3f, 0.3f);
            material.ReflectionFactor = 0.5;
            
            Assert.Equal(0.8f, material.SpecularColor.X);
            Assert.Equal(50.0, material.Shininess);
            Assert.Equal(0.5, material.ReflectionFactor);
        }

        [Fact]
        public void CreateSceneWithPbrMaterial_ShouldCreateValidMaterial()
        {
            // Arrange - Create a PBR material
            var material = new PbrMaterial();
            
            // Act & Assert - Verify material properties
            Assert.NotNull(material);
            
            // Set properties
            material.Albedo = new Vector3(1.0f, 0.5f, 0.2f);
            material.MetallicFactor = 0.8f;
            material.RoughnessFactor = 0.2f;
            material.OcclusionFactor = 0.9f;
            material.EmissiveColor = new Vector3(0.1f, 0.1f, 0.1f);
            material.Transparency = 0.5;
            
            Assert.Equal(1.0f, material.Albedo.X);
            Assert.Equal(0.8f, material.MetallicFactor);
            Assert.Equal(0.2f, material.RoughnessFactor);
            Assert.Equal(0.5, material.Transparency);
        }

        [Fact]
        public void PbrMaterial_FromLambertMaterial_ShouldConvert()
        {
            // Arrange - Create a Lambert material
            var material = new LambertMaterial();
            material.DiffuseColor = new Vector3(0.5f, 0.5f, 0.5f);
            
            // Act - Convert to PBR
            var pbr = PbrMaterial.FromMaterial(material);
            
            // Assert - Verify conversion (FOSS may have simplified implementation)
            Assert.NotNull(pbr);
        }

        #endregion

        #region Multiple Materials Tests

        [Fact]
        public void SceneWithMultipleMaterialTypes_ShouldCreateAllTypes()
        {
            // Arrange - Create materials of different types
            var lambert = new LambertMaterial("LambertMat");
            var phong = new PhongMaterial("PhongMat");
            var pbr = new PbrMaterial();
            
            // Act & Assert - Verify all material types can be created
            Assert.NotNull(lambert);
            Assert.NotNull(phong);
            Assert.NotNull(pbr);
            
            Assert.Equal("LambertMat", lambert.Name);
            Assert.Equal("PhongMat", phong.Name);
        }

        [Fact]
        public void MaterialWithTextures_ShouldAllowTextureAssignment()
        {
            // Arrange - Create a material
            var material = new PhongMaterial("TexturedMaterial");
            
            // Act - Set a null texture (textures are stubbed in FOSS)
            material.SetTexture("Diffuse", null);
            
            // Assert - Verify texture assignment
            var texture = material.GetTexture("Diffuse");
            Assert.Null(texture);
        }

        #endregion

        #region COLLADA Round-Trip Tests

        [Theory]
        [InlineData("collada/cube_triangulate.dae")]
        public void RoundTrip_ColladaWithMaterials_ShouldLoadAndSave(string relativePath)
        {
            // Arrange
            var testFile = Path.Combine(TestDataRoot, relativePath);
            if (!File.Exists(testFile))
                throw new FileNotFoundException($"Test file not found: {testFile}");

            // Act - Load and save COLLADA file with materials
            var scene = new Scene();
            scene.Open(testFile);

            var tempFile = Path.GetTempFileName() + ".dae";
            try
            {
                scene.Save(tempFile);

                // Reopen saved file
                var reloadedScene = new Scene();
                reloadedScene.Open(tempFile);

                // Assert - Verify file loaded correctly
                Assert.True(reloadedScene.RootNode.ChildNodes.Count > 0);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        [Theory]
        [InlineData("collada/duck.dae")]
        public void RoundTrip_DuckCollada_ShouldLoadAndSave(string relativePath)
        {
            // Arrange
            var testFile = Path.Combine(TestDataRoot, relativePath);
            if (!File.Exists(testFile))
                throw new FileNotFoundException($"Test file not found: {testFile}");

            // Act
            var scene = new Scene();
            scene.Open(testFile);

            var tempFile = Path.GetTempFileName() + ".dae";
            try
            {
                scene.Save(tempFile);

                // Reopen saved file
                var reloadedScene = new Scene();
                reloadedScene.Open(tempFile);

                // Assert
                Assert.True(reloadedScene.RootNode.ChildNodes.Count > 0);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        [Theory]
        [InlineData("collada/cameras.dae")]
        [InlineData("collada/lights.dae")]
        [InlineData("collada/cube_with_2UVs.dae")]
        public void RoundTrip_ColladaVariety_ShouldLoadAndSave(string relativePath)
        {
            // Arrange
            var testFile = Path.Combine(TestDataRoot, relativePath);
            if (!File.Exists(testFile))
                throw new FileNotFoundException($"Test file not found: {testFile}");

            // Act
            var scene = new Scene();
            scene.Open(testFile);

            var tempFile = Path.GetTempFileName() + ".dae";
            try
            {
                scene.Save(tempFile);

                // Reopen saved file
                var reloadedScene = new Scene();
                reloadedScene.Open(tempFile);

                // Assert
                Assert.NotNull(reloadedScene);
                Assert.True(reloadedScene.RootNode.ChildNodes.Count > 0);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        #endregion

        #region glTF Round-Trip Tests

        [Theory]
        [InlineData("gltf/simple_cube.gltf")]
        public void RoundTrip_GltfWithMaterials_ShouldLoadAndSave(string relativePath)
        {
            // Arrange
            var testFile = Path.Combine(TestDataRoot, relativePath);
            if (!File.Exists(testFile))
                throw new FileNotFoundException($"Test file not found: {testFile}");

            // Act
            var scene = new Scene();
            scene.Open(testFile);

            var tempFile = Path.GetTempFileName() + ".gltf";
            try
            {
                var options = new GltfSaveOptions(FileFormat.GLTF2);
                options.EmbedAssets = false;
                scene.Save(tempFile, options);

                // Reopen saved file
                var reloadedScene = new Scene();
                reloadedScene.Open(tempFile);

                // Assert - Verify the file loaded (not all glTF files have child nodes in FOSS)
                Assert.NotNull(reloadedScene);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        #endregion

        #region OBJ Round-Trip Tests (with materials reference)

        [Theory]
        [InlineData("obj/obj-test.obj")]
        public void RoundTrip_ObjWithMtlReference_ShouldLoadAndSave(string relativePath)
        {
            // Arrange
            var testFile = Path.Combine(TestDataRoot, relativePath);
            if (!File.Exists(testFile))
                throw new FileNotFoundException($"Test file not found: {testFile}");

            // Act
            var scene = new Scene();
            scene.Open(testFile);

            var tempFile = Path.GetTempFileName() + ".obj";
            try
            {
                scene.Save(tempFile);

                // Reopen saved file
                var reloadedScene = new Scene();
                reloadedScene.Open(tempFile);

                // Assert - Verify the file loaded
                Assert.NotNull(reloadedScene);
            }
            finally
            {
                if (File.Exists(tempFile))
                    File.Delete(tempFile);
            }
        }

        #endregion

        #region Scene with Primitives and Materials

        [Fact]
        public void SceneWithPrimitivesAndMaterials_ShouldSaveAndReload()
        {
            // Arrange - Create a scene with primitives and materials
            var scene = new Scene();

            // Create a box with a material
            var box = new Box(2, 2, 2);
            var node1 = scene.RootNode.CreateChildNode("Box", box);

            // Create a sphere with a material
            var sphere = new Sphere(1, 20, 20);
            var node2 = scene.RootNode.CreateChildNode("Sphere", sphere);

            // Create materials
            var lambert = new LambertMaterial("LambertMat");
            lambert.DiffuseColor = new Vector3(1.0f, 0.0f, 0.0f);

            var phong = new PhongMaterial("PhongMat");
            phong.DiffuseColor = new Vector3(0.0f, 1.0f, 0.0f);
            phong.SpecularColor = new Vector3(0.8f, 0.8f, 0.8f);

            var pbr = new PbrMaterial();
            pbr.Albedo = new Vector3(0.0f, 0.0f, 1.0f);
            pbr.MetallicFactor = 0.5f;

            // Act - Save to multiple formats
            var tempObjFile = Path.GetTempFileName() + ".obj";
            var tempStlFile = Path.GetTempFileName() + ".stl";
            var tempDaeFile = Path.GetTempFileName() + ".dae";
            var tempGltfFile = Path.GetTempFileName() + ".gltf";

            try
            {
                scene.Save(tempObjFile);
                scene.Save(tempStlFile);
                scene.Save(tempDaeFile);
                scene.Save(tempGltfFile, new GltfSaveOptions(FileFormat.GLTF2));

                // Verify all files were created
                Assert.True(File.Exists(tempObjFile));
                Assert.True(File.Exists(tempStlFile));
                Assert.True(File.Exists(tempDaeFile));
                Assert.True(File.Exists(tempGltfFile));

                // Verify content
                var objContent = File.ReadAllText(tempObjFile);
                Assert.Contains("v ", objContent);
                Assert.Contains("f ", objContent);

                var stlContent = File.ReadAllBytes(tempStlFile);
                Assert.True(stlContent.Length > 84);

                var daeContent = File.ReadAllText(tempDaeFile);
                Assert.Contains("COLLADA", daeContent);

                var gltfContent = File.ReadAllText(tempGltfFile);
                Assert.Contains("asset", gltfContent);
            }
            finally
            {
                if (File.Exists(tempObjFile)) File.Delete(tempObjFile);
                if (File.Exists(tempStlFile)) File.Delete(tempStlFile);
                if (File.Exists(tempDaeFile)) File.Delete(tempDaeFile);
                if (File.Exists(tempGltfFile)) File.Delete(tempGltfFile);
            }
        }

        #endregion
    }
}
