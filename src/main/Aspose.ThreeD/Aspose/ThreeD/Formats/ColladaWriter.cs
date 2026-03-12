using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Collada (.dae) format writer
    /// </summary>
    internal class ColladaWriter : IExporter
    {
        public void Export(Scene scene, Stream stream, SaveOptions options)
        {
            if (options is ColladaSaveOptions saveOptions)
            {
                Write(stream, scene, saveOptions);
            }
            else
            {
                throw new ArgumentException("Options must be ColladaSaveOptions", nameof(options));
            }
        }

        private static void Write(Stream stream, Scene scene, ColladaSaveOptions options)
        {
            var doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"));
            var ns = "http://www.collada.org/2005/11/COLLADASchema";
            var root = new XElement(XName.Get("COLLADA", ns));
            root.Add(new XAttribute("xmlns", ns));
            root.Add(new XAttribute(XNamespace.Xmlns + "xs", "http://www.w3.org/2001/XMLSchema"));
            root.Add(new XAttribute(XNamespace.Xmlns + "xsi", "http://www.w3.org/2001/XMLSchema-instance"));
            root.Add(new XAttribute("version", "1.4.1"));
            doc.Add(root);

            WriteAsset(root, ns, scene);
            WriteLibraryGeometries(root, ns, scene);
            WriteLibraryMaterials(root, ns, scene);
            WriteLibraryEffects(root, ns, scene);
            WriteScene(root, ns, scene);

            var settings = new XmlWriterSettings
            {
                Indent = options.Indented,
                IndentChars = "    ",
                NewLineChars = "\n",
                NewLineOnAttributes = false,
                Encoding = new System.Text.UTF8Encoding(false)
            };

            using (var writer = XmlWriter.Create(stream, settings))
            {
                doc.Save(writer);
            }
        }

        private static void WriteAsset(XElement root, XNamespace ns, Scene scene)
        {
            var assetElement = new XElement(ns + "asset");
            root.Add(assetElement);

            var unitElement = new XElement(ns + "unit");
            unitElement.Add(new XAttribute("meter", "0.01"));
            unitElement.Add(new XAttribute("name", "centimeter"));
            assetElement.Add(unitElement);

            var upAxisElement = new XElement(ns + "up_axis");
            upAxisElement.Value = "Y_UP";
            assetElement.Add(upAxisElement);
        }

        private static void WriteLibraryGeometries(XElement root, XNamespace ns, Scene scene)
        {
            var libraryGeometries = new XElement(ns + "library_geometries");
            root.Add(libraryGeometries);

            var geometryMap = new Dictionary<string, Mesh>();
            CollectMeshes(scene.RootNode, geometryMap);

            // Create a mapping from geometry key to geometry ID
            var geometryIdMap = new Dictionary<string, int>();
            int geometryId = 0;
            foreach (var key in geometryMap.Keys)
            {
                geometryIdMap[key] = geometryId++;
            }

            // Write all geometries
            foreach (var kvp in geometryMap)
            {
                var meshEntity = kvp.Value;
                var geometryKey = kvp.Key;
                var geoId = geometryIdMap[geometryKey];
                WriteMeshGeometry(libraryGeometries, ns, meshEntity, geoId);
            }

            // Now we need to write visual scenes with the geometry map
            WriteLibraryVisualScenes(root, ns, scene, geometryIdMap);
        }

        private static void WriteMeshGeometry(XElement libraryGeometries, XNamespace ns, Mesh meshEntity, int geometryId)
        {
            var geometryElement = new XElement(ns + "geometry");
            var id = $"geometry-{geometryId}";
            geometryElement.Add(new XAttribute("id", id));
            geometryElement.Add(new XAttribute("name", meshEntity.Name ?? "Geometry"));

            var meshEl = new XElement(ns + "mesh");
            geometryElement.Add(meshEl);

            var positions = new List<float>();
            foreach (var cp in meshEntity.ControlPoints)
            {
                positions.Add((float)cp.X);
                positions.Add((float)cp.Y);
                positions.Add((float)cp.Z);
            }

            WriteSource(meshEl, ns, id, "positions", "X", "Y", "Z", positions.ToArray());

            var verticesElement = new XElement(ns + "vertices");
            verticesElement.Add(new XAttribute("id", $"{id}-vertices"));

            var positionInput = new XElement(ns + "input");
            positionInput.Add(new XAttribute("semantic", "POSITION"));
            positionInput.Add(new XAttribute("source", $"#{id}-positions"));
            verticesElement.Add(positionInput);
            meshEl.Add(verticesElement);

            var triangles = new List<int[]>();
            foreach (var poly in meshEntity.Polygons)
            {
                if (poly.Length >= 3)
                {
                    if (poly.Length == 3)
                    {
                        triangles.Add(poly);
                    }
                    else
                    {
                        for (int i = 1; i < poly.Length - 1; i++)
                        {
                            triangles.Add(new[] { poly[0], poly[i], poly[i + 1] });
                        }
                    }
                }
            }

            if (triangles.Count > 0)
            {
                var trianglesElement = new XElement(ns + "triangles");
                trianglesElement.Add(new XAttribute("count", triangles.Count.ToString()));
                trianglesElement.Add(new XAttribute("material", meshEntity.Name ?? "Material"));

                var vertexInput = new XElement(ns + "input");
                vertexInput.Add(new XAttribute("semantic", "VERTEX"));
                vertexInput.Add(new XAttribute("source", $"#{id}-vertices"));
                vertexInput.Add(new XAttribute("offset", "0"));
                trianglesElement.Add(vertexInput);

                var pElement = new XElement(ns + "p");
                var indexList = new List<int>();
                foreach (var tri in triangles)
                {
                    foreach (var idx in tri)
                    {
                        indexList.Add(idx);
                    }
                }
                pElement.Value = string.Join(" ", indexList.Select(v => v.ToString(System.Globalization.CultureInfo.InvariantCulture)));
                trianglesElement.Add(pElement);
                meshEl.Add(trianglesElement);
            }

            libraryGeometries.Add(geometryElement);
        }

        private static void WriteSource(XElement meshElement, XNamespace ns, string geometryId, string name, string paramX, string paramY, string paramZ, float[] data)
        {
            var sourceId = $"{geometryId}-{name}";
            var sourceElement = new XElement(ns + "source");
            sourceElement.Add(new XAttribute("id", sourceId));

            var floatArray = new XElement(ns + "float_array");
            floatArray.Add(new XAttribute("id", $"{sourceId}-array"));
            floatArray.Add(new XAttribute("count", data.Length.ToString()));
            floatArray.Value = string.Join(" ", data.Select(v => v.ToString(System.Globalization.CultureInfo.InvariantCulture)));
            sourceElement.Add(floatArray);

            var techniqueCommon = new XElement(ns + "technique_common");
            var accessor = new XElement(ns + "accessor");
            accessor.Add(new XAttribute("count", (data.Length / 3).ToString()));
            accessor.Add(new XAttribute("offset", "0"));
            accessor.Add(new XAttribute("source", $"#{sourceId}-array"));
            accessor.Add(new XAttribute("stride", "3"));

            var paramXElement = new XElement(ns + "param");
            paramXElement.Add(new XAttribute("name", paramX));
            paramXElement.Add(new XAttribute("type", "float"));
            accessor.Add(paramXElement);

            var paramYElement = new XElement(ns + "param");
            paramYElement.Add(new XAttribute("name", paramY));
            paramYElement.Add(new XAttribute("type", "float"));
            accessor.Add(paramYElement);

            var paramZElement = new XElement(ns + "param");
            paramZElement.Add(new XAttribute("name", paramZ));
            paramZElement.Add(new XAttribute("type", "float"));
            accessor.Add(paramZElement);

            techniqueCommon.Add(accessor);
            sourceElement.Add(techniqueCommon);
            meshElement.Add(sourceElement);
        }

        private static void CollectMeshes(Node node, Dictionary<string, Mesh> geometryMap)
        {
            foreach (var entity in node.Entities)
            {
                if (entity is Mesh entityMesh)
                {
                    var key = $"mesh-{entity.GetHashCode()}";
                    if (!geometryMap.ContainsKey(key))
                    {
                        geometryMap[key] = entityMesh;
                    }
                }
                else if (entity is Box box)
                {
                    var boxMesh = box.ToMesh();
                    if (!geometryMap.ContainsKey("Box"))
                    {
                        geometryMap["Box"] = boxMesh;
                    }
                }
                else if (entity is Cylinder cylinder)
                {
                    var cylinderMesh = cylinder.ToMesh();
                    if (!geometryMap.ContainsKey("Cylinder"))
                    {
                        geometryMap["Cylinder"] = cylinderMesh;
                    }
                }
                else if (entity is Sphere sphere)
                {
                    var sphereMesh = sphere.ToMesh();
                    if (!geometryMap.ContainsKey("Sphere"))
                    {
                        geometryMap["Sphere"] = sphereMesh;
                    }
                }
            }

            foreach (var childNode in node.ChildNodes)
            {
                CollectMeshes(childNode, geometryMap);
            }
        }

        private static void WriteLibraryMaterials(XElement root, XNamespace ns, Scene scene)
        {
            var libraryMaterials = new XElement(ns + "library_materials");
            root.Add(libraryMaterials);

            var materials = new HashSet<Shading.Material>();
            CollectMaterials(scene.RootNode, materials);

            int materialId = 0;
            foreach (var material in materials)
            {
                var materialElement = new XElement(ns + "material");
                var id = $"material-{materialId++}";
                materialElement.Add(new XAttribute("id", id));
                materialElement.Add(new XAttribute("name", material.Name ?? "Material"));

                var instanceEffect = new XElement(ns + "instance_effect");
                instanceEffect.Add(new XAttribute("url", $"#effect-{id}"));
                materialElement.Add(instanceEffect);

                libraryMaterials.Add(materialElement);
            }
        }

        private static void CollectMaterials(Node node, HashSet<Shading.Material> materials)
        {
            if (node.Material != null)
            {
                materials.Add(node.Material);
            }

            foreach (var childNode in node.ChildNodes)
            {
                CollectMaterials(childNode, materials);
            }
        }

        private static void WriteLibraryEffects(XElement root, XNamespace ns, Scene scene)
        {
            var libraryEffects = new XElement(ns + "library_effects");
            root.Add(libraryEffects);

            var materials = new HashSet<Shading.Material>();
            CollectMaterials(scene.RootNode, materials);

            foreach (var material in materials)
            {
                var materialId = $"material-{material.GetHashCode()}";
                WriteEffect(libraryEffects, ns, material, materialId);
            }
        }

        private static void WriteEffect(XElement libraryEffects, XNamespace ns, Shading.Material material, string materialId)
        {
            var effectElement = new XElement(ns + "effect");
            effectElement.Add(new XAttribute("id", $"effect-{materialId}"));

            var profileCommon = new XElement(ns + "profile_COMMON");
            effectElement.Add(profileCommon);

            var technique = new XElement(ns + "technique");
            technique.Add(new XAttribute("sid", "common"));
            profileCommon.Add(technique);

            var shaderType = new XElement(ns + "phong");
            technique.Add(shaderType);

            var diffuse = new XElement(ns + "diffuse");
            var color = new XElement(ns + "color");
            color.Value = "0.5 0.5 0.5 1";
            diffuse.Add(color);
            shaderType.Add(diffuse);

            var specular = new XElement(ns + "specular");
            var specColor = new XElement(ns + "color");
            specColor.Value = "0.5 0.5 0.5 1";
            specular.Add(specColor);
            shaderType.Add(specular);

            var shininess = new XElement(ns + "shininess");
            var floatVal = new XElement(ns + "float");
            floatVal.Value = "16";
            shininess.Add(floatVal);
            shaderType.Add(shininess);

            var transparent = new XElement(ns + "transparent");
            var transparentColor = new XElement(ns + "color");
            transparentColor.Value = "0 0 0 1";
            transparent.Add(transparentColor);
            shaderType.Add(transparent);

            var transparency = new XElement(ns + "transparency");
            var transparencyFloat = new XElement(ns + "float");
            transparencyFloat.Value = "1";
            transparency.Add(transparencyFloat);
            shaderType.Add(transparency);

            profileCommon.Add(technique);
            libraryEffects.Add(effectElement);
        }

        private static void WriteLibraryVisualScenes(XElement root, XNamespace ns, Scene scene, Dictionary<string, int> geometryIdMap)
        {
            var libraryVisualScenes = new XElement(ns + "library_visual_scenes");
            root.Add(libraryVisualScenes);

            var visualSceneElement = new XElement(ns + "visual_scene");
            visualSceneElement.Add(new XAttribute("id", "VisualSceneNode"));
            visualSceneElement.Add(new XAttribute("name", "untitled"));

            foreach (var childNode in scene.RootNode.ChildNodes)
            {
                WriteNode(visualSceneElement, ns, childNode, 0, geometryIdMap);
            }

            libraryVisualScenes.Add(visualSceneElement);
        }

        private static void WriteNode(XElement visualSceneElement, XNamespace ns, Node node, int depth, Dictionary<string, int> geometryIdMap)
        {
            var nodeElement = new XElement(ns + "node");
            var nodeId = $"node-{depth}";
            nodeElement.Add(new XAttribute("id", nodeId));
            nodeElement.Add(new XAttribute("name", node.Name ?? "Node"));

            var transform = node.Transform;

            if (transform != null)
            {
                if (transform.Translation != FVector3.Zero)
                {
                    var translateElement = new XElement(ns + "translate");
                    translateElement.Add(new XAttribute("sid", "translate"));
                    translateElement.Value = $"{transform.Translation.X} {transform.Translation.Y} {transform.Translation.Z}";
                    nodeElement.Add(translateElement);
                }

                if (transform.Rotation != Quaternion.Identity)
                {
                    var axis = new FVector3();
                    float angle = 0;

                    var q = transform.Rotation;
                    if (Math.Abs(q.W - 1.0f) < 1e-6f)
                    {
                        angle = 0;
                    }
                    else
                    {
                        angle = 2.0f * (float)Math.Acos(q.W);
                        float s = (float)Math.Sqrt(1.0 - q.W * q.W);
                        if (s > 1e-6f)
                        {
                            axis = new FVector3(q.X / s, q.Y / s, q.Z / s);
                        }
                        else
                        {
                            axis = new FVector3(1, 0, 0);
                        }
                    }

                    var rotateElement = new XElement(ns + "rotate");
                    rotateElement.Add(new XAttribute("sid", "rotate"));
                    rotateElement.Value = $"{axis.X} {axis.Y} {axis.Z} {angle * 180.0f / (float)Math.PI}";
                    nodeElement.Add(rotateElement);
                }

                if (transform.Scale != new FVector3(1, 1, 1))
                {
                    var scaleElement = new XElement(ns + "scale");
                    scaleElement.Add(new XAttribute("sid", "scale"));
                    scaleElement.Value = $"{transform.Scale.X} {transform.Scale.Y} {transform.Scale.Z}";
                    nodeElement.Add(scaleElement);
                }
            }

            foreach (var entity in node.Entities)
            {
                string geometryRef = null;
                if (entity is Mesh entityMesh)
                {
                    var key = $"mesh-{entity.GetHashCode()}";
                    if (geometryIdMap.TryGetValue(key, out int geoId))
                    {
                        geometryRef = $"#geometry-{geoId}";
                    }
                }
                else if (entity is Box)
                {
                    if (geometryIdMap.TryGetValue("Box", out int boxId))
                    {
                        geometryRef = $"#geometry-{boxId}";
                    }
                }
                else if (entity is Cylinder)
                {
                    if (geometryIdMap.TryGetValue("Cylinder", out int cylId))
                    {
                        geometryRef = $"#geometry-{cylId}";
                    }
                }
                else if (entity is Sphere)
                {
                    if (geometryIdMap.TryGetValue("Sphere", out int sphereId))
                    {
                        geometryRef = $"#geometry-{sphereId}";
                    }
                }

                if (geometryRef != null)
                {
                    WriteInstanceGeometry(nodeElement, ns, geometryRef);
                }
            }

            int childDepth = depth + 1;
            foreach (var childNode in node.ChildNodes)
            {
                WriteNode(nodeElement, ns, childNode, childDepth, geometryIdMap);
            }

            visualSceneElement.Add(nodeElement);
        }

        private static void WriteInstanceGeometry(XElement nodeElement, XNamespace ns, string geometryRef)
        {
            var instanceGeometry = new XElement(ns + "instance_geometry");
            instanceGeometry.Add(new XAttribute("url", geometryRef));

            var bindMaterial = new XElement(ns + "bind_material");
            var techniqueCommon = new XElement(ns + "technique_common");
            var instanceMaterial = new XElement(ns + "instance_material");
            instanceMaterial.Add(new XAttribute("symbol", "Material"));
            instanceMaterial.Add(new XAttribute("target", $"#material-0"));
            techniqueCommon.Add(instanceMaterial);
            bindMaterial.Add(techniqueCommon);
            instanceGeometry.Add(bindMaterial);
            nodeElement.Add(instanceGeometry);
        }

        private static void WriteScene(XElement root, XNamespace ns, Scene scene)
        {
            var sceneElement = new XElement(ns + "scene");
            root.Add(sceneElement);

            var instanceVisualScene = new XElement(ns + "instance_visual_scene");
            instanceVisualScene.Add(new XAttribute("url", "#VisualSceneNode"));
            sceneElement.Add(instanceVisualScene);
        }
    }
}
