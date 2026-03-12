namespace Aspose.ThreeD.Utilities
{
    public struct Rect
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int Left => X;

        public int Right => X + Width;

        public int Top => Y;

        public int Bottom => Y + Height;

        public bool Contains(int x, int y)
        {
            return x >= Left && x <= Right && y >= Top && y <= Bottom;
        }
    }
}
