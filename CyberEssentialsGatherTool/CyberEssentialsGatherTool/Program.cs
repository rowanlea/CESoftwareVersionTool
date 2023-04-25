using CyberEssentialsGatherTool.FileManagement;
using CyberEssentialsGatherTool.Parsing;
using System.Text.Json;

namespace CyberEssentialsGatherTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the name of the file you wish to parse (including file extension):");
            string fileName = Console.ReadLine();

            UserProfile profile;

            if (fileName.EndsWith(".csv")) // Windows
            {
                WindowsFileReader reader = new WindowsFileReader();
                var fileData = reader.ReadFile(fileName);

                WindowsParser parser = new WindowsParser();
                profile = parser.ParseFile(fileName, fileData);
            }
            else // Mac
            {
                MacFileReader reader = new MacFileReader();
                var fileData = reader.ReadFile(fileName);

                MacParser parser = new MacParser();
                profile = parser.ParseFile(fileData);
            }

            string profileJson = JsonSerializer.Serialize(profile);
            string newFileName = $"{profile.Name}.json";
            File.WriteAllText(newFileName, profileJson);
        }
    }
}