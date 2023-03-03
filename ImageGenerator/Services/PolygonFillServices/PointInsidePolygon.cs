using ImageGenerator.Interfaces;
using ImageGenerator.Model;

namespace ImageGenerator.Services.PolygonFillServices
{
    public class PointInsidePolygon : IRegionFillAlgorithm
    {
        public List<Size> GetPixelsInsideRegions(List<Region> regions, Size size)
        {
            List<Size> result = new();

            Position scale = Position.GetScaleStep(size.X, size.Y);
            Position centerOffset = new(scale.X * 0.5, scale.Y * 0.5);
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    foreach (Region region in regions)
                    {
                        int mappedY = size.Y - j;
                        Position pixelToPoint = new(i * scale.X + centerOffset.X, j * scale.Y + centerOffset.Y);
                        if (region.IsPointInsideRegion(pixelToPoint))
                        {
                            result.Add(new Size(i + 1, mappedY));
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
