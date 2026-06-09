using System;
using Aspose.ThreeD.Render;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// The base class of all curve implementations.
    /// </summary>
    public abstract class Curve : Entity, INamedObject
    {
        /// <summary>
        /// Gets or sets the color of the line, default value is white(1, 1, 1)
        /// </summary>
        public Vector3 Color { get; set; }

        /// <summary>
        /// Gets the key of the entity renderer registered in the renderer
        /// </summary>
        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("Curve");
        }

        /// <summary>
        /// Protected constructor to allow derived classes to set name
        /// </summary>
        /// <param name="name">The name of the curve</param>
        protected Curve(string name) : base(name)
        {
        }
    }
}
