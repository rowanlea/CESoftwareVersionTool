using CyberEssentialsGatherTool.Model;
using System.Text.Json;
using System.Xml;

namespace CyberEssentialsGatherTool.Parsing
{
    public class JsonParser
    {
        public UserProfile ParseFile(string fileData)
        {
            ArgumentException.ThrowIfNullOrEmpty(fileData);

            UserProfile profile = JsonSerializer.Deserialize<UserProfile>(fileData);

            if (string.IsNullOrEmpty(profile.Name) ||
                string.IsNullOrEmpty(profile.OS) ||
                string.IsNullOrEmpty(profile.OSVersion) ||
                profile.Software.Count == 0)
            {
                throw new FileLoadException("File failed to load.");
            }

            RemoveEmptySoftwareVersions(profile);

            return profile;
        }

        private void RemoveEmptySoftwareVersions(UserProfile profile)
        {
            profile.Software = profile.Software.Where(x => !string.IsNullOrEmpty(x.Version)).ToList();
        }
    }
}
