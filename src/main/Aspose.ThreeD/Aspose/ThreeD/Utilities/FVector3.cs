using System;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// Represents a 3D vector
    /// </summary>
    public struct FVector3 : IComparable<FVector3>
    {
        public float X;
        public float Y;
        public float Z;

        public FVector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public FVector3(FVector2 xy, float z)
        {
            X = xy.X;
            Y = xy.Y;
            Z = z;
        }

        public FVector3(FVector4 vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
        }

        public FVector3(Vector4 vec)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = (float)vec.Z;
        }

        public FVector3(Vector3 vec)
        {
            X = (float)vec.X;
            Y = (float)vec.Y;
            Z = (float)vec.Z;
        }

        public static FVector3 Zero => new FVector3(0, 0, 0);
        public static FVector3 One => new FVector3(1, 1, 1);
        public static FVector3 UnitX => new FVector3(1, 0, 0);
        public static FVector3 UnitY => new FVector3(0, 1, 0);
        public static FVector3 UnitZ => new FVector3(0, 0, 1);

        public float this[int index]
        {
            get
            {
                return index switch
                {
                    0 => X,
                    1 => Y,
                    2 => Z,
                    _ => throw new IndexOutOfRangeException($"Invalid vector index: {index}")
                };
            }
            set
            {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    default: throw new IndexOutOfRangeException($"Invalid vector index: {index}");
                }
            }
        }

        public int CompareTo(FVector3 other)
        {
            int cmp = X.CompareTo(other.X);
            if (cmp != 0) return cmp;
            cmp = Y.CompareTo(other.Y);
            if (cmp != 0) return cmp;
            return Z.CompareTo(other.Z);
        }

        public static FVector3 Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input string is null or whitespace", nameof(input));

            var parts = input.Trim().Trim('(', ')').Split(new[] { ',', ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 3)
            {
                float x = float.Parse(parts[0]);
                float y = float.Parse(parts[1]);
                float z = float.Parse(parts[2]);
                return new FVector3(x, y, z);
            }
            throw new FormatException($"Input string '{input}' is not a valid FVector3");
        }

        public FVector3 Normalize()
        {
            float len = (float)Math.Sqrt(X * X + Y * Y + Z * Z);
            if (len > 1e-6f)
            {
                return new FVector3(X / len, Y / len, Z / len);
            }
            return Zero;
        }

        public FVector3 Cross(FVector3 rhs)
        {
            return new FVector3(
                Y * rhs.Z - Z * rhs.Y,
                Z * rhs.X - X * rhs.Z,
                X * rhs.Y - Y * rhs.X
            );
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        public static explicit operator Vector3(FVector3 v)
        {
            return new Vector3(v.X, v.Y, v.Z);
        }

        public static FVector3 operator +(FVector3 a, FVector3 b)
        {
            return new FVector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static FVector3 operator -(FVector3 a, FVector3 b)
        {
            return new FVector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static FVector3 operator -(FVector3 a)
        {
            return new FVector3(-a.X, -a.Y, -a.Z);
        }

        public static FVector3 operator *(FVector3 a, float b)
        {
            return new FVector3(a.X * b, a.Y * b, a.Z * b);
        }

        public static FVector3 operator *(float b, FVector3 a)
        {
            return new FVector3(a.X * b, a.Y * b, a.Z * b);
        }

        public static FVector3 operator /(FVector3 a, float b)
        {
            return new FVector3(a.X / b, a.Y / b, a.Z / b);
        }
    }
}
