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
        private readonly List<Vector4> _data;

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        public List<Vector4> Data => _data;

        /// <summary>
        /// Initializes a new instance of the VertexElementVector4 class.
        /// </summary>
        public VertexElementVector4()
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementVector4 class.
        /// </summary>
        public VertexElementVector4(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.Unknown, mappingMode, referenceMode)
        {
            _data = new List<Vector4>();
        }

        /// <summary>
        /// Copies data to specified element
        /// </summary>
        public void CopyTo(VertexElementVector4 target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            target._data.AddRange(_data);
            target.SetIndices(_indices);
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(Vector4[] data)
        {
            _data.Clear();
            _data.AddRange(data);
        }

        /// <summary>
        /// Removes all elements from the direct and the index arrays.
        /// </summary>
        public void Clear()
        {
            _data.Clear();
            SetIndices(Array.Empty<int>());
        }

        private int[] _indices = Array.Empty<int>();

        /// <summary>
        /// Gets the indices data
        /// </summary>
        public int[] Indices => _indices;

        /// <summary>
        /// Sets the indices data
        /// </summary>
        public void SetIndices(int[] data)
        {
            _indices = data ?? Array.Empty<int>();
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
}
