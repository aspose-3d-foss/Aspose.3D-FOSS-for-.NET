using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines blend weight for specified components.
    /// </summary>
    public class VertexElementWeight : VertexElementDoublesTemplate, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementWeight class.
        /// </summary>
        public VertexElementWeight()
        {
            _type = VertexElementType.Weight;
            _indices = new List<int>();
            Name = string.Empty;
        }
    }
}
