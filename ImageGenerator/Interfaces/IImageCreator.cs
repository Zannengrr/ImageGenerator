using System.Drawing.Imaging;

namespace ImageGenerator.Interfaces
{
    public interface IImageCreator
    {
        public void CreateImage(ImageFormat outputFormat, string outputPath);
    }
}
