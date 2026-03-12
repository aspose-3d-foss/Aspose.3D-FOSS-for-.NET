using System;

namespace Aspose.ThreeD.Utilities
{
    public struct Vector3 : IComparable<Vector3>, IEquatable<Vector3>
    {
        public double x;
        public double y;
        public double z;

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(FVector3 vec)
        {
            x = vec.X;
            y = vec.Y;
            z = vec.Z;
        }

        public Vector3(double v)
        {
            x = v;
            y = v;
            z = v;
        }

        public Vector3(Vector4 vec4)
        {
            x = vec4.x;
            y = vec4.y;
            z = vec4.z;
        }

        public double Length2 => x * x + y * y + z * z;
        public double Length => Math.Sqrt(Length2);

        public static Vector3 Zero => new Vector3(0, 0, 0);
        public static Vector3 One => new Vector3(1, 1, 1);
        public static Vector3 UnitX => new Vector3(1, 0, 0);
        public static Vector3 UnitY => new Vector3(0, 1, 0);
        public static Vector3 UnitZ => new Vector3(0, 0, 1);

        public double this[int index]
        {
            get
            {
                return index switch
                {
                    0 => x,
                    1 => y,
                    2 => z,
                    _ => throw new IndexOutOfRangeException()
                };
            }
            set
            {
                switch (index)
                {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

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

        public bool Equals(object? obj)
        {
            return obj is Vector3 other && Equals(other);
        }

        public bool Equals(Vector3 rhs)
        {
            return x == rhs.x && y == rhs.y && z == rhs.z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z);
        }

        public double Dot(Vector3 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z;
        }

        public Vector3 Normalize()
        {
            double len = Length;
            if (len > 0)
            {
                return new Vector3(x / len, y / len, z / len);
            }
            return new Vector3(0, 0, 0);
        }

        public Vector3 Sin()
        {
            return new Vector3(Math.Sin(x), Math.Sin(y), Math.Sin(z));
        }

        public Vector3 Cos()
        {
            return new Vector3(Math.Cos(x), Math.Cos(y), Math.Cos(z));
        }

        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3(
                y * rhs.z - z * rhs.y,
                z * rhs.x - x * rhs.z,
                x * rhs.y - y * rhs.x
            );
        }

        public void Set(double newX, double newY, double newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
        }

        public override string ToString()
        {
            return $"({x}, {y}, {z})";
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
            int cmp = x.CompareTo(other.x);
            if (cmp != 0) return cmp;
            cmp = y.CompareTo(other.y);
            if (cmp != 0) return cmp;
            return z.CompareTo(other.z);
        }

        public static explicit operator FVector3(Vector3 v)
        {
            return new FVector3((float)v.x, (float)v.y, (float)v.z);
        }

        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.x, -v.y, -v.z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        public static Vector3 operator *(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x * rhs.x, lhs.y * rhs.y, lhs.z * rhs.z);
        }

        public static Vector3 operator *(double lhs, Vector3 rhs)
        {
            return new Vector3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }

        public static Vector3 operator *(Vector3 lhs, double rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }

        public static Vector3 operator /(Vector3 lhs, double rhs)
        {
            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        public static Vector3 operator /(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x / rhs.x, lhs.y / rhs.y, lhs.z / rhs.z);
        }

        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return !lhs.Equals(rhs);
        }
    }
}
