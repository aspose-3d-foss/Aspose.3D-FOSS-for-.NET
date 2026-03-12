using System;

namespace Aspose.ThreeD.Utilities
{
    public class TransformBuilder
    {
        private Matrix4 _matrix;
        private ComposeOrder _order;

        public TransformBuilder(Matrix4 initial, ComposeOrder order)
        {
            _matrix = initial;
            _order = order;
        }

        public TransformBuilder(ComposeOrder order) : this(Matrix4.Identity, order)
        {
        }

        public Matrix4 Matrix
        {
            get => _matrix;
            set => _matrix = value;
        }

        public ComposeOrder ComposeOrder
        {
            get => _order;
            set => _order = value;
        }

        public void Compose(Matrix4 m)
        {
            if (_order == ComposeOrder.Append)
            {
                _matrix = _matrix * m;
            }
            else
            {
                _matrix = m * _matrix;
            }
        }

        public TransformBuilder Append(Matrix4 m)
        {
            Compose(m);
            return this;
        }

        public TransformBuilder Prepend(Matrix4 m)
        {
            _matrix = m * _matrix;
            return this;
        }

        public TransformBuilder Rearrange(Axis newX, Axis newY, Axis newZ)
        {
            Matrix4 rearrange = Matrix4.Identity;
            return this;
        }

        public TransformBuilder Scale(double s)
        {
            return Scale(s, s, s);
        }

        public TransformBuilder Scale(double x, double y, double z)
        {
            Matrix4 scale = Matrix4.Scale(new FVector3((float)x, (float)y, (float)z));
            Compose(scale);
            return this;
        }

        public TransformBuilder Scale(Vector3 s)
        {
            Matrix4 scale = Matrix4.Scale(new FVector3((float)s.x, (float)s.y, (float)s.z));
            Compose(scale);
            return this;
        }

        public TransformBuilder RotateDegree(double angle, Vector3 axis)
        {
            return RotateRadian(angle * Math.PI / 180.0, axis);
        }

        public TransformBuilder RotateRadian(double angle, Vector3 axis)
        {
            Quaternion q = new Quaternion((float)axis.x, (float)axis.y, (float)axis.z, (float)Math.Cos(angle / 2));
            Matrix4 rotation = Matrix4.Rotation(q);
            Compose(rotation);
            return this;
        }

        public TransformBuilder Rotate(Quaternion q)
        {
            Matrix4 rotation = Matrix4.Rotation(q);
            Compose(rotation);
            return this;
        }

        public TransformBuilder RotateEulerDegree(double degX, double degY, double degZ)
        {
            return RotateEulerRadian(degX * Math.PI / 180.0, degY * Math.PI / 180.0, degZ * Math.PI / 180.0);
        }

        public TransformBuilder RotateEulerRadian(double x, double y, double z)
        {
            return RotateEulerRadian(new Vector3(x, y, z));
        }

        public TransformBuilder RotateEulerRadian(Vector3 r)
        {
            RotateRadian(r, RotationOrder.XYZ);
            return this;
        }

        public TransformBuilder Translate(double tx, double ty, double tz)
        {
            Matrix4 translation = Matrix4.Translation(new FVector3((float)tx, (float)ty, (float)tz));
            Compose(translation);
            return this;
        }

        public TransformBuilder Translate(Vector3 v)
        {
            Matrix4 translation = Matrix4.Translation(new FVector3((float)v.x, (float)v.y, (float)v.z));
            Compose(translation);
            return this;
        }

        public void Reset()
        {
            _matrix = Matrix4.Identity;
        }

        public void RotateDegree(Vector3 rot, RotationOrder order)
        {
            RotateRadian(new Vector3(rot.x * Math.PI / 180.0, rot.y * Math.PI / 180.0, rot.z * Math.PI / 180.0), order);
        }

        public void RotateRadian(Vector3 rot, RotationOrder order)
        {
            Matrix4 rx = Matrix4.Rotation(new Quaternion((float)Math.Sin(rot.x / 2), 0, 0, (float)Math.Cos(rot.x / 2)));
            Matrix4 ry = Matrix4.Rotation(new Quaternion(0, (float)Math.Sin(rot.y / 2), 0, (float)Math.Cos(rot.y / 2)));
            Matrix4 rz = Matrix4.Rotation(new Quaternion(0, 0, (float)Math.Sin(rot.z / 2), (float)Math.Cos(rot.z / 2)));

            Matrix4 combined;
            switch (order)
            {
                case RotationOrder.XYZ:
                    combined = rx * ry * rz;
                    break;
                case RotationOrder.XZY:
                    combined = rx * rz * ry;
                    break;
                case RotationOrder.YZX:
                    combined = ry * rz * rx;
                    break;
                case RotationOrder.YXZ:
                    combined = ry * rx * rz;
                    break;
                case RotationOrder.ZXY:
                    combined = rz * rx * ry;
                    break;
                case RotationOrder.ZYX:
                    combined = rz * ry * rx;
                    break;
                default:
                    throw new ArgumentException("Unknown rotation order");
            }

            Compose(combined);
        }
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }
}
