namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Base class for all primitives
    /// </summary>
    public abstract class Primitive : Geometry, INamedObject, IMeshConvertible
    {
        private string _name;

        /// <summary>
        /// Initializes a new instance of the Primitive class.
        /// </summary>
        protected Primitive(string name) : base(name)
        {
            _name = name;
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// Convert current object to mesh
        /// </summary>
        public abstract Mesh ToMesh();
    }
}
