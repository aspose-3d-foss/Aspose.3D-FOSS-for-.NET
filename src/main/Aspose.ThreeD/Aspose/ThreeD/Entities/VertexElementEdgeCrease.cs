using System;
using System.Collections.Generic;

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
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementEdgeCrease class.
        /// </summary>
        public VertexElementEdgeCrease(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(mappingMode, referenceMode)
        {
        }
    }
}
