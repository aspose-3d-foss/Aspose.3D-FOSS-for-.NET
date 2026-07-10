using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines if specified polygon is hole
    /// </summary>
    public class VertexElementHole : VertexElementTemplate<bool>, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementHole class.
        /// </summary>
        public VertexElementHole()
        {
            _type = VertexElementType.Hole;
            _indices = new List<int>();
            Name = string.Empty;
        }
    }
}
