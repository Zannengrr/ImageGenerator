namespace ImageGenerator.Model
{
    public class Image
    {
        public Size Size { get; set; }
        public List<Region> Regions { get; set; } = new List<Region>();

        public Image(Size size, List<Region> regions)
        {
            Size = new(size);
            foreach (Region region in regions)
            {
                Regions.Add(new Region(region));
            }
        }
    }

    public static class ImageExtension
    {
        public static Position CalculateCenterOffset(this Image image)
        {
            return new Position(1 / ((double)image.Size.X * 2), 1 / ((double)image.Size.Y * 2));
        }
    }
}
