namespace ImageGenerator.Model
{
    public class Region
    {
        public Position[] Positions { get; set; }
        public BoundingBox BoundingBox { get; set; }

        public Region() { }

        public Region(Region region)
        {
            Positions = region.Positions;
            IsReagionValid();
            BoundingBox = GetBoundingBox();
        }

        private void IsReagionValid()
        {
            if (Positions.Length < 3) throw new Exception("Area has less then 3 points");

            double sum = 0;
            for (int i = 0, i0 = Positions.Length - 1; i < Positions.Length; i0 = i++)
            {
                sum += (Positions[i].X - Positions[i0].X) * (Positions[i].Y + Positions[i0].Y);
            }

            if (sum < 0.0) throw new Exception("Points are not in clockwise order");
        }

        private BoundingBox GetBoundingBox()
        {
            Position maxPosition = new();
            Position minPosition = new(1.0, 1.0);

            foreach (Position position in Positions)
            {
                if (position.X > maxPosition.X) maxPosition.X = position.X;
                if (position.Y > maxPosition.Y) maxPosition.Y = position.Y;
                if (position.X < minPosition.X) minPosition.X = position.X;
                if (position.Y < minPosition.Y) minPosition.Y = position.Y;
            }
            return new BoundingBox(maxPosition, minPosition);
        }

        public bool IsPointInsideRegion(Position point)
        {
            //bounding box check
            if (point.X < BoundingBox.Min.X ||
                point.X > BoundingBox.Max.X ||
                point.Y < BoundingBox.Min.Y ||
                point.Y > BoundingBox.Max.Y) return false;

            bool inside = false;
            for (int i = 0, j = Positions.Length - 1; i < Positions.Length; j = i++)
            {
                if (((Positions[i].Y > point.Y) != (Positions[j].Y > point.Y)) &&
                    (point.X < (Positions[j].X - Positions[i].X) * (point.Y - Positions[i].Y) / (Positions[j].Y - Positions[i].Y) + Positions[i].X))
                {
                    inside = !inside;
                }
            }

            return inside;
        }

        public List<Edge> GetNonHorizontalEdges()
        {
            List<Edge> edges = new();
            for (int i = 0, i0 = Positions.Length - 1; i < Positions.Length; i0 = i++)
            {
                if (Positions[i0].Y == Positions[i].Y) continue;
                edges.Add(new Edge(Positions[i0], Positions[i]));
            }

            return edges;
        }
    }
}
