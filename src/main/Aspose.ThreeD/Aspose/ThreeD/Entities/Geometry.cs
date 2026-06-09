using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Deformers;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Static factory for creating vertex elements
    /// </summary>
    internal static class VertexElementFactory
    {
        /// <summary>
        /// Creates a vertex element based on type
        /// </summary>
        public static VertexElement Create(VertexElementType type)
        {
            return Create(type, MappingMode.ControlPoint, ReferenceMode.Direct);
        }

        /// <summary>
        /// Creates a vertex element based on type with mapping and reference modes
        /// </summary>
        public static VertexElement Create(VertexElementType type, MappingMode mappingMode, ReferenceMode referenceMode)
        {
            switch (type)
            {
                case VertexElementType.Normal:
                case VertexElementType.Binormal:
                case VertexElementType.Tangent:
                    return new VertexElementVector(type, mappingMode, referenceMode);

                case VertexElementType.UV:
                    return new VertexElementUV(TextureMapping.Diffuse, mappingMode, referenceMode);

                case VertexElementType.VertexColor:
                    return new VertexElementVertexColor(mappingMode, referenceMode);

                case VertexElementType.Material:
                    return new VertexElementMaterial(mappingMode, referenceMode);

                default:
                    throw new ArgumentException($"Unsupported vertex element type: {type}");
            }
        }
    }

    /// <summary>
    /// The base class of all renderable geometric objects (like Mesh, Box, Cylinder and etc.).
    /// </summary>
    public abstract class Geometry : Entity
    {
        private readonly List<Deformer> _deformers;
        private readonly List<VertexElement> _vertexElements;
        private readonly List<Vector4> _controlPoints;
        private bool _visible;
        private bool _castShadows;
        private bool _receiveShadows;

        /// <summary>
        /// Initializes a new instance of the Geometry class.
        /// </summary>
        protected Geometry(string name) : base(name)
        {
            _deformers = new List<Deformer>();
            _vertexElements = new List<VertexElement>();
            _controlPoints = new List<Vector4>();
            _visible = true;
            _castShadows = true;
            _receiveShadows = true;
        }

        /// <summary>
        /// Gets or sets if the geometry is visible
        /// </summary>
        public bool Visible
        {
            get => _visible;
            set => _visible = value;
        }

        /// <summary>
        /// Gets all deformers associated with this geometry.
        /// </summary>
        public IList<Deformer> Deformers => _deformers;

        /// <summary>
        /// Gets all control points
        /// </summary>
        public IList<Vector4> ControlPoints => _controlPoints;

        /// <summary>
        /// Gets or sets whether this geometry can cast shadow
        /// </summary>
        public bool CastShadows
        {
            get => _castShadows;
            set => _castShadows = value;
        }

        /// <summary>
        /// Gets or sets whether this geometry can receive shadow.
        /// </summary>
        public bool ReceiveShadows
        {
            get => _receiveShadows;
            set => _receiveShadows = value;
        }

        /// <summary>
        /// Gets all vertex elements
        /// </summary>
        public IList<VertexElement> VertexElements => _vertexElements;

        /// <summary>
        /// Gets all deformers
        /// </summary>
        public void GetDeformers()
        {
            throw new NotImplementedException("Getting deformers is not yet implemented");
        }

        /// <summary>
        /// Gets a vertex element with specified type
        /// </summary>
        public VertexElement? GetElement(VertexElementType type)
        {
            foreach (var element in _vertexElements)
            {
                if (element.VertexElementType == type)
                    return element;
            }
            return null;
        }

        /// <summary>
        /// Gets a VertexElementUV instance with given texture mapping type
        /// </summary>
        public VertexElementUV? GetVertexElementOfUV(TextureMapping textureMapping)
        {
            foreach (var element in _vertexElements)
            {
                if (element is VertexElementUV uv && uv.Mapping == textureMapping)
                    return uv;
            }
            return null;
        }

        /// <summary>
        /// Creates a vertex element with specified type and add it to geometry.
        /// </summary>
        public VertexElement CreateElement(VertexElementType type)
        {
            var element = VertexElementFactory.Create(type);
            _vertexElements.Add(element);
            return element;
        }

        /// <summary>
        /// Adds an existing vertex element to current geometry
        /// </summary>
        public void AddElement(VertexElement element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            _vertexElements.Add(element);
        }

        /// <summary>
        /// Creates a vertex element with specified type and add it to geometry.
        /// </summary>
        public VertexElement CreateElement(VertexElementType type, MappingMode mappingMode, ReferenceMode referenceMode)
        {
            var element = VertexElementFactory.Create(type, mappingMode, referenceMode);
            _vertexElements.Add(element);
            return element;
        }

        /// <summary>
        /// Creates a VertexElementUV with given texture mapping type.
        /// </summary>
        public VertexElementUV CreateElementUV(TextureMapping uvMapping)
        {
            return CreateElementUV(uvMapping, MappingMode.ControlPoint, ReferenceMode.Direct);
        }

        /// <summary>
        /// Creates a VertexElementUV with given texture mapping type.
        /// </summary>
        public VertexElementUV CreateElementUV(TextureMapping uvMapping, MappingMode mappingMode, ReferenceMode referenceMode)
        {
            var element = new VertexElementUV(uvMapping, mappingMode, referenceMode);
            _vertexElements.Add(element);
            return element;
        }
    }
}
