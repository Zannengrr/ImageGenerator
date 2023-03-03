using ImageGenerator.Interfaces;
using ImageGenerator.Model;

namespace ImageGenerator.Services.PolygonFillServices
{
    public class ScanLine : IRegionFillAlgorithm
    {
        public List<Size> GetPixelsInsideRegions(List<Region> regions, Size size)
        {
            List<Size> result = new();

            Position scale = Position.GetScaleStep(size.X, size.Y);
            foreach (Region region in regions)
            {
                for (double y = region.BoundingBox.Min.Y; y <= region.BoundingBox.Max.Y; y += scale.Y)
                {
                    List<double> intersections = new();

                    for (int i = 0, i0 = region.Positions.Length - 1; i < region.Positions.Length; i0 = i++)
                    {
                        if (region.Positions[i].Y <= y && region.Positions[i0].Y > y || region.Positions[i0].Y <= y && region.Positions[i].Y > y)
                        {
                            double intersectionX = (y * (region.Positions[i0].X - region.Positions[i].X) -
                                (region.Positions[i].Y * region.Positions[i0].X - region.Positions[i].X * region.Positions[i0].Y)) /
                                (region.Positions[i0].Y - region.Positions[i].Y);
                            intersections.Add(intersectionX);
                        }
                    }
                    intersections.Sort();

                    int pixelY = size.Y + 1 - (int)Math.Ceiling(y * (size.Y - 1) + 1);
                    for (int i = 0; i < intersections.Count - 1; i += 2)
                    {

                        int xmin = (int)Math.Ceiling(intersections[i] * (size.X - 1) + 1);
                        int xmax = (int)Math.Floor(intersections[i + 1] * (size.X - 1) + 1);
                        for (int pixelX = xmin; pixelX <= xmax; pixelX++)
                        {
                            result.Add(new Size(pixelX, pixelY));
                        }
                    }
                }
            }

            return result;
        }
    }
}
