using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Orientable entities shall implement this interface.
    /// </summary>
    public interface IOrientable
    {
        /// <summary>
        /// Gets or sets the direction that the entity is looking at.
        /// </summary>
        Vector3 Direction { get; set; }

        /// <summary>
        /// Gets or sets the target that the entity is looking at.
        /// </summary>
        Node Target { get; set; }
    }
}
