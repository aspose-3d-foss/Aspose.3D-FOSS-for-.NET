using System;
using System.Collections.Generic;

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
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementVisibility class.
        /// </summary>
        public VertexElementVisibility(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(mappingMode, referenceMode)
        {
        }
    }
}
