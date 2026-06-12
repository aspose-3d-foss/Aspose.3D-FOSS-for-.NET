using System;
using System.Collections.Generic;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines the vertex crease for specified components
    /// </summary>
    public class VertexElementVertexCrease : VertexElementDoublesTemplate
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementVertexCrease class.
        /// </summary>
        public VertexElementVertexCrease()
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementVertexCrease class.
        /// </summary>
        public VertexElementVertexCrease(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(mappingMode, referenceMode)
        {
        }
    }
}
