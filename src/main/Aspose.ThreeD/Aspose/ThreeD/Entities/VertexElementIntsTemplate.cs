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
        internal VertexElementIntsTemplate()
        {
        }

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        private readonly List<int> _data = new List<int>();
        public IArrayList<int> Data => new ArrayListAdapter<int>(_data);

        /// <summary>
        /// Copies data to specified element
        /// </summary>
        public void CopyTo(VertexElementIntsTemplate target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            foreach (var item in Data)
            {
                target.Data.Add(item);
            }
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(int[] data)
        {
            Data.Clear();
            foreach (var item in data)
            {
                Data.Add(item);
            }
        }

        /// <summary>
        /// Removes all elements from the direct and the index arrays.
        /// </summary>
        public override void Clear()
        {
            Data.Clear();
            base.Clear();
        }
    }
}
