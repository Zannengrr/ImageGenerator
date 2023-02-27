namespace ImageGenerator.Model
{
    public struct Region
    {
        public Position[] Positions { get; set; }
        private BoundingBox boundingBox { get; set; }

        public Region(Region region)
        {
            Positions = region.Positions;
            boundingBox = GetBoundingBox();
        }

        public bool IsPointInsideRegion(Position point)
        {
            //bounding box check
            if (point.X < boundingBox.LowerLeft.X ||
                point.X > boundingBox.UpperRight.X ||
                point.Y < boundingBox.LowerLeft.Y ||
                point.Y > boundingBox.UpperRight.Y) return false;

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

        //provjera da li zadnja točka ima bar jednu koordinatu jednaku kao i prva
        //provjera da li svaka koordinata ima bar jednu točku jednaku kao i prijašnja osim prve
    }
}
