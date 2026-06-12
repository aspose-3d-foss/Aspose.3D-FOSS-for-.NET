using System;
using System.Collections.Generic;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines polygon group for specified components to group related polygons together.
    /// </summary>
    public class VertexElementPolygonGroup : VertexElementIntsTemplate
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementPolygonGroup class.
        /// </summary>
        public VertexElementPolygonGroup()
            : this(MappingMode.Polygon, ReferenceMode.IndexToDirect)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementPolygonGroup class.
        /// </summary>
        public VertexElementPolygonGroup(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(mappingMode, referenceMode)
        {
        }
    }
}
