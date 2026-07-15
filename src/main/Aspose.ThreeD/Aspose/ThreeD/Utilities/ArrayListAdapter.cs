// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Collections;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// Adapter class that wraps List&lt;T&gt; and implements IArrayList&lt;T&gt;
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    internal class ArrayListAdapter<T> : IArrayList<T>
    {
        private readonly List<T> _list;

        public ArrayListAdapter(List<T> list)
        {
            _list = list ?? throw new ArgumentNullException(nameof(list));
        }

        public T this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public T[] ToArray()
        {
            return _list.ToArray();
        }

        public void AddRange(IList<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            foreach (var item in list)
            {
                _list.Add(item);
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            _list.AddRange(collection);
        }
    }
}
