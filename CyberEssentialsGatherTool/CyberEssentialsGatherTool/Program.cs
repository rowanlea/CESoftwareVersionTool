using CyberEssentialsGatherTool.FileManagement;
using CyberEssentialsGatherTool.Model;
using CyberEssentialsGatherTool.Parsing;
using System.Text.Json;

namespace CyberEssentialsGatherTool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParseFileToJson();
            //UseGather();
        }

        private static void UseGather()
        {
            string baseDirectory = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Real\\";

            List<UserProfile> users = new List<UserProfile>();

            Gather gather = new(users);
            gather.AppendWindowsFiles(baseDirectory + "Windows");
            gather.AppendMacFiles(baseDirectory + "Mac");
            gather.AppendJsonFiles(baseDirectory + "Json");

            gather.VerifyProfiles(true, false);
        }

        private static void ParseFileToJson()
        {
            Console.WriteLine("Please enter the name of the file you wish to parse (including file extension):");
            string fileName = Console.ReadLine();

            UserProfile profile;
            FileReader reader = new FileReader();

            if (fileName.EndsWith(".csv")) // Windows
            {
                var fileData = reader.ReadFileLines(fileName);

                WindowsParser parser = new WindowsParser();
                profile = parser.ParseFile(fileName, fileData);

                string profileJson = JsonSerializer.Serialize(profile);
                string newFileName = $"{profile.Name}.json";
                File.WriteAllText(newFileName, profileJson);
            }
            else // Mac
            {
                var fileData = reader.ReadFileText($"Desktop/{fileName}");

                MacParser parser = new MacParser();
                profile = parser.ParseFile(fileData);

                string profileJson = JsonSerializer.Serialize(profile);
                string newFileName = $"Desktop/{profile.Name}.json";
                File.WriteAllText(newFileName, profileJson);
            }
        }
    }
}