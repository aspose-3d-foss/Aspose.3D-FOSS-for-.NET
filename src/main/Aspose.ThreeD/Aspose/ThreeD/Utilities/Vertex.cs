using System;

namespace Aspose.ThreeD.Utilities
{
    public abstract class Vertex : IComparable<Vertex>
    {
        public abstract int CompareTo(Vertex other);

        public abstract Vector4 ReadVector4(VertexField field);

        public abstract FVector4 ReadFVector4(VertexField field);

        public abstract Vector3 ReadVector3(VertexField field);

        public abstract FVector3 ReadFVector3(VertexField field);

        public abstract Vector2 ReadVector2(VertexField field);

        public abstract FVector2 ReadFVector2(VertexField field);

        public abstract double ReadDouble(VertexField field);

        public abstract float ReadFloat(VertexField field);
    }
}
