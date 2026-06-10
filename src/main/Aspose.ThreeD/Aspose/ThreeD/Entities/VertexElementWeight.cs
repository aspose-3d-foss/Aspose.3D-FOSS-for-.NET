using System;
using System.Collections.Generic;

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
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementWeight class.
        /// </summary>
        public VertexElementWeight(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(mappingMode, referenceMode)
        {
        }
    }
}
