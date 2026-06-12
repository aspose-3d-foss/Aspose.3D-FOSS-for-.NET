using System;
using Aspose.ThreeD;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Formats
{
    /// <summary>
    /// Load options for Wavefront OBJ format
    /// </summary>
    public class ObjLoadOptions : LoadOptions
    {
        /// <summary>
        /// Initializes a new instance of the ObjLoadOptions class
        /// </summary>
        public ObjLoadOptions() : base()
        {
            FlipCoordinateSystem = false;
            EnableMaterials = true;
            Scale = 1.0;
            NormalizeNormal = true;
        }

        /// <summary>
        /// Gets or sets whether flip coordinate system of control points/normal during importing
        /// </summary>
        public bool FlipCoordinateSystem { get; set; }

        /// <summary>
        /// Gets or sets whether import materials for each object
        /// </summary>
        public bool EnableMaterials { get; set; }

        /// <summary>
        /// Scales on x/y/z axis, default value is 1.0
        /// </summary>
        public double Scale { get; set; }

        /// <summary>
        /// Gets or sets whether to normalize the normal vector during the loading.
        /// Default value is true.
        /// </summary>
        public bool NormalizeNormal { get; set; }
    }

    /// <summary>
    /// Save options for Wavefront OBJ format
    /// </summary>
    public class ObjSaveOptions : SaveOptions
    {
        /// <summary>
        /// Initializes a new instance of the ObjSaveOptions class
        /// </summary>
        public ObjSaveOptions() : base()
        {
            ApplyUnitScale = false;
            PointCloud = false;
            Verbose = false;
            SerializeW = false;
            EnableMaterials = true;
            FlipCoordinateSystem = false;
            AxisSystem = new AxisSystem();
        }

        /// <summary>
        /// Apply to the mesh.
        /// Default value is false.
        /// </summary>
        public bool ApplyUnitScale { get; set; }

        /// <summary>
        /// Gets or sets the flag whether the exporter should export the scene as point cloud(without topological structure), default value is false
        /// </summary>
        public bool PointCloud { get; set; }

        /// <summary>
        /// Gets or sets whether generate comments for each section
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// Gets or sets whether serialize W component in model's vertex position.
        /// </summary>
        public bool SerializeW { get; set; }

        /// <summary>
        /// Gets or sets whether import/export materials for each object
        /// </summary>
        public bool EnableMaterials { get; set; }

        /// <summary>
        /// Gets or sets whether flip coordinate system of control points/normal during importing/exporting.
        /// </summary>
        public bool FlipCoordinateSystem { get; set; }

        /// <summary>
        /// Gets or sets the axis system in the exported file.
        /// </summary>
        public AxisSystem AxisSystem { get; set; }
    }

    /// <summary>
    /// Load options for STL format
    /// </summary>
    public class StlLoadOptions : LoadOptions
    {
        /// <summary>
        /// Initializes a new instance of the StlLoadOptions class
        /// </summary>
        public StlLoadOptions() : base()
        {
        }
    }

    /// <summary>
    /// Save options for STL format
    /// </summary>
    public class StlSaveOptions : SaveOptions
    {
        /// <summary>
        /// Initializes a new instance of the StlSaveOptions class
        /// </summary>
        public StlSaveOptions() : base()
        {
        }
    }

    /// <summary>
    /// Load options for glTF format
    /// </summary>
    public class GltfLoadOptions : LoadOptions
    {
        /// <summary>
        /// Initializes a new instance of the GltfLoadOptions class
        /// </summary>
        public GltfLoadOptions() : base()
        {
            FlipTexCoordV = true;
        }

        /// <summary>
        /// Gets or sets whether to flip the V coordinate of texture coordinates during import.
        /// Default value is true.
        /// </summary>
        public bool FlipTexCoordV { get; set; }
    }

    /// <summary>
    /// Save options for glTF format
    /// </summary>
    public class GltfSaveOptions : SaveOptions
    {
        /// <summary>
        /// Initializes a new instance of the GltfSaveOptions class
        /// </summary>
        public GltfSaveOptions() : base()
        {
        }
    }

    /// <summary>
    /// Load options for FBX format
    /// </summary>
    public class FbxLoadOptions : LoadOptions
    {
        /// <summary>
        /// Initializes a new instance of the FbxLoadOptions class
        /// </summary>
        public FbxLoadOptions() : base()
        {
        }
    }

    /// <summary>
    /// Save options for FBX format
    /// </summary>
    public class FbxSaveOptions : SaveOptions
    {
        /// <summary>
        /// Initializes a new instance of the FbxSaveOptions class
        /// </summary>
        public FbxSaveOptions() : base()
        {
        }
    }

    /// <summary>
    /// Save options for Collada format
    /// </summary>
    public class ColladaSaveOptions : SaveOptions
    {
        /// <summary>
        /// Initializes a new instance of the ColladaSaveOptions class
        /// </summary>
        public ColladaSaveOptions()
        {
            Indented = false;
            TransformStyle = ColladaTransformStyle.Components;
        }

        /// <summary>
        /// Gets or sets whether the exported XML document is indented.
        /// </summary>
        public bool Indented { get; set; }

        /// <summary>
        /// Gets or sets the style of node transformation
        /// </summary>
        public ColladaTransformStyle TransformStyle { get; set; }
    }
    public class Microsoft3MFSaveOptions : SaveOptions
    {
        public Microsoft3MFSaveOptions() : base()
        {
        }
    }

    public class PlyLoadOptions : LoadOptions
    {
        public PlyLoadOptions() : base()
        {
        }
    }

    public class PlySaveOptions : SaveOptions
    {
        public PlySaveOptions() : base()
        {
        }
    }

    /// <summary>
    /// Save options for Google draco files
    /// </summary>
    public class DracoSaveOptions : SaveOptions
    {
        /// <summary>
        /// Construct a default configuration for saving draco files.
        /// </summary>
        public DracoSaveOptions() : base()
        {
        }

        /// <summary>
        /// Quantization bits for position, default value is 14
        /// </summary>
        public int PositionBits { get; set; } = 14;

        /// <summary>
        /// Quantization bits for texture coordinate, default value is 12
        /// </summary>
        public int TextureCoordinateBits { get; set; } = 12;

        /// <summary>
        /// Quantization bits for vertex color, default value is 10
        /// </summary>
        public int ColorBits { get; set; } = 10;

        /// <summary>
        /// Quantization bits for normal vectors, default value is 10
        /// </summary>
        public int NormalBits { get; set; } = 10;

        /// <summary>
        /// Compression level, default value is
        /// </summary>
        public DracoCompressionLevel CompressionLevel { get; set; } = DracoCompressionLevel.Standard;

        /// <summary>
        /// Apply  to the mesh.
        /// Default value is false.
        /// </summary>
        public bool ApplyUnitScale { get; set; } = false;

        /// <summary>
        /// Export the scene as point cloud, default value is false.
        /// </summary>
        public bool PointCloud { get; set; } = false;
    }

    /// <summary>
    /// Compression level for draco file
    /// </summary>
    public enum DracoCompressionLevel
    {
        NoCompression,
        Fast,
        Standard,
        Optimal,
    }

    /// <summary>
    /// Options for PDF loading
    /// </summary>
    public class PdfLoadOptions : LoadOptions
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public PdfLoadOptions() : base()
        {
        }

        /// <summary>
        /// The password to unlock the encrypted PDF file.
        /// </summary>
        public byte[] Password { get; set; }
    }

    /// <summary>
    /// The save options in PDF exporting.
    /// </summary>
    public class PdfSaveOptions : SaveOptions
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public PdfSaveOptions() : base()
        {
        }

        /// <summary>
        /// Render mode specifies the style in which the 3D artwork is rendered.
        /// </summary>
        public PdfRenderMode RenderMode { get; set; } = PdfRenderMode.Solid;

        /// <summary>
        /// LightingScheme specifies the lighting to apply to 3D artwork.
        /// </summary>
        public PdfLightingScheme LightingScheme { get; set; } = PdfLightingScheme.Artwork;

        /// <summary>
        /// Background color of the 3D view in PDF file.
        /// </summary>
        public Vector3 BackgroundColor { get; set; } = new Vector3(1, 1, 1);

        /// <summary>
        /// Gets or sets the face color to be used  when rendering the 3D content. 
        /// This is only relevant only when the  has a value of Illustration.
        /// </summary>
        public Vector3 FaceColor { get; set; } = new Vector3(0.75f, 0.75f, 0.75f);

        /// <summary>
        /// Gets or sets the auxiliary color to be used  when rendering the 3D content.
        /// The interpretation of this color depends on the
        /// </summary>
        public Vector3 AuxiliaryColor { get; set; } = new Vector3(0, 0, 0);
    }

    /// <summary>
    /// Render mode specifies the style in which the 3D artwork is rendered.
    /// </summary>
    public enum PdfRenderMode
    {
        Solid,
        SolidWireframe,
        Transparent,
        TransparentWireframe,
        BoundingBox,
        TransparentBoundingBox,
        TransparentBoundingBoxOutline,
        Wireframe,
        ShadedWireframe,
        HiddenWireframe,
        Vertices,
        ShadedVertices,
        Illustration,
        SolidOutline,
        ShadedIllustration,
    }

    /// <summary>
    /// LightingScheme specifies the lighting to apply to 3D artwork.
    /// </summary>
    public enum PdfLightingScheme
    {
        Artwork,
        None,
        White,
        Day,
        Night,
        Hard,
        Primary,
        Blue,
        Red,
        Cube,
        CAD,
        Headlamp,
    }
}
