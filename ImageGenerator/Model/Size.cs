namespace ImageGenerator.Model
{
    public struct Size
    {
        public int X;
        public int Y;

        public Size(Size size)
        {
            X = size.X;
            Y = size.Y;
        }
    }
}
