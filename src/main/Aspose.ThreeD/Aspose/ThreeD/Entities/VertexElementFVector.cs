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
        internal VertexElementFVector()
        {
        }

        /// <summary>
        /// Gets the vertex data
        /// </summary>
        private readonly List<FVector4> _data = new List<FVector4>();
        public IArrayList<FVector4> Data => new ArrayListAdapter<FVector4>(_data);

        /// <summary>
        /// Copies data to specified element
        /// </summary>
        public void CopyTo(VertexElementFVector target)
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
        public void SetData(FVector4[] data)
        {
            Data.Clear();
            foreach (var item in data)
            {
                Data.Add(item);
            }
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(FVector3[] data)
        {
            Data.Clear();
            foreach (var item in data)
            {
                Data.Add(new FVector4(item.X, item.Y, item.Z));
            }
        }

        /// <summary>
        /// Sets the data
        /// </summary>
        public void SetData(FVector2[] data)
        {
            Data.Clear();
            foreach (var item in data)
            {
                Data.Add(new FVector4(item.X, item.Y, 0, 1));
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
