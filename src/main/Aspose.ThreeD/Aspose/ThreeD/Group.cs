using System;
using Aspose.ThreeD.Utilities;
using Aspose.ThreeD.Render;

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

        public override EntityRendererKey GetEntityRendererKey()
        {
            return new EntityRendererKey("Group");
        }
    }
}
