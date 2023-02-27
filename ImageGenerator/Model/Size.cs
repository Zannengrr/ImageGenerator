namespace ImageGenerator.Model
{
    public struct Size
    {
        public int X;
        public int Y;

        //make it only positive values, watch out for overflow if using uint
        public Size(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Size(Size size)
        {
            X = size.X;
            Y = size.Y;
        }
    }
}
