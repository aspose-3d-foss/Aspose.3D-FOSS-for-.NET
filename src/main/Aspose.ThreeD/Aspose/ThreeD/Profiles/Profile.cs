using Aspose.ThreeD.Render;

namespace Aspose.ThreeD.Profiles
{
    /// <summary>
    /// 2D Profile in xy plane
    /// </summary>
    public abstract class Profile : Entity, INamedObject
    {
        /// <summary>
        /// Gets the key of the entity renderer registered in the renderer
        /// </summary>
        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("Profile");
        }

        /// <summary>
        /// Protected constructor to allow derived classes to set name
        /// </summary>
        /// <param name="name">The name of the profile</param>
        protected Profile(string name) : base(name)
        {
        }
    }
}
