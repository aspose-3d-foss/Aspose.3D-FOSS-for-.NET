namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// The type of the vertex element, defined how it will be used in modeling.
    /// </summary>
    public enum VertexElementType
    {
        /// <summary>
        /// Vertex normal
        /// </summary>
        Normal,

        /// <summary>
        /// Binormal
        /// </summary>
        Binormal,

        /// <summary>
        /// Tangent
        /// </summary>
        Tangent,

        /// <summary>
        /// UV coordinates
        /// </summary>
        UV,

        /// <summary>
        /// Vertex color
        /// </summary>
        VertexColor,

        /// <summary>
        /// Edge crease
        /// </summary>
        EdgeCrease,

        /// <summary>
        /// Vertex crease
        /// </summary>
        VertexCrease,

        /// <summary>
        /// Material index
        /// </summary>
        Material,

        /// <summary>
        /// Polygon group
        /// </summary>
        PolygonGroup,

        /// <summary>
        /// Smoothing group
        /// </summary>
        SmoothingGroup,

        /// <summary>
        /// Hole
        /// </summary>
        Hole,

        /// <summary>
        /// User data
        /// </summary>
        UserData,

        /// <summary>
        /// Visibility
        /// </summary>
        Visibility,

        /// <summary>
        /// Specular
        /// </summary>
        Specular,

        /// <summary>
        /// Weight
        /// </summary>
        Weight
    }

    /// <summary>
    /// Mapping mode
    /// </summary>
    public enum MappingMode
    {
        /// <summary>
        /// Control point mapping
        /// </summary>
        ControlPoint,

        /// <summary>
        /// Polygon vertex mapping
        /// </summary>
        PolygonVertex,

        /// <summary>
        /// Polygon mapping
        /// </summary>
        Polygon,

        /// <summary>
        /// Edge mapping
        /// </summary>
        Edge,

        /// <summary>
        /// All same mapping
        /// </summary>
        AllSame
    }

    /// <summary>
    /// defines how mapping information is stored and referenced by.
    /// </summary>
    public enum ReferenceMode
    {
        /// <summary>
        /// Direct reference
        /// </summary>
        Direct,

        /// <summary>
        /// Index reference
        /// </summary>
        Index,

        /// <summary>
        /// Index to direct
        /// </summary>
        IndexToDirect
    }

    /// <summary>
    /// The texture mapping type for 
    /// Describes which kind of texture mapping is used.
    /// </summary>
    public enum TextureMapping
    {
        /// <summary>
        /// Ambient texture mapping
        /// </summary>
        Ambient,

        /// <summary>
        /// Emissive texture mapping
        /// </summary>
        Emissive,

        /// <summary>
        /// Diffuse texture mapping
        /// </summary>
        Diffuse,

        /// <summary>
        /// Opacity texture mapping
        /// </summary>
        Opacity,

        /// <summary>
        /// Bump texture mapping
        /// </summary>
        Bump,

        /// <summary>
        /// Normal texture mapping
        /// </summary>
        Normal,

        /// <summary>
        /// Specular texture mapping
        /// </summary>
        Specular,

        /// <summary>
        /// Glow texture mapping
        /// </summary>
        Glow,

        /// <summary>
        /// Reflection texture mapping
        /// </summary>
        Reflection,

        /// <summary>
        /// Shadow texture mapping
        /// </summary>
        Shadow,

        /// <summary>
        /// Shininess texture mapping
        /// </summary>
        Shininess,

        /// <summary>
        /// Displacement texture mapping
        /// </summary>
        Displacement
    }

    /// <summary>
    /// Mesh's Boolean operation
    /// </summary>
    public enum BooleanOperation
    {
        /// <summary>
        /// Add operation
        /// </summary>
        Add,
        
        /// <summary>
        /// Subtract operation
        /// </summary>
        Sub,
        
        /// <summary>
        /// Intersect operation
        /// </summary>
        Intersect
    }

    /// <summary>
    /// The dimension of the curves.
    /// </summary>
    public enum CurveDimension
    {
        /// <summary>
        /// Two dimensional curve
        /// </summary>
        TwoDimensional,

        /// <summary>
        /// Three dimensional curve
        /// </summary>
        ThreeDimensional,
    }

    /// <summary>
    /// NURBS types.
    /// </summary>
    public enum NurbsType
    {
        /// <summary>
        /// Open NURBS curve
        /// </summary>
        Open,

        /// <summary>
        /// Closed NURBS curve
        /// </summary>
        Closed,

        /// <summary>
        /// Periodic NURBS curve
        /// </summary>
        Periodic,
    }

    /// <summary>
    /// Patch direction's types.
    /// </summary>
    public enum PatchDirectionType
    {
        Bezier,
        QuadraticBezier,
        CardinalSpline,
        BasisSpline,
        Linear,
    }

    /// <summary>
    /// Share vertex/control point data between sub-meshes or each sub-mesh has its own compacted data.
    /// </summary>
    public enum SplitMeshPolicy
    {
        /// <summary>
        /// Clone data for each sub-mesh
        /// </summary>
        CloneData,

        /// <summary>
        /// Compact data for each sub-mesh
        /// </summary>
        CompactData
    }
    /// <summary>
    /// 
    /// </summary>
    public enum SkeletonType
    {
        /// <summary>
        /// Skeleton type
        /// </summary>
        Skeleton,

        /// <summary>
        /// Bone type
        /// </summary>
        Bone
    }
}
