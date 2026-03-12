using System;
using System.Collections.Generic;
using System.Linq;

namespace Aspose.ThreeD.Utilities
{
    public sealed class VertexDeclaration : IEnumerable<VertexField>, IEquatable<VertexDeclaration>, IComparable<VertexDeclaration>
    {
        private List<VertexField> _fields;
        private bool _sealed;

        public VertexDeclaration()
        {
            _fields = new List<VertexField>();
            _sealed = false;
        }

        public bool Sealed => _sealed;

        public int Count => _fields.Count;

        public VertexField this[int index] => _fields[index];

        public int Size => _fields.Count > 0 ? _fields[_fields.Count - 1].Offset + _fields[_fields.Count - 1].Size : 0;

        public void Clear()
        {
            if (_sealed)
                throw new InvalidOperationException("VertexDeclaration is sealed and cannot be modified");
            _fields.Clear();
        }

        public VertexField AddField(VertexFieldDataType dataType, VertexFieldSemantic semantic, int index, string alias)
        {
            if (_sealed)
                throw new InvalidOperationException("VertexDeclaration is sealed and cannot be modified");

            int offset = Size;
            int size = GetFieldSize(dataType);
            var field = new VertexField(dataType, semantic, index, alias, offset, size);
            _fields.Add(field);
            return field;
        }

        private int GetFieldSize(VertexFieldDataType dataType)
        {
            return dataType switch
            {
                VertexFieldDataType.Float => 4,
                VertexFieldDataType.FVector2 => 8,
                VertexFieldDataType.FVector3 => 12,
                VertexFieldDataType.FVector4 => 16,
                VertexFieldDataType.Double => 8,
                VertexFieldDataType.Vector2 => 16,
                VertexFieldDataType.Vector3 => 24,
                VertexFieldDataType.Vector4 => 32,
                VertexFieldDataType.Int8 => 1,
                VertexFieldDataType.ByteVector4 => 4,
                VertexFieldDataType.Int16 => 2,
                VertexFieldDataType.Int32 => 4,
                VertexFieldDataType.Int64 => 8,
                _ => throw new ArgumentException($"Unknown data type: {dataType}")
            };
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            foreach (var field in _fields)
            {
                hash.Add(field.GetHashCode());
            }
            return hash.ToHashCode();
        }

        public bool Equals(object? obj)
        {
            return obj is VertexDeclaration other && Equals(other);
        }

        public bool Equals(VertexDeclaration other)
        {
            if (_fields.Count != other._fields.Count)
                return false;

            for (int i = 0; i < _fields.Count; i++)
            {
                if (!_fields[i].Equals(other._fields[i]))
                    return false;
            }

            return true;
        }

        public int CompareTo(VertexDeclaration other)
        {
            int cmp = _fields.Count.CompareTo(other._fields.Count);
            if (cmp != 0) return cmp;

            for (int i = 0; i < _fields.Count; i++)
            {
                cmp = _fields[i].CompareTo(other._fields[i]);
                if (cmp != 0) return cmp;
            }

            return 0;
        }

        public override string ToString()
        {
            return string.Join(", ", _fields);
        }

        public IEnumerator<VertexField> GetEnumerator()
        {
            return _fields.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
