using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    public interface IIndexedVertexElement
    {
        int[] Indices { get; }
        int GetIndex(int i);
    }

    public class VertexElementNormal : VertexElementVector
    {
        private readonly List<Vector4> _normals;

        public VertexElementNormal() : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
        }

        public VertexElementNormal(MappingMode mappingMode, ReferenceMode referenceMode) 
            : base(VertexElementType.Normal, mappingMode, referenceMode)
        {
            _normals = new List<Vector4>();
        }

        public List<Vector4> Normals => _normals;
    }

    public class VertexElementTangent : VertexElementVector
    {
        private readonly List<Vector4> _tangents;

        public VertexElementTangent() : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
        }

        public VertexElementTangent(MappingMode mappingMode, ReferenceMode referenceMode) 
            : base(VertexElementType.Tangent, mappingMode, referenceMode)
        {
            _tangents = new List<Vector4>();
        }

        public List<Vector4> Tangents => _tangents;
    }

    public class VertexElementBinormal : VertexElementVector
    {
        private readonly List<Vector4> _binormals;

        public VertexElementBinormal() : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
        }

        public VertexElementBinormal(MappingMode mappingMode, ReferenceMode referenceMode) 
            : base(VertexElementType.Binormal, mappingMode, referenceMode)
        {
            _binormals = new List<Vector4>();
        }

        public List<Vector4> Binormals => _binormals;
    }
}
