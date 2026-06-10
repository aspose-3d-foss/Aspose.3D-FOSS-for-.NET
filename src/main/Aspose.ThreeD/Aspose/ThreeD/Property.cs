using System;
using System.Collections.Generic;
using Aspose.ThreeD.Animation;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Class to hold user-defined properties.
    /// </summary>
    public abstract class Property
    {
        private object? _value;
        private readonly string _name;
        private readonly Type _valueType;
        private Dictionary<string, object>? _extraData;
        private Dictionary<string, BindPoint>? _bindPoints;

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object? Value
        {
            get => _value;
            set => _value = value;
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// Gets the type of the property value.
        /// </summary>
        public Type ValueType => _valueType;

        /// <summary>
        /// Initializes a new instance of the Property class.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        protected Property(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _value = null;
            _valueType = typeof(object);
        }

        /// <summary>
        /// Initializes a new instance of the Property class.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        protected Property(string name, object? value) : this(name)
        {
            _value = value;
            _valueType = value?.GetType() ?? typeof(object);
        }

        /// <summary>
        /// Gets extra data of the property associated by name.
        /// </summary>
        /// <param name="name">The name of the extra data.</param>
        /// <returns>The extra data, or null if not found.</returns>
        public object? GetExtra(string name)
        {
            return _extraData != null && _extraData.TryGetValue(name, out var value) ? value : null;
        }

        /// <summary>
        /// Sets extra data of the property associated by name.
        /// </summary>
        /// <param name="name">The name of the extra data.</param>
        /// <param name="value">The extra data value.</param>
        public void SetExtra(string name, object? value)
        {
            if (_extraData == null)
            {
                _extraData = new Dictionary<string, object>();
            }
            _extraData[name] = value;
        }

        /// <summary>
        /// Gets the property bind point on specified animation instance.
        /// </summary>
        /// <param name="anim">The animation node.</param>
        /// <param name="create">Whether to create the bind point if not exists.</param>
        /// <returns>The bind point.</returns>
        public BindPoint GetBindPoint(AnimationNode anim, bool create)
        {
            return null!;
        }

        /// <summary>
        /// Gets the keyframe sequence on specified animation instance.
        /// </summary>
        /// <param name="anim">The animation node.</param>
        /// <param name="create">Whether to create the keyframe sequence if not exists.</param>
        /// <returns>The keyframe sequence.</returns>
        public KeyframeSequence GetKeyframeSequence(AnimationNode anim, bool create)
        {
            return null!;
        }

        /// <summary>
        /// Returns a string that represents the current property.
        /// </summary>
        /// <returns>A string that represents the current property.</returns>
        public override string ToString()
        {
            return $"Property: {Name}";
        }
    }

    /// <summary>
    /// Default implementation of Property for dynamic properties.
    /// </summary>
    public class DynamicProperty : Property
    {
        /// <summary>
        /// Initializes a new instance of the DynamicProperty class.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        public DynamicProperty(string name) : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DynamicProperty class.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public DynamicProperty(string name, object? value) : base(name, value)
        {
        }
    }
}
