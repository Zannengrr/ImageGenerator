namespace ImageGenerator.Model
{
    public class BoundingBox
    {
        public Position UpperRight { get; set; } = new();
        public Position LowerLeft { get; set; } = new();
        public BoundingBox() { }
        public BoundingBox(Position maxPoints, Position minPoints)
        {
            UpperRight = maxPoints;
            LowerLeft = minPoints;
        }
    }
}
