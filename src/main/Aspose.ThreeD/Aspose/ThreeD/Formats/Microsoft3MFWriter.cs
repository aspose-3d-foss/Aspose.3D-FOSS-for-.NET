using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Xml.Linq;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    internal class Microsoft3MFWriter : IExporter
    {
        public void Export(Scene scene, Stream stream, SaveOptions options)
        {
            if (options is Microsoft3MFSaveOptions tmfOptions)
            {
                Write(stream, scene, tmfOptions);
            }
            else
            {
                throw new ArgumentException("Options must be Microsoft3MFSaveOptions", nameof(options));
            }
        }

        private static void Write(Stream stream, Scene scene, Microsoft3MFSaveOptions options)
        {
            using var zip = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen: true);

            var contentTypesEntry = zip.CreateEntry("[Content_Types].xml");
            using (var entryStream = contentTypesEntry.Open())
            using (var writer = new StreamWriter(entryStream, leaveOpen: true))
            {
                writer.Write(ContentTypesXml);
            }

            var relsEntry = zip.CreateEntry("_rels/.rels");
            using (var entryStream = relsEntry.Open())
            using (var writer = new StreamWriter(entryStream, leaveOpen: true))
            {
                writer.Write(RelsXml);
            }

            var model3DDir = zip.CreateEntry("3D/3dmodel.model");
            using (var entryStream = model3DDir.Open())
            using (var writer = new StreamWriter(entryStream, leaveOpen: true))
            {
                var xml = Generate3DModelXml(scene, options);
                writer.Write(xml);
            }
        }

        private static string Generate3DModelXml(Scene scene, Microsoft3MFSaveOptions options)
        {
            var ns = XNamespace.Get("http://schemas.microsoft.com/3dmanufacturing/core/2015/02");
            var modelElement = new XElement(ns + "model");
            modelElement.SetAttributeValue("unit", "millimeter");
            modelElement.SetAttributeValue(XNamespace.Xml + "lang", "en-US");

            var resourcesElement = new XElement(ns + "resources");
            
            var meshes = ExtractMeshes(scene);
            
            var objectId = 1;
            foreach (var meshKvp in meshes)
            {
                var mesh = meshKvp.Value;
                var objectElement = new XElement(ns + "object");
                objectElement.SetAttributeValue("id", objectId);
                objectElement.SetAttributeValue("type", "model");
                if (!string.IsNullOrEmpty(mesh.Name))
                {
                    objectElement.SetAttributeValue("name", mesh.Name);
                }

                var meshElement = GenerateMeshElement(mesh, ns);
                objectElement.Add(meshElement);
                resourcesElement.Add(objectElement);

                objectId++;
            }

            modelElement.Add(resourcesElement);

            var buildElement = new XElement(ns + "build");
            objectId = 1;
            foreach (var meshKvp in meshes)
            {
                var itemElement = new XElement(ns + "item");
                itemElement.SetAttributeValue("objectid", objectId);
                buildElement.Add(itemElement);
                objectId++;
            }

            modelElement.Add(buildElement);

            var doc = new XDocument(modelElement);
            using (var sw = new StringWriter())
            {
                doc.Save(sw);
                return sw.ToString();
            }
        }

        private static List<KeyValuePair<string, Mesh>> ExtractMeshes(Scene scene)
        {
            var meshList = new List<KeyValuePair<string, Mesh>>();
            var uniqueMeshes = new HashSet<Mesh>();
            var meshCounter = 0;

            Node node = scene.RootNode;
            var stack = new Stack<Node>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                foreach (var entity in current.Entities)
                {
                    if (entity is Mesh mesh)
                    {
                        if (uniqueMeshes.Add(mesh))
                        {
                            string key = $"Mesh_{meshCounter}";
                            meshList.Add(new KeyValuePair<string, Mesh>(key, mesh));
                            meshCounter++;
                        }
                    }
                    else if (entity is Primitive primitive)
                    {
                        var meshFromPrimitive = primitive.ToMesh();
                        if (uniqueMeshes.Add(meshFromPrimitive))
                        {
                            string key = $"Mesh_{meshCounter}";
                            meshList.Add(new KeyValuePair<string, Mesh>(key, meshFromPrimitive));
                            meshCounter++;
                        }
                    }
                }

                foreach (var child in current.ChildNodes)
                {
                    stack.Push(child);
                }
            }

            return meshList;
        }

        private static XElement GenerateMeshElement(Mesh mesh, XNamespace ns)
        {
            var meshElement = new XElement(ns + "mesh");

            var verticesElement = new XElement(ns + "vertices");
            foreach (var controlPoint in mesh.ControlPoints)
            {
                var vertexElement = new XElement(ns + "vertex");
                var x = controlPoint.X;
                var y = controlPoint.Y;
                var z = controlPoint.Z;
                vertexElement.SetAttributeValue("x", x);
                vertexElement.SetAttributeValue("y", y);
                vertexElement.SetAttributeValue("z", z);
                verticesElement.Add(vertexElement);
            }

            if (verticesElement.HasElements)
            {
                meshElement.Add(verticesElement);
            }

            var trianglesElement = new XElement(ns + "triangles");
            foreach (var polygon in mesh.Polygons)
            {
                if (polygon.Length == 3)
                {
                    var triangleElement = new XElement(ns + "triangle");
                    triangleElement.SetAttributeValue("v1", polygon[0]);
                    triangleElement.SetAttributeValue("v2", polygon[1]);
                    triangleElement.SetAttributeValue("v3", polygon[2]);
                    trianglesElement.Add(triangleElement);
                }
                else if (polygon.Length == 4)
                {
                    var triangle1 = new XElement(ns + "triangle");
                    triangle1.SetAttributeValue("v1", polygon[0]);
                    triangle1.SetAttributeValue("v2", polygon[1]);
                    triangle1.SetAttributeValue("v3", polygon[2]);
                    trianglesElement.Add(triangle1);

                    var triangle2 = new XElement(ns + "triangle");
                    triangle2.SetAttributeValue("v1", polygon[0]);
                    triangle2.SetAttributeValue("v2", polygon[2]);
                    triangle2.SetAttributeValue("v3", polygon[3]);
                    trianglesElement.Add(triangle2);
                }
                else
                {
                    for (int i = 1; i < polygon.Length - 1; i++)
                    {
                        var triangleElement = new XElement(ns + "triangle");
                        triangleElement.SetAttributeValue("v1", polygon[0]);
                        triangleElement.SetAttributeValue("v2", polygon[i]);
                        triangleElement.SetAttributeValue("v3", polygon[i + 1]);
                        trianglesElement.Add(triangleElement);
                    }
                }
            }

            if (trianglesElement.HasElements)
            {
                meshElement.Add(trianglesElement);
            }

            return meshElement;
        }

        private const string ContentTypesXml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<Types xmlns=""http://schemas.openxmlformats.org/package/2006/content-types"">
  <Default Extension=""rels"" ContentType=""application/vnd.openxmlformats-package.relationships+xml"" />
  <Default Extension=""model"" ContentType=""application/vnd.ms-package.3dmanufacturing-3dmodel+xml"" />
</Types>";

        private const string RelsXml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">
  <Relationship Target="" /3D/3dmodel.model"" Id=""rel0"" Type=""http://schemas.microsoft.com/3dmanufacturing/2013/01/3dmodel"" />
</Relationships>";
    }
}
