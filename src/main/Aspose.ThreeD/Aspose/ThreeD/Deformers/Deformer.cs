using System;
using System.Collections.Generic;
using Aspose.ThreeD.Entities;

namespace Aspose.ThreeD.Deformers;

/// <summary>
/// Base class for  and
/// </summary>
public abstract class Deformer : A3DObject, INamedObject
{
    private Geometry? owner;

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    protected Deformer(string name) : base(name)
    {
    }

    /// <summary>
    /// Gets the geometry which owns this deformer
    /// </summary>
    public Geometry Owner => owner ?? throw new InvalidOperationException("Owner is not set");
}
