using System;
using System.Collections.Generic;
using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Render;

namespace Aspose.ThreeD
{
    /// <summary>
    /// A  represents the logical relationships of .
    /// </summary>
    public class Group : Entity
    {
        /// <summary>
        /// Construct a new instance of
        /// </summary>
        public Group(string name) : base(name ?? "Group")
        {
        }

        /// <summary>
        /// Parent group of current group
        /// </summary>
        public Group? Parent { get; }

        /// <summary>
        /// Sub-groups
        /// </summary>
        public IList<Group> Groups { get; } = new List<Group>();

        /// <summary>
        /// The nodes in this group
        /// </summary>
        public IList<Node> Nodes { get; } = new List<Node>();

        /// <summary>
        /// Gets the string representation of
        /// </summary>
        public override string ToString()
        {
            return $"Group: {Name}";
        }
    }
}
