namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Entities that implemented this interface can be converted to mesh
    /// </summary>
    public interface IMeshConvertible
    {
        /// <summary>
        /// Convert current object to mesh
        /// </summary>
        Mesh ToMesh();
    }
}
