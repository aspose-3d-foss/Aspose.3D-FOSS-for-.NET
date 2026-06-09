namespace Aspose.ThreeD.Entities;

/// <summary>
/// A  is a parametric modeling surface, similar to , it's also defined by two 
/// , the  and .
/// 
/// But difference between  and  is that the  curve 
/// can be one of , , ,  and
/// </summary>
public class Patch : Geometry, INamedObject
{
    private readonly PatchDirection u;
    private readonly PatchDirection v;

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public Patch() : this("Patch")
    {
    }

    /// <summary>
    /// Initializes a new instance of the  class.
    /// </summary>
    public Patch(string name) : base(name)
    {
        u = new PatchDirection();
        v = new PatchDirection();
    }

    /// <summary>
    /// Gets the u direction.
    /// </summary>
    public PatchDirection U => u;

    /// <summary>
    /// Gets the v direction.
    /// </summary>
    public PatchDirection V => v;
}
