using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// A smoothing group is a group of polygons in a polygon mesh which should appear to form a smooth surface.
    /// Some early 3d modeling software like 3D studio max for DOS used smoothing group to void storing normal vector for each mesh vertex.
    /// </summary>
    public class VertexElementSmoothingGroup : VertexElementIntsTemplate, IIndexedVertexElement
    {
        /// <summary>
        /// Initializes a new instance of the VertexElementSmoothingGroup class.
        /// </summary>
        public VertexElementSmoothingGroup()
        {
            _type = VertexElementType.SmoothingGroup;
            _indices = new List<int>();
            Name = string.Empty;
        }
    }
}
