using System.Drawing;
using System.Drawing.Imaging;
using ImageGenerator.Model;
using Region = ImageGenerator.Model.Region;
using Size = ImageGenerator.Model.Size;

namespace ImageGenerator.Services
{
    public class ImageCreator
    {
        public Size Size { get; set; }
        public List<Region> Regions { get; set; } = new List<Region>();

        public ImageCreator(Size size, List<Region> regions)
        {
            Size = new(size);
            foreach (Region region in regions)
            {
                Regions.Add(new Region(region));
            }
        }

        //add a library that works on all platforms
        public void CreateImage(ImageFormat outputFormat)
        {
            Position centerOffset = new Position((1 / ((double)Size.X * 2)), (1 / ((double)Size.Y * 2))); //method to calculate center offset
            Bitmap image = new(Size.X, Size.Y);
            int yCoordinateSystemConversion = image.Height - 1; //make a method to convert to a specific coordinate system
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    foreach (Region region in Regions)
                    {
                        if (region.IsPointInsideRegion(new Position(i / (double)Size.X + centerOffset.X, (j / (double)Size.Y) + centerOffset.Y)))
                        {
                            image.SetPixel(i, yCoordinateSystemConversion - j, Color.White);
                            break;
                        }

                        image.SetPixel(i, yCoordinateSystemConversion - j, Color.Black);
                    }
                }
            }
            image.Save($"{Environment.CurrentDirectory}/Data/Output.jpeg", outputFormat);
        }

        //needs validation for data
    }
}
