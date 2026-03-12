using System;

namespace Aspose.ThreeD.Utilities
{
    public struct FVector2 : IComparable<FVector2>, IEquatable<FVector2>
    {
        public float X;
        public float Y;

        public FVector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public FVector2(FVector3 vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        public FVector2(Vector2 vec)
        {
            X = (float)vec.x;
            Y = (float)vec.y;
        }

        public int CompareTo(FVector2 other)
        {
            int cmp = X.CompareTo(other.X);
            if (cmp != 0) return cmp;
            return Y.CompareTo(other.Y);
        }

        public bool Equals(FVector2 rhs)
        {
            return X == rhs.X && Y == rhs.Y;
        }

        public override bool Equals(object? obj)
        {
            return obj is FVector2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public static explicit operator Vector2(FVector2 v)
        {
            return new Vector2(v.X, v.Y);
        }

        public static FVector2 operator +(FVector2 a, FVector2 b)
        {
            return new FVector2(a.X + b.X, a.Y + b.Y);
        }

        public static FVector2 operator -(FVector2 a, FVector2 b)
        {
            return new FVector2(a.X - b.X, a.Y - b.Y);
        }

        public static FVector2 operator *(FVector2 a, float b)
        {
            return new FVector2(a.X * b, a.Y * b);
        }

        public static bool operator ==(FVector2 a, FVector2 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(FVector2 a, FVector2 b)
        {
            return !a.Equals(b);
        }
    }
}
