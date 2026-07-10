using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines if specified components is visible
    /// </summary>
    public class VertexElementVisibility : VertexElementTemplate<bool>, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementVisibility class.
        /// </summary>
        public VertexElementVisibility()
        {
            _type = VertexElementType.Visibility;
            _indices = new List<int>();
            Name = string.Empty;
        }
    }
}
