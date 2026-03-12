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
    internal class Microsoft3MFReader : IImporter
    {
        public Scene Import(Stream stream, LoadOptions options)
        {
            return Read(stream);
        }

        private static Scene Read(Stream stream)
        {
            var scene = new Scene();
            
            using var zip = new ZipArchive(stream, ZipArchiveMode.Read);
            
            var modelEntry = zip.GetEntry("3D/3dmodel.model");
            if (modelEntry == null)
                throw new InvalidOperationException("3D model file not found in 3MF archive");

            XDocument doc;
            using (var entryStream = modelEntry.Open())
            using (var reader = new StreamReader(entryStream))
            {
                doc = XDocument.Load(reader);
            }

            var ns = doc.Root!.Name.Namespace;
            
            var meshMap = new Dictionary<string, Mesh>();
            LoadMeshes(doc, ns, meshMap);
            
            var buildItems = ParseBuild(doc, ns, meshMap);
            
            foreach (var node in buildItems)
            {
                scene.RootNode.ChildNodes.Add(node);
            }

            return scene;
        }

        private static void LoadMeshes(XDocument doc, XNamespace ns, Dictionary<string, Mesh> meshMap)
        {
            var resourcesElement = doc.Root?.Element(ns + "resources");
            if (resourcesElement == null)
                return;

            foreach (var objectElement in resourcesElement.Elements(ns + "object"))
            {
                var id = objectElement.Attribute("id")?.Value;
                if (string.IsNullOrEmpty(id))
                    continue;

                var meshElement = objectElement.Element(ns + "mesh");
                if (meshElement == null)
                    continue;

                var mesh = ParseMesh(meshElement, ns);
                mesh.Name = objectElement.Attribute("name")?.Value ?? id;

                meshMap[id] = mesh;
            }
        }

        private static Mesh ParseMesh(XElement meshElement, XNamespace ns)
        {
            var mesh = new Mesh();

            var verticesElement = meshElement.Element(ns + "vertices");
            if (verticesElement != null)
            {
                foreach (var vertexElement in verticesElement.Elements(ns + "vertex"))
                {
                    var xAttr = vertexElement.Attribute("x");
                    var yAttr = vertexElement.Attribute("y");
                    var zAttr = vertexElement.Attribute("z");

                    var x = xAttr != null ? float.Parse(xAttr.Value) : 0;
                    var y = yAttr != null ? float.Parse(yAttr.Value) : 0;
                    var z = zAttr != null ? float.Parse(zAttr.Value) : 0;

                    mesh.ControlPoints.Add(new Vector4(x, y, z, 1f));
                }
            }

            foreach (var triangleElement in meshElement.Elements(ns + "triangle"))
            {
                var v1Attr = triangleElement.Attribute("v1");
                var v2Attr = triangleElement.Attribute("v2");
                var v3Attr = triangleElement.Attribute("v3");

                if (v1Attr == null || v2Attr == null || v3Attr == null)
                    continue;

                var v1 = int.Parse(v1Attr.Value);
                var v2 = int.Parse(v2Attr.Value);
                var v3 = int.Parse(v3Attr.Value);

                int[] triangle = { v1, v2, v3 };

                mesh.CreatePolygon(triangle);
            }

            return mesh;
        }

        private static List<Node> ParseBuild(XDocument doc, XNamespace ns, Dictionary<string, Mesh> meshMap)
        {
            var buildElement = doc.Root?.Element(ns + "build");
            if (buildElement == null)
                return new List<Node>();

            var nodes = new List<Node>();

            foreach (var itemElement in buildElement.Elements(ns + "item"))
            {
                var objectidAttr = itemElement.Attribute("objectid");
                if (objectidAttr == null)
                    continue;

                var objectId = objectidAttr.Value;
                
                if (meshMap.TryGetValue(objectId, out var mesh))
                {
                    var node = new Node($"Mesh_{objectId}", mesh);
                    nodes.Add(node);
                }
            }

            return nodes;
        }
    }
}
