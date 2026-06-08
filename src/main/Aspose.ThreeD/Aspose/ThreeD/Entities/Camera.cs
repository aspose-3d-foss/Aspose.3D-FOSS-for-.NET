using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Render;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// The base class of Camera and Light
    /// </summary>
    public abstract class Frustum : Entity
    {
        /// <summary>
        /// Initializes a new instance of the Frustum class
        /// </summary>
        protected Frustum(string name) : base(name)
        {
        }
    }

    /// <summary>
    /// Camera
    /// </summary>
    public class Camera : Frustum
    {
        /// <summary>
        /// Initializes a new instance of the Camera class
        /// </summary>
        public Camera() : base("Camera")
        {
        }

        /// <summary>
        /// Initializes a new instance of the Camera class
        /// </summary>
        public Camera(string name) : base(name)
        {
        }

        /// <summary>
        /// Gets the bounding box of current entity in its object space coordinate system.
        /// </summary>
        public override BoundingBox GetBoundingBox()
        {
            return new BoundingBox();
        }

        /// <summary>
        /// Gets the key of the entity renderer registered in the renderer
        /// </summary>
        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("Camera");
        }
    }
}
