using System;

namespace Aspose.ThreeD.Utilities
{
    public struct Vector3 : IComparable<Vector3>
    {
        public double X;
        public double Y;
        public double Z;

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(FVector3 vec)
        {
            X = vec.X;
            Y = vec.Y;
            Z = vec.Z;
        }

        public Vector3(double v)
        {
            X = v;
            Y = v;
            Z = v;
        }

        public Vector3(Vector4 vec4)
        {
            X = vec4.X;
            Y = vec4.Y;
            Z = vec4.Z;
        }

        public double Item
        {
            get => X;
            set => X = value;
        }

        public double Length2 => X * X + Y * Y + Z * Z;
        public double Length => Math.Sqrt(Length2);

        public static Vector3 Zero => new Vector3(0, 0, 0);
        public static Vector3 One => new Vector3(1, 1, 1);
        public static Vector3 UnitX => new Vector3(1, 0, 0);
        public static Vector3 UnitY => new Vector3(0, 1, 0);
        public static Vector3 UnitZ => new Vector3(0, 0, 1);

        public static Vector3 Parse(string input)
        {
            var parts = input.Trim('(', ')').Split(',');
            if (parts.Length != 3)
                throw new ParseException("Invalid Vector3 format");
            return new Vector3(
                double.Parse(parts[0].Trim()),
                double.Parse(parts[1].Trim()),
                double.Parse(parts[2].Trim())
            );
        }

        public override bool Equals(object obj)
        {
            return obj is Vector3 other && X == other.X && Y == other.Y && Z == other.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public double Dot(Vector3 rhs)
        {
            return X * rhs.X + Y * rhs.Y + Z * rhs.Z;
        }

        public Vector3 Normalize()
        {
            double len = Length;
            if (len > 0)
            {
                return new Vector3(X / len, Y / len, Z / len);
            }
            return new Vector3(0, 0, 0);
        }

        public Vector3 Sin()
        {
            return new Vector3(Math.Sin(X), Math.Sin(Y), Math.Sin(Z));
        }

        public Vector3 Cos()
        {
            return new Vector3(Math.Cos(X), Math.Cos(Y), Math.Cos(Z));
        }

        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3(
                Y * rhs.Z - Z * rhs.Y,
                Z * rhs.X - X * rhs.Z,
                X * rhs.Y - Y * rhs.X
            );
        }

        public void Set(double newX, double newY, double newZ)
        {
            X = newX;
            Y = newY;
            Z = newZ;
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        public double AngleBetween(Vector3 dir, Vector3 up)
        {
            Vector3 a = Normalize();
            Vector3 b = dir.Normalize();
            double dot = Math.Max(-1.0, Math.Min(1.0, a.Dot(b)));
            double angle = Math.Acos(dot);
            Vector3 cross = a.Cross(b);
            if (cross.Dot(up) < 0)
                angle = -angle;
            return angle;
        }

        public double AngleBetween(Vector3 dir)
        {
            Vector3 a = Normalize();
            Vector3 b = dir.Normalize();
            double dot = Math.Max(-1.0, Math.Min(1.0, a.Dot(b)));
            return Math.Acos(dot);
        }

        public int CompareTo(Vector3 other)
        {
            int cmp = X.CompareTo(other.X);
            if (cmp != 0) return cmp;
            cmp = Y.CompareTo(other.Y);
            if (cmp != 0) return cmp;
            return Z.CompareTo(other.Z);
        }

        public static explicit operator FVector3(Vector3 v)
        {
            return new FVector3((float)v.X, (float)v.Y, (float)v.Z);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.X, -v.Y, -v.Z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        public static Vector3 operator *(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X * rhs.X, lhs.Y * rhs.Y, lhs.Z * rhs.Z);
        }

        public static Vector3 operator *(double lhs, Vector3 rhs)
        {
            return new Vector3(lhs * rhs.X, lhs * rhs.Y, lhs * rhs.Z);
        }

        public static Vector3 operator *(Vector3 lhs, double rhs)
        {
            return new Vector3(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);
        }

        public static Vector3 operator /(Vector3 lhs, double rhs)
        {
            return new Vector3(lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);
        }

        public static Vector3 operator /(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.X / rhs.X, lhs.Y / rhs.Y, lhs.Z / rhs.Z);
        }

        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }

        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z;
        }
    }
}
