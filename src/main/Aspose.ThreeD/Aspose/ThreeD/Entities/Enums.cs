namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Vertex element type
    /// </summary>
    public enum VertexElementType
    {
        /// <summary>
        /// Unknown type
        /// </summary>
        Unknown,

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
        /// Vertex weight
        /// </summary>
        VertexWeight,

        /// <summary>
        /// Edge crease
        /// </summary>
        EdgeCrease,

        /// <summary>
        /// Vertex crease
        /// </summary>
        VertexCrease,

        /// <summary>
        /// Texture coordinate
        /// </summary>
        TextureCoordinate,

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
        Specular
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
    /// Reference mode
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
        IndexToDirect
    }

    /// <summary>
    /// Texture mapping
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
        /// Specular texture mapping
        /// </summary>
        Specular,

        /// <summary>
        /// Shininess texture mapping
        /// </summary>
        Shininess,

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
        /// Reflection texture mapping
        /// </summary>
        Reflection
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
    /// Split mesh policy.
    /// </summary>
    public enum SplitMeshPolicy
    {
        /// <summary>
        /// Split by materials
        /// </summary>
        ByMaterials,

        /// <summary>
        /// Split by polygons
        /// </summary>
        ByPolygons
    }

    /// <summary>
    /// Skeleton type.
    /// </summary>
    public enum SkeletonType
    {
        /// <summary>
        /// Limb node
        /// </summary>
        LimbNode,

        /// <summary>
        /// Root
        /// </summary>
        Root
    }

}
