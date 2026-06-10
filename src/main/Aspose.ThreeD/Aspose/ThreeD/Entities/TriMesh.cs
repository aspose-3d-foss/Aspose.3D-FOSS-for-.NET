using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A TriMesh contains raw data that can be used by GPU directly.
    /// This class is a utility to help to construct a mesh that only contains per-vertex data.
    /// </summary>
    public class TriMesh : Entity, INamedObject, IEnumerable<Vertex>, IEnumerable
    {
        private readonly VertexDeclaration _vertexDeclaration;
        private readonly List<byte> _vertices;
        private readonly List<int> _indices;
        private int _unmergedVerticesCount;

        public TriMesh(string name, VertexDeclaration declaration) : base(name)
        {
            _vertexDeclaration = declaration ?? throw new ArgumentNullException(nameof(declaration));
            _vertices = new List<byte>();
            _indices = new List<int>();
            _unmergedVerticesCount = 0;
        }

        public VertexDeclaration VertexDeclaration => _vertexDeclaration;
        public int VerticesCount => _vertices.Count / GetVertexSize();
        public int IndicesCount => _indices.Count;
        public int UnmergedVerticesCount => _unmergedVerticesCount;
        public int Capacity => _vertices.Capacity;
        public int VerticesSizeInBytes => _vertices.Count;

        private int GetVertexSize()
        {
            int size = 0;
            foreach (var field in _vertexDeclaration)
            {
                switch (field.DataType)
                {
                    case VertexFieldDataType.Float: size += 4; break;
                    case VertexFieldDataType.Double: size += 8; break;
                    case VertexFieldDataType.Int8: size += 1; break;
                    case VertexFieldDataType.Int16: size += 2; break;
                    case VertexFieldDataType.Int32: size += 4; break;
                    case VertexFieldDataType.FVector2: size += 8; break;
                    case VertexFieldDataType.FVector3: size += 12; break;
                    case VertexFieldDataType.FVector4: size += 16; break;
                    case VertexFieldDataType.Vector2: size += 16; break;
                    case VertexFieldDataType.Vector3: size += 24; break;
                    case VertexFieldDataType.Vector4: size += 32; break;
                    case VertexFieldDataType.ByteVector4: size += 4; break;
                    case VertexFieldDataType.Int64: size += 8; break;
                }
            }
            return size;
        }

        public static TriMesh FromMesh(VertexDeclaration declaration, Mesh mesh) => throw new NotImplementedException();
        public static TriMesh CopyFrom(TriMesh input, VertexDeclaration vd) => throw new NotImplementedException();
        public static TriMesh FromMesh(Mesh mesh, bool useFloat) => throw new NotImplementedException();
        public Vertex BeginVertex() => throw new NotImplementedException();
        public int EndVertex() => throw new NotImplementedException();
        public void WriteVerticesTo(Stream stream) => throw new NotImplementedException();
        public void Write16bIndicesTo(Stream stream) => throw new NotImplementedException();
        public void Write32bIndicesTo(Stream stream) => throw new NotImplementedException();
        public byte[] VerticesToArray() => throw new NotImplementedException();
        public void IndicesToArray(ref ushort[] result) => throw new NotImplementedException();
        public void IndicesToArray(ref int[] result) => throw new NotImplementedException();
        public override string ToString() => $"TriMesh({VerticesCount} vertices, {IndicesCount} indices)";
        public static TriMesh FromRawData(VertexDeclaration vd, byte[] vertices, int[] indices, bool generateVertexMapping) => throw new NotImplementedException();
        public void LoadVerticesFromBytes(byte[] verticesInBytes) => throw new NotImplementedException();
        public void AddTriangle(int a, int b, int c) { _indices.Add(a); _indices.Add(b); _indices.Add(c); }
        public IEnumerator<Vertex> GetEnumerator() => throw new NotImplementedException();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
        public Vector4 ReadVector4(int idx, VertexField field) => throw new NotImplementedException();
        public FVector4 ReadFVector4(int idx, VertexField field) => throw new NotImplementedException();
        public Vector3 ReadVector3(int idx, VertexField field) => throw new NotImplementedException();
        public FVector3 ReadFVector3(int idx, VertexField field) => throw new NotImplementedException();
        public Vector2 ReadVector2(int idx, VertexField field) => throw new NotImplementedException();
        public FVector2 ReadFVector2(int idx, VertexField field) => throw new NotImplementedException();
        public double ReadDouble(int idx, VertexField field) => throw new NotImplementedException();
        public float ReadFloat(int idx, VertexField field) => throw new NotImplementedException();
    }
}
