namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Vertex element type
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
        /// Polygon size
        /// </summary>
        PolygonSize,

        /// <summary>
        /// Hole
        /// </summary>
        Hole,

        /// <summary>
        /// User data
        /// </summary>
        UserData
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
        /// Union operation
        /// </summary>
        Union,
        /// <summary>
        /// Subtract operation
        /// </summary>
        Subtract,
        /// <summary>
        /// Intersection operation
        /// </summary>
        Intersection
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
}
