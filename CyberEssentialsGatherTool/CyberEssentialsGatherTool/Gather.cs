using CyberEssentialsGatherTool.FileManagement;
using CyberEssentialsGatherTool.Model;
using CyberEssentialsGatherTool.Parsing;

namespace CyberEssentialsGatherTool
{
    internal class Gather
    {
        private List<UserProfile> _profiles;

        // File Reading
        FileReader _fileReader;

        // File Parsing
        WindowsParser _windowsParser;
        MacParser _macParser;
        JsonParser _jsonParser;

        public Gather(List<UserProfile> profiles)
        {
            _profiles = profiles;
            _fileReader = new();
            _windowsParser = new();
            _macParser = new();
            _jsonParser = new();
        }

        public void AppendWindowsFiles(string directory)
        {
            var fileNames = _fileReader.GetAllFilesInFolder(directory);

            foreach (var file in fileNames)
            {
                string[] rawFileData = _fileReader.ReadFileLines(file);
                string fileName = FileUtils.GetFileNameFromFullPath(file);

                UserProfile profile = _windowsParser.ParseFile(fileName, rawFileData);

                _profiles.Add(profile);
            }
        }

        public void AppendMacFiles(string directory)
        {
            var fileNames = _fileReader.GetAllFilesInFolder(directory);

            foreach (var file in fileNames)
            {
                string rawFileData = _fileReader.ReadFileText(file);
                UserProfile profile = _macParser.ParseFile(rawFileData);
                _profiles.Add(profile);
            }
        }

        public void AppendJsonFiles(string directory)
        {
            var fileNames = _fileReader.GetAllFilesInFolder(directory);

            foreach (var file in fileNames)
            {
                string rawFileData = _fileReader.ReadFileText(file);
                UserProfile profile = _jsonParser.ParseFile(rawFileData);
                
                _profiles.Add(profile);
            }
        }

        public void VerifyProfiles(bool software = true, bool softwareCount = true)
        {
            foreach (var profile in _profiles)
            {
                // User
                if (string.IsNullOrEmpty(profile.Name))
                {
                    Console.WriteLine("Error missing name!");
                    continue;
                }
                if (string.IsNullOrEmpty(profile.OS))
                {
                    Console.WriteLine($"Error missing OS for: {profile.Name}");
                }
                if (string.IsNullOrEmpty(profile.OSVersion))
                {
                    Console.WriteLine($"Error missing OS Version for: {profile.Name}");
                }

                if (software)
                {

                    if (softwareCount)
                    {
                        // Software
                        if (profile.Software.Count == 0)
                        {
                            Console.WriteLine($"Error missing software for: {profile.Name}, using {profile.OS}");
                        }
                        else if (profile.Software.Count <= 50)
                        {
                            Console.WriteLine($"Error low software count ({profile.Software.Count}): {profile.Name}, using {profile.OS}");
                        }
                    }

                    foreach (var entry in profile.Software)
                    {
                        if (string.IsNullOrEmpty(entry.Name))
                        {
                            Console.WriteLine($"Missing software name for user: {profile.Name}, using {profile.OS}");
                        }

                        if (string.IsNullOrEmpty(entry.Version))
                        {
                            Console.WriteLine($"Missing software version for user: {profile.Name}, using {profile.OS}, for: {entry.Name}");
                        }
                    }
                }
            }
        }
    }
}
