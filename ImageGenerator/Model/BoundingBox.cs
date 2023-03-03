namespace ImageGenerator.Model
{
    public class BoundingBox
    {
        public Position Max { get; set; } = new();
        public Position Min { get; set; } = new();
        public BoundingBox(Position maxPoints, Position minPoints)
        {
            Max = maxPoints;
            Min = minPoints;
        }
    }
}
