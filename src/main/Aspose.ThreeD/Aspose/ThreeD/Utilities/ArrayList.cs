using System;
using System.Collections.Generic;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// Aspose.3D has its own highly optimized implementation of <see cref="List{T}"/> for better loading/saving performance
    /// Only this interface is exposed for user with <see cref="IList{T}"/> compatible and similar interfaces.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    public class ArrayList<T> : IArrayList<T>
    {
        private readonly List<T> _innerList;

        /// <summary>
        /// Initializes a new instance of the ArrayList class
        /// </summary>
        public ArrayList()
        {
            _innerList = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the ArrayList class with the specified collection
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list</param>
        public ArrayList(IEnumerable<T> collection)
        {
            _innerList = new List<T>(collection);
        }

        /// <summary>
        /// Gets the number of elements in the list
        /// </summary>
        public int Count => _innerList.Count;

        /// <summary>
        /// Gets a value indicating whether the list is read-only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the element at the specified index
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set</param>
        /// <returns>The element at the specified index</returns>
        public T this[int index]
        {
            get => _innerList[index];
            set => _innerList[index] = value;
        }

        /// <summary>
        /// Adds an item to the list
        /// </summary>
        /// <param name="item">The object to add to the list</param>
        public void Add(T item)
        {
            _innerList.Add(item);
        }

        /// <summary>
        /// Removes all items from the list
        /// </summary>
        public void Clear()
        {
            _innerList.Clear();
        }

        /// <summary>
        /// Determines whether the list contains a specific value
        /// </summary>
        /// <param name="item">The object to locate in the list</param>
        /// <returns>true if item is found in the list; otherwise, false</returns>
        public bool Contains(T item)
        {
            return _innerList.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the list to an Array, starting at a particular Array index
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from list</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _innerList.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the list
        /// </summary>
        /// <param name="item">The object to remove from the list</param>
        /// <returns>true if item was successfully removed from the list; otherwise, false</returns>
        public bool Remove(T item)
        {
            return _innerList.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a non-generic collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection</returns>
        global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
        {
            return _innerList.GetEnumerator();
        }

        /// <summary>
        /// Determines the index of a specific item in the list
        /// </summary>
        /// <param name="item">The object to locate in the list</param>
        /// <returns>The index of item if found in the list; otherwise, -1</returns>
        public int IndexOf(T item)
        {
            return _innerList.IndexOf(item);
        }

        /// <summary>
        /// Inserts an item to the list at the specified index
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted</param>
        /// <param name="item">The object to insert into the list</param>
        public void Insert(int index, T item)
        {
            _innerList.Insert(index, item);
        }

        /// <summary>
        /// Removes the item at the specified index
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove</param>
        public void RemoveAt(int index)
        {
            _innerList.RemoveAt(index);
        }

        /// <summary>
        /// Converts all items in the list to an array
        /// </summary>
        /// <returns>Items array</returns>
        public T[] ToArray()
        {
            return _innerList.ToArray();
        }
    }
}
