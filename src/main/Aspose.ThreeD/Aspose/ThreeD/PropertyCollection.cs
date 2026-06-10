using System;
using System.Collections.Generic;
using System.Linq;

namespace Aspose.ThreeD
{
    /// <summary>
    /// The collection of properties.
    /// </summary>
    public class PropertyCollection : IEnumerable<Property>
    {
        private readonly Dictionary<string, Property> _properties;
        private readonly Dictionary<string, object> _indexers;

        /// <summary>
        /// Initializes a new instance of the PropertyCollection class.
        /// </summary>
        public PropertyCollection()
        {
            _properties = new Dictionary<string, Property>();
            _indexers = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets the count of declared properties.
        /// </summary>
        public int Count => _properties.Count;

        /// <summary>
        /// Gets the property by index.
        /// </summary>
        /// <param name="index">The index of the property.</param>
        /// <returns>The property at the specified index.</returns>
        public Property this[int index]
        {
            get
            {
                var key = GetKeyByIndex(index);
                return _properties[key];
            }
        }

        /// <summary>
        /// Gets the property value by name.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <returns>The property value.</returns>
        public object this[string name]
        {
            get => _indexers.TryGetValue(name, out var value) ? value : null!;
            set => _indexers[name] = value;
        }

        private string GetKeyByIndex(int index)
        {
            if (index < 0 || index >= _properties.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            return _properties.Keys.ToArray()[index];
        }

        /// <summary>
        /// Finds the property.
        /// It can be a dynamic property (Created by CreateDynamicProperty/SetProperty) 
        /// or native property(Identified by its name).
        /// </summary>
        /// <param name="property">The property name.</param>
        /// <returns>The found property, or null if not found.</returns>
        public Property? FindProperty(string property)
        {
            return _properties.TryGetValue(property, out var prop) ? prop : null;
        }

        /// <summary>
        /// Removes a dynamic property.
        /// </summary>
        /// <param name="property">The property to remove.</param>
        /// <returns>True if the property was removed, false otherwise.</returns>
        public bool RemoveProperty(Property property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            return _properties.Remove(property.Name);
        }

        /// <summary>
        /// Removes a dynamic property.
        /// </summary>
        /// <param name="property">The property name.</param>
        /// <returns>True if the property was removed, false otherwise.</returns>
        public bool RemoveProperty(string property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            return _properties.Remove(property);
        }

        /// <summary>
        /// Adds a property to the collection.
        /// </summary>
        /// <param name="property">The property to add.</param>
        public void Add(Property property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            _properties[property.Name] = property;
            _indexers[property.Name] = property.Value;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public IEnumerator<Property> GetEnumerator()
        {
            return _properties.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
