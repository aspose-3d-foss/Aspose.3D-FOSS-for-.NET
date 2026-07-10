using System;
using System.Collections.Generic;
using System.Collections;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// Aspose.3D has its own highly optimized implementation of <see cref="List{T}"/> for better loading/saving performance
    /// Only this interface is exposed for user with <see cref="IList{T}"/> compatible and similar interfaces.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    public interface IArrayList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
    {
        /// <summary>
        /// Converts all items in the list to an array
        /// </summary>
        /// <returns>Items array</returns>
        T[] ToArray();

        /// <summary>
        /// Adds the elements of the specified list to the end of this list.
        /// </summary>
        /// <param name="list">The collection whose elements should be added to the end of this list.</param>
        void AddRange(IList<T> list);

        /// <summary>
        /// Adds the elements of the specified collection to the end of this list.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of this list.</param>
        void AddRange(IEnumerable<T> collection);
    }
}
