using System;
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
    public class VertexElementUV : VertexElement
    {
        private readonly TextureMapping _mapping;

        /// <summary>
        /// Initializes a new instance of the VertexElementUV class
        /// </summary>
        public VertexElementUV(TextureMapping mapping, MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.UV, mappingMode, referenceMode)
        {
            _mapping = mapping;
        }

        /// <summary>
        /// Gets the texture mapping
        /// </summary>
        public TextureMapping Mapping => _mapping;
    }

    /// <summary>
    /// Vertex element with vector data (normals, tangents, etc.)
    /// </summary>
    public class VertexElementVector : VertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementVector class
        /// </summary>
        public VertexElementVector(VertexElementType type, MappingMode mappingMode, ReferenceMode referenceMode)
            : base(type, mappingMode, referenceMode)
        {
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
