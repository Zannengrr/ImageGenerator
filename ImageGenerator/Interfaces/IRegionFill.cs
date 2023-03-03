using ImageGenerator.Model;
using System.Drawing;
using Region = ImageGenerator.Model.Region;
using Size = ImageGenerator.Model.Size;

namespace ImageGenerator.Interfaces
{
    public interface IRegionFillAlgorithm
    {
        public List<Point> GetPixelsInsideRegions(List<Region> regions, Size size);
    }
}