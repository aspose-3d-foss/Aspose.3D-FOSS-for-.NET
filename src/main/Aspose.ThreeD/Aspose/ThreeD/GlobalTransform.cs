using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    /// <summary>
    /// The global transform of the node
    /// </summary>
    public class GlobalTransform
    {
        private Matrix4 _matrix;

        /// <summary>
        /// Initializes a new instance of the GlobalTransform class
        /// </summary>
        public GlobalTransform()
        {
            _matrix = Matrix4.Identity;
        }

        /// <summary>
        /// Gets the transformation matrix
        /// </summary>
        public Matrix4 Matrix
        {
            get => _matrix;
            set => _matrix = value;
        }
    }
}
