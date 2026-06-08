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
            var color = new Vector3(0.5f, 0.5f, 0.5f);
            
            material.EmissiveColor = color;
            material.AmbientColor = color;
            material.DiffuseColor = color;
            material.TransparentColor = color;
            material.Transparency = 0.3;
            
            Assert.Equal(0.5f, material.EmissiveColor.X);
            Assert.Equal(0.5f, material.AmbientColor.X);
            Assert.Equal(0.5f, material.DiffuseColor.X);
            Assert.Equal(0.5f, material.TransparentColor.X);
            Assert.Equal(0.3, material.Transparency);
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
            var specularColor = new Vector3(0.8f, 0.8f, 0.8f);
            
            material.SpecularColor = specularColor;
            material.Shininess = 50.0;
            material.SpecularFactor = 1.0;
            material.ReflectionColor = new Vector3(0.2f, 0.2f, 0.2f);
            material.ReflectionFactor = 0.5;
            
            Assert.Equal(0.8f, material.SpecularColor.X);
            Assert.Equal(50.0, material.Shininess);
            Assert.Equal(1.0, material.SpecularFactor);
            Assert.Equal(0.2f, material.ReflectionColor.X);
            Assert.Equal(0.5, material.ReflectionFactor);
        }

        [Fact]
        public void PbrMaterial_DefaultConstructor_ShouldCreateInstance()
        {
            var material = new PbrMaterial();
            
            Assert.NotNull(material);
        }

        [Fact]
        public void PbrMaterial_AlbedoConstructor_ShouldCreateInstance()
        {
            var material = new PbrMaterial(new Vector3(1.0f, 0.5f, 0.2f));
            
            Assert.NotNull(material);
            Assert.Equal(1.0f, material.Albedo.X);
            Assert.Equal(0.5f, material.Albedo.Y);
            Assert.Equal(0.2f, material.Albedo.Z);
        }

        [Fact]
        public void PbrMaterial_Properties_ShouldBeSettable()
        {
            var material = new PbrMaterial();
            var albedo = new Vector3(1.0f, 0.5f, 0.2f);
            
            material.Albedo = albedo;
            material.MetallicFactor = 0.8;
            material.RoughnessFactor = 0.2;
            material.OcclusionFactor = 0.9;
            material.Transparency = 0.5;
            
            Assert.Equal(1.0f, material.Albedo.X);
            Assert.Equal(0.8, material.MetallicFactor);
            Assert.Equal(0.2, material.RoughnessFactor);
            Assert.Equal(0.9, material.OcclusionFactor);
            Assert.Equal(0.5, material.Transparency);
        }

        [Fact]
        public void PbrMaterial_FromMaterial_ShouldCreateInstance()
        {
            var material = new LambertMaterial();
            var pbr = PbrMaterial.FromMaterial(material);
            
            Assert.NotNull(pbr);
        }
    }
}
