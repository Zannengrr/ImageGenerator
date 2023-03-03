// See https://aka.ms/new-console-template for more information

using ImageGenerator.Interfaces;
using ImageGenerator.Model;
using ImageGenerator.Services;
using Newtonsoft.Json;
using System.Drawing.Imaging;

//Modify for paths and filenames
string dataDirectoryname = "Data";
string inputFileName = "Input.txt";
string outputFileName = "Output.jpeg";
string currentDataDir = $"{Environment.CurrentDirectory}/{dataDirectoryname}";
ImageFormat format = ImageFormat.Jpeg;

//Change instance to any of the following to check performance PointInsidePolygon, ScanLine, ScanLineActiveEdges
IRegionFillAlgorithm polygonFillAlgorithm = new ScanLineActiveEdges();
//

Directory.CreateDirectory($"{currentDataDir}");
string inputFilePath = $"{currentDataDir}/{inputFileName}";
string outputFilePath = $"{currentDataDir}/{outputFileName}";

try
{
    if (!File.Exists(inputFilePath)) throw new Exception($"Input.txt file is missing, please add the file to {currentDataDir} folder and run the program again");

    string file = File.ReadAllText(inputFilePath);
    ImageData? imageData = JsonConvert.DeserializeObject<ImageData>(file);
    if (imageData is not null) new ImageCreatorPoint(imageData, polygonFillAlgorithm).CreateImage(format, outputFilePath);
    Console.WriteLine($"Image has been generated in {outputFilePath}");
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}\nStack:{e.StackTrace}\n\nCheck data and start app again");
}
finally
{
    Console.WriteLine("Press Enter key to exit app");
    Console.Read();
}