using System;

namespace Aspose.ThreeD.Utilities
{
    public class VertexField : IComparable<VertexField>
    {
        private VertexFieldDataType _dataType;
        private VertexFieldSemantic _semantic;
        private string _alias;
        private int _index;
        private int _offset;
        private int _size;

        // Internal parameterless constructor (matches On-Premise)
        internal VertexField()
        {
        }

        // Internal 6-parameter constructor for internal use
        internal VertexField(VertexFieldDataType dataType, VertexFieldSemantic semantic, int index, string alias, int offset, int size)
        {
            _dataType = dataType;
            _semantic = semantic;
            _index = index;
            _alias = alias;
            _offset = offset;
            _size = size;
        }

        public VertexFieldDataType DataType => _dataType;

        public VertexFieldSemantic Semantic => _semantic;

        public string Alias => _alias;

        public int Index => _index;

        public int Offset => _offset;

        public int Size => _size;

        public override int GetHashCode()
        {
            return HashCode.Combine(_dataType, _semantic, _index, _alias, _offset, _size);
        }

        public bool Equals(object? obj)
        {
            return obj is VertexField other && Equals(other);
        }

        public int CompareTo(VertexField other)
        {
            int cmp = _semantic.CompareTo(other._semantic);
            if (cmp != 0) return cmp;
            cmp = _index.CompareTo(other._index);
            if (cmp != 0) return cmp;
            return _offset.CompareTo(other._offset);
        }

        public override string ToString()
        {
            return $"{_semantic}{_index} ({_dataType}) Offset: {_offset}, Size: {_size}";
        }
    }
}
