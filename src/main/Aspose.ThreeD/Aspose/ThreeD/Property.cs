using System;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Represents a property
    /// </summary>
    public class Property
    {
        private string _name;
        private object? _value;
        private PropertyFlags _flags;

        /// <summary>
        /// Initializes a new instance of the Property class
        /// </summary>
        public Property(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _value = null;
            _flags = PropertyFlags.None;
        }

        /// <summary>
        /// Initializes a new instance of the Property class
        /// </summary>
        public Property(string name, object? value)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _value = value;
            _flags = PropertyFlags.None;
        }

        /// <summary>
        /// Gets or sets the name of the property
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets the value of the property
        /// </summary>
        public object? Value
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>
        /// Gets or sets the flags of the property
        /// </summary>
        public PropertyFlags Flags
        {
            get => _flags;
            set => _flags = value;
        }
    }
}
