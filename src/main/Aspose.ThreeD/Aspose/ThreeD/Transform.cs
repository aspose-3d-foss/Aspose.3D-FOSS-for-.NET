using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// The local transform of the node
    /// </summary>
    public class Transform
    {
        private FVector3 _translation;
        private Quaternion _rotation;
        private FVector3 _scale;

        /// <summary>
        /// Initializes a new instance of the Transform class
        /// </summary>
        public Transform()
        {
            _translation = FVector3.Zero;
            _rotation = Quaternion.Identity;
            _scale = new FVector3(1, 1, 1);
        }

        /// <summary>
        /// Gets or sets the translation
        /// </summary>
        public FVector3 Translation
        {
            get => _translation;
            set => _translation = value;
        }

        /// <summary>
        /// Gets or sets the rotation represented as a quaternion
        /// </summary>
        public Quaternion Rotation
        {
            get => _rotation;
            set => _rotation = value;
        }

        /// <summary>
        /// Gets or sets the scale
        /// </summary>
        public FVector3 Scale
        {
            get => _scale;
            set => _scale = value;
        }

        /// <summary>
        /// Gets the transformation matrix
        /// </summary>
        public Matrix4 Matrix
        {
            get
            {
                var matrix = Matrix4.Identity;
                var t = Matrix4.Translation(_translation);
                var r = Matrix4.Rotation(_rotation);
                var s = Matrix4.Scale(_scale);
                return matrix * s * r * t;
            }
        }
    }
}
