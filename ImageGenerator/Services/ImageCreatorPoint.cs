using System.Drawing;
using System.Drawing.Imaging;
using ImageGenerator.Interfaces;
using ImageData = ImageGenerator.Model.ImageData;

namespace ImageGenerator.Services
{
    public class ImageCreatorPoint: IImageCreator
    {
        private ImageData image { get; set; }

        private IRegionFillAlgorithm regionFillAlgorithm { get; set; }

        public ImageCreatorPoint(ImageData imageData, IRegionFillAlgorithm algorithm)
        {
            image = new ImageData(imageData.Size, imageData.Regions);
            regionFillAlgorithm = algorithm;
        }

        public void CreateImage(ImageFormat outputFormat, string outputPath)
        {
            Bitmap pixelImage = new(image.Size.X, image.Size.Y);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<Point> polygonsTofill = regionFillAlgorithm.GetPixelsInsideRegions(image.Regions, image.Size);

            watch.Stop();
            Console.WriteLine($"Time for algorithm to finish in miliseconds: {watch.ElapsedMilliseconds}");

            foreach (Point pixel in polygonsTofill)
            {
                pixelImage.SetPixel(pixel.X, pixel.Y, Color.White);
            }

            pixelImage.Save(outputPath, outputFormat);
        }
    }
}
