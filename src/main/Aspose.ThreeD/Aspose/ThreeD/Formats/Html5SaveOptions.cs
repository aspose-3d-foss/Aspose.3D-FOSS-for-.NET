using System;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Save options for HTML5
    /// </summary>
    public class Html5SaveOptions : SaveOptions
    {
        /// <summary>
        /// Constructor of  with all default settings.
        /// </summary>
        public Html5SaveOptions()
        {
        }

        /// <summary>
        /// Display a grid in the scene.
        /// Default value is true.
        /// </summary>
        public bool ShowGrid { get; set; }

        /// <summary>
        /// Display rulers of x/y/z axes in the scene to measure the model.
        /// Default value is false.
        /// </summary>
        public bool ShowRulers { get; set; }

        /// <summary>
        /// Display a simple UI in the scene.
        /// Default value is true.
        /// </summary>
        public bool ShowUI { get; set; }

        /// <summary>
        /// Display a orientation box.
        /// Default value is true.
        /// </summary>
        public bool OrientationBox { get; set; }

        /// <summary>
        /// Gets or sets the up vector, value can be "x"/"y"/"z", default value is "y"
        /// </summary>
        public string UpVector { get; set; }

        /// <summary>
        /// Gets or sets the far plane of the camera, default value is 1000.
        /// </summary>
        public double FarPlane { get; set; }

        /// <summary>
        /// Gets or sets the near plane of the camera, default value is 1
        /// </summary>
        public double NearPlane { get; set; }

        /// <summary>
        /// Gets or sets the default look at position, default value is (0, 0, 0)
        /// </summary>
        public Vector3 LookAt { get; set; }

        /// <summary>
        /// Gets or sets the initial position of the camera, default value is (10, 10, 10)
        /// </summary>
        public Vector3 CameraPosition { get; set; }

        /// <summary>
        /// Gets or sets the field of the view, default value is 45, measured in degree.
        /// </summary>
        public double FieldOfView { get; set; }
    }
}
