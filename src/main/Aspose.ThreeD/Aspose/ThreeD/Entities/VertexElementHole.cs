using System;
using System.Collections.Generic;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines if specified polygon is hole
    /// </summary>
    public class VertexElementHole : VertexElementTemplate<bool>, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementHole class.
        /// </summary>
        public VertexElementHole()
            : this(MappingMode.AllSame, ReferenceMode.IndexToDirect)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementHole class.
        /// </summary>
        public VertexElementHole(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(mappingMode, referenceMode)
        {
        }
    }
}
