using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A helper class for defining concrete implementations.
    /// </summary>
    public abstract class VertexElementTemplate<T> : VertexElement, IIndexedVertexElement
    {
        private readonly List<T> _data;
        private readonly List<T> _internalData;
        private readonly ArrayListAdapter<T> _dataAdapter;

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        public IArrayList<T> Data => _dataAdapter;

        /// <summary>
        /// Initializes a new instance of the VertexElementTemplate class.
        /// </summary>
        protected VertexElementTemplate()
        {
            _data = new List<T>();
            _internalData = new List<T>();
            _dataAdapter = new ArrayListAdapter<T>(_internalData);
        }

        /// <summary>
        /// Copies data to specified element
        /// </summary>
        public void CopyTo(VertexElementTemplate<T> target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            target._internalData.Clear();
            target._internalData.AddRange(_internalData);
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(T[] data)
        {
            _data.Clear();
            _data.AddRange(data);
            _internalData.Clear();
            _internalData.AddRange(_data);
        }

        /// <summary>
        /// Removes all elements from the direct and the index arrays.
        /// </summary>
        public override void Clear()
        {
            _data.Clear();
            _internalData.Clear();
            base.Clear();
        }
    }
}
