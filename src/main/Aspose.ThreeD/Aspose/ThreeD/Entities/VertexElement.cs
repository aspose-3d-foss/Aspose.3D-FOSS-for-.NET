using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Base class of vertex elements.
    /// A vertex element type is identified by VertexElementType. 
    /// A VertexElement describes how the vertex element is mapped to a geometry surface and how the mapping information is arranged in memory. 
    /// A VertexElement contains Normals, UVs or other kind of information.
    /// </summary>
    public abstract class VertexElement : IIndexedVertexElement
    {
        protected VertexElementType _type;
        private MappingMode _mappingMode;
        private ReferenceMode _referenceMode;
        protected List<int> _indices;

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
        public IArrayList<int> Indices => new ArrayListAdapter<int>(_indices);

        /// <summary>
        /// Sets the indices data
        /// </summary>
        public void SetIndices(int[] data)
        {
            _indices = new List<int>(data ?? Array.Empty<int>());
        }

        /// <summary>
        /// Clears all the data from this vertex element.
        /// </summary>
        public virtual void Clear()
        {
            _indices = new List<int>();
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
    /// Defines the UV coordinates for specified components.
    /// A geometry can have multiple UV elements, and each one have different texture mapping.
    /// </summary>
    public class VertexElementUV : VertexElementFVector, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementUV class.
        /// The default texture mapping type is Diffuse.
        /// </summary>
        public VertexElementUV()
        {
            _type = VertexElementType.UV;
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementUV class.
        /// </summary>
        public VertexElementUV(TextureMapping textureMapping)
        {
            _type = VertexElementType.UV;
        }

        public void AddData(IEnumerable<Vector2> data)
        {
            if (data == null)
                return;
            foreach (var item in data)
            {
                base.Data.Add(new FVector4((float)item.X, (float)item.Y, 0, 1));
            }
        }

        public void AddData(IEnumerable<Vector3> data)
        {
            if (data == null)
                return;
            foreach (var item in data)
            {
                base.Data.Add(new FVector4((float)item.X, (float)item.Y, (float)item.Z, 1));
            }
        }

        /// <summary>
        /// Checks if this element matches the given texture mapping.
        /// </summary>
        internal bool MatchesTextureMapping(TextureMapping textureMapping)
        {
            // On-Premise version doesn't expose the texture mapping,
            // so we can't compare. This method is only used internally
            // and always returns true for now.
            return true;
        }
    }

    /// <summary>
    /// Defines the vertex color for specified components
    /// </summary>
    public class VertexElementVertexColor : VertexElementFVector, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementVertexColor class.
        /// </summary>
        public VertexElementVertexColor()
        {
            _type = VertexElementType.VertexColor;
        }
    }

    /// <summary>
    /// Defines material index for specified components.
    /// 
    /// A node can have multiple materials, the Material is used to render different part of the geometry in different materials.
    /// </summary>
    public class VertexElementMaterial : VertexElement, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementMaterial class.
        /// </summary>
        public VertexElementMaterial()
        {
            _type = VertexElementType.Material;
            _indices = new List<int>();
            Name = string.Empty;
        }

        /// <summary>
        /// Removes all elements from the direct and the index arrays.
        /// </summary>
        public override void Clear()
        {
            _indices = new List<int>();
        }
    }
}
