using System;
using System.Collections.Generic;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Base class of all Aspose.3D objects
    /// </summary>
    public abstract class SceneObject : INamedObject
    {
        private string _name;
        private readonly PropertyCollection _properties;

        /// <summary>
        /// Initializes a new instance of the SceneObject class
        /// </summary>
        protected SceneObject()
        {
            _name = string.Empty;
            _properties = new PropertyCollection();
        }

        /// <summary>
        /// Initializes a new instance of the SceneObject class with a name
        /// </summary>
        protected SceneObject(string name)
        {
            _name = name ?? string.Empty;
            _properties = new PropertyCollection();
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value ?? string.Empty;
        }

        /// <summary>
        /// Gets the collection of properties
        /// </summary>
        public PropertyCollection Properties => _properties;
    }
}
