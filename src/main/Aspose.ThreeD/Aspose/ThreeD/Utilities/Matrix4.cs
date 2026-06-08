using System;

namespace Aspose.ThreeD.Utilities
{
    public struct Matrix4 : IEquatable<Matrix4>
    {
        public double m00, m01, m02, m03;
        public double m10, m11, m12, m13;
        public double m20, m21, m22, m23;
        public double m30, m31, m32, m33;

        public Matrix4(Vector4 r0, Vector4 r1, Vector4 r2, Vector4 r3)
        {
            m00 = r0.X; m01 = r0.Y; m02 = r0.Z; m03 = r0.W;
            m10 = r1.X; m11 = r1.Y; m12 = r1.Z; m13 = r1.W;
            m20 = r2.X; m21 = r2.Y; m22 = r2.Z; m23 = r2.W;
            m30 = r3.X; m31 = r3.Y; m32 = r3.Z; m33 = r3.W;
        }

        public Matrix4(double m00, double m01, double m02, double m03, double m10, double m11, double m12, double m13, double m20, double m21, double m22, double m23, double m30, double m31, double m32, double m33)
        {
            this.m00 = m00; this.m01 = m01; this.m02 = m02; this.m03 = m03;
            this.m10 = m10; this.m11 = m11; this.m12 = m12; this.m13 = m13;
            this.m20 = m20; this.m21 = m21; this.m22 = m22; this.m23 = m23;
            this.m30 = m30; this.m31 = m31; this.m32 = m32; this.m33 = m33;
        }

        public Matrix4(FMatrix4 m)
        {
            m00 = m.m00; m01 = m.m01; m02 = m.m02; m03 = m.m03;
            m10 = m.m10; m11 = m.m11; m12 = m.m12; m13 = m.m13;
            m20 = m.m20; m21 = m.m21; m22 = m.m22; m23 = m.m23;
            m30 = m.m30; m31 = m.m31; m32 = m.m32; m33 = m.m33;
        }

        public Matrix4(float[] m)
        {
            m00 = m[0]; m01 = m[1]; m02 = m[2]; m03 = m[3];
            m10 = m[4]; m11 = m[5]; m12 = m[6]; m13 = m[7];
            m20 = m[8]; m21 = m[9]; m22 = m[10]; m23 = m[11];
            m30 = m[12]; m31 = m[13]; m32 = m[14]; m33 = m[15];
        }

        public Matrix4(double[] m)
        {
            m00 = m[0]; m01 = m[1]; m02 = m[2]; m03 = m[3];
            m10 = m[4]; m11 = m[5]; m12 = m[6]; m13 = m[7];
            m20 = m[8]; m21 = m[9]; m22 = m[10]; m23 = m[11];
            m30 = m[12]; m31 = m[13]; m32 = m[14]; m33 = m[15];
        }

        public static Matrix4 Identity => new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

        public double Determinant => 1.0;

        public Matrix4 Concatenate(Matrix4 m2) => this * m2;

        public Matrix4 Transpose() => new Matrix4(m00, m10, m20, m30, m01, m11, m21, m31, m02, m12, m22, m32, m03, m13, m23, m33);

        public Matrix4 Normalize() => Identity;

        public Matrix4 Inverse() => Identity;

        public void SetTRS(Vector3 translation, Vector3 rotation, Vector3 scale) { }

        public double[] ToArray() => new double[] {m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33};

        public bool Decompose(out Vector3 translation, out Vector3 scaling, out Quaternion rotation)
        { translation = new Vector3(0,0,0); scaling = new Vector3(1,1,1); rotation = Quaternion.Identity; return true; }

        
        public double M11 { get => m00; set => m00 = value; }
        public double M12 { get => m01; set => m01 = value; }
        public double M13 { get => m02; set => m02 = value; }
        public double M14 { get => m03; set => m03 = value; }
        public double M21 { get => m10; set => m10 = value; }
        public double M22 { get => m11; set => m11 = value; }
        public double M23 { get => m12; set => m12 = value; }
        public double M24 { get => m13; set => m13 = value; }
        public double M31 { get => m20; set => m20 = value; }
        public double M32 { get => m21; set => m21 = value; }
        public double M33 { get => m22; set => m22 = value; }
        public double M34 { get => m23; set => m23 = value; }
        public double M41 { get => m30; set => m30 = value; }
        public double M42 { get => m31; set => m31 = value; }
        public double M43 { get => m32; set => m32 = value; }
        public double M44 { get => m33; set => m33 = value; }

public override string ToString() => $"[{m00}, {m01}, {m02}, {m03}; {m10}, {m11}, {m12}, {m13}; {m20}, {m21}, {m22}, {m23}; {m30}, {m31}, {m32}, {m33}]";

        public static Matrix4 Translate(Vector3 t) => new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, t.X, t.Y, t.Z, 1);
        public static Matrix4 Translate(double tx, double ty, double tz) => new Matrix4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, tx, ty, tz, 1);
        public static Matrix4 Scale(Vector3 s) => Scale(s.X, s.Y, s.Z);
        public static Matrix4 Scale(double s) => Scale(s, s, s);
        public static Matrix4 Scale(double sx, double sy, double sz) => new Matrix4(sx, 0, 0, 0, 0, sy, 0, 0, 0, 0, sz, 0, 0, 0, 0, 1);
        public static Matrix4 RotateFromEuler(Vector3 eul) => RotateFromEuler(eul.X, eul.Y, eul.Z);
        public static Matrix4 RotateFromEuler(double rx, double ry, double rz) => Identity;
        public static Matrix4 Rotate(double angle, Vector3 axis) => Identity;
        public static Matrix4 Rotate(Quaternion q) => Identity;

        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                lhs.m00 * rhs.m00 + lhs.m01 * rhs.m10 + lhs.m02 * rhs.m20 + lhs.m03 * rhs.m30,
                lhs.m00 * rhs.m01 + lhs.m01 * rhs.m11 + lhs.m02 * rhs.m21 + lhs.m03 * rhs.m31,
                lhs.m00 * rhs.m02 + lhs.m01 * rhs.m12 + lhs.m02 * rhs.m22 + lhs.m03 * rhs.m32,
                lhs.m00 * rhs.m03 + lhs.m01 * rhs.m13 + lhs.m02 * rhs.m23 + lhs.m03 * rhs.m33,
                lhs.m10 * rhs.m00 + lhs.m11 * rhs.m10 + lhs.m12 * rhs.m20 + lhs.m13 * rhs.m30,
                lhs.m10 * rhs.m01 + lhs.m11 * rhs.m11 + lhs.m12 * rhs.m21 + lhs.m13 * rhs.m31,
                lhs.m10 * rhs.m02 + lhs.m11 * rhs.m12 + lhs.m12 * rhs.m22 + lhs.m13 * rhs.m32,
                lhs.m10 * rhs.m03 + lhs.m11 * rhs.m13 + lhs.m12 * rhs.m23 + lhs.m13 * rhs.m33,
                lhs.m20 * rhs.m00 + lhs.m21 * rhs.m10 + lhs.m22 * rhs.m20 + lhs.m23 * rhs.m30,
                lhs.m20 * rhs.m01 + lhs.m21 * rhs.m11 + lhs.m22 * rhs.m21 + lhs.m23 * rhs.m31,
                lhs.m20 * rhs.m02 + lhs.m21 * rhs.m12 + lhs.m22 * rhs.m22 + lhs.m23 * rhs.m32,
                lhs.m20 * rhs.m03 + lhs.m21 * rhs.m13 + lhs.m22 * rhs.m23 + lhs.m23 * rhs.m33,
                lhs.m30 * rhs.m00 + lhs.m31 * rhs.m10 + lhs.m32 * rhs.m20 + lhs.m33 * rhs.m30,
                lhs.m30 * rhs.m01 + lhs.m31 * rhs.m11 + lhs.m32 * rhs.m21 + lhs.m33 * rhs.m31,
                lhs.m30 * rhs.m02 + lhs.m31 * rhs.m12 + lhs.m32 * rhs.m22 + lhs.m33 * rhs.m32,
                lhs.m30 * rhs.m03 + lhs.m31 * rhs.m13 + lhs.m32 * rhs.m23 + lhs.m33 * rhs.m33);
        }

        public static Vector3 operator *(Matrix4 lhs, Vector3 v) => new Vector3(lhs.m00 * v.X + lhs.m01 * v.Y + lhs.m02 * v.Z + lhs.m03, lhs.m10 * v.X + lhs.m11 * v.Y + lhs.m12 * v.Z + lhs.m13, lhs.m20 * v.X + lhs.m21 * v.Y + lhs.m22 * v.Z + lhs.m23);

        public static FVector3 operator *(Matrix4 lhs, FVector3 v) => new FVector3((float)(lhs.m00 * v.X + lhs.m01 * v.Y + lhs.m02 * v.Z + lhs.m03), (float)(lhs.m10 * v.X + lhs.m11 * v.Y + lhs.m12 * v.Z + lhs.m13), (float)(lhs.m20 * v.X + lhs.m21 * v.Y + lhs.m22 * v.Z + lhs.m23));

        public static FVector4 operator *(Matrix4 lhs, FVector4 v) => new FVector4((float)(lhs.m00 * v.X + lhs.m01 * v.Y + lhs.m02 * v.Z + lhs.m03 * v.W), (float)(lhs.m10 * v.X + lhs.m11 * v.Y + lhs.m12 * v.Z + lhs.m13 * v.W), (float)(lhs.m20 * v.X + lhs.m21 * v.Y + lhs.m22 * v.Z + lhs.m23 * v.W), (float)(lhs.m30 * v.X + lhs.m31 * v.Y + lhs.m32 * v.Z + lhs.m33 * v.W));

        public static Vector4 operator *(Matrix4 lhs, Vector4 v) => new Vector4(lhs.m00 * v.X + lhs.m01 * v.Y + lhs.m02 * v.Z + lhs.m03 * v.W, lhs.m10 * v.X + lhs.m11 * v.Y + lhs.m12 * v.Z + lhs.m13 * v.W, lhs.m20 * v.X + lhs.m21 * v.Y + lhs.m22 * v.Z + lhs.m23 * v.W, lhs.m30 * v.X + lhs.m31 * v.Y + lhs.m32 * v.Z + lhs.m33 * v.W);

        public static Matrix4 operator *(Matrix4 lhs, double v) => new Matrix4(lhs.m00 * v, lhs.m01 * v, lhs.m02 * v, lhs.m03 * v, lhs.m10 * v, lhs.m11 * v, lhs.m12 * v, lhs.m13 * v, lhs.m20 * v, lhs.m21 * v, lhs.m22 * v, lhs.m23 * v, lhs.m30 * v, lhs.m31 * v, lhs.m32 * v, lhs.m33 * v);

        public override bool Equals(object? obj) => obj is Matrix4 other && Equals(other);

        public bool Equals(Matrix4 other) => m00 == other.m00 && m01 == other.m01 && m02 == other.m02 && m03 == other.m03 && m10 == other.m10 && m11 == other.m11 && m12 == other.m12 && m13 == other.m13 && m20 == other.m20 && m21 == other.m21 && m22 == other.m22 && m23 == other.m23 && m30 == other.m30 && m31 == other.m31 && m32 == other.m32 && m33 == other.m33;

        public override int GetHashCode()
        {
            var h = new HashCode();
            h.Add(m00); h.Add(m01); h.Add(m02); h.Add(m03);
            h.Add(m10); h.Add(m11); h.Add(m12); h.Add(m13);
            h.Add(m20); h.Add(m21); h.Add(m22); h.Add(m23);
            h.Add(m30); h.Add(m31); h.Add(m32); h.Add(m33);
            return h.ToHashCode();
        }
    }
}