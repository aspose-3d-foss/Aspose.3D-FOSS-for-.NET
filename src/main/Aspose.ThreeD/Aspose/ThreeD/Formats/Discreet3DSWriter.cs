using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Shading;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Internal class for exporting 3DS files.
    /// </summary>
    internal class Discreet3DSWriter : IExporter
    {
        private BinaryWriter _writer;
        private SaveOptions _options;
        private Scene _scene;
        private List<LambertMaterial> _materials;
        private Dictionary<string, int> _nameCounter;
        private int _duplicatedNameCounterBase;
        private string _duplicatedNameSeparator;
        private string _duplicatedNameCounterFormat;

        public void Export(Scene scene, Stream stream, SaveOptions options)
        {
            if (options is Discreet3dsSaveOptions discreetOptions)
            {
                _options = discreetOptions;
                Write(stream, scene, discreetOptions);
            }
            else
            {
                throw new ArgumentException("Options must be Discreet3dsSaveOptions", nameof(options));
            }
        }

        private void Write(Stream stream, Scene scene, Discreet3dsSaveOptions options)
        {
            _scene = scene;
            _writer = new BinaryWriter(stream, Encoding.ASCII);
            _materials = new List<LambertMaterial>();
            _nameCounter = new Dictionary<string, int>();
            _duplicatedNameCounterBase = options.DuplicatedNameCounterBase > 0 ? options.DuplicatedNameCounterBase : 2;
            _duplicatedNameSeparator = string.IsNullOrEmpty(options.DuplicatedNameSeparator) ? "_" : options.DuplicatedNameSeparator;
            _duplicatedNameCounterFormat = options.DuplicatedNameCounterFormat ?? "";

            // Write main chunk (0x4D4D)
            var mainChunkStart = _writer.BaseStream.Position;
            _writer.Write(ChunkConstants.CHUNK_MAIN);
            _writer.Write(0); // Placeholder for chunk size

            // Write editor chunk (0x3D3D) - main container for 3D data
            var editorChunkStart = _writer.BaseStream.Position;
            _writer.Write(ChunkConstants.CHUNK_OBJMESH);
            _writer.Write(0); // Placeholder for chunk size

            // Write scene materials
            WriteMaterials();

            // Write scene objects (nodes with meshes)
            WriteNodes(scene.RootNode);

            // Write lights if requested
            if (options.ExportLight)
            {
                WriteLights(scene.RootNode);
            }

            // Write cameras if requested
            if (options.ExportCamera)
            {
                WriteCameras(scene.RootNode);
            }

            // Fill in chunk sizes
            var currentPos = _writer.BaseStream.Position;
            var editorChunkSize = (uint)(currentPos - editorChunkStart);
            _writer.BaseStream.Seek(editorChunkStart + 2, SeekOrigin.Begin);
            _writer.Write(editorChunkSize);
            _writer.BaseStream.Seek(currentPos, SeekOrigin.Begin);

            // Fill in main chunk size
            currentPos = _writer.BaseStream.Position;
            var mainChunkSize = (uint)(currentPos - mainChunkStart);
            _writer.BaseStream.Seek(mainChunkStart + 2, SeekOrigin.Begin);
            _writer.Write(mainChunkSize);
            _writer.BaseStream.Seek(currentPos, SeekOrigin.Begin);
        }

        private void WriteMaterials()
        {
            // Collect materials from scene
            CollectMaterials(_scene.RootNode);

            if (_materials.Count == 0)
            {
                return;
            }

            // Write material chunk (0x3DAA)
            var mliChunkStart = _writer.BaseStream.Position;
            _writer.Write(ChunkConstants.CHUNK_MLI);
            _writer.Write(0); // Placeholder for chunk size

            // Write each material
            foreach (var material in _materials)
            {
                WriteMaterial(material);
            }

            // Fill in chunk size
            var currentPos = _writer.BaseStream.Position;
            var mliChunkSize = (uint)(currentPos - mliChunkStart);
            _writer.BaseStream.Seek(mliChunkStart + 2, SeekOrigin.Begin);
            _writer.Write(mliChunkSize);
            _writer.BaseStream.Seek(currentPos, SeekOrigin.Begin);
        }

        private void CollectMaterials(Node node)
        {
            foreach (var entity in node.Entities)
            {
                if (entity is Mesh mesh)
                {
                    // For now, we'll add default materials
                    // In a full implementation, we'd extract from mesh materials
                }
            }

            foreach (var childNode in node.ChildNodes)
            {
                CollectMaterials(childNode);
            }
        }

        private void WriteMaterial(LambertMaterial material)
        {
            var mtlChunkStart = _writer.BaseStream.Position;
            _writer.Write(ChunkConstants.CHUNK_MTL);
            _writer.Write(0); // Placeholder for chunk size

            // Write material name (0xA000)
            var nameStart = _writer.BaseStream.Position;
            _writer.Write(ChunkConstants.CHUNK_MTL_NAME);
            _writer.Write(0); // Placeholder for chunk size

            var nameBytes = Encoding.ASCII.GetBytes(material.Name ?? "Unnamed");
            _writer.Write(nameBytes);
            _writer.Write((byte)0); // Null terminator

            var currentPos = _writer.BaseStream.Position;
            var nameChunkSize = (uint)(currentPos - nameStart);
            _writer.BaseStream.Seek(nameStart + 2, SeekOrigin.Begin);
            _writer.Write(nameChunkSize);
            _writer.BaseStream.Seek(currentPos, SeekOrigin.Begin);

            // Write ambient color (0xA010)
            WriteColorChunk(ChunkConstants.CHUNK_MTL_AMBIENT, material.AmbientColor);

            // Write diffuse color (0xA020)
            WriteColorChunk(ChunkConstants.CHUNK_MTL_DIFFUSE, material.DiffuseColor);

            // Fill in chunk size
            currentPos = _writer.BaseStream.Position;
            var mtlChunkSize = (uint)(currentPos - mtlChunkStart);
            _writer.BaseStream.Seek(mtlChunkStart + 2, SeekOrigin.Begin);
            _writer.Write(mtlChunkSize);
            _writer.BaseStream.Seek(currentPos, SeekOrigin.Begin);
        }

        private void WriteColorChunk(ushort chunkId, Vector3 color)
        {
            var chunkStart = _writer.BaseStream.Position;
            _writer.Write(chunkId);
            _writer.Write(0); // Placeholder for chunk size

            _writer.Write((float)color.X);
            _writer.Write((float)color.Y);
            _writer.Write((float)color.Z);

            var currentPos = _writer.BaseStream.Position;
            var chunkSize = (uint)(currentPos - chunkStart);
            _writer.BaseStream.Seek(chunkStart + 2, SeekOrigin.Begin);
            _writer.Write(chunkSize);
            _writer.BaseStream.Seek(currentPos, SeekOrigin.Begin);
        }

        private void WriteNodes(Node node)
        {
            foreach (var entity in node.Entities)
            {
                if (entity is Mesh entityMesh)
                {
                    WriteMesh(node.Name ?? "Unnamed", entityMesh);
                }
                else if (entity is Primitive primitive)
                {
                    var mesh = primitive.ToMesh();
                    WriteMesh(node.Name ?? "Unnamed", mesh);
                }
            }

            foreach (var childNode in node.ChildNodes)
            {
                WriteNodes(childNode);
            }
        }

        private void WriteMesh(string name, Mesh mesh)
        {
            var nodeName = GetUniqueName(name);

            // Write object block (0x4000)
            var objBlockStart = _writer.BaseStream.Position;
            _writer.Write(ChunkConstants.CHUNK_OBJBLOCK);
            _writer.Write(0); // Placeholder for chunk size

            // Write object name (null-terminated ASCII)
            var nameBytes = Encoding.ASCII.GetBytes(nodeName);
            _writer.Write(nameBytes);
            _writer.Write((byte)0); // Null terminator

            // Write trimesh chunk (0x4100)
            var trimeshStart = _writer.BaseStream.Position;
            _writer.Write(ChunkConstants.CHUNK_TRIMESH);
            _writer.Write(0); // Placeholder for chunk size

            // Write vertex list (0x4110)
            WriteVertexList(mesh);

            // Write face list (0x4120)
            WriteFaceList(mesh);

            // Fill in trimesh chunk size
            var currentPos = _writer.BaseStream.Position;
            var trimeshSize = (uint)(currentPos - trimeshStart);
            _writer.BaseStream.Seek(trimeshStart + 2, SeekOrigin.Begin);
            _writer.Write(trimeshSize);
            _writer.BaseStream.Seek(currentPos, SeekOrigin.Begin);

            // Fill in object block chunk size
            currentPos = _writer.BaseStream.Position;
            var objBlockSize = (uint)(currentPos - objBlockStart);
            _writer.BaseStream.Seek(objBlockStart + 2, SeekOrigin.Begin);
            _writer.Write(objBlockSize);
            _writer.BaseStream.Seek(currentPos, SeekOrigin.Begin);
        }

        private void WriteVertexList(Mesh mesh)
        {
            var vertListStart = _writer.BaseStream.Position;
            _writer.Write(ChunkConstants.CHUNK_VERTLIST);
            _writer.Write(0); // Placeholder for chunk size

            var numVertices = mesh.ControlPoints.Count;
            var totalSize = 6 + (numVertices * 12) + 4; // Header + vertices + size field

            foreach (var cp in mesh.ControlPoints)
            {
                var x = (float)cp.X;
                var y = (float)cp.Y;
                var z = (float)cp.Z;

                // Flip coordinate system: FOSS uses Y-up, 3DS uses Z-up
                if (_options is Discreet3dsSaveOptions discreetOptions && discreetOptions.FlipCoordinateSystem)
                {
                    // Convert Y-up to Z-up: swap Y and Z, negate Z
                    var temp = y;
                    y = z;
                    z = -temp;
                }

                _writer.Write(x);
                _writer.Write(y);
                _writer.Write(z);
            }

            // Fill in chunk size
            var currentPos = _writer.BaseStream.Position;
            var chunkSize = (uint)(currentPos - vertListStart);
            _writer.BaseStream.Seek(vertListStart + 2, SeekOrigin.Begin);
            _writer.Write(chunkSize);
            _writer.BaseStream.Seek(currentPos, SeekOrigin.Begin);
        }

        private void WriteFaceList(Mesh mesh)
        {
            var faceListStart = _writer.BaseStream.Position;
            _writer.Write(ChunkConstants.CHUNK_FACELIST);
            _writer.Write(0); // Placeholder for chunk size

            var numFaces = mesh.PolygonCount;
            var totalSize = 6 + (numFaces * 8); // Header + faces (3 shorts + 1 flags each)

            foreach (var polygon in mesh.Polygons)
            {
                if (polygon.Length == 3)
                {
                    _writer.Write((ushort)polygon[0]);
                    _writer.Write((ushort)polygon[1]);
                    _writer.Write((ushort)polygon[2]);
                    _writer.Write((ushort)0); // Flags
                }
                else if (polygon.Length == 4)
                {
                    // Split quad into two triangles
                    _writer.Write((ushort)polygon[0]);
                    _writer.Write((ushort)polygon[1]);
                    _writer.Write((ushort)polygon[2]);
                    _writer.Write((ushort)0); // Flags

                    _writer.Write((ushort)polygon[0]);
                    _writer.Write((ushort)polygon[2]);
                    _writer.Write((ushort)polygon[3]);
                    _writer.Write((ushort)0); // Flags
                }
                else
                {
                    // Triangulate polygon
                    for (var i = 0; i < polygon.Length - 2; i++)
                    {
                        _writer.Write((ushort)polygon[0]);
                        _writer.Write((ushort)polygon[i + 1]);
                        _writer.Write((ushort)polygon[i + 2]);
                        _writer.Write((ushort)0); // Flags
                    }
                }
            }

            // Fill in chunk size
            var currentPos = _writer.BaseStream.Position;
            var chunkSize = (uint)(currentPos - faceListStart);
            _writer.BaseStream.Seek(faceListStart + 2, SeekOrigin.Begin);
            _writer.Write(chunkSize);
            _writer.BaseStream.Seek(currentPos, SeekOrigin.Begin);
        }

        private void WriteLights(Node node)
        {
            // Light export is stubbed for now
        }

        private void WriteCameras(Node node)
        {
            // Camera export is stubbed for now
        }

        private string GetUniqueName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "Unnamed";
            }

            if (!_nameCounter.ContainsKey(name))
            {
                _nameCounter[name] = 0;
                return name;
            }

            _nameCounter[name]++;
            var counter = _nameCounter[name] + _duplicatedNameCounterBase - 1;
            var formattedCounter = string.IsNullOrEmpty(_duplicatedNameCounterFormat)
                ? counter.ToString()
                : string.Format(_duplicatedNameCounterFormat, counter);

            return $"{name}{_duplicatedNameSeparator}{formattedCounter}";
        }
    }
}
