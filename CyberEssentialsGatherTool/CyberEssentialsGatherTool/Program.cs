using CyberEssentialsGatherTool.Calculators;
using CyberEssentialsGatherTool.FileManagement;
using CyberEssentialsGatherTool.Model;
using CyberEssentialsGatherTool.Parsing;
using CyberEssentialsGatherTool.Spreadsheet;
using System.Text.Json;

namespace CyberEssentialsGatherTool
{
    internal class Program
    {
       static void Main(string[] args)
        {
            string baseDirectory = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Real\\";
            //TestGather(baseDirectory);
            //ParseFileToJson();
            //CheckCurrentEmyployees(baseDirectory);
            UseGather(baseDirectory);
        }

        private static void CheckCurrentEmyployees(string baseDirectory)
        {
            FileReader reader = new FileReader();
            var employees = reader.ReadFileLines($"{baseDirectory}\\EmployeeList.txt").ToList();

            employees.Sort();

            foreach (var name in employees)
            {
                Console.WriteLine(name);
            }
        }

        private static void TestGather(string baseDirectory)
        {
            List<UserProfile> users = GetUserData(baseDirectory);

            List<string> names = users.Select(x => x.Name).ToList();

            names.Sort();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private static List<UserProfile> GetUserData(string baseDirectory)
        {
            List<UserProfile> users = new List<UserProfile>();

            Gather gather = new(users);
            gather.AppendWindowsFiles(baseDirectory + "Windows");
            gather.AppendMacFiles(baseDirectory + "Mac");
            gather.AppendJsonFiles(baseDirectory + "Json");

            gather.VerifyProfiles(true, false);
            return users;
        }

        private static void UseGather(string baseDirectory)
        {
            List<UserProfile> users = GetUserData(baseDirectory);

            List<CombinedSoftwareVersions> combinedSoftwareVersions = SoftwareVersionCalculator.CalculateSoftware(users);

            List<OSInfo> osVersions = OSVersionCalculator.CalculateOSVersion(users);

            SoftwareSpreadsheetWriter.WriteToSpreadsheet(combinedSoftwareVersions, baseDirectory);
            //OSSpreadsheetWriter.WriteToSpreadsheet(osVersions, baseDirectory);
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