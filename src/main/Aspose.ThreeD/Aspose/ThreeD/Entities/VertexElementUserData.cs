using System;
using System.Collections.Generic;

namespace Aspose.ThreeD.Entities
{
    /// <summary>
    /// Defines custom user data for specified components.
    /// Usually it's application-specific data for special purpose.
    /// </summary>
    public class VertexElementUserData : VertexElement, IIndexedVertexElement
    {
        private object _data;

        /// <summary>
        /// The user data attached in this element
        /// </summary>
        public object Data
        {
            get => _data;
            set => _data = value;
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementUserData class.
        /// </summary>
        public VertexElementUserData()
            : this(MappingMode.AllSame, ReferenceMode.Direct)
        {
        }

        /// <summary>
        /// Initializes a new instance of the VertexElementUserData class.
        /// </summary>
        public VertexElementUserData(MappingMode mappingMode, ReferenceMode referenceMode)
            : base(VertexElementType.Unknown, mappingMode, referenceMode)
        {
        }

        /// <summary>
        /// Clears all the data from this vertex element.
        /// </summary>
        public override void Clear()
        {
            _data = null;
            base.Clear();
        }
    }
}
