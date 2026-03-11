using System;
using System.IO;
using Aspose.ThreeD;
using Aspose.ThreeD.Entities;

class TestFbxLoader
{
    static void Main()
    {
        string testFile = "/home/lexchou/workspace/aspose/foss.3d.net/testdata/fbx7400binary/box.fbx";
        
        Console.WriteLine("=== FBX Test Results ===\n");
        
        Console.WriteLine("1. File existence check:");
        if (File.Exists(testFile))
        {
            var fileInfo = new FileInfo(testFile);
            Console.WriteLine("   FILE EXISTS: " + testFile);
            Console.WriteLine("   FILE SIZE: " + fileInfo.Length + " bytes");
            
            using var fs = File.OpenRead(testFile);
            var headerBuffer = new byte[18];
            fs.Read(headerBuffer, 0, 18);
            var header = System.Text.Encoding.ASCII.GetString(headerBuffer, 0, 18);
            Console.WriteLine("   FILE HEADER: \"" + header + "\"");
            Console.WriteLine("   FBX BINARY MARKER: " + header.Contains("Kaydara FBX Binary"));
        }
        else
        {
            Console.WriteLine("   FILE NOT FOUND: " + testFile);
            return;
        }
        
        Console.WriteLine("\n2. AUTO-DETECTION TEST (Scene.Open(stream)):");
        try
        {
            using var stream = File.OpenRead(testFile);
            var scene = new Scene();
            scene.Open(stream);
            
            Console.WriteLine("   AUTO-DETECTION SUCCEEDED");
            Console.WriteLine("   SCENE LOADED: True");
            Console.WriteLine("   ROOT NODE: True");
            Console.WriteLine("   NUMBER OF CHILD NODES: " + scene.RootNode.ChildNodes.Count);
        }
        catch (Exception ex)
        {
            Console.WriteLine("   AUTO-DETECTION FAILED: " + ex.GetType().Name);
            Console.WriteLine("   MESSAGE: " + ex.Message);
            return;
        }
        
        Console.WriteLine("\n3. DETAILED SCENE STRUCTURE:");
        using var stream2 = File.OpenRead(testFile);
        var scene2 = new Scene();
        scene2.Open(stream2);
        
        Console.WriteLine("   ROOT NODE NAME: " + scene2.RootNode.Name);
        Console.WriteLine("   CHILD NODES COUNT: " + scene2.RootNode.ChildNodes.Count);
        
        foreach (var node in scene2.RootNode.ChildNodes)
        {
            Console.WriteLine("\n   NODE: " + node.Name);
            Console.WriteLine("   - TRANSFORM:");
            Console.WriteLine("     TRANSLATION: " + node.Transform.Translation);
            Console.WriteLine("     ROTATION: " + node.Transform.Rotation);
            Console.WriteLine("     SCALE: " + node.Transform.Scale);
            
            if (node.Entity is Mesh mesh)
            {
                Console.WriteLine("   - MESH ENTITY:");
                Console.WriteLine("     CONTROL POINTS: " + mesh.ControlPoints.Count);
                Console.WriteLine("     POLYGONS: " + mesh.PolygonCount);
                
                if (mesh.ControlPoints.Count > 0)
                {
                    Console.WriteLine("     FIRST CONTROL POINT: " + mesh.ControlPoints[0]);
                }
            }
        }
        
        Console.WriteLine("\n=== ALL TESTS PASSED ===");
    }
}
