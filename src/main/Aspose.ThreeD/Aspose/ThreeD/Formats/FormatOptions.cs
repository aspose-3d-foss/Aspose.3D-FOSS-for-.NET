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
        /// Initializes of a new  instance.
        /// </summary>
        public StlLoadOptions() : base()
        {
        }

        /// <summary>
        /// Initializes of a new  instance.
        /// </summary>
        public StlLoadOptions(FileContentType contentType)
        {
        }

        /// <summary>
        /// Gets or sets whether to flip coordinate system of control points/normal during importing.
        /// </summary>
        public bool FlipCoordinateSystem { get; set; }

        /// <summary>
        /// Ignore the normal data that stored in STL file and recalculate the normal data based on the vertex position.
        /// Default value is false
        /// </summary>
        public bool RecalculateNormal { get; set; }
    }

    /// <summary>
    /// Save options for STL format
    /// </summary>
    public class StlSaveOptions : SaveOptions
    {
        /// <summary>
        /// Initializes of a new  instance.
        /// </summary>
        public StlSaveOptions() : base()
        {
        }

        /// <summary>
        /// Initializes of a new  instance.
        /// </summary>
        public StlSaveOptions(FileContentType contentType)
        {
        }

        /// <summary>
        /// Gets or sets the axis system in the exported stl file.
        /// </summary>
        public AxisSystem AxisSystem { get; set; }

        /// <summary>
        /// Gets or sets whether flip coordinate system of control points/normal during exporting.
        /// </summary>
        public bool FlipCoordinateSystem { get; set; }
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
        /// Constructor of
        /// </summary>
        public GltfSaveOptions(FileContentType contentType)
        {
        }

        /// <summary>
        /// Constructor of
        /// </summary>
        public GltfSaveOptions(FileFormat format)
        {
        }

        /// <summary>
        /// The JSON content of GLTF file is indented for human reading, default value is false
        /// </summary>
        public bool PrettyPrint { get; set; }

        /// <summary>
        /// When GLTF2 exporter detected an invalid normal, this will be used instead of its original value to bypass the validation.
        /// Default value is (0, 1, 0)
        /// </summary>
        public Nullable<Vector3> FallbackNormal { get; set; }

        /// <summary>
        /// Embed all external assets as base64 into single file in ASCII mode, default value is false.
        /// </summary>
        public bool EmbedAssets { get; set; }

        /// <summary>
        /// Standard glTF only supports PNG/JPG as its texture format, this option will guide how Aspose.3D
        /// convert the non-standard images to supported format during the exporting.
        /// Default value is
        /// </summary>
        public GltfEmbeddedImageFormat ImageFormat { get; set; }

        /// <summary>
        /// Custom converter to convert the geometry's material to PBR material
        /// If this is unassigned, glTF 2.0 exporter will automatically convert the standard material to PBR material.
        /// Default value is null
        /// This property is used when exporting a scene to a glTF 2.0 file.
        /// </summary>
        public MaterialConverter MaterialConverter { get; set; }

        /// <summary>
        /// Serialize materials using KHR common material extensions, default value is false.
        /// Set this to false will cause Aspose.3D export a set of vertex/fragment shader if
        /// </summary>
        public bool UseCommonMaterials { get; set; }

        /// <summary>
        /// Use external draco encoder to accelerate the draco compression speed.
        /// </summary>
        public string ExternalDracoEncoder { get; set; }

        /// <summary>
        /// Flip texture coordinate  v(t) component, default value is true.
        /// </summary>
        public bool FlipTexCoordV { get; set; }

        /// <summary>
        /// The file name of the external buffer file used to store binary data.
        /// If this file is not specified, Aspose.3D will generate a name for you.
        /// This is ignored when export glTF in binary mode.
        /// </summary>
        public string BufferFile { get; set; }

        /// <summary>
        /// Save scene object's dynamic properties into 'extra' fields in the generated glTF file.
        /// This is useful to provide application-specific data.
        /// Default value is false.
        /// </summary>
        public bool SaveExtras { get; set; }

        /// <summary>
        /// Apply  to the mesh.
        /// Default value is false.
        /// </summary>
        public bool ApplyUnitScale { get; set; }

        /// <summary>
        /// Gets or sets whether to enable draco compression
        /// </summary>
        public bool DracoCompression { get; set; }
    }

    /// <summary>
    /// Load options for FBX format
    /// </summary>
    public class FbxLoadOptions : LoadOptions
    {
        /// <summary>
        /// Constructor of
        /// </summary>
        public FbxLoadOptions(FileFormat format)
        {
        }

        /// <summary>
        /// Constructor of
        /// </summary>
        public FbxLoadOptions() : base()
        {
        }

        /// <summary>
        /// Gets or sets whether to keep the builtin properties in GlobalSettings which have a native property replacement in .
        /// Set this to true if you want the full properties in GlobalSettings
        /// Default value is false
        /// </summary>
        public bool KeepBuiltinGlobalSettings { get; set; }

        /// <summary>
        /// Gets or sets whether to enable compatible mode.
        /// Compatible mode will try to support non-standard FBX definitions like PBR materials exported by Blender.
        /// Default value is false.
        /// </summary>
        public bool CompatibleMode { get; set; }
    }

    /// <summary>
    /// Save options for FBX format
    /// </summary>
    public class FbxSaveOptions : SaveOptions
    {
        /// <summary>
        /// Initializes a
        /// </summary>
        public FbxSaveOptions(FileFormat format)
        {
        }

        /// <summary>
        /// Initialize a using latest supported version.
        /// </summary>
        public FbxSaveOptions(FileContentType contentType)
        {
        }
        /// <summary>
        /// Reuse the mesh for the primitives with same parameters, this will significantly reduce the size of FBX output which scene was constructed by large set of primitive shapes(like imported from CAD files).
        /// Default value is false
        /// </summary>
        public bool ReusePrimitiveMesh { get; set; }

        /// <summary>
        /// Compression large binary data in the FBX file(e.g. animation data, control points, vertex element data, indices), default value is true.
        /// </summary>
        public bool EnableCompression { get; set; }

        /// <summary>
        /// Gets or sets whether reuse repeated curve data by increasing last data's ref count
        /// </summary>
        public Nullable<bool> FoldRepeatedCurveData { get; set; }

        /// <summary>
        /// Gets or sets whether export legacy material properties, used for back compatibility.
        /// This option is turned on by default.
        /// </summary>
        public bool ExportLegacyMaterialProperties { get; set; }

        /// <summary>
        /// Gets or sets whether generate a Video instance for  when exporting as FBX.
        /// </summary>
        public bool VideoForTexture { get; set; }

        /// <summary>
        /// Gets or sets whether to embed the texture to the final output file.
        /// FBX Exporter will try to find the texture's raw data from , and embed the file to final FBX file.
        /// Default value is false.
        /// </summary>
        public bool EmbedTextures { get; set; }

        /// <summary>
        /// Gets or sets whether always generate a  for geometries if the attached node contains materials.
        /// This is turned off by default.
        /// </summary>
        public bool GenerateVertexElementMaterial { get; set; }
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

        /// <summary>
        /// Enable compression on the output 3mf file
        /// Default value is true
        /// </summary>
        public bool EnableCompression { get; set; } = true;

        /// <summary>
        /// Mark all geometries in scene to be printable.
        /// Or you can manually mark node to be printable by 
        /// Default value is true
        /// </summary>
        public bool BuildAll { get; set; } = true;
    }

    public class PlyLoadOptions : LoadOptions
    {
        public PlyLoadOptions() : base()
        {
        }

        /// <summary>
        /// Gets or sets flip coordinate system of control points/normal during importing/exporting.
        /// </summary>
        public bool FlipCoordinateSystem { get; set; }
    }

    public class PlySaveOptions : SaveOptions
    {
        public PlySaveOptions() : base()
        {
        }

        /// <summary>
        /// Constructor of
        /// </summary>
        public PlySaveOptions(FileContentType contentType)
        {
        }

        /// <summary>
        /// Export the scene as point cloud, the default value is false.
        /// </summary>
        public bool PointCloud { get; set; }

        /// <summary>
        /// Flip the coordinate while saving the scene, default value is true
        /// </summary>
        public bool FlipCoordinate { get; set; }

        /// <summary>
        /// The element name for the vertex data, default value is "vertex"
        /// </summary>
        public string VertexElement { get; set; } = "vertex";

        /// <summary>
        /// The component names for position data, default value is ("x", "y", "z")
        /// </summary>
        public Tuple<string, string, string> PositionComponents { get; set; }

        /// <summary>
        /// The component names for normal data, default value is ("nx", "ny", "nz")
        /// </summary>
        public Tuple<string, string, string> NormalComponents { get; set; }

        /// <summary>
        /// The component names for texture coordinate data, default value is ("u", "v")
        /// </summary>
        public Tuple<string, string> TextureCoordinateComponents { get; set; }

        /// <summary>
        /// The component names for vertex color, default value is ("red", "green", "blue")
        /// </summary>
        public Tuple<string, string, string> ColorComponents { get; set; }

        /// <summary>
        /// The element name for the face data, default value is "face"
        /// </summary>
        public string FaceElement { get; set; } = "face";

        /// <summary>
        /// The property name for the face data, default value is "vertex_index"
        /// </summary>
        public string FaceProperty { get; set; } = "vertex_index";

        /// <summary>
        /// Gets or sets the axis system in the exported stl file.
        /// </summary>
        public AxisSystem AxisSystem { get; set; }
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

        /// <summary>
        /// Gets or sets to flip the coordinate system of the scene during exporting.
        /// </summary>
        public bool FlipCoordinateSystem { get; set; }

        /// <summary>
        /// Embed the external textures into the PDF file, default value is false.
        /// </summary>
        public bool EmbedTextures { get; set; }
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
