using ImageGenerator.Interfaces;
using ImageGenerator.Model;
using System.Drawing;
using Region = ImageGenerator.Model.Region;
using Size = ImageGenerator.Model.Size;

namespace ImageGenerator.Services.PolygonFillServices
{
    public class PointInsidePolygon : IRegionFillAlgorithm
    {
        public List<Point> GetPixelsInsideRegions(List<Region> regions, Size size)
        {
            List<Point> result = new();

            Position scale = Position.GetScaleStep(size.X, size.Y);
            Position centerOffset = new(scale.X * 0.5, scale.Y * 0.5);
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    foreach (Region region in regions)
                    {
                        int mappedY = size.Y - j - 1;
                        Position pixelToPoint = new(i * scale.X + centerOffset.X, j * scale.Y + centerOffset.Y);
                        if (region.IsPointInsideRegion(pixelToPoint))
                        {
                            result.Add(new Point(i, mappedY));
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
