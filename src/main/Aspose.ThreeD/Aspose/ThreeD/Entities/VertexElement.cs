using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Base class of vertex elements
    /// </summary>
    public abstract class VertexElement
    {
        private readonly VertexElementType _type;
        private readonly MappingMode _mappingMode;
        private readonly ReferenceMode _referenceMode;

        /// <summary>
        /// Initializes a new instance of the VertexElement class
        /// </summary>
        protected VertexElement(VertexElementType type, MappingMode mappingMode, ReferenceMode referenceMode)
        {
            _type = type;
            _mappingMode = mappingMode;
            _referenceMode = referenceMode;
        }

        /// <summary>
        /// Gets the vertex element type
        /// </summary>
        public VertexElementType VertexElementType => _type;

        /// <summary>
        /// Gets the mapping mode
        /// </summary>
        public MappingMode MappingMode => _mappingMode;

        /// <summary>
        /// Gets the reference mode
        /// </summary>
        public ReferenceMode ReferenceMode => _referenceMode;
    }

    /// <summary>
    /// Vertex element with UV coordinates
    /// </summary>
    public class VertexElementUV : VertexElement, IIndexedVertexElement
    {
        private readonly TextureMapping _mapping;
        private readonly List<FVector2> _data;
        private int[] _indices = Array.Empty<int>();

        /// <summary>
        /// Initializes a new instance of the VertexElementUV class
        /// </summary>
        public VertexElementUV(TextureMapping mapping, MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.UV, mappingMode, referenceMode)
        {
            _mapping = mapping;
            _data = new List<FVector2>();
        }

        /// <summary>
        /// Gets the texture mapping
        /// </summary>
        public TextureMapping Mapping => _mapping;

        /// <summary>
        /// Gets the UV data
        /// </summary>
        public List<FVector2> Data => _data;

        /// <summary>
        /// Gets the indices for index-to-direct mapping
        /// </summary>
        public int[] Indices => _indices;

        /// <summary>
        /// Sets the indices for index-to-direct mapping
        /// </summary>
        public void SetIndices(int[] indices)
        {
            _indices = indices ?? Array.Empty<int>();
        }

        /// <summary>
        /// Gets the index at the specified position
        /// </summary>
        public int GetIndex(int i)
        {
            if (i >= 0 && i < _indices.Length)
                return _indices[i];
            return i;
        }
    }

    /// <summary>
    /// Vertex element with vector data (normals, tangents, etc.)
    /// </summary>
    public class VertexElementVector : VertexElement, IIndexedVertexElement
    {
        private readonly List<FVector4> _data;
        private int[] _indices = Array.Empty<int>();

        /// <summary>
        /// Initializes a new instance of the VertexElementVector class
        /// </summary>
        public VertexElementVector(VertexElementType type, MappingMode mappingMode, ReferenceMode referenceMode)
            : base(type, mappingMode, referenceMode)
        {
            _data = new List<FVector4>();
        }

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        public List<FVector4> Data => _data;

        /// <summary>
        /// Gets the indices for index-to-direct mapping
        /// </summary>
        public int[] Indices => _indices;

        /// <summary>
        /// Sets the indices for index-to-direct mapping
        /// </summary>
        public void SetIndices(int[] indices)
        {
            _indices = indices ?? Array.Empty<int>();
        }

        /// <summary>
        /// Gets the index at the specified position
        /// </summary>
        public int GetIndex(int i)
        {
            if (i >= 0 && i < _indices.Length)
                return _indices[i];
            return i;
        }
    }

    /// <summary>
    /// Vertex element with color data
    /// </summary>
    public class VertexElementVertexColor : VertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementVertexColor class
        /// </summary>
        public VertexElementVertexColor(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.VertexColor, mappingMode, referenceMode)
        {
        }
    }

    /// <summary>
    /// Vertex element with material index
    /// </summary>
    public class VertexElementMaterial : VertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementMaterial class
        /// </summary>
        public VertexElementMaterial(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.Material, mappingMode, referenceMode)
        {
        }
    }
}
