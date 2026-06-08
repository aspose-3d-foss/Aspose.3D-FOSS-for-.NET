using System;

namespace Aspose.ThreeD.Utilities
{
    public struct BoundingBox2D
    {
        private Vector2 _minimum;
        private Vector2 _maximum;
        private BoundingBoxExtent _extent;

        public BoundingBox2D(Vector2 minimum, Vector2 maximum)
        {
            _minimum = minimum;
            _maximum = maximum;
            _extent = BoundingBoxExtent.Finite;
        }

        public BoundingBox2D()
        {
            _minimum = new Vector2(0, 0);
            _maximum = new Vector2(0, 0);
            _extent = BoundingBoxExtent.Null;
        }

        public BoundingBoxExtent Extent => _extent;

        public Vector2 Minimum => _minimum;

        public Vector2 Maximum => _maximum;

        public void Merge(Vector2 pt)
        {
            if (_extent == BoundingBoxExtent.Null)
            {
                _minimum = pt;
                _maximum = pt;
                _extent = BoundingBoxExtent.Finite;
            }
            else
            {
                if (pt.X < _minimum.X) _minimum.X = pt.X;
                if (pt.Y < _minimum.Y) _minimum.Y = pt.Y;
                if (pt.X > _maximum.X) _maximum.X = pt.X;
                if (pt.Y > _maximum.Y) _maximum.Y = pt.Y;
            }
        }

        public void Merge(BoundingBox2D bb)
        {
            if (bb._extent == BoundingBoxExtent.Null)
                return;

            if (_extent == BoundingBoxExtent.Null)
            {
                _minimum = bb._minimum;
                _maximum = bb._maximum;
                _extent = BoundingBoxExtent.Finite;
            }
            else
            {
                if (bb._minimum.X < _minimum.X) _minimum.X = bb._minimum.X;
                if (bb._minimum.Y < _minimum.Y) _minimum.Y = bb._minimum.Y;
                if (bb._maximum.X > _maximum.X) _maximum.X = bb._maximum.X;
                if (bb._maximum.Y > _maximum.Y) _maximum.Y = bb._maximum.Y;
            }
        }

        public override string ToString()
        {
            return $"Minimum: {_minimum}, Maximum: {_maximum}";
        }
    }
}
