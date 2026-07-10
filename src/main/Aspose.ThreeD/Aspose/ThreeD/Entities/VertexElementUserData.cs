using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;

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
        {
            _type = VertexElementType.UserData;
            _indices = new List<int>();
            Name = string.Empty;
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
