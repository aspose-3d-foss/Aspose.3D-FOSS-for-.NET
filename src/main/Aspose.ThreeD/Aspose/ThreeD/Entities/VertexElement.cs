using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Base class of vertex elements
    /// A vertex element type is identified by VertexElementType.
    /// A VertexElement describes how the vertex element is mapped to a geometry surface and how the mapping information is arranged in memory.
    /// A VertexElement contains Normals, UVs or other kind of information.
    /// </summary>
    public abstract class VertexElement
    {
        private readonly VertexElementType _type;
        private MappingMode _mappingMode;
        private ReferenceMode _referenceMode;
        private IArrayList<int> _indices;

        /// <summary>
        /// Gets the type of the
        /// </summary>
        public VertexElementType VertexElementType => _type;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets how the element is mapped.
        /// </summary>
        public MappingMode MappingMode
        {
            get => _mappingMode;
            set => _mappingMode = value;
        }

        /// <summary>
        /// Gets or sets how the element is referenced.
        /// </summary>
        public ReferenceMode ReferenceMode
        {
            get => _referenceMode;
            set => _referenceMode = value;
        }

        /// <summary>
        /// Gets the indices data
        /// </summary>
        public IArrayList<int> Indices => _indices;

        /// <summary>
        /// Sets the indices data
        /// </summary>
        public void SetIndices(int[] data)
        {
            _indices = new ArrayList<int>(data ?? Array.Empty<int>());
        }

        /// <summary>
        /// Clears all the data from this vertex element.
        /// </summary>
        public virtual void Clear()
        {
            _indices = new ArrayList<int>();
        }

        /// <summary>
        /// Initializes a new instance of the VertexElement class
        /// </summary>
        protected VertexElement(VertexElementType type, MappingMode mappingMode, ReferenceMode referenceMode)
        {
            _type = type;
            _mappingMode = mappingMode;
            _referenceMode = referenceMode;
            _indices = new ArrayList<int>();
            Name = string.Empty;
        }

        /// <summary>
        /// String representation of vertex element.
        /// </summary>
        public override string ToString()
        {
            return $"VertexElement({VertexElementType})";
        }
    }

    /// <summary>
    /// Vertex element with UV coordinates
    /// </summary>
    public class VertexElementUV : VertexElement
    {
        private readonly TextureMapping _mapping;
        private readonly List<FVector2> _data;

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
    }

    /// <summary>
    /// Vertex element with vector data (normals, tangents, etc.)
    /// </summary>
    public class VertexElementVector : VertexElement
    {
        private readonly List<FVector4> _data;

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
    }

    /// <summary>
    /// Vertex element with color data
    /// </summary>
    public class VertexElementVertexColor : VertexElement
    {
        private readonly List<FVector4> _data;

        /// <summary>
        /// Initializes a new instance of the VertexElementVertexColor class
        /// </summary>
        public VertexElementVertexColor(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.VertexColor, mappingMode, referenceMode)
        {
            _data = new List<FVector4>();
        }

        /// <summary>
        /// Gets the vertex color data
        /// </summary>
        public List<FVector4> Data => _data;
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
