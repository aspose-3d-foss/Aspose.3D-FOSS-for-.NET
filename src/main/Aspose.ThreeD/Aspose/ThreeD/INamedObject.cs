using System;

namespace Aspose.ThreeD
{
    /// <summary>
    /// Interface for named objects
    /// </summary>
    public interface INamedObject
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the name
        /// </summary>
        /// <returns>The name of the object</returns>
        string GetName();
    }
}
