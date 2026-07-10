using System;
using Aspose.ThreeD.Entities;

namespace Aspose.ThreeD.Utilities
{
    /// <summary>
    /// The axis-aligned bounding box
    /// </summary>
    public struct BoundingBox
    {
        private Vector3 _minimum;
        private Vector3 _maximum;

        /// <summary>
        /// Initialize a finite bounding box with given minimum and maximum corner
        /// </summary>
        public BoundingBox(Vector3 minimum, Vector3 maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
        }

        /// <summary>
        /// The null bounding box
        /// </summary>
        public static BoundingBox Null
        {
            get => new BoundingBox(Vector3.Zero, Vector3.Zero);
        }

        /// <summary>
        /// The infinite bounding box
        /// </summary>
        public static BoundingBox Infinite
        {
            get => new BoundingBox(
                new Vector3(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity),
                new Vector3(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity));
        }

        /// <summary>
        /// Initialize a finite bounding box with given minimum and maximum corner
        /// </summary>
        public BoundingBox(FVector3 minimum, FVector3 maximum)
        {
            _minimum = new Vector3(minimum.X, minimum.Y, minimum.Z);
            _maximum = new Vector3(maximum.X, maximum.Y, maximum.Z);
        }

        /// <summary>
        /// Initialize a finite bounding box with given minimum and maximum corner
        /// </summary>
        public BoundingBox(double minX, double minY, double minZ, double maxX, double maxY, double maxZ)
        {
            _minimum = new Vector3(minX, minY, minZ);
            _maximum = new Vector3(maxX, maxY, maxZ);
        }

        /// <summary>
        /// Gets the extent of the bounding box.
        /// </summary>
        public BoundingBoxExtent Extent
        {
            get
            {
                if (_minimum == new Vector3(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity) &&
                    _maximum == new Vector3(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity))
                    return BoundingBoxExtent.Infinite;
                if (_minimum == Vector3.Zero && _maximum == Vector3.Zero)
                    return BoundingBoxExtent.Null;
                return BoundingBoxExtent.Finite;
            }
        }

        /// <summary>
        /// The minimum corner of the bounding box
        /// </summary>
        public Vector3 Minimum => _minimum;

        /// <summary>
        /// The maximum corner of the bounding box
        /// </summary>
        public Vector3 Maximum => _maximum;

        /// <summary>
        /// The size of the bounding box
        /// </summary>
        public Vector3 Size => _maximum - _minimum;

        /// <summary>
        /// The center of the bounding box.
        /// </summary>
        public Vector3 Center => (_minimum + _maximum) * 0.5;

        /// <summary>
        /// Calculates the absolute largest coordinate value of any contained point.
        /// </summary>
        public double Scale()
        {
            var size = Size;
            return Math.Max(Math.Abs(size.X), Math.Max(Math.Abs(size.Y), Math.Abs(size.Z)));
        }

        /// <summary>
        /// Construct a bounding box from given geometry
        /// </summary>
        public static BoundingBox FromGeometry(Geometry geometry)
        {
            if (geometry == null)
                return BoundingBox.Null;

            var bbox = geometry.GetBoundingBox();
            return bbox;
        }

        /// <summary>
        /// Merge current bounding box with given point
        /// </summary>
        public void Merge(Vector4 pt)
        {
            Merge(new Vector3(pt.X / pt.W, pt.Y / pt.W, pt.Z / pt.W));
        }

        /// <summary>
        /// Merge current bounding box with given point
        /// </summary>
        public void Merge(Vector3 pt)
        {
            _minimum = new Vector3(
                Math.Min(_minimum.X, pt.X),
                Math.Min(_minimum.Y, pt.Y),
                Math.Min(_minimum.Z, pt.Z));
            _maximum = new Vector3(
                Math.Max(_maximum.X, pt.X),
                Math.Max(_maximum.Y, pt.Y),
                Math.Max(_maximum.Z, pt.Z));
        }

        /// <summary>
        /// Merge current bounding box with given point
        /// </summary>
        public void Merge(FVector3 pt)
        {
            Merge(new Vector3(pt.X, pt.Y, pt.Z));
        }

        /// <summary>
        /// Merge current bounding box with given point
        /// </summary>
        public void Merge(double x, double y, double z)
        {
            Merge(new Vector3(x, y, z));
        }

        /// <summary>
        /// Merges the new box into the current bounding box.
        /// </summary>
        public void Merge(BoundingBox bb)
        {
            _minimum = new Vector3(
                Math.Min(_minimum.X, bb._minimum.X),
                Math.Min(_minimum.Y, bb._minimum.Y),
                Math.Min(_minimum.Z, bb._minimum.Z));
            _maximum = new Vector3(
                Math.Max(_maximum.X, bb._maximum.X),
                Math.Max(_maximum.Y, bb._maximum.Y),
                Math.Max(_maximum.Z, bb._maximum.Z));
        }

        /// <summary>
        /// Gets the string representation of the bounding box.
        /// </summary>
        public override string ToString()
        {
            return $"Minimum: {_minimum}, Maximum: {_maximum}";
        }

        /// <summary>
        /// Returns the hash code for this instance
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(_minimum, _maximum);
        }

        /// <summary>
        /// Determines if two objects are equal
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is BoundingBox bb && Equals(bb);
        }

        /// <summary>
        /// Check if current bounding box overlaps with specified bounding box.
        /// </summary>
        public bool OverlapsWith(BoundingBox box)
        {
            return _minimum.X <= box._maximum.X && _maximum.X >= box._minimum.X &&
                   _minimum.Y <= box._maximum.Y && _maximum.Y >= box._minimum.Y &&
                   _minimum.Z <= box._maximum.Z && _maximum.Z >= box._minimum.Z;
        }

        /// <summary>
        /// Check if the point p is inside the bounding box
        /// </summary>
        public bool Contains(Vector3 p)
        {
            return p.X >= _minimum.X && p.X <= _maximum.X &&
                   p.Y >= _minimum.Y && p.Y <= _maximum.Y &&
                   p.Z >= _minimum.Z && p.Z <= _maximum.Z;
        }

        /// <summary>
        /// The bounding box to check if it's inside current bounding box.
        /// </summary>
        public bool Contains(BoundingBox bbox)
        {
            return _minimum.X <= bbox._minimum.X && _maximum.X >= bbox._maximum.X &&
                   _minimum.Y <= bbox._minimum.Y && _maximum.Y >= bbox._maximum.Y &&
                   _minimum.Z <= bbox._minimum.Z && _maximum.Z >= bbox._maximum.Z;
        }

        /// <summary>
        /// Operator overloading for multiply, new bounding box's minimum and maximum corner will be transformed by the matrix.
        /// </summary>
        public static BoundingBox operator *(BoundingBox bbox, Matrix4 mat)
        {
            // Transform all 8 corners and compute new bounding box
            var corners = new Vector3[]
            {
                new Vector3(bbox._minimum.X, bbox._minimum.Y, bbox._minimum.Z),
                new Vector3(bbox._maximum.X, bbox._minimum.Y, bbox._minimum.Z),
                new Vector3(bbox._minimum.X, bbox._maximum.Y, bbox._minimum.Z),
                new Vector3(bbox._maximum.X, bbox._maximum.Y, bbox._minimum.Z),
                new Vector3(bbox._minimum.X, bbox._minimum.Y, bbox._maximum.Z),
                new Vector3(bbox._maximum.X, bbox._minimum.Y, bbox._maximum.Z),
                new Vector3(bbox._minimum.X, bbox._maximum.Y, bbox._maximum.Z),
                new Vector3(bbox._maximum.X, bbox._maximum.Y, bbox._maximum.Z),
            };

            Vector3 min = new Vector3(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity);
            Vector3 max = new Vector3(double.NegativeInfinity, double.NegativeInfinity, double.NegativeInfinity);

            foreach (var corner in corners)
            {
                var transformed = mat * corner;
                min = new Vector3(
                    Math.Min(min.X, transformed.X),
                    Math.Min(min.Y, transformed.Y),
                    Math.Min(min.Z, transformed.Z));
                max = new Vector3(
                    Math.Max(max.X, transformed.X),
                    Math.Max(max.Y, transformed.Y),
                    Math.Max(max.Z, transformed.Z));
            }

            return new BoundingBox(min, max);
        }

        /// <summary>
        /// Check if two bounding boxes are equal
        /// </summary>
    }
}
