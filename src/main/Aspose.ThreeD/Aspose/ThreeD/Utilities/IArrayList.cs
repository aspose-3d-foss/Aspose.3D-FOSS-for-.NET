using System.Collections.Generic;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// Aspose.3D has its own highly optimized implementation of <see cref="List{T}"/> for better loading/saving performance
    /// Only this interface is exposed for user with <see cref="IList{T}"/> compatible and similar interfaces.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    public interface IArrayList<T> : IList<T>
    {
        /// <summary>
        /// Converts all items in the list to an array
        /// </summary>
        /// <returns>Items array</returns>
        T[] ToArray();
    }
}
