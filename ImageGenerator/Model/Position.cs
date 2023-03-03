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
            Validation(x, y);
            X = x;
            Y = y;
        }

        public static Position operator +(Position a, Position b) 
        {
            return new Position(a.X + b.X, a.Y + b.Y);
        }

        public static Position operator -(Position a, Position b)
        {
            return new Position(a.X - b.X, a.Y - b.Y);
        }

        private static void Validation(double x, double y)
        {
            if (x < minRange || x > maxRange || y < minRange || y > maxRange) 
                throw new ArgumentException($"Error: Position values of X and Y must be within range of {minRange} - {maxRange}\nX={x}\nY={y}");
        }

        public static Position GetScaleStep(int x, int y)
        {
            return new Position(1/(double)x, 1/(double)y);
        }
    }
}
