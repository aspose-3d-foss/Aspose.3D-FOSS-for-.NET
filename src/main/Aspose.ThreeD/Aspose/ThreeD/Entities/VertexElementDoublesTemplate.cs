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
        internal VertexElementDoublesTemplate()
        {
        }

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        private readonly List<double> _data = new List<double>();
        public IArrayList<double> Data => new ArrayListAdapter<double>(_data);

        /// <summary>
        /// Copies data to specified element
        /// </summary>
        public void CopyTo(VertexElementDoublesTemplate target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            foreach (var item in Data)
            {
                target.Data.Add(item);
            }
        }

        public void SetData(double[] data)
        {
            Data.Clear();
            foreach (var item in data)
            {
                Data.Add(item);
            }
        }

        public override void Clear()
        {
            Data.Clear();
            base.Clear();
        }
    }
}
