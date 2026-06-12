using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A helper class for defining concrete implementations.
    /// </summary>
    public class VertexElementFVector : VertexElement, IIndexedVertexElement
    {
        private List<FVector4> _data;
        private ArrayList<FVector4> _internalData;

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        public IArrayList<FVector4> Data => _internalData;

        /// <summary>
        /// Initializes a new instance of the VertexElementFVector class.
        /// </summary>
        public VertexElementFVector()
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
            _internalData = new ArrayList<FVector4>();
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementFVector class.
        /// </summary>
        public VertexElementFVector(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.Unknown, mappingMode, referenceMode)
        {
            _data = new List<FVector4>();
            _internalData = new ArrayList<FVector4>();
        }

        /// <summary>
        /// Copies data to specified element
        /// </summary>
        public void CopyTo(VertexElementFVector target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            target._data.AddRange(_data);
            target._internalData = new ArrayList<FVector4>(_data);
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(FVector4[] data)
        {
            _data.Clear();
            _data.AddRange(data);
            _internalData = new ArrayList<FVector4>(_data);
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(FVector3[] data)
        {
            _data.Clear();
            foreach (var item in data)
            {
                _data.Add(new FVector4(item));
            }
            _internalData = new ArrayList<FVector4>(_data);
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(FVector2[] data)
        {
            _data.Clear();
            foreach (var item in data)
            {
                _data.Add(new FVector4(item.X, item.Y, 0, 1));
            }
            _internalData = new ArrayList<FVector4>(_data);
        }

        /// <summary>
        /// Removes all elements from the direct and the index arrays.
        /// </summary>
        public override void Clear()
        {
            _data.Clear();
            _internalData = new ArrayList<FVector4>();
            base.Clear();
        }
    }
}
