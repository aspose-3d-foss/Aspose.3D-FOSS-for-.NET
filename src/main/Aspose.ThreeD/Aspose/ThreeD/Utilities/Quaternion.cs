using System;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// A quaternion is usually used to represent a rotation in 3D space.
    /// </summary>
    public struct Quaternion : IEquatable<Quaternion>
    {
        public double W;
        public double X;
        public double Y;
        public double Z;

        public Quaternion(double w, double x, double y, double z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        public double Length => Math.Sqrt(W * W + X * X + Y * Y + Z * Z);

        public static readonly Quaternion Identity = new Quaternion(1, 0, 0, 0);

        public bool Equals(object? obj)
        {
            return obj is Quaternion other && W == other.W && X == other.X && Y == other.Y && Z == other.Z;
        }

        public bool Equals(Quaternion other)
        {
            return W == other.W && X == other.X && Y == other.Y && Z == other.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(W, X, Y, Z);
        }

        public Quaternion Conjugate()
        {
            return new Quaternion(W, -X, -Y, -Z);
        }

        public Quaternion Inverse()
        {
            double length2 = W * W + X * X + Y * Y + Z * Z;
            if (length2 == 0)
            {
                return new Quaternion(0, 0, 0, 0);
            }
            double invLen = 1.0 / length2;
            return new Quaternion(W * invLen, -X * invLen, -Y * invLen, -Z * invLen);
        }

        public double Dot(Quaternion q)
        {
            return W * q.W + X * q.X + Y * q.Y + Z * q.Z;
        }

        public Vector3 EulerAngles()
        {
            double sqW = W * W;
            double sqX = X * X;
            double sqY = Y * Y;
            double sqZ = Z * Z;

            double test = W * X + Y * Z;
            if (Math.Abs(test - 0.5) < 1e-10)
            {
                return new Vector3(Math.PI / 2, 0, 0);
            }
            if (Math.Abs(test + 0.5) < 1e-10)
            {
                return new Vector3(-Math.PI / 2, 0, 0);
            }

            double sinPitch = 2.0 * (W * Y - Z * X);
            double pitch = Math.Asin(sinPitch);

            double yaw, roll;
            if (Math.Abs(pitch - Math.PI / 2) < 1e-10)
            {
                yaw = 2 * Math.Atan2(Y, W);
                roll = 0;
            }
            else if (Math.Abs(pitch + Math.PI / 2) < 1e-10)
            {
                yaw = -2 * Math.Atan2(Y, W);
                roll = 0;
            }
            else
            {
                yaw = Math.Atan2(2 * (W * Z + X * Y), 1 - 2 * (sqZ + sqY));
                roll = Math.Atan2(2 * (W * X + Y * Z), 1 - 2 * (sqX + sqY));
            }

            return new Vector3(pitch, yaw, roll);
        }

        public Quaternion Normalize()
        {
            double len = Length;
            if (len == 0)
            {
                return new Quaternion(0, 0, 0, 0);
            }
            double invLen = 1.0 / len;
            return new Quaternion(W * invLen, X * invLen, Y * invLen, Z * invLen);
        }

        public void ToAngleAxis(out double angle, out Vector3 axis)
        {
            double length = Length;
            if (length == 0)
            {
                angle = 0;
                axis = new Vector3(1, 0, 0);
                return;
            }

            double sinHalfAngle = Math.Sqrt(X * X + Y * Y + Z * Z);
            if (sinHalfAngle == 0)
            {
                angle = 0;
                axis = new Vector3(1, 0, 0);
                return;
            }

            angle = 2 * Math.Atan2(sinHalfAngle, W);
            axis = new Vector3(X / sinHalfAngle, Y / sinHalfAngle, Z / sinHalfAngle);
        }

        public Quaternion Concat(Quaternion rhs)
        {
            return new Quaternion(
                W * rhs.W - X * rhs.X - Y * rhs.Y - Z * rhs.Z,
                W * rhs.X + X * rhs.W + Y * rhs.Z - Z * rhs.Y,
                W * rhs.Y - X * rhs.Z + Y * rhs.W + Z * rhs.X,
                W * rhs.Z + X * rhs.Y - Y * rhs.X + Z * rhs.W
            );
        }

        public static Quaternion FromAngleAxis(double a, Vector3 axis)
        {
            double halfAngle = a * 0.5;
            double s = Math.Sin(halfAngle);
            double c = Math.Cos(halfAngle);

            Vector3 normalizedAxis = axis.Normalize();
            return new Quaternion(c, normalizedAxis.X * s, normalizedAxis.Y * s, normalizedAxis.Z * s);
        }

        public static Quaternion FromRotation(Vector3 orig, Vector3 dest)
        {
            orig = orig.Normalize();
            dest = dest.Normalize();

            double cosTheta = orig.Dot(dest);
            Vector3 cross = orig.Cross(dest);

            if (cosTheta > 1 - 1e-10)
            {
                return Identity;
            }

            if (cosTheta < -1 + 1e-10)
            {
                Vector3 axis = new Vector3(1, 0, 0).Cross(orig);
                if (axis.Length == 0)
                {
                    axis = new Vector3(0, 1, 0).Cross(orig);
                }
                axis = axis.Normalize();
                return FromAngleAxis(Math.PI, axis);
            }

            double s = Math.Sqrt((1 + cosTheta) * 2);
            double invS = 1 / s;

            return new Quaternion(s * 0.5, cross.X * invS, cross.Y * invS, cross.Z * invS);
        }

        public static Quaternion FromEulerAngle(double pitch, double yaw, double roll)
        {
            double cy = Math.Cos(yaw * 0.5);
            double sy = Math.Sin(yaw * 0.5);
            double cp = Math.Cos(pitch * 0.5);
            double sp = Math.Sin(pitch * 0.5);
            double cr = Math.Cos(roll * 0.5);
            double sr = Math.Sin(roll * 0.5);

            return new Quaternion(
                cr * cp * cy + sr * sp * sy,
                sr * cp * cy - cr * sp * sy,
                cr * sp * cy + sr * cp * sy,
                cr * cp * sy - sr * sp * cy
            );
        }

        public static Quaternion FromEulerAngle(Vector3 eulerAngle)
        {
            return FromEulerAngle(eulerAngle.X, eulerAngle.Y, eulerAngle.Z);
        }

        public Matrix4 ToMatrix()
        {
            return ToMatrix(new Vector3(0, 0, 0));
        }

        public Matrix4 ToMatrix(Vector3 translation)
        {
            double ww = W * W;
            double wx = W * X;
            double wy = W * Y;
            double wz = W * Z;

            double xx = X * X;
            double xy = X * Y;
            double xz = X * Z;

            double yy = Y * Y;
            double yz = Y * Z;

            double zz = Z * Z;
             return new Matrix4(
                 (double)(1 - 2 * (yy + zz)), (double)(2 * (xy - wz)), (double)(2 * (xz + wy)), 0,
                 (double)(2 * (xy + wz)), (double)(1 - 2 * (xx + zz)), (double)(2 * (yz - wx)), 0,
                 (double)(2 * (xz - wy)), (double)(2 * (yz + wx)), (double)(1 - 2 * (xx + yy)), 0,
                 (double)translation.X, (double)translation.Y, (double)translation.Z, 1
             );        }

        public override string ToString()
        {
            return $"({W}, {X}, {Y}, {Z})";
        }

        public static Quaternion Interpolate(float t, Quaternion from, Quaternion to)
        {
            return Slerp(t, from, to);
        }

        public static Quaternion Slerp(double t, Quaternion v1, Quaternion v2)
        {
            double cosTheta = v1.Dot(v2);
            
            if (cosTheta < 0)
            {
                v2 = new Quaternion(-v2.W, -v2.X, -v2.Y, -v2.Z);
                cosTheta = -cosTheta;
            }
            
            if (Math.Abs(cosTheta) > 1 - 1e-10)
            {
                return new Quaternion(
                    v1.W + t * (v2.W - v1.W),
                    v1.X + t * (v2.X - v1.X),
                    v1.Y + t * (v2.Y - v1.Y),
                    v1.Z + t * (v2.Z - v1.Z)
                );
            }
            
            double theta = Math.Acos(cosTheta);
            double sinTheta = Math.Sin(theta);
            
            if (Math.Abs(sinTheta) < 1e-10)
            {
                return new Quaternion(
                    v1.W + t * (v2.W - v1.W),
                    v1.X + t * (v2.X - v1.X),
                    v1.Y + t * (v2.Y - v1.Y),
                    v1.Z + t * (v2.Z - v1.Z)
                );
            }
            
            double t1 = Math.Sin((1 - t) * theta) / sinTheta;
            double t2 = Math.Sin(t * theta) / sinTheta;
            
            return new Quaternion(
                v1.W * t1 + v2.W * t2,
                v1.X * t1 + v2.X * t2,
                v1.Y * t1 + v2.Y * t2,
                v1.Z * t1 + v2.Z * t2
            );
        }

        public static Quaternion operator +(Quaternion lhs, Quaternion rhs)
        {
            return new Quaternion(lhs.W + rhs.W, lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);
        }

        public static Quaternion operator /(Quaternion lhs, double rhs)
        {
            return new Quaternion(lhs.W / rhs, lhs.X / rhs, lhs.Y / rhs, lhs.Z / rhs);
        }

        public static Quaternion operator *(Quaternion lhs, double rhs)
        {
            return new Quaternion(lhs.W * rhs, lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);
        }

        public static Quaternion operator *(Quaternion lhs, Quaternion rhs)
        {
            return new Quaternion(
                lhs.W * rhs.W - lhs.X * rhs.X - lhs.Y * rhs.Y - lhs.Z * rhs.Z,
                lhs.W * rhs.X + lhs.X * rhs.W + lhs.Y * rhs.Z - lhs.Z * rhs.Y,
                lhs.W * rhs.Y - lhs.X * rhs.Z + lhs.Y * rhs.W + lhs.Z * rhs.X,
                lhs.W * rhs.Z + lhs.X * rhs.Y - lhs.Y * rhs.X + lhs.Z * rhs.W
            );
        }

        public static Vector3 operator *(Quaternion q, Vector3 v)
        {
            Vector3 qVec = new Vector3(q.X, q.Y, q.Z);
            Vector3 uv = qVec.Cross(v);
            Vector3 uuv = qVec.Cross(uv);
            return v + (uv * (2.0 * q.W)) + (uuv * 2.0);
        }

        public static Vector4 operator *(Quaternion q, Vector4 v)
        {
            Vector3 qVec = new Vector3(q.X, q.Y, q.Z);
            Vector3 uv = qVec.Cross(new Vector3(v.X, v.Y, v.Z));
            Vector3 uuv = qVec.Cross(uv);
            Vector3 result = new Vector3(v.X, v.Y, v.Z) + (uv * (2.0 * q.W)) + (uuv * 2.0);
            return new Vector4(result.X, result.Y, result.Z, v.W);
        }

        public static FVector3 operator *(Quaternion q, FVector3 v)
        {
            Vector3 qVec = new Vector3(q.X, q.Y, q.Z);
            Vector3 uv = qVec.Cross(new Vector3(v.X, v.Y, v.Z));
            Vector3 uuv = qVec.Cross(uv);
            Vector3 result = new Vector3(v.X, v.Y, v.Z) + (uv * (2.0 * q.W)) + (uuv * 2.0);
            return new FVector3((float)result.X, (float)result.Y, (float)result.Z);
        }

        public static FVector4 operator *(Quaternion q, FVector4 v)
        {
            Vector3 qVec = new Vector3(q.X, q.Y, q.Z);
            Vector3 uv = qVec.Cross(new Vector3(v.X, v.Y, v.Z));
            Vector3 uuv = qVec.Cross(uv);
            Vector3 result = new Vector3(v.X, v.Y, v.Z) + (uv * (2.0 * q.W)) + (uuv * 2.0);
            return new FVector4((float)result.X, (float)result.Y, (float)result.Z, v.W);
        }

        public static Vector3 operator *(Vector3 v, Quaternion q)
        {
            Quaternion inv = q.Conjugate();
            return inv * v;
        }

        public static bool operator ==(Quaternion lhs, Quaternion rhs)
        {
            return lhs.W == rhs.W && lhs.X == rhs.X && lhs.Y == rhs.Y && lhs.Z == rhs.Z;
        }

        public static bool operator !=(Quaternion lhs, Quaternion rhs)
        {
            return lhs.W != rhs.W || lhs.X != rhs.X || lhs.Y != rhs.Y || lhs.Z != rhs.Z;
        }
    }
}