using System;

namespace Aspose.ThreeD.Utilities
{
    public struct Vector2 : IComparable<Vector2>, IEquatable<Vector2>
    {
        public double X;
        public double Y;

        public Vector2(double s)
        {
            X = s;
            Y = s;
        }

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector2(Vector3 s)
        {
            X = s.X;
            Y = s.Y;
        }

        public Vector2(FVector2 vec)
        {
            X = vec.X;
            Y = vec.Y;
        }

        public double U
        {
            get => X;
            set => X = value;
        }

        public double V
        {
            get => Y;
            set => Y = value;
        }

        public double Length => Math.Sqrt(X * X + Y * Y);

        public double Dot(Vector2 rhs)
        {
            return X * rhs.X + Y * rhs.Y;
        }

        public bool Equals(Vector2 rhs)
        {
            return X == rhs.X && Y == rhs.Y;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public double Cross(Vector2 v)
        {
            return X * v.Y - Y * v.X;
        }

        public Vector2 Normalize()
        {
            double len = Length;
            if (len > 0)
            {
                return new Vector2(X / len, Y / len);
            }
            return new Vector2(0, 0);
        }

        public int CompareTo(Vector2 other)
        {
            int cmp = X.CompareTo(other.X);
            if (cmp != 0) return cmp;
            return Y.CompareTo(other.Y);
        }

        public static explicit operator FVector2(Vector2 v)
        {
            return new FVector2(v);
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }

        public static Vector2 operator /(Vector2 lhs, double rhs)
        {
            return new Vector2(lhs.X / rhs, lhs.Y / rhs);
        }

        public static Vector2 operator *(Vector2 lhs, double rhs)
        {
            return new Vector2(lhs.X * rhs, lhs.Y * rhs);
        }

        public static Vector2 operator *(double lhs, Vector2 rhs)
        {
            return new Vector2(lhs * rhs.X, lhs * rhs.Y);
        }

        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return !lhs.Equals(rhs);
        }
    }
}
