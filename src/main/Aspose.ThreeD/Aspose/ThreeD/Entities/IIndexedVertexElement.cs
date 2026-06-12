using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// VertexElement with indices data.
    /// </summary>
    public interface IIndexedVertexElement
    {
        /// <summary>
        /// Gets the indices data
        /// </summary>
        IArrayList<int> Indices { get; }
    }
}
