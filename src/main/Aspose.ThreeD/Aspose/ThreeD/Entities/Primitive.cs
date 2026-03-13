namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Base class for all primitives
    /// </summary>
    public abstract class Primitive : Geometry, INamedObject, IMeshConvertible
    {
        /// <summary>
        /// Initializes a new instance of the Primitive class.
        /// </summary>
        protected Primitive(string name) : base(name)
        {
        }

        /// <summary>
        /// Converts current object to mesh
        /// </summary>
        public abstract Mesh ToMesh();
    }
}
