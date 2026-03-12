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
                if (pt.x < _minimum.x) _minimum.x = pt.x;
                if (pt.y < _minimum.y) _minimum.y = pt.y;
                if (pt.x > _maximum.x) _maximum.x = pt.x;
                if (pt.y > _maximum.y) _maximum.y = pt.y;
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
                if (bb._minimum.x < _minimum.x) _minimum.x = bb._minimum.x;
                if (bb._minimum.y < _minimum.y) _minimum.y = bb._minimum.y;
                if (bb._maximum.x > _maximum.x) _maximum.x = bb._maximum.x;
                if (bb._maximum.y > _maximum.y) _maximum.y = bb._maximum.y;
            }
        }

        public override string ToString()
        {
            return $"Minimum: {_minimum}, Maximum: {_maximum}";
        }
    }
}
