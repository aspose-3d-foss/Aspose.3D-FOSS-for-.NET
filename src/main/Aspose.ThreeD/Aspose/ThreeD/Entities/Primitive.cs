namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Base class for all primitives
    /// </summary>
    public abstract class Primitive : Geometry, INamedObject, IMeshConvertible
    {
        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        public Primitive(string name) : base(name)
        {
        }

        /// <summary>
        /// Gets or sets whether this geometry can cast shadow
        /// </summary>
        public new bool CastShadows
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether this geometry can receive shadow.
        /// </summary>
        public new bool ReceiveShadows
        {
            get;
            set;
        }

        /// <summary>
        /// Converts current object to mesh
        /// </summary>
        public abstract Mesh ToMesh();
    }
}
