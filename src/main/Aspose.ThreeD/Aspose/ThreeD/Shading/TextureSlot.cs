namespace Aspose.ThreeD.Shading
{
    /// <summary>
    /// Texture slot in Material, can be enumerated through material instance.
    /// </summary>
    public class TextureSlot
    {
        private string _slotName;
        private TextureBase _texture;

        /// <summary>
        /// The slot name that indicates where this texture will be bounded to.
        /// </summary>
        public string SlotName
        {
            get => _slotName;
            internal set => _slotName = value;
        }

        /// <summary>
        /// The texture that will be bounded to the material.
        /// </summary>
        public TextureBase Texture
        {
            get => _texture;
            internal set => _texture = value;
        }

        internal TextureSlot(string slotName, TextureBase texture)
        {
            _slotName = slotName;
            _texture = texture;
        }
    }
}
