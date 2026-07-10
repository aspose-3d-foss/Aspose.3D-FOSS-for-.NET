using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// A transform contains information that allow access to object's translate/scale/rotation or transform matrix at minimum cost
    /// This is used by local transform.
    /// </summary>
    public class Transform : A3DObject, INamedObject
    {
        internal Transform()
        {
        }

        private Vector3 _translation;
        private Vector3 _scaling;
        private Quaternion _rotation;
        private Vector3 _preRotation;
        private Vector3 _postRotation;
        private Vector3 _scalingOffset;
        private Vector3 _scalingPivot;
        private Vector3 _rotationOffset;
        private Vector3 _rotationPivot;
        private Vector3 _geometricTranslation;
        private Vector3 _geometricScaling;
        private Vector3 _geometricRotation;
        private Vector3 _eulerAngles;
        private Matrix4 _transformMatrix;

        /// <summary>
        /// Gets or sets the translation
        /// </summary>
        public Vector3 Translation
        {
            get => _translation;
            set => _translation = value;
        }

        /// <summary>
        /// Gets or sets the scaling
        /// </summary>
        public Vector3 Scaling
        {
            get => _scaling;
            set => _scaling = value;
        }

        /// <summary>
        /// Gets or sets the scaling offset
        /// </summary>
        public Vector3 ScalingOffset
        {
            get => _scalingOffset;
            set => _scalingOffset = value;
        }

        /// <summary>
        /// Gets or sets the scaling pivot
        /// </summary>
        public Vector3 ScalingPivot
        {
            get => _scalingPivot;
            set => _scalingPivot = value;
        }

        /// <summary>
        /// Gets or sets the pre-rotation represented in degree
        /// </summary>
        public Vector3 PreRotation
        {
            get => _preRotation;
            set => _preRotation = value;
        }

        /// <summary>
        /// Gets or sets the rotation offset
        /// </summary>
        public Vector3 RotationOffset
        {
            get => _rotationOffset;
            set => _rotationOffset = value;
        }

        /// <summary>
        /// Gets or sets the rotation pivot
        /// </summary>
        public Vector3 RotationPivot
        {
            get => _rotationPivot;
            set => _rotationPivot = value;
        }

        /// <summary>
        /// Gets or sets the post-rotation represented in degree
        /// </summary>
        public Vector3 PostRotation
        {
            get => _postRotation;
            set => _postRotation = value;
        }

        /// <summary>
        /// Gets or sets the rotation represented in Euler angles, measured in degree
        /// </summary>
        public Vector3 EulerAngles
        {
            get => _eulerAngles;
            set => _eulerAngles = value;
        }

        /// <summary>
        /// Gets or sets the rotation represented in quaternion.
        /// </summary>
        public Quaternion Rotation
        {
            get => Quaternion.FromEulerAngle(_eulerAngles);
            set => _eulerAngles = value.EulerAngles();
        }

        /// <summary>
        /// Gets or sets the transform matrix.
        /// </summary>
        public Matrix4 TransformMatrix
        {
            get => _transformMatrix;
            set => _transformMatrix = value;
        }

        /// <summary>
        /// Gets or sets the geometric translation.
        /// Geometric transformation only affects the entities attached and leave the child nodes unaffected.
        /// It will be merged as local transformation when you export the geometric transformation to file types that does not support it.
        /// </summary>
        public Vector3 GeometricTranslation
        {
            get => _geometricTranslation;
            set => _geometricTranslation = value;
        }

        /// <summary>
        /// Gets or sets the geometric scaling.
        /// Geometric transformation only affects the entities attached and leave the child nodes unaffected.
        /// It will be merged as local transformation when you export the geometric transformation to file types that does not support it.
        /// </summary>
        public Vector3 GeometricScaling
        {
            get => _geometricScaling;
            set => _geometricScaling = value;
        }

        /// <summary>
        /// Gets or sets the geometric Euler rotation(measured in degree).
        /// Geometric transformation only affects the entities attached and leave the child nodes unaffected.
        /// It will be merged as local transformation when you export the geometric transformation to file types that does not support it.
        /// </summary>
        public Vector3 GeometricRotation
        {
            get => _geometricRotation;
            set => _geometricRotation = value;
        }

        /// <summary>
        /// Sets the geometric translation.
        /// Geometric transformation only affects the entities attached and leave the child nodes unaffected.
        /// It will be merged as local transformation when you export the geometric transformation to file types that does not support it.
        /// </summary>
        public Transform SetGeometricTranslation(double x, double y, double z)
        {
            _geometricTranslation = new Vector3(x, y, z);
            return this;
        }

        /// <summary>
        /// Sets the geometric scaling.
        /// Geometric transformation only affects the entities attached and leave the child nodes unaffected.
        /// It will be merged as local transformation when you export the geometric transformation to file types that does not support it.
        /// </summary>
        public Transform SetGeometricScaling(double sx, double sy, double sz)
        {
            _geometricScaling = new Vector3(sx, sy, sz);
            return this;
        }

        /// <summary>
        /// Sets the geometric Euler rotation(measured in degree).
        /// Geometric transformation only affects the entities attached and leave the child nodes unaffected.
        /// It will be merged as local transformation when you export the geometric transformation to file types that does not support it.
        /// </summary>
        public Transform SetGeometricRotation(double rx, double ry, double rz)
        {
            _geometricRotation = new Vector3(rx, ry, rz);
            return this;
        }

        /// <summary>
        /// Sets the translation of current transform.
        /// </summary>
        public Transform SetTranslation(double tx, double ty, double tz)
        {
            _translation = new Vector3(tx, ty, tz);
            return this;
        }

        /// <summary>
        /// Sets the scale of current transform.
        /// </summary>
        public Transform SetScale(double sx, double sy, double sz)
        {
            _scaling = new Vector3(sx, sy, sz);
            return this;
        }

        /// <summary>
        /// Sets the Euler angles in degrees of current transform.
        /// </summary>
        public Transform SetEulerAngles(double rx, double ry, double rz)
        {
            _eulerAngles = new Vector3(rx, ry, rz);
            _rotation = Quaternion.FromEulerAngle(rx, ry, rz);
            return this;
        }

        /// <summary>
        /// Sets the rotation(as quaternion components) of current transform.
        /// </summary>
        public Transform SetRotation(double rw, double rx, double ry, double rz)
        {
            _rotation = new Quaternion(rx, ry, rz, rw);
            _eulerAngles = _rotation.EulerAngles();
            return this;
        }

        /// <summary>
        /// Sets the pre-rotation represented in degree
        /// </summary>
        public Transform SetPreRotation(double rx, double ry, double rz)
        {
            _preRotation = new Vector3(rx, ry, rz);
            return this;
        }

        /// <summary>
        /// Sets the post-rotation represented in degree
        /// </summary>
        public Transform SetPostRotation(double rx, double ry, double rz)
        {
            _postRotation = new Vector3(rx, ry, rz);
            return this;
        }
    }
}
