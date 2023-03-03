namespace ImageGenerator.Model
{
    public class ImageData
    {
        public Size Size { get; set; }
        public List<Region> Regions { get; set; } = new List<Region>();

        public ImageData(Size size, List<Region> regions)
        {
            Size = new(size);
            foreach (Region region in regions)
            {
                Regions.Add(new Region(region));
            }
        }
    }
}
