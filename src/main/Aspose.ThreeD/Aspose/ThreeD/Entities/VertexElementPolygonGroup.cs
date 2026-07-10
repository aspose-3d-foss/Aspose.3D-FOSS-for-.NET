using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines polygon group for specified components to group related polygons together.
    /// </summary>
    public class VertexElementPolygonGroup : VertexElementIntsTemplate, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementPolygonGroup class.
        /// </summary>
        public VertexElementPolygonGroup()
        {
            _type = VertexElementType.PolygonGroup;
            _indices = new List<int>();
            Name = string.Empty;
        }
    }
}
