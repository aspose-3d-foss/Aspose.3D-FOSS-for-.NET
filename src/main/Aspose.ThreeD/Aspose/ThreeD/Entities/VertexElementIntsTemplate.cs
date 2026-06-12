using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A helper class for defining concrete implementations.
    /// </summary>
    public class VertexElementIntsTemplate : VertexElement, IIndexedVertexElement
    {
        private List<int> _data;
        private ArrayList<int> _internalData;

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        public IArrayList<int> Data => _internalData;

        /// <summary>
        /// Initializes a new instance of the VertexElementIntsTemplate class.
        /// </summary>
        public VertexElementIntsTemplate()
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
            _internalData = new ArrayList<int>();
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementIntsTemplate class.
        /// </summary>
        public VertexElementIntsTemplate(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.Unknown, mappingMode, referenceMode)
        {
            _data = new List<int>();
            _internalData = new ArrayList<int>();
        }

        /// <summary>
        /// Copies data to specified element
        /// </summary>
        public void CopyTo(VertexElementIntsTemplate target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            target._data.AddRange(_data);
            target._internalData = new ArrayList<int>(_data);
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(int[] data)
        {
            _data.Clear();
            _data.AddRange(data);
            _internalData = new ArrayList<int>(_data);
        }

        /// <summary>
        /// Removes all elements from the direct and the index arrays.
        /// </summary>
        public override void Clear()
        {
            _data.Clear();
            _internalData = new ArrayList<int>();
            base.Clear();
        }
    }
}
