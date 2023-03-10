# ImageGenerator

The assignment was done in C# language with .NET 7 framework

You can start the program in any of 3 ways:  
1. If opening the project from the zip file: Going to **{projectFolder}/ImageGenerator/bin/Release/net7.0/** or **{projectFolder}/ImageGenerator/bin/Debug/net7.0/** and run **ImageGenerator.exe**  
2. Opening **ImageGenerator.sln** in Visual Studio and running either a Debug or Publish build  
3. Opening ImageGenerator folder in Visual Studio Code and running **".NET Core Launch (console)"** option from Run and Debug window  

The input file is in json format as this example:

```json
{
    "regions": [
        {
            "positions": [
                {
                    "x": 0.25,
                    "y": 0.0
                },
                {
                    "x": 0.5,
                    "y": 0.5
                },
                {
                    "x": 0.75,
                    "y": 0.0
                }
            ]
        },
        {
            "positions": [
                {
                    "x": 0.5,
                    "y": 0.5
                },
                {
                    "x": 0.5,
                    "y": 1.0
                },
                {
                    "x": 1.0,
                    "y": 1.0
                },
                {
                    "x": 1.0,
                    "y": 0.5
                }
            ]
        }
    ],
    "size": {
        "x": 4,
        "y": 4
    }
}
```

Taken from the information of the assignment.

You can change the input and output path and file names by changing any of the parameters inside the "Modify for paths and filenames block".  
By default the project autogenerates a Data folder inside of the published folder and copies the files "Input.txt" and "Input-Example.txt" to it and uses the "Input.txt" file as input to generate an image from the data inside it.  
You can also modify the type of algorithm to use by changing which instance you want to create. By default the algorithm to use is set to ScanLineActiveEdges.cs  

The project is ran from the Program.cs    
The project is structured into 3 folders:
- Data
- Interfaces
- Model
- Services

Data has Input.txt and Input-Example.txt files that are copied into the published/debug folders and Input.txt file is used as the input file.  
Interfaces have defined interfaces that are used in the program like IRegionFill.  
Model has files that are data models used in the project.  
Services has all the implementations of algorithms for finding points inside an area and ImageCreator.cs file that has a method that generates an image based of the input data and algorithm passed in to the constructor.  
ImageCreator accepts ImageData and IRegionFillAlygorithm as arguments during instantiation. By calling CreateImage we generate the image to the output folder.  
