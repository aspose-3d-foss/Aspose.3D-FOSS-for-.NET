using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// The pose is used to store transformation matrix when the geometry is skinned.
    /// The pose is a set of <see cref="BonePose"/>, each <see cref="BonePose"/> saves the concrete transformation information of the bone node.
    /// </summary>
    public class Pose : A3DObject, INamedObject
    {
        private readonly List<BonePose> bonePoses = new List<BonePose>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Pose"/> class.
        /// </summary>
        public Pose() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pose"/> class.
        /// </summary>
        /// <param name="name">The name of the pose.</param>
        public Pose(string name) : base(name)
        {
        }

        /// <summary>
        /// Gets or sets the type of the pose.
        /// </summary>
        public PoseType PoseType { get; set; }

        /// <summary>
        /// Gets all <see cref="BonePose"/> instances.
        /// </summary>
        public IList<BonePose> BonePoses => bonePoses;

        /// <summary>
        /// Saves pose transformation matrix for the given bone node.
        /// </summary>
        /// <param name="node">The scene node, points to a skinned skeleton node.</param>
        /// <param name="matrix">The transform matrix of the node in current pose.</param>
        /// <param name="localMatrix">If true, the matrix is defined in local coordinate; otherwise, global transformation matrix is implied.</param>
        public void AddBonePose(Node node, Matrix4 matrix, bool localMatrix)
        {
            var bonePose = new BonePose
            {
                Node = node,
                Matrix = matrix,
                IsLocal = localMatrix
            };
            bonePoses.Add(bonePose);
        }

        /// <summary>
        /// Saves pose transformation matrix for the given bone node.
        /// Global transformation matrix is implied.
        /// </summary>
        /// <param name="node">The scene node, points to a skinned skeleton node.</param>
        /// <param name="matrix">The transform matrix of the node in current pose.</param>
        public void AddBonePose(Node node, Matrix4 matrix)
        {
            AddBonePose(node, matrix, false);
        }
    }
}
