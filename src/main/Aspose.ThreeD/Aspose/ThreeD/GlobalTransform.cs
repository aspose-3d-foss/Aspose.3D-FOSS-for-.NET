using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Global transform is similar to  but it's immutable while it represents the final evaluated transformation.
    /// Right-hand coordinate system is used while evaluating global transform
    /// </summary>
    public class GlobalTransform
    {
        internal GlobalTransform()
        {
        }

        /// <summary>
        /// Gets the translation
        /// </summary>
        public Vector3 Translation => Vector3.Zero;

        /// <summary>
        /// Gets the scale
        /// </summary>
        public Vector3 Scale => Vector3.One;

        /// <summary>
        /// Gets the rotation represented in Euler angles, measured in degree
        /// </summary>
        public Vector3 EulerAngles => Vector3.Zero;

        /// <summary>
        /// Gets the rotation represented in quaternion.
        /// </summary>
        public Quaternion Rotation => Quaternion.Identity;

        /// <summary>
        /// Gets the transform matrix.
        /// </summary>
        public Matrix4 TransformMatrix => Matrix4.Identity;
    }
}
