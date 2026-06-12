using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A helper class for defining concrete implementations.
    /// </summary>
    public class VertexElementDoublesTemplate : VertexElement, IIndexedVertexElement
    {
        private List<double> _data;
        private ArrayList<double> _internalData;

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        public IArrayList<double> Data => _internalData;

        /// <summary>
        /// Initializes a new instance of the VertexElementDoublesTemplate class.
        /// </summary>
        public VertexElementDoublesTemplate()
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
            _internalData = new ArrayList<double>();
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementDoublesTemplate class.
        /// </summary>
        public VertexElementDoublesTemplate(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.Unknown, mappingMode, referenceMode)
        {
            _data = new List<double>();
            _internalData = new ArrayList<double>();
        }

        /// <summary>
        /// Copies data to specified element
        /// </summary>
        public void CopyTo(VertexElementDoublesTemplate target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            target._data.AddRange(_data);
            target._internalData = new ArrayList<double>(_data);
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(double[] data)
        {
            _data.Clear();
            _data.AddRange(data);
            _internalData = new ArrayList<double>(_data);
        }

        /// <summary>
        /// Removes all elements from the direct and the index arrays.
        /// </summary>
        public override void Clear()
        {
            _data.Clear();
            _internalData = new ArrayList<double>();
            base.Clear();
        }
    }
}
