using System;
using Aspose.ThreeD.Utilities;

namespace Aspose.ThreeD
{
    public class Group : Entity
    {
        public Group() : this(null)
        {
        }

        public Group(string name) : base(name ?? "Group")
        {
        }

        public override BoundingBox GetBoundingBox()
        {
            return new BoundingBox();
        }

        public override string GetEntityRendererKey()
        {
            return "Group";
        }
    }
}
