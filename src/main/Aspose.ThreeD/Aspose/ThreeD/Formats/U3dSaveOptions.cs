using System;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Save options for universal 3d
    /// </summary>
    public class U3dSaveOptions : SaveOptions
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public U3dSaveOptions()
        {
        }

        /// <summary>
        /// Gets or sets whether flip coordinate system of control points/normal during importing/exporting.
        /// </summary>
        public bool FlipCoordinateSystem { get; set; }

        /// <summary>
        /// Gets or sets whether to enable mesh data compression.
        /// </summary>
        public bool MeshCompression { get; set; }

        /// <summary>
        /// Gets or sets whether to export normal data.
        /// </summary>
        public bool ExportNormals { get; set; }

        /// <summary>
        /// Gets or sets whether to export texture coordinates.
        /// </summary>
        public bool ExportTextureCoordinates { get; set; }

        /// <summary>
        /// Gets or sets whether to export vertex's diffuse color.
        /// </summary>
        public bool ExportVertexDiffuse { get; set; }

        /// <summary>
        /// Gets or sets whether to export vertex' specular color.
        /// </summary>
        public bool ExportVertexSpecular { get; set; }

        /// <summary>
        /// Embed the external textures into the U3D file, default value is false.
        /// </summary>
        public bool EmbedTextures { get; set; }
    }
}
