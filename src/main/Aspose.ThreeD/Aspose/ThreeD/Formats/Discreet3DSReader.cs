using System;
using System.Collections.Generic;
using System.IO;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Shading;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Internal class for importing 3DS files.
    /// </summary>
    internal class Discreet3DSReader : IImporter
    {
        private BinaryReader _reader;
        private LoadOptions _options;
        private Scene _scene;
        private Node _rootNode;
        private List<LambertMaterial> _materials;
        private List<Mesh> _meshes;
        private List<Node> _nodes;
        private Dictionary<string, int> _meshIndexMap;
        private Dictionary<string, int> _nodeIndexMap;
        private float _masterScale;

        public Scene Import(Stream stream, LoadOptions options)
        {
            _options = options;
            _scene = new Scene();
            _rootNode = _scene.RootNode;
            _materials = new List<LambertMaterial>();
            _meshes = new List<Mesh>();
            _nodes = new List<Node>();
            _meshIndexMap = new Dictionary<string, int>();
            _nodeIndexMap = new Dictionary<string, int>();
            _masterScale = 1.0f;

            _reader = new BinaryReader(stream);

            // Read and parse the main chunk
            ParseMainChunk();

            // Create the node hierarchy
            CreateNodeHierarchy();

            return _scene;
        }

        private void ParseMainChunk()
        {
            var chunk = ChunkHelper.ReadChunk(_reader);

            if (chunk.Id != ChunkConstants.CHUNK_MAIN)
            {
                throw new InvalidOperationException("Invalid 3DS file: expected main chunk");
            }

            var startPosition = _reader.BaseStream.Position;
            while (_reader.BaseStream.Position - startPosition < chunk.Size - 6)
            {
                var subChunk = ChunkHelper.ReadChunk(_reader);
                ParseMainSubChunk(subChunk);
            }
        }

        private void ParseMainSubChunk(ChunkHelper.Chunk subChunk)
        {
            switch (subChunk.Id)
            {
                case ChunkConstants.CHUNK_OBJMESH:
                    ParseEditorChunk(subChunk);
                    break;
                case ChunkConstants.CHUNK_MLI:
                    ParseMaterialChunk();
                    break;
                case ChunkConstants.CHUNK_PRJ:
                    ChunkHelper.SkipChunk(_reader, subChunk);
                    break;
                default:
                    ChunkHelper.SkipChunk(_reader, subChunk);
                    break;
            }
        }

        private void ParseEditorChunk(ChunkHelper.Chunk objmeshChunk)
        {
            var startPosition = _reader.BaseStream.Position;
            var endPosition = startPosition + objmeshChunk.Size - 6;

            while (_reader.BaseStream.Position < endPosition)
            {
                var subChunk = ChunkHelper.ReadChunk(_reader);
                ParseEditorSubChunk(subChunk, endPosition);
            }
        }

        private void ParseEditorSubChunk(ChunkHelper.Chunk subChunk, long objblockEndPosition)
        {
            switch (subChunk.Id)
            {
                case ChunkConstants.CHUNK_OBJBLOCK:
                    ParseObjectChunk(objblockEndPosition);
                    break;
                default:
                    ChunkHelper.SkipChunk(_reader, subChunk);
                    break;
            }
        }

        private void ParseObjectChunk(long objblockEndPosition)
        {
            var name = ChunkHelper.ReadString(_reader);
            Mesh mesh = null;

            // Continue parsing type chunks until OBJBLOCK ends
            while (_reader.BaseStream.Position < objblockEndPosition)
            {
                var subChunk = ChunkHelper.ReadChunk(_reader);
                ParseTypeChunk(subChunk, ref mesh);
            }

            Node node = _rootNode.CreateChildNode(name);
            if (mesh != null)
            {
                node.AddEntity(mesh);
            }
            _nodes.Add(node);
            _nodeIndexMap[name] = _nodes.Count - 1;
        }

        private void ParseTypeChunk(ChunkHelper.Chunk subChunk, ref Mesh mesh)
        {
            switch (subChunk.Id)
            {
                case ChunkConstants.CHUNK_TRIMESH:
                    mesh = new Mesh("Unnamed");
                    _meshes.Add(mesh);

                    var typeChunkEnd = _reader.BaseStream.Position + subChunk.Size - 6;
                    while (_reader.BaseStream.Position < typeChunkEnd)
                    {
                        var meshSubChunk = ChunkHelper.ReadChunk(_reader);
                        ParseMeshSubChunk(mesh, meshSubChunk);
                    }
                    break;
                case ChunkConstants.CHUNK_LIGHT:
                    var lightEnd = _reader.BaseStream.Position + subChunk.Size - 6;
                    while (_reader.BaseStream.Position < lightEnd)
                    {
                        ChunkHelper.SkipChunk(_reader, ChunkHelper.ReadChunk(_reader));
                    }
                    break;
                case ChunkConstants.CHUNK_CAMERA:
                    var cameraEnd = _reader.BaseStream.Position + subChunk.Size - 6;
                    while (_reader.BaseStream.Position < cameraEnd)
                    {
                        ChunkHelper.SkipChunk(_reader, ChunkHelper.ReadChunk(_reader));
                    }
                    break;
                default:
                    ChunkHelper.SkipChunk(_reader, subChunk);
                    break;
            }
        }

        private void ParseMeshSubChunk(Mesh mesh, ChunkHelper.Chunk subChunk)
        {
            switch (subChunk.Id)
            {
                case ChunkConstants.CHUNK_VERTLIST:
                    ParseVertexList(mesh, subChunk);
                    break;
                case ChunkConstants.CHUNK_FACELIST:
                    ParseFaceList(mesh, subChunk);
                    break;
                case ChunkConstants.CHUNK_TRMATRIX:
                    ParseTransformMatrix(mesh, subChunk);
                    break;
                case ChunkConstants.CHUNK_FACEMAT:
                    ParseFaceMaterial(mesh, subChunk);
                    break;
                case ChunkConstants.CHUNK_MAPLIST:
                    ChunkHelper.SkipChunk(_reader, subChunk);
                    break;
                case ChunkConstants.CHUNK_SMOOLIST:
                    ParseSmoothingGroups(mesh, subChunk);
                    break;
                default:
                    ChunkHelper.SkipChunk(_reader, subChunk);
                    break;
            }
        }

        private void ParseVertexList(Mesh mesh, ChunkHelper.Chunk chunk)
        {
            var numVertices = (chunk.Size - 6) / 12;
            var contentStart = _reader.BaseStream.Position;

            for (var i = 0; i < numVertices; i++)
            {
                var x = _reader.ReadSingle();
                var y = _reader.ReadSingle();
                var z = _reader.ReadSingle();

                mesh.ControlPoints.Add(new Vector4((double)x, (double)y, (double)(-z), 1.0));
            }

            // Seek to the end of the chunk content
            var contentSize = chunk.Size - 6;
            var expectedEnd = contentStart + contentSize;
            if (_reader.BaseStream.Position < expectedEnd)
            {
                var remaining = expectedEnd - _reader.BaseStream.Position;
                _reader.BaseStream.Seek(remaining, SeekOrigin.Current);
            }
        }

        private void ParseFaceList(Mesh mesh, ChunkHelper.Chunk chunk)
        {
            var numFaces = (chunk.Size - 6) / 8;
            var contentStart = _reader.BaseStream.Position;

            for (var i = 0; i < numFaces; i++)
            {
                var v0 = _reader.ReadUInt16();
                var v1 = _reader.ReadUInt16();
                var v2 = _reader.ReadUInt16();
                var flags = _reader.ReadUInt16();

                mesh.CreatePolygon(v0, v1, v2);
            }

            // Seek to the end of the chunk content
            var contentSize = chunk.Size - 6;
            var expectedEnd = contentStart + contentSize;
            if (_reader.BaseStream.Position < expectedEnd)
            {
                var remaining = expectedEnd - _reader.BaseStream.Position;
                _reader.BaseStream.Seek(remaining, SeekOrigin.Current);
            }
        }

        private void ParseTransformMatrix(Mesh mesh, ChunkHelper.Chunk chunk)
        {
            _reader.BaseStream.Seek(64, SeekOrigin.Current);
        }

        private void ParseFaceMaterial(Mesh mesh, ChunkHelper.Chunk chunk)
        {
            ChunkHelper.SkipChunk(_reader, chunk);
        }

        private void ParseSmoothingGroups(Mesh mesh, ChunkHelper.Chunk chunk)
        {
            ChunkHelper.SkipChunk(_reader, chunk);
        }

        private void ParseMaterialChunk()
        {
            var chunk = ChunkHelper.ReadChunk(_reader);
            var end = _reader.BaseStream.Position + chunk.Size - 6;

            while (_reader.BaseStream.Position < end)
            {
                var subChunk = ChunkHelper.ReadChunk(_reader);
                switch (subChunk.Id)
                {
                    case ChunkConstants.CHUNK_MTL:
                        ParseMaterial(subChunk);
                        break;
                    default:
                        ChunkHelper.SkipChunk(_reader, subChunk);
                        break;
                }
            }
        }

        private void ParseMaterial(ChunkHelper.Chunk chunk)
        {
            var material = new LambertMaterial();

            var end = _reader.BaseStream.Position + chunk.Size - 6;
            var nameRead = false;

            while (_reader.BaseStream.Position < end)
            {
                var subChunk = ChunkHelper.ReadChunk(_reader);
                switch (subChunk.Id)
                {
                    case ChunkConstants.CHUNK_MTL_NAME:
                        material.Name = ChunkHelper.ReadString(_reader);
                        nameRead = true;
                        break;
                    case ChunkConstants.CHUNK_MTL_AMBIENT:
                        var ambient = ChunkHelper.ReadColor(_reader);
                        material.AmbientColor = new Vector3((double)ambient.X, (double)ambient.Y, (double)ambient.Z);
                        break;
                    case ChunkConstants.CHUNK_MTL_DIFFUSE:
                        var diffuse = ChunkHelper.ReadColor(_reader);
                        material.DiffuseColor = new Vector3((double)diffuse.X, (double)diffuse.Y, (double)diffuse.Z);
                        break;
                    case ChunkConstants.CHUNK_MTL_SHADING:
                        break;
                    default:
                        ChunkHelper.SkipChunk(_reader, subChunk);
                        break;
                }
            }

            if (nameRead)
            {
                _materials.Add(material);
            }
        }

        private void CreateNodeHierarchy()
        {
            // For now, all objects are directly under root
        }
    }
}
