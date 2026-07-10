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
        {
            _type = VertexElementType.Specular;
            _indices = new List<int>();
            Name = string.Empty;
        }
    }
}
