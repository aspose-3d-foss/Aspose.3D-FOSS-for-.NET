using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// The Skeleton is mainly used by CAD software to help designer to manipulate the transformation of skeletal structure, it's usually useless outside the CAD softwares.
    /// </summary>
    public class Skeleton : Entity, INamedObject
    {
        private double _size;
        private SkeletonType _type;

        /// <summary>
        /// Initializes a new instance of the Skeleton class.
        /// </summary>
        public Skeleton() : this("Skeleton", SkeletonType.Skeleton)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Skeleton class.
        /// </summary>
        /// <param name="name">Entity name</param>
        public Skeleton(string name) : this(name, SkeletonType.Skeleton)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Skeleton class.
        /// </summary>
        /// <param name="name">Entity name</param>
        /// <param name="type">Skeleton type</param>
        public Skeleton(string name, SkeletonType type) : base(name)
        {
            _size = 1.0;
            _type = type;
        }

        /// <summary>
        /// Gets or sets the limb node size that used in CAD software to represent the size of the bone.
        /// </summary>
        public double Size
        {
            get => _size;
            set => _size = value;
        }

        /// <summary>
        /// Gets or sets the type of the skeleton.
        /// </summary>
        public SkeletonType Type
        {
            get => _type;
            set => _type = value;
        }
    }
}
