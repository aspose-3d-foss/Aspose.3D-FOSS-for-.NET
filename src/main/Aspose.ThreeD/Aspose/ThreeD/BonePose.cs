using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// The  contains the transformation matrix for a bone node
    /// </summary>
    public class BonePose : A3DObject
    {
        /// <summary>
        /// Initializes a new instance of the BonePose class
        /// </summary>
        public BonePose() : base()
        {
        }

        /// <summary>
        /// Gets or sets the scene node, points to a skinned skeleton node
        /// </summary>
        public Node Node { get; set; }

        /// <summary>
        /// Gets or sets the transform matrix of the node in current pose.
        /// </summary>
        public Matrix4 Matrix { get; set; }

        /// <summary>
        /// Gets or sets if the matrix is defined in local coordinate.
        /// </summary>
        public bool IsLocal { get; set; }
    }
}
