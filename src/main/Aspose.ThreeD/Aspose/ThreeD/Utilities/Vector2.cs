using System;

namespace Aspose.ThreeD.Utilities
{
    public struct Vector2 : IComparable<Vector2>, IEquatable<Vector2>
    {
        public double x;
        public double y;

        public Vector2(double s)
        {
            x = s;
            y = s;
        }

        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector3 s)
        {
            x = s.x;
            y = s.y;
        }

        public Vector2(FVector2 vec)
        {
            x = vec.X;
            y = vec.Y;
        }

        public double U
        {
            get => x;
            set => x = value;
        }

        public double V
        {
            get => y;
            set => y = value;
        }

        public double Length => Math.Sqrt(x * x + y * y);

        public double Dot(Vector2 rhs)
        {
            return x * rhs.x + y * rhs.y;
        }

        public bool Equals(Vector2 rhs)
        {
            return x == rhs.x && y == rhs.y;
        }

        public override bool Equals(object? obj)
        {
            return obj is Vector2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public double Cross(Vector2 v)
        {
            return x * v.y - y * v.x;
        }

        public Vector2 Normalize()
        {
            double len = Length;
            if (len > 0)
            {
                return new Vector2(x / len, y / len);
            }
            return new Vector2(0, 0);
        }

        public int CompareTo(Vector2 other)
        {
            int cmp = x.CompareTo(other.x);
            if (cmp != 0) return cmp;
            return y.CompareTo(other.y);
        }

        public static explicit operator FVector2(Vector2 v)
        {
            return new FVector2(v);
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator -(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator /(Vector2 lhs, double rhs)
        {
            return new Vector2(lhs.x / rhs, lhs.y / rhs);
        }

        public static Vector2 operator *(Vector2 lhs, double rhs)
        {
            return new Vector2(lhs.x * rhs, lhs.y * rhs);
        }

        public static Vector2 operator *(double lhs, Vector2 rhs)
        {
            return new Vector2(lhs * rhs.x, lhs * rhs.y);
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
