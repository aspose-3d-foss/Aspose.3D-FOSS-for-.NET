using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.ThreeD.Shading
{
    /// <summary>
    /// Material defines the parameters necessary for visual appearance of geometry.
    /// Aspose.3D provides shading model for Lambert, Phong and PbrMaterial.
    /// </summary>
    public abstract class Material : A3DObject, INamedObject, IEnumerable<TextureSlot>, IEnumerable
    {
        private Dictionary<string, TextureBase> _textures = new Dictionary<string, TextureBase>();

        /// <summary>
        /// Used in GetTexture/SetTexture to assign a specular texture mapping.
        /// </summary>
        public const string MapSpecular = "Specular";

        /// <summary>
        /// Used in GetTexture/SetTexture to assign a diffuse texture mapping.
        /// </summary>
        public const string MapDiffuse = "Diffuse";

        /// <summary>
        /// Used in GetTexture/SetTexture to assign a emissive texture mapping.
        /// </summary>
        public const string MapEmissive = "Emissive";

        /// <summary>
        /// Used in GetTexture/SetTexture to assign a ambient texture mapping.
        /// </summary>
        public const string MapAmbient = "Ambient";

        /// <summary>
        /// Used in GetTexture/SetTexture to assign a normal texture mapping.
        /// </summary>
        public const string MapNormal = "Normal";

        /// <summary>
        /// Initializes a new instance of the Material class.
        /// </summary>
        internal Material() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Material class.
        /// </summary>
        internal Material(string name) : base(name)
        {
        }

        /// <summary>        /// </summary>
        public TextureBase GetTexture(string slotName)
        {
            _textures.TryGetValue(slotName, out var texture);
            return texture;
        }

        /// <summary>
        /// Sets the texture to specified slot.
        /// </summary>
        public void SetTexture(string slotName, TextureBase texture)
        {
            _textures[slotName] = texture;
        }

        /// <summary>
        /// Formats object to string.
        /// </summary>
        public override string ToString()
        {
            return $"Material [{Name}]";
        }

        /// <summary>
        /// Gets the enumerator to enumerate internal texture slots.
        /// </summary>
        public IEnumerator<TextureSlot> GetEnumerator()
        {
            foreach (var kvp in _textures)
            {
                yield return new TextureSlot(kvp.Key, kvp.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
