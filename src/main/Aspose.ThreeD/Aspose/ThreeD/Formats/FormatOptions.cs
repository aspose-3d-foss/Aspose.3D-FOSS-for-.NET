using System;
using Aspose.ThreeD;

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

    /// <summary>
    /// Load options for Collada format
    /// </summary>
    public class ColladaLoadOptions : LoadOptions
    {
        /// <summary>
        /// Initializes a new instance of the ColladaLoadOptions class
        /// </summary>
        public ColladaLoadOptions() : base()
        {
            FlipCoordinateSystem = false;
        }

        /// <summary>
        /// Gets or sets whether flip coordinate system of control points/normal during importing
        /// </summary>
        public bool FlipCoordinateSystem { get; set; }
    }

    public class TmfLoadOptions : LoadOptions
    {
        public TmfLoadOptions() : base()
        {
        }
    }

    public class TmfSaveOptions : SaveOptions
    {
        public TmfSaveOptions() : base()
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
}
