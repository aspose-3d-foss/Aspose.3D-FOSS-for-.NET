using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A helper class for defining concrete implementations.
    /// </summary>
    public class VertexElementVector4 : VertexElement, IIndexedVertexElement
    {
        private ArrayList<Vector4> _internalData;

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        public IArrayList<Vector4> Data => _internalData;

        /// <summary>
        /// Initializes a new instance of the VertexElementVector4 class.
        /// </summary>
        public VertexElementVector4()
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
            _internalData = new ArrayList<Vector4>();
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementVector4 class.
        /// </summary>
        public VertexElementVector4(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.Unknown, mappingMode, referenceMode)
        {
            _internalData = new ArrayList<Vector4>();
        }

        /// <summary>
        /// Copies data to specified element
        /// </summary>
        public void CopyTo(VertexElementVector4 target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            target._internalData = new ArrayList<Vector4>(_internalData);
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(Vector4[] data)
        {
            _internalData = new ArrayList<Vector4>(data ?? Array.Empty<Vector4>());
        }

        /// <summary>
        /// Removes all elements from the direct and the index arrays.
        /// </summary>
        public override void Clear()
        {
            _internalData = new ArrayList<Vector4>();
            base.Clear();
        }
    }
}
