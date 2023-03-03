namespace ImageGenerator.Model
{
    public class Edge
    {
        public double Xvalue { get; set; }
        public double Ymin { get; set; }
        public double Ymax { get; set; }
        public double Slope { get; set; }
        public bool IsHorizontalLine { get; set; } = false;
        public Edge(Position p1, Position p2) 
        {
            if(p1.Y < p2.Y)
            {
                Ymin = p1.Y;
                Xvalue = p1.X;
                Ymax = p2.Y;
            }
            else if(p2.Y < p1.Y)
            {
                Ymin = p2.Y;
                Xvalue = p2.X;
                Ymax = p1.Y;
            }
            else
            {
                //horizontal line
                Ymin = Xvalue = Ymax = Slope = 0;
                IsHorizontalLine = true;
                return;
            }

            Slope = (p2.X - p1.X) / (p2.Y - p1.Y);
        }
    }
}
