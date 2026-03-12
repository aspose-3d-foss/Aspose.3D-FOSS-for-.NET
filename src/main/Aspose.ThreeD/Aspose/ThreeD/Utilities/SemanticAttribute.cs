using System;

namespace Aspose.ThreeD.Utilities
{
    public sealed class SemanticAttribute : Attribute
    {
        public SemanticAttribute(VertexFieldSemantic semantic)
        {
            Semantic = semantic;
            Alias = null;
        }

        public SemanticAttribute(VertexFieldSemantic semantic, string alias)
        {
            Semantic = semantic;
            Alias = alias;
        }

        public VertexFieldSemantic Semantic { get; }

        public string Alias { get; }
    }
}
