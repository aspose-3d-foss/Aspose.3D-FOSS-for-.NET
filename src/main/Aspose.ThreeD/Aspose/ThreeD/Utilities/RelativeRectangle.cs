namespace Aspose.ThreeD.Utilities
{
    public struct RelativeRectangle
    {
        public float ScaleX { get; set; }
        public float ScaleY { get; set; }
        public float ScaleWidth { get; set; }
        public float ScaleHeight { get; set; }

        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public int OffsetWidth { get; set; }
        public int OffsetHeight { get; set; }

        public RelativeRectangle(int left, int top, int width, int height)
        {
            ScaleX = 0;
            ScaleY = 0;
            ScaleWidth = 0;
            ScaleHeight = 0;
            OffsetX = left;
            OffsetY = top;
            OffsetWidth = width;
            OffsetHeight = height;
        }

        public Rect ToAbsolute(int left, int top, int width, int height)
        {
            int absX = (int)(ScaleX * width) + OffsetX;
            int absY = (int)(ScaleY * height) + OffsetY;
            int absWidth = (int)(ScaleWidth * width) + OffsetWidth;
            int absHeight = (int)(ScaleHeight * height) + OffsetHeight;
            return new Rect(absX, absY, absWidth, absHeight);
        }

        public static RelativeRectangle FromScale(float scaleX, float scaleY, float scaleWidth, float scaleHeight)
        {
            return new RelativeRectangle(0, 0, 0, 0)
            {
                ScaleX = scaleX,
                ScaleY = scaleY,
                ScaleWidth = scaleWidth,
                ScaleHeight = scaleHeight
            };
        }

        public override string ToString()
        {
            return $"Scale: ({ScaleX}, {ScaleY}, {ScaleWidth}, {ScaleHeight}), Offset: ({OffsetX}, {OffsetY}, {OffsetWidth}, {OffsetHeight})";
        }
    }
}
