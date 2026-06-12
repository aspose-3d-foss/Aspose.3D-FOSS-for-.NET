using System;
using System.Collections.Generic;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// The base class of all entities.
    /// Entity represents a concrete object that attached under a node like /.
    /// </summary>
    public abstract class Entity : SceneObject
    {
        private readonly List<Node> _parentNodes;
        private bool _excluded;

        /// <summary>
        /// Initializes a new instance of the Entity class.
        /// </summary>
        public Entity(string name) : base(name)
        {
            _parentNodes = new List<Node>();
            _excluded = false;
        }

        /// <summary>
        /// Gets or sets whether to exclude this entity during exporting.
        /// </summary>
        public bool Excluded
        {
            get => _excluded;
            set => _excluded = value;
        }

        /// <summary>
        /// Gets all parent nodes, an entity can be attached to multiple parent nodes for geometry instancing
        /// </summary>
        public List<Node> ParentNodes => _parentNodes;

        /// <summary>
        /// Gets or sets the first parent node, if set the first parent node, this entity will be detached from other parent nodes.
        /// </summary>
        public Node ParentNode
        {
            get
            {
                return _parentNodes.Count > 0 ? _parentNodes[0] : null;
            }
            set
            {
                if (value == null)
                {
                    _parentNodes.Clear();
                }
                else
                {
                    _parentNodes.Clear();
                    _parentNodes.Add(value);
                }
            }
        }

        /// <summary>
        /// Gets the bounding box of current entity in its object space coordinate system.
        /// </summary>
        public BoundingBox GetBoundingBox()
        {
            return BoundingBox.Null;
        }

        /// <summary>
        /// Gets the key of the entity renderer registered in the renderer
        /// </summary>
        public virtual EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey(this.GetType().Name);
        }
    }
}
