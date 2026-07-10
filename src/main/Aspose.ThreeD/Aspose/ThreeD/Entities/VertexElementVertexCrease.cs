using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines the vertex crease for specified components
    /// </summary>
    public class VertexElementVertexCrease : VertexElementDoublesTemplate, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementVertexCrease class.
        /// </summary>
        public VertexElementVertexCrease()
        {
            _type = VertexElementType.VertexCrease;
            _indices = new List<int>();
            Name = string.Empty;
        }
    }
}
