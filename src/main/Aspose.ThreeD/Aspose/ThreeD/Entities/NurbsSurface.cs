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
        var mesh = new Mesh(Name);
        
        // Sample the NURBS surface and convert to mesh
        // The surface is defined by U and V directions
        var uDir = U;
        var vDir = V;
        
        // Default to 10 segments if not set
        var uDivisions = uDir.Divisions > 0 ? uDir.Divisions : 10;
        var vDivisions = vDir.Divisions > 0 ? vDir.Divisions : 10;
        
        // Generate control points for the mesh
        for (int vIndex = 0; vIndex <= vDivisions; vIndex++)
        {
            for (int uIndex = 0; uIndex <= uDivisions; uIndex++)
            {
                // Simple linear interpolation for now
                // In a full implementation, this would evaluate the NURBS surface
                var uParam = (double)uIndex / uDivisions;
                var vParam = (double)vIndex / vDivisions;
                
                // For now, generate a simple grid - a real NURBS implementation
                // would evaluate the basis functions and compute the actual surface point
                var x = (float)(uParam - 0.5f);
                var y = (float)(vParam - 0.5f);
                var z = 0.0f;
                
                mesh.ControlPoints.Add(new Vector4(x, y, z, 1));
            }
        }
        
        // Create polygons (quads) connecting the grid points
        for (int vIndex = 0; vIndex < vDivisions; vIndex++)
        {
            for (int uIndex = 0; uIndex < uDivisions; uIndex++)
            {
                var p0 = vIndex * (uDivisions + 1) + uIndex;
                var p1 = p0 + 1;
                var p2 = p0 + (uDivisions + 1) + 1;
                var p3 = p0 + (uDivisions + 1);
                
                mesh.CreatePolygon(p0, p1, p2, p3);
            }
        }
        
        return mesh;
    }
}
