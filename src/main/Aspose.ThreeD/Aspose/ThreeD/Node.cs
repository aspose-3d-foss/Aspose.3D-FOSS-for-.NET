using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Represents an element in the scene graph.
    /// A scene graph is a tree of Node objects. The tree management services are self contained in this class.
    /// Note the Aspose.3D SDK does not test the validity of the constructed scene graph. It is the responsibility of the caller to make sure that it does not generate cyclic graphs in a node hierarchy.
    /// Besides the tree management, this class defines all the properties required to describe the position of the object in the scene. This information include the basic Translation, Rotation and Scaling properties and the more advanced options for pivots, limits, and IK joints attributes such the stiffness and dampening.
    /// When it is first created, the Node object is "empty" (i.e: it is an object without any graphical representation that only contains the position information). In this state, it can be used to represent parents in the node tree structure but not much more. The normal use of this type of objects is to add them an entity that will specialize the node (see the "Entity").
    /// The entity is an object in itself and is connected to the the Node. This also means that the same entity can be shared among multiple nodes. Camera, Light, Mesh, etc... are all entities and they all derived from the base class Entity.
    /// </summary>
    public class Node : SceneObject
    {
        private readonly List<Node> _childNodes;
        private readonly List<Entity> _entities;
        private readonly List<Shading.Material> _materials;
        private readonly List<CustomObject> _metaDatas;
        private readonly Transform _transform;
        private readonly GlobalTransform _globalTransform;
        private AssetInfo? _assetInfo;
        private Node? _parentNode;
        private bool _visible;
        private bool _excluded;
        private Entity? _entity;
        private Shading.Material? _material;

        /// <summary>
        /// Initializes a new instance of the Node class.
        /// </summary>
        public Node() : base()
        {
            _childNodes = new List<Node>();
            _entities = new List<Entity>();
            _materials = new List<Shading.Material>();
            _metaDatas = new List<CustomObject>();
            _transform = new Transform();
            _globalTransform = new GlobalTransform();
            _assetInfo = null;
            _parentNode = null;
            _visible = true;
            _excluded = false;
        }

        /// <summary>
        /// Initializes a new instance of the Node class.
        /// </summary>
        public Node(string name) : base(name)
        {
            _childNodes = new List<Node>();
            _entities = new List<Entity>();
            _materials = new List<Shading.Material>();
            _metaDatas = new List<CustomObject>();
            _transform = new Transform();
            _globalTransform = new GlobalTransform();
            _assetInfo = null;
            _parentNode = null;
            _visible = true;
            _excluded = false;
        }

        /// <summary>
        /// Initializes a new instance of the Node class.
        /// </summary>
        public Node(string name, Entity entity) : base(name)
        {
            _childNodes = new List<Node>();
            _entities = new List<Entity>();
            _materials = new List<Shading.Material>();
            _metaDatas = new List<CustomObject>();
            _transform = new Transform();
            _globalTransform = new GlobalTransform();
            _assetInfo = null;
            _parentNode = null;
            _visible = true;
            _excluded = false;
            _entity = entity;
            if (entity != null)
            {
                _entities.Add(entity);
            }
        }

        /// <summary>
        /// Per-node asset info
        /// </summary>
        public AssetInfo? AssetInfo
        {
            get => _assetInfo;
            set => _assetInfo = value;
        }

        /// <summary>
        /// Gets or sets to show the node
        /// </summary>
        public bool Visible
        {
            get => _visible;
            set => _visible = value;
        }

        /// <summary>
        /// Gets the children nodes.
        /// </summary>
        public IList<Node> ChildNodes => _childNodes;

        /// <summary>
        /// Gets or sets the first entity attached to this node, if sets, will clear other entities.
        /// </summary>
        public Entity? Entity
        {
            get => _entity;
            set
            {
                _entity = value;
                _entities.Clear();
                if (value != null)
                {
                    _entities.Add(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets whether to exclude this node and all child nodes/entities during exporting.
        /// </summary>
        public bool Excluded
        {
            get => _excluded;
            set => _excluded = value;
        }

        /// <summary>
        /// Gets all node entities.
        /// </summary>
        public IList<Entity> Entities => _entities;

        /// <summary>
        /// Gets the meta data defined in this node.
        /// </summary>
        public IList<CustomObject> MetaDatas => _metaDatas;

        /// <summary>
        /// Gets the materials associated with this node.
        /// </summary>
        public IList<Shading.Material> Materials => _materials;

        /// <summary>
        /// Gets or sets the first material associated with this node, if sets, will clear other materials
        /// </summary>
        public Shading.Material? Material
        {
            get => _material;
            set
            {
                _material = value;
                _materials.Clear();
                if (value != null)
                {
                    _materials.Add(value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the parent node.
        /// </summary>
        public Node? ParentNode
        {
            get => _parentNode;
            set => _parentNode = value;
        }

        /// <summary>
        /// Gets the local transform.
        /// </summary>
        public Transform Transform => _transform;

        /// <summary>
        /// Gets the global transform.
        /// </summary>
        public GlobalTransform GlobalTransform => _globalTransform;

        /// <summary>
        /// Creates a child node
        /// </summary>
        public Node CreateChildNode()
        {
            var node = new Node();
            AddChildNode(node);
            return node;
        }

        /// <summary>
        /// Create a new child node with given node name
        /// </summary>
        public Node CreateChildNode(string nodeName)
        {
            var node = new Node(nodeName);
            AddChildNode(node);
            return node;
        }

        /// <summary>
        /// Create a new child node with given entity attached
        /// </summary>
        public Node CreateChildNode(Entity entity)
        {
            var node = new Node(null, entity);
            AddChildNode(node);
            return node;
        }

        /// <summary>
        /// Create a new child node with given node name
        /// </summary>
        public Node CreateChildNode(string nodeName, Entity entity)
        {
            var node = new Node(nodeName, entity);
            AddChildNode(node);
            return node;
        }

        /// <summary>
        /// Create a new child node with given node name, and attach specified entity and a material
        /// </summary>
        public Node CreateChildNode(string nodeName, Entity entity, Shading.Material material)
        {
            var node = new Node(nodeName, entity);
            node.Material = material;
            AddChildNode(node);
            return node;
        }

        /// <summary>
        /// Add a child node to this node
        /// </summary>
        public void AddChildNode(Node node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            _childNodes.Add(node);
            node.ParentNode = this;
        }

        /// <summary>
        /// Add an entity to the node.
        /// </summary>
        public void AddEntity(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entities.Add(entity);
        }

        /// <summary>
        /// Detach everything under the node and attach them to current node.
        /// </summary>
        public void Merge(Node node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            foreach (var child in node._childNodes)
            {
                AddChildNode(child);
            }
            node._childNodes.Clear();
        }

        /// <summary>
        /// Evaluate the global transform, include the geometric transform or not.
        /// </summary>
        public Matrix4 EvaluateGlobalTransform(bool withGeometricTransform)
        {
            var matrix = _transform.Matrix;
            var current = _parentNode;
            while (current != null)
            {
                matrix = current._transform.Matrix * matrix;
                current = current._parentNode;
            }
            return matrix;
        }

        /// <summary>
        /// Gets the child node at specified index.
        /// </summary>
        public Node GetChild(int index)
        {
            if (index < 0 || index >= _childNodes.Count)
                throw new ArgumentOutOfRangeException(nameof(index));

            return _childNodes[index];
        }

        /// <summary>
        /// Gets the child node with the specified name
        /// </summary>
        public Node? GetChild(string nodeName)
        {
            foreach (var node in _childNodes)
            {
                if (node.Name == nodeName)
                    return node;
            }
            return null;
        }

        /// <summary>
        /// Walks through all descendant nodes(including the current node) and call the visitor with the node.
        /// Visitor can break the walk-through by returning false
        /// </summary>
        public bool Accept(NodeVisitor visitor)
        {
            if (!visitor(this))
                return false;

            foreach (var child in _childNodes)
            {
                if (!child.Accept(visitor))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Calculate the bounding box of the node
        /// </summary>
        public BoundingBox GetBoundingBox()
        {
            var bbox = new BoundingBox();
            foreach (var entity in _entities)
            {
                var entityBbox = entity.GetBoundingBox();
            }
            return bbox;
        }

        /// <summary>
        /// Select single object under current node using XPath-like query syntax.
        /// </summary>
        public object? SelectSingleObject(string path)
        {
            return null;
        }

        /// <summary>
        /// Select multiple objects under current node using XPath-like query syntax.
        /// </summary>
        public List<object> SelectObjects(string path)
        {
            return new List<object>();
        }

        /// <summary>
        /// Gets the string representation of this node.
        /// </summary>
        public override string ToString()
        {
            return $"Node: {Name}";
        }
    }
}
