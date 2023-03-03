using ImageGenerator.Model;

namespace ImageGenerator.Interfaces
{
    public interface IRegionFillAlgorithm
    {
        public List<Size> GetPixelsInsideRegions(List<Region> regions, Size size);
    }
}