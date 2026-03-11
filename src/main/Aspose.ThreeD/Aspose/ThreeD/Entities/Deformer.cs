using System;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Deformer
    /// </summary>
    public abstract class Deformer
    {
        /// <summary>
        /// Initializes a new instance of the Deformer class
        /// </summary>
        protected Deformer()
        {
        }
    }

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
}
