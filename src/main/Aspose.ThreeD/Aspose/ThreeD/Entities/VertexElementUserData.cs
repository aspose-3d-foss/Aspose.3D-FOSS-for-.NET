using System;
using System.Collections.Generic;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines custom user data for specified components.
    /// Usually it's application-specific data for special purpose.
    /// </summary>
    public class VertexElementUserData : VertexElement, IIndexedVertexElement
    {
        private object _data;

        /// <summary>
        /// Initializes a new instance of the VertexElementUserData class.
        /// </summary>
        public VertexElementUserData()
            : this(MappingMode.AllSame, ReferenceMode.Direct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementUserData class.
        /// </summary>
        public VertexElementUserData(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.Unknown, mappingMode, referenceMode)
        {
        }

        /// <summary>
        /// The user data attached in this element
        /// </summary>
        public object Data
        {
            get => _data;
            set => _data = value;
        }

        /// <summary>
        /// Clears all the data from this vertex element.
        /// </summary>
        public void Clear()
        {
            _data = null;
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
