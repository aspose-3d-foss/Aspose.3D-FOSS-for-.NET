using Aspose.ThreeD.Utilities;
using System;

namespace Aspose.ThreeD.Entities;

/// <summary>
/// is a surface represented by NURBS(Non-uniform rational basis spline),
/// A  is defined by two  and .
/// The w component in control point is used as control point's weight whatever the direction's type is a  or
/// </summary>
public class NurbsSurface : Geometry, INamedObject, IMeshConvertible
{
    private readonly NurbsDirection u;
    private readonly NurbsDirection v;

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public NurbsSurface() : this("NurbsSurface")
    {
    }

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public NurbsSurface(string name) : base(name)
    {
        u = new NurbsDirection();
        v = new NurbsDirection();
    }

    /// <summary>
    /// Gets the NURBS surface's U direction
    /// </summary>
    public NurbsDirection U => u;

    /// <summary>
    /// Gets the NURBS surface's V direction
    /// </summary>
    public NurbsDirection V => v;

    /// <summary>
    /// Convert the NURBS surface to the mesh
    /// </summary>
    public Mesh ToMesh()
    {
        throw new NotImplementedException();
    }
}
