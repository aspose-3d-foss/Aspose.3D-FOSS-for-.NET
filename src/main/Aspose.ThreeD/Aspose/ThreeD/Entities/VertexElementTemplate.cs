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
        private List<T> _data;
        private ArrayList<T> _internalData;

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        public IArrayList<T> Data => _internalData;

        /// <summary>
        /// Initializes a new instance of the VertexElementTemplate class.
        /// </summary>
        protected VertexElementTemplate()
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
            _internalData = new ArrayList<T>();
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementTemplate class.
        /// </summary>
        protected VertexElementTemplate(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.Unknown, mappingMode, referenceMode)
        {
            _data = new List<T>();
            _internalData = new ArrayList<T>();
        }

        /// <summary>
        /// Copies data to specified element
        /// </summary>
        public void CopyTo(VertexElementTemplate<T> target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            target._data.AddRange(_data);
            target._internalData = new ArrayList<T>(_data);
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(T[] data)
        {
            _data.Clear();
            _data.AddRange(data);
            _internalData = new ArrayList<T>(_data);
        }

        /// <summary>
        /// Removes all elements from the direct and the index arrays.
        /// </summary>
        public override void Clear()
        {
            _data.Clear();
            _internalData = new ArrayList<T>();
            base.Clear();
        }
    }
}
