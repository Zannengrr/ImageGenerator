namespace ImageGenerator.Model
{
    public struct Position
    {
        public double X { get; set; } = 0.0;
        public double Y { get; set; } = 0.0;

        private static readonly double minRange = 0.0;
        private static readonly double maxRange = 1.0;

        public Position(double x, double y)
        {
            X = Math.Clamp(x, minRange, maxRange);
            Y = Math.Clamp(y, minRange, maxRange);
        }
    }
}
