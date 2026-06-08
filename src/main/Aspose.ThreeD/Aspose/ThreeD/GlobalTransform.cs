using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Global transform is similar to  but it's immutable while it represents the final evaluated transformation.
    /// Right-hand coordinate system is used while evaluating global transform
    /// </summary>
    public class GlobalTransform : A3DObject
    {
        private readonly Matrix4 _matrix;

        /// <summary>
        /// Initializes a new instance of the GlobalTransform class
        /// </summary>
        public GlobalTransform()
            : this(Matrix4.Identity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the GlobalTransform class with the specified matrix
        /// </summary>
        /// <param name="matrix">The transform matrix</param>
        public GlobalTransform(Matrix4 matrix)
        {
            _matrix = matrix;
        }

        /// <summary>
        /// Gets the translation
        /// </summary>
        public Vector3 Translation
        {
            get
            {
                Vector3 translation;
                Vector3 scaling;
                Quaternion rotation;
                _matrix.Decompose(out translation, out scaling, out rotation);
                return translation;
            }
        }

        /// <summary>
        /// Gets the scale
        /// </summary>
        public Vector3 Scale
        {
            get
            {
                Vector3 translation;
                Vector3 scaling;
                Quaternion rotation;
                _matrix.Decompose(out translation, out scaling, out rotation);
                return scaling;
            }
        }

        /// <summary>
        /// Gets the rotation represented in Euler angles, measured in degree
        /// </summary>
        public Vector3 EulerAngles
        {
            get
            {
                Vector3 translation;
                Vector3 scaling;
                Quaternion rotation;
                _matrix.Decompose(out translation, out scaling, out rotation);
                return rotation.EulerAngles();
            }
        }

        /// <summary>
        /// Gets the rotation represented in quaternion.
        /// </summary>
        public Quaternion Rotation
        {
            get
            {
                Vector3 translation;
                Vector3 scaling;
                Quaternion rotation;
                _matrix.Decompose(out translation, out scaling, out rotation);
                return rotation;
            }
        }

        /// <summary>
        /// Gets the transform matrix.
        /// </summary>
        public Matrix4 TransformMatrix => _matrix;
    }
}
