using System;
using System.Collections.Generic;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A helper class for defining concrete implementations.
    /// </summary>
    public class VertexElementIntsTemplate : VertexElement, IIndexedVertexElement
    {
        private readonly List<int> _data;

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        public List<int> Data => _data;

        /// <summary>
        /// Initializes a new instance of the VertexElementIntsTemplate class.
        /// </summary>
        public VertexElementIntsTemplate()
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementIntsTemplate class.
        /// </summary>
        public VertexElementIntsTemplate(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.Unknown, mappingMode, referenceMode)
        {
            _data = new List<int>();
        }

        /// <summary>
        /// Copies data to specified element
        /// </summary>
        public void CopyTo(VertexElementIntsTemplate target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            target._data.AddRange(_data);
            target.SetIndices(_indices);
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(int[] data)
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
