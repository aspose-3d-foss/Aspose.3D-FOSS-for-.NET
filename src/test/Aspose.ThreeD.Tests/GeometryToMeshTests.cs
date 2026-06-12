using System;
using System.IO;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Formats;
using Aspose.ThreeD.Utilities;
using Xunit;

namespace Aspose.ThreeD.Tests;

/// <summary>
/// Tests for geometry ToMesh() method
/// </summary>
public class GeometryToMeshTests
{
    private const string TestOutputDir = "../../../../../testdata/output/geometry";
    
    public GeometryToMeshTests()
    {
        Directory.CreateDirectory(TestOutputDir);
    }
    
    private void SaveMeshToObj(Mesh mesh, string filename)
    {
        var scene = new Scene();
        var node = new Node();
        node.Entity = mesh;
        scene.RootNode.ChildNodes.Add(node);
        
        var path = Path.Combine(TestOutputDir, filename);
        scene.Save(path, new ObjSaveOptions());
    }
    
    [Fact]
    public void Box_ToMesh_ShouldCreateMesh()
    {
        var box = new Box(10, 20, 30);
        var mesh = box.ToMesh();
        
        Assert.NotNull(mesh);
        Assert.Equal(8, mesh.ControlPoints.Count);
        
        SaveMeshToObj(mesh, "Box.obj");
    }
    
    [Fact]
    public void Cylinder_ToMesh_ShouldCreateMesh()
    {
        var cylinder = new Cylinder(5, 5, 20);
        var mesh = cylinder.ToMesh();
        
        Assert.NotNull(mesh);
        Assert.True(mesh.ControlPoints.Count > 0);
        
        SaveMeshToObj(mesh, "Cylinder.obj");
    }
    
    [Fact]
    public void Sphere_ToMesh_ShouldCreateMesh()
    {
        var sphere = new Sphere(10, 32, 16);
        var mesh = sphere.ToMesh();
        
        Assert.NotNull(mesh);
        Assert.True(mesh.ControlPoints.Count > 0);
        
        SaveMeshToObj(mesh, "Sphere.obj");
    }
    
    [Fact]
    public void Pyramid_ToMesh_ShouldCreateMesh()
    {
        var pyramid = new Pyramid(10, 10, 20);
        var mesh = pyramid.ToMesh();
        
        Assert.NotNull(mesh);
        Assert.True(mesh.ControlPoints.Count >= 4);
        
        SaveMeshToObj(mesh, "Pyramid.obj");
    }
    
    [Fact]
    public void Torus_ToMesh_ShouldCreateMesh()
    {
        var torus = new Torus(10, 3);
        var mesh = torus.ToMesh();
        
        Assert.NotNull(mesh);
        Assert.True(mesh.ControlPoints.Count > 0);
        
        SaveMeshToObj(mesh, "Torus.obj");
    }
    
    [Fact]
    public void Dish_ToMesh_ShouldCreateMesh()
    {
        var dish = new Dish(10, 5);
        var mesh = dish.ToMesh();
        
        Assert.NotNull(mesh);
        Assert.True(mesh.ControlPoints.Count > 0);
        
        SaveMeshToObj(mesh, "Dish.obj");
    }
    
    [Fact]
    public void Mesh_ToMesh_ShouldReturnSameMesh()
    {
        var mesh = new Mesh();
        mesh.CreatePolygon(new int[] { 0, 1, 2 });
        
        var result = mesh.ToMesh();
        
        Assert.NotNull(result);
        Assert.Equal(mesh, result);
    }
}
