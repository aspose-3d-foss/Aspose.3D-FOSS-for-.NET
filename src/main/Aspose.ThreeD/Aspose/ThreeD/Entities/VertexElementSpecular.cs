using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines specular color for specified components.
    /// </summary>
    public class VertexElementSpecular : VertexElementFVector, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementSpecular class.
        /// </summary>
        public VertexElementSpecular()
            : this(MappingMode.ControlPoint, ReferenceMode.Direct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementSpecular class.
        /// </summary>
        public VertexElementSpecular(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(mappingMode, referenceMode)
        {
        }
    }
}
