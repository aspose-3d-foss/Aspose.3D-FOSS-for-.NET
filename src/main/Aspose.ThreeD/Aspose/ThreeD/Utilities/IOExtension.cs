using System.IO;

namespace Aspose.ThreeD.Utilities
{
    public static class IOExtension
    {
        public static void Write(BinaryWriter writer, Matrix4 mat)
        {
            writer.Write(mat.m00);
            writer.Write(mat.m01);
            writer.Write(mat.m02);
            writer.Write(mat.m03);
            writer.Write(mat.m10);
            writer.Write(mat.m11);
            writer.Write(mat.m12);
            writer.Write(mat.m13);
            writer.Write(mat.m20);
            writer.Write(mat.m21);
            writer.Write(mat.m22);
            writer.Write(mat.m23);
            writer.Write(mat.m30);
            writer.Write(mat.m31);
            writer.Write(mat.m32);
            writer.Write(mat.m33);
        }

        public static void Write(BinaryWriter writer, FMatrix4 mat)
        {
            writer.Write(mat.m00);
            writer.Write(mat.m01);
            writer.Write(mat.m02);
            writer.Write(mat.m03);
            writer.Write(mat.m10);
            writer.Write(mat.m11);
            writer.Write(mat.m12);
            writer.Write(mat.m13);
            writer.Write(mat.m20);
            writer.Write(mat.m21);
            writer.Write(mat.m22);
            writer.Write(mat.m23);
            writer.Write(mat.m30);
            writer.Write(mat.m31);
            writer.Write(mat.m32);
            writer.Write(mat.m33);
        }

        public static void Write(BinaryWriter writer, FVector2 v)
        {
            writer.Write(v.X);
            writer.Write(v.Y);
        }

        public static void Write(BinaryWriter writer, FVector3 v)
        {
            writer.Write(v.X);
            writer.Write(v.Y);
            writer.Write(v.Z);
        }

        public static void Write(BinaryWriter writer, FVector4 v)
        {
            writer.Write(v.X);
            writer.Write(v.Y);
            writer.Write(v.Z);
            writer.Write(v.W);
        }

        public static void Write(BinaryWriter writer, Vector2 v)
        {
            writer.Write((float)v.X);
            writer.Write((float)v.Y);
        }

        public static void Write(BinaryWriter writer, Vector3 v)
        {
            writer.Write((float)v.X);
            writer.Write((float)v.Y);
            writer.Write((float)v.Z);
        }

        public static void Write(BinaryWriter writer, Vector4 v)
        {
            writer.Write((float)v.X);
            writer.Write((float)v.Y);
            writer.Write((float)v.Z);
            writer.Write((float)v.W);
        }
    }
}
