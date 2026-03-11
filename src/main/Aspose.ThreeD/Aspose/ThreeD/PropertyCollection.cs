using System;
using System.Collections.Generic;

namespace Aspose.ThreeD
{
    /// <summary>
    /// A collection of properties
    /// </summary>
    public class PropertyCollection : IEnumerable<Property>
    {
        private readonly Dictionary<string, Property> _properties;

        /// <summary>
        /// Initializes a new instance of the PropertyCollection class
        /// </summary>
        public PropertyCollection()
        {
            _properties = new Dictionary<string, Property>();
        }

        /// <summary>
        /// Gets the property with the specified name
        /// </summary>
        public Property? this[string name]
        {
            get
            {
                _properties.TryGetValue(name, out var prop);
                return prop;
            }
        }

        /// <summary>
        /// Gets the number of properties in the collection
        /// </summary>
        public int Count => _properties.Count;

        /// <summary>
        /// Adds a property to the collection
        /// </summary>
        public void Add(Property property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            _properties[property.Name] = property;
        }

        /// <summary>
        /// Finds a property
        /// </summary>
        public Property? FindProperty(string name)
        {
            return this[name];
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection
        /// </summary>
        public IEnumerator<Property> GetEnumerator()
        {
            return _properties.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
