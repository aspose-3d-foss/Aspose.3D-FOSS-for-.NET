using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities;

/// <summary>
/// The shape describes the deformation on a set of control points, which is similar to the cluster deformer in Maya.
/// For example, we can add a shape to a created geometry. 
/// And the shape and the geometry have the same topological information but different position of the control points. 
/// With varying amounts of influence, the geometry performs a deformation effect.
/// </summary>
public class Shape : Geometry, INamedObject
{
    private readonly IList<int> indices;

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public Shape() : this("Shape")
    {
    }

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public Shape(string name) : base(name)
    {
        indices = new List<int>();
    }

    /// <summary>
    /// Gets the indices.
    /// </summary>
    public IList<int> Indices => indices;

    /// <summary>
    /// Creates a shape from control points
    /// </summary>
    public static Shape FromControlPoints(Vector3[] controlPoints)
    {
        throw new NotImplementedException();
    }
}
