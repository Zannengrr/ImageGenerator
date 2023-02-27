// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using ImageGenerator.Services;
using System.Drawing.Imaging;

string inputFilePath = $"{Environment.CurrentDirectory}/Data/Input.txt";
string file = File.ReadAllText(inputFilePath);

ImageCreator? imageCreator = JsonConvert.DeserializeObject<ImageCreator>(file);

imageCreator?.CreateImage(ImageFormat.Jpeg);