// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using ImageGenerator.Services;
using System.Drawing.Imaging;
using ImageGenerator.Model;

//Modify for paths and filenames
string dataDirectoryname = "Data";
string inputFileName = "Input.txt";
string outputFileName = "Output.jpeg";
string currentDataDir = $"{Environment.CurrentDirectory}/{dataDirectoryname}";
ImageFormat format = ImageFormat.Jpeg;
//

Directory.CreateDirectory($"{currentDataDir}");
string inputFilePath = $"{currentDataDir}/{inputFileName}";
string outputFilePath = $"{currentDataDir}/{outputFileName}";

if (!File.Exists(inputFilePath))
{
    Console.WriteLine($"Input.txt file is missing, please add the file to {currentDataDir} folder and run the program again");
}
else
{
    string file = File.ReadAllText(inputFilePath);
    Image? imageData = JsonConvert.DeserializeObject<Image>(file);
    if(imageData is not null) new ImageCreator().CreateImage(imageData, format, outputFilePath);
    Console.WriteLine($"Image has been generated in {outputFilePath}");
}