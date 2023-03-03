namespace ImageGenerator.Model
{
    public struct Size
    {
        public int X;
        public int Y;

        public Size(Size size)
        {
            Validation(size.X, size.Y);
            X = size.X;
            Y = size.Y;
        }

        public Size(int x, int y)
        {
            Validation(x, y);
            X = x;
            Y = y;
        }

        private static void Validation(int x, int y)
        {
            if (x < 1 || y < 1) throw new ArgumentException("Error: Size contains values that are less then 1");
        }

    }
}
