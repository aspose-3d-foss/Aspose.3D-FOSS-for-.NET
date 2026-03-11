using System;

namespace Aspose.ThreeD
{
    /// <summary>
    /// The base class of all Aspose.ThreeD objects, all sub classes will support dynamic properties.
    /// </summary>
    public class A3DObject : INamedObject
    {
        private string _name;
        private readonly PropertyCollection _properties;

        /// <summary>
        /// Initializes a new instance of the A3DObject class with no name.
        /// </summary>
        public A3DObject()
        {
            _name = string.Empty;
            _properties = new PropertyCollection();
        }

        /// <summary>
        /// Initializes a new instance of the A3DObject class.
        /// </summary>
        public A3DObject(string name)
        {
            _name = name ?? string.Empty;
            _properties = new PropertyCollection();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value ?? string.Empty;
        }

        /// <summary>
        /// Gets the collection of all properties.
        /// </summary>
        public PropertyCollection Properties => _properties;

        /// <summary>
        /// Removes a dynamic property.
        /// </summary>
        public bool RemoveProperty(Property property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            return _properties.FindProperty(property.Name) != null;
        }

        /// <summary>
        /// Remove the specified property identified by name
        /// </summary>
        public bool RemoveProperty(string property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            return _properties.FindProperty(property) != null;
        }

        /// <summary>
        /// Get the value of specified property
        /// </summary>
        public object? GetProperty(string property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            var prop = _properties.FindProperty(property);
            return prop?.Value;
        }

        /// <summary>
        /// Sets the value of specified property
        /// </summary>
        public void SetProperty(string property, object? value)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            var prop = _properties.FindProperty(property);
            if (prop != null)
            {
                prop.Value = value;
            }
            else
            {
                _properties.Add(new Property(property, value));
            }
        }

        /// <summary>
        /// Finds the property.
        /// It can be a dynamic property (Created by CreateDynamicProperty/SetProperty) 
        /// or native property(Identified by its name)
        /// </summary>
        public Property? FindProperty(string propertyName)
        {
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));

            return _properties.FindProperty(propertyName);
        }
    }
}
