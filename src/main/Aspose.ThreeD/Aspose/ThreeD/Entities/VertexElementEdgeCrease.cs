using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines the edge crease for specified components
    /// </summary>
    public class VertexElementEdgeCrease : VertexElementDoublesTemplate, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementEdgeCrease class.
        /// </summary>
        public VertexElementEdgeCrease()
        {
            _type = VertexElementType.EdgeCrease;
            _indices = new List<int>();
            Name = string.Empty;
        }
    }
}
