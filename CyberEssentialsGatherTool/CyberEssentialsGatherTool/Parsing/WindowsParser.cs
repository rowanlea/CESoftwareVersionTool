namespace CyberEssentialsGatherTool.Parsing
{
    public class WindowsParser
    {
        public UserProfile ParseFile(string filename, string[] fileData)
        {
            UserProfile profile = new UserProfile();
            ParseUserAndOSData(profile, filename);

            for (int i = 1; i < fileData.Length; i++)
            {
                fileData[i] = fileData[i].Replace("\"", "");
                var dataParts = fileData[i].Split(',');
                profile.Software.Add(new SoftwareInfo
                {
                    Name = dataParts[0],
                    Version = dataParts[1],
                    Vendor = dataParts[2]
                });
            }

            return profile;
        }

        private void ParseUserAndOSData(UserProfile profile, string data)
        {
            var splitData = data.Split('#');
            profile.Name = splitData[0].Split(@"\").Last();
            profile.OS = splitData[1];
            profile.OSVersion = splitData[2].Remove(splitData[2].Length - 4);
        }
    }
}
