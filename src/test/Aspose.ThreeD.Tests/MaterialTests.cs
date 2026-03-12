using Aspose.ThreeD.Shading;
using Aspose.ThreeD.Utilities;
using Xunit;

namespace Aspose.ThreeD.Tests
{
    public class MaterialTests
    {
        [Fact]
        public void LambertMaterial_DefaultConstructor_ShouldCreateInstance()
        {
            var material = new LambertMaterial();
            
            Assert.NotNull(material);
        }

        [Fact]
        public void LambertMaterial_NameConstructor_ShouldSetName()
        {
            var material = new LambertMaterial("TestMaterial");
            
            Assert.Equal("TestMaterial", material.Name);
        }

        [Fact]
        public void LambertMaterial_Properties_ShouldBeSettable()
        {
            var material = new LambertMaterial();
            var color = new Vector4(0.5f, 0.5f, 0.5f, 1.0f);
            
            material.Ambient = color;
            material.Diffuse = color;
            material.Emissive = color;
            material.Reflective = color;
            material.Reflectivity = 0.5f;
            material.Transparency = 0.3f;
            material.IndexOfRefraction = 1.5f;
            material.Texture = "texture.png";
            
            Assert.Equal(0.5f, material.Ambient.X);
            Assert.Equal(0.5f, material.Diffuse.X);
            Assert.Equal(0.5f, material.Emissive.X);
            Assert.Equal(0.5f, material.Reflective.X);
            Assert.Equal(0.5f, material.Reflectivity);
            Assert.Equal(0.3f, material.Transparency);
            Assert.Equal(1.5f, material.IndexOfRefraction);
            Assert.Equal("texture.png", material.Texture);
        }

        [Fact]
        public void PhongMaterial_DefaultConstructor_ShouldCreateInstance()
        {
            var material = new PhongMaterial();
            
            Assert.NotNull(material);
        }

        [Fact]
        public void PhongMaterial_NameConstructor_ShouldSetName()
        {
            var material = new PhongMaterial("PhongMaterial");
            
            Assert.Equal("PhongMaterial", material.Name);
        }

        [Fact]
        public void PhongMaterial_Properties_ShouldBeSettable()
        {
            var material = new PhongMaterial();
            var specular = new Vector4(0.8f, 0.8f, 0.8f, 1.0f);
            
            material.Specular = specular;
            material.Shininess = 50.0f;
            material.SpecularPower = 32.0f;
            
            Assert.Equal(0.8f, material.Specular.X);
            Assert.Equal(50.0f, material.Shininess);
            Assert.Equal(32.0f, material.SpecularPower);
        }

        [Fact]
        public void PbrMaterial_DefaultConstructor_ShouldCreateInstance()
        {
            var material = new PbrMaterial();
            
            Assert.NotNull(material);
        }

        [Fact]
        public void PbrMaterial_NameConstructor_ShouldSetName()
        {
            var material = new PbrMaterial("PbrMaterial");
            
            Assert.Equal("PbrMaterial", material.Name);
        }

        [Fact]
        public void PbrMaterial_Properties_ShouldBeSettable()
        {
            var material = new PbrMaterial();
            var baseColor = new Vector4(1.0f, 0.5f, 0.2f, 1.0f);
            
            material.BaseColor = baseColor;
            material.Metallic = 0.8f;
            material.Roughness = 0.2f;
            material.Occlusion = 0.9f;
            material.EmissiveTexture = "emissive.png";
            material.MetallicRoughnessTexture = "mrt.png";
            material.OcclusionTexture = "occlusion.png";
            material.NormalTexture = "normal.png";
            material.BaseColorTexture = "base.png";
            
            Assert.Equal(1.0f, material.BaseColor.X);
            Assert.Equal(0.8f, material.Metallic);
            Assert.Equal(0.2f, material.Roughness);
            Assert.Equal(0.9f, material.Occlusion);
            Assert.Equal("emissive.png", material.EmissiveTexture);
            Assert.Equal("mrt.png", material.MetallicRoughnessTexture);
            Assert.Equal("occlusion.png", material.OcclusionTexture);
            Assert.Equal("normal.png", material.NormalTexture);
            Assert.Equal("base.png", material.BaseColorTexture);
        }
    }
}
