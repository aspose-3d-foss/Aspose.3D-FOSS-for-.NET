namespace Aspose.ThreeD
{
    /// <summary>
    /// File format type
    /// </summary>
    public sealed class FileFormatType
    {
        private readonly string _extension;

        /// <summary>
        /// Initializes a new instance of the FileFormatType class
        /// </summary>
        /// <param name="extension">The extension name of this file format, started with .</param>
        internal FileFormatType(string extension)
        {
            _extension = extension;
        }

        /// <summary>
        /// The extension name of this file format, started with .
        /// </summary>
        public string Extension => _extension;

        /// <summary>
        /// Autodesk Maya format type
        /// </summary>
        public static readonly FileFormatType Maya = new FileFormatType(".mb");

        /// <summary>
        /// Blender format type
        /// </summary>
        public static readonly FileFormatType Blender = new FileFormatType(".blend");

        /// <summary>
        /// FBX file format type
        /// </summary>
        public static readonly FileFormatType FBX = new FileFormatType(".fbx");

        /// <summary>
        /// STL file format type
        /// </summary>
        public static readonly FileFormatType STL = new FileFormatType(".stl");

        /// <summary>
        /// Wavefront OBJ format type
        /// </summary>
        public static readonly FileFormatType WavefrontOBJ = new FileFormatType(".obj");

        /// <summary>
        /// Discreet 3D Studio's file format
        /// </summary>
        public static readonly FileFormatType Discreet3DS = new FileFormatType(".3ds");

        /// <summary>
        /// Khronos Group's Collada file format.
        /// </summary>
        public static readonly FileFormatType COLLADA = new FileFormatType(".dae");

        /// <summary>
        /// Universal 3D file format type
        /// </summary>
        public static readonly FileFormatType Universal3D = new FileFormatType(".u3d");

        /// <summary>
        /// Portable Document Format
        /// </summary>
        public static readonly FileFormatType PDF = new FileFormatType(".pdf");

        /// <summary>
        /// Khronos Group's glTF
        /// </summary>
        public static readonly FileFormatType GLTF = new FileFormatType(".gltf");

        /// <summary>
        /// AutoCAD DXF
        /// </summary>
        public static readonly FileFormatType DXF = new FileFormatType(".dxf");

        /// <summary>
        /// Polygon File Format or Stanford Triangle Format
        /// </summary>
        public static readonly FileFormatType PLY = new FileFormatType(".ply");

        /// <summary>
        /// DirectX's X File
        /// </summary>
        public static readonly FileFormatType X = new FileFormatType(".x");

        /// <summary>
        /// Google Draco Mesh
        /// </summary>
        public static readonly FileFormatType Draco = new FileFormatType(".draco");

        /// <summary>
        /// 3D Manufacturing Format
        /// </summary>
        public static readonly FileFormatType Microsoft3MF = new FileFormatType(".3mf");

        /// <summary>
        /// AVEVA Plant Design Management System Model.
        /// </summary>
        public static readonly FileFormatType Rvm = new FileFormatType(".rvm");

        /// <summary>
        /// 3D Studio Max's ASCII Scene Exporter format.
        /// </summary>
        public static readonly FileFormatType ASE = new FileFormatType(".ase");

        /// <summary>
        /// Zip archive that contains other 3d file format.
        /// </summary>
        public static readonly FileFormatType Zip = new FileFormatType(".zip");

        /// <summary>
        /// Universal Scene Description
        /// </summary>
        public static readonly FileFormatType USD = new FileFormatType(".usd");

        /// <summary>
        /// Point Cloud Data used by Point Cloud Library
        /// </summary>
        public static readonly FileFormatType Pcd = new FileFormatType(".pcd");

        /// <summary>
        /// Xyz point cloud file
        /// </summary>
        public static readonly FileFormatType Xyz = new FileFormatType(".xyz");

        /// <summary>
        /// ISO 16739-1 Industry Foundation Classes data model.
        /// </summary>
        public static readonly FileFormatType IFC = new FileFormatType(".ifc");

        /// <summary>
        /// Siemens PLM Software NX's JT File
        /// </summary>
        public static readonly FileFormatType SiemensJT = new FileFormatType(".jt");

        /// <summary>
        /// Additive manufacturing file format
        /// </summary>
        public static readonly FileFormatType AMF = new FileFormatType(".amf");

        /// <summary>
        /// The Virtual Reality Modeling Language
        /// </summary>
        public static readonly FileFormatType VRML = new FileFormatType(".wrl");

        /// <summary>
        /// HTML5 File
        /// </summary>
        public static readonly FileFormatType HTML5 = new FileFormatType(".html");

        /// <summary>
        /// Aspose.3D Web format.
        /// </summary>
        public static readonly FileFormatType Aspose3DWeb = new FileFormatType(".a3dw");

        /// <summary>
        /// Get the name of this file format type
        /// </summary>
        public override string ToString()
        {
            return _extension;
        }
    }
}
