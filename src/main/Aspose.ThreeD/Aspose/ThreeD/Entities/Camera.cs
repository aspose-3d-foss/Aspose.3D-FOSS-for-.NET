using System;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// The base class of Camera and Light
    /// </summary>
    public abstract class Frustum : Entity, INamedObject, IOrientable
    {
        private RotationMode _rotationMode = RotationMode.FixedTarget;
        private double _nearPlane = 0.1;
        private double _farPlane = 1000.0;
        private double _aspect = 1.0;
        private double _orthoHeight = 1.0;
        private Vector3 _up = new Vector3(0, 1, 0);
        private Vector3 _lookAt = new Vector3(0, 0, -1);

        /// <summary>
        /// Initializes a new instance of the Frustum class
        /// </summary>
        protected Frustum(string name) : base(name)
        {
        }

        /// <summary>
        /// Gets or sets the frustum's orientation mode
        /// This property only works when the Target is null.
        /// If the value is LookAt, the direction is always calculated by the property Direction
        /// Otherwise the Direction is always calculated by the Target
        /// </summary>
        public RotationMode RotationMode
        {
            get => _rotationMode;
            set => _rotationMode = value;
        }

        /// <summary>
        /// Gets or sets the frustum's near plane distance.
        /// </summary>
        public double NearPlane
        {
            get => _nearPlane;
            set => _nearPlane = value;
        }

        /// <summary>
        /// Gets or sets the frustum's far plane distance.
        /// </summary>
        public double FarPlane
        {
            get => _farPlane;
            set => _farPlane = value;
        }

        /// <summary>
        /// Gets or sets the aspect ratio of the frustum
        /// </summary>
        public double Aspect
        {
            get => _aspect;
            set => _aspect = value;
        }

        /// <summary>
        /// Gets or sets the height when frustum in orthographic projection.
        /// </summary>
        public double OrthoHeight
        {
            get => _orthoHeight;
            set => _orthoHeight = value;
        }

        /// <summary>
        /// Gets or sets the up direction of the camera
        /// </summary>
        public Vector3 Up
        {
            get => _up;
            set => _up = value;
        }

        /// <summary>
        /// Gets or sets the the interested position that the camera is looking at.
        /// </summary>
        public Vector3 LookAt
        {
            get => _lookAt;
            set => _lookAt = value;
        }

        /// <summary>
        /// Gets or sets the direction that the camera is looking at.
        /// Changes on this property will also affects the LookAt and Target.
        /// </summary>
        public Vector3 Direction
        {
            get => _lookAt;
            set
            {
                // Update lookAt based on direction
                // This is a simplified implementation
                _lookAt = value;
            }
        }
         /// <summary>
         /// Gets or sets the target that the camera is looking at.
         /// If the user supports this property, it should be prior to Direction property.
         /// </summary>
         public Node Target { get; set; }
     }
    /// <summary>
    /// The camera describes the eye point of the viewer looking at the scene.
    /// </summary>
    public class Camera : Frustum, INamedObject, IOrientable
    {
        private ProjectionType _projectionType = ProjectionType.Perspective;
        private double _fieldOfView = 45.0;
        private double _fieldOfViewX = 45.0;
        private double _fieldOfViewY = 45.0;
        private double _width = 1.0;
        private double _height = 1.0;
        private double _aspectRatio = 1.0;
        private Vector2 _magnification = new Vector2(1, 1);
        private ApertureMode _apertureMode = ApertureMode.HorizAndVert;

        /// <summary>
        /// Initializes a new instance of the Camera class.
        /// </summary>
        public Camera() : base("Camera")
        {
        }

        /// <summary>
        /// Initializes a new instance of the Camera class.
        /// </summary>
        public Camera(ProjectionType projectionType) : base("Camera")
        {
            _projectionType = projectionType;
        }

        /// <summary>
        /// Initializes a new instance of the Camera class.
        /// </summary>
        public Camera(string name) : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Camera class.
        /// </summary>
        public Camera(string name, ProjectionType projectionType) : base(name)
        {
            _projectionType = projectionType;
        }

        /// <summary>
        /// Gets or sets the camera's aperture mode
        /// </summary>
        public ApertureMode ApertureMode
        {
            get => _apertureMode;
            set => _apertureMode = value;
        }

        /// <summary>
        /// Gets or sets the camera's field of view in degrees, this property is used only when ApertureMode is HorizontalAndVertical or Vertical
        /// </summary>
        public double FieldOfView
        {
            get => _fieldOfView;
            set => _fieldOfView = value;
        }

        /// <summary>
        /// Gets or sets the camera's horizontal field of view in degrees, this property is used only when ApertureMode is Horizontal
        /// </summary>
        public double FieldOfViewX
        {
            get => _fieldOfViewX;
            set => _fieldOfViewX = value;
        }

        /// <summary>
        /// Gets or sets the camera's vertical field of view in degrees, this property is used only when ApertureMode is Vertical
        /// </summary>
        public double FieldOfViewY
        {
            get => _fieldOfViewY;
            set => _fieldOfViewY = value;
        }

        /// <summary>
        /// Gets or sets the view plane's width measured in inches
        /// </summary>
        public double Width
        {
            get => _width;
            set => _width = value;
        }

        /// <summary>
        /// Gets or sets the view plane's height measured in inches
        /// </summary>
        public double Height
        {
            get => _height;
            set => _height = value;
        }

        /// <summary>
        /// Gets or sets the view plane aspect ratio.
        /// </summary>
        public double AspectRatio
        {
            get => _aspectRatio;
            set => _aspectRatio = value;
        }

        /// <summary>
        /// Gets or sets the magnification used in orthographic camera
        /// </summary>
        public Vector2 Magnification
        {
            get => _magnification;
            set => _magnification = value;
        }

        /// <summary>
        /// Gets or sets the camera's projection type.
        /// By default the perspective projection is used.
        /// </summary>
        public ProjectionType ProjectionType
        {
            get => _projectionType;
            set => _projectionType = value;
        }

        /// <summary>
        /// Move camera forward towards its direction or target.
        /// </summary>
        public void MoveForward(double distance)
        {
            // This method would require access to the Node transform
            // which is not available in the Camera class
            throw new NotImplementedException("MoveForward requires access to Node transform");
        }
    }
}
