using System;
using System.Collections.Generic;

namespace Aspose.ThreeD
{
    /// <summary>
    /// The root class of objects that will be stored inside a scene.
    /// </summary>
    public abstract class SceneObject : A3DObject
    {
        private Scene _scene;

        /// <summary>
        /// Initialize an SceneObject with a default name
        /// </summary>
        public SceneObject(string name) : base(name)
        {
        }

        /// <summary>
        /// Initialize an SceneObject.
        /// </summary>
        public SceneObject() : base()
        {
        }

        /// <summary>
        /// Gets the scene that this object belongs to
        /// </summary>
        public Scene Scene => _scene;
    }
}
