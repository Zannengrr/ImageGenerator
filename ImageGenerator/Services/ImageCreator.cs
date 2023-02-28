using System.Drawing;
using System.Drawing.Imaging;
using ImageGenerator.Model;
using Image = ImageGenerator.Model.Image;
using Region = ImageGenerator.Model.Region;
using Size = ImageGenerator.Model.Size;

namespace ImageGenerator.Services
{
    public class ImageCreator
    {
        //add a library that works on all platforms
        public void CreateImage(Image imageData, ImageFormat outputFormat, string outputPath)
        {
            Position centerOffset = imageData.CalculateCenterOffset(); //move to Size class or make extension?
            Position scale = new Position(1 / (double)imageData.Size.X, 1 / (double)imageData.Size.Y);
            Bitmap image = new(imageData.Size.X, imageData.Size.Y); //see for a library that works on any platform
            for (int i = 0; i < image.Width; i++)
            {
                for (int j = 0; j < image.Height; j++)
                {
                    foreach (Region region in imageData.Regions) //see if we should make an interesection of areas?
                    {
                        int mappedY = image.Height - 1 - j;
                        Position pixelToPoint = new Position(i * scale.X + centerOffset.X, j * scale.Y + centerOffset.Y);
                        if (region.IsPointInsideRegion(pixelToPoint))
                        {
                            image.SetPixel(i, mappedY, Color.White);
                            break;
                        }
                    }
                }
            }
            image.Save(outputPath, outputFormat);
        }

        //needs validation for data
    }
}
