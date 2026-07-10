using System;
using System.Collections.Generic;
using Aspose.ThreeD.Entities;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    public class VertexElementNormal : VertexElementFVector, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementNormal class.
        /// </summary>
        public VertexElementNormal()
        {
            _type = VertexElementType.Normal;
            _indices = new List<int>();
            Name = string.Empty;
        }
    }

    public class VertexElementTangent : VertexElementFVector, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementTangent class.
        /// </summary>
        public VertexElementTangent()
        {
            _type = VertexElementType.Tangent;
            _indices = new List<int>();
            Name = string.Empty;
        }
    }

    public class VertexElementBinormal : VertexElementFVector, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementBinormal class.
        /// </summary>
        public VertexElementBinormal()
        {
            _type = VertexElementType.Binormal;
            _indices = new List<int>();
            Name = string.Empty;
        }
    }
}
