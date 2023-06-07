using CyberEssentialsGatherTool.Model;

namespace CyberEssentialsGatherTool.Calculators
{
    public static class OSVersionCalculator
    {
        public static List<OSInfo> CalculateOSVersion(List<UserProfile> users)
        {
            var combinedOSInfo = new List<OSInfo>();

            foreach (UserProfile user in users)
            {
                var foundOS = combinedOSInfo.Where(c => c.OSName == user.OS);
                if (foundOS.Any())
                {
                    AddVersion(user, foundOS);
                }
                else
                {
                    AddNewOS(combinedOSInfo, user);
                }
            }

            return combinedOSInfo;
        }

        private static void AddVersion(UserProfile user, IEnumerable<OSInfo> foundOS)
        {
            var foundVersion = foundOS.FirstOrDefault().OSVersions.Where(v => v.Version == user.OSVersion);
            if (foundVersion.Any())
            {
                foundVersion.FirstOrDefault().Count++;
            }
            else
            {
                foundOS.FirstOrDefault().OSVersions.Add(new VersionCount { Version = user.OSVersion, Count = 1 });
            }
        }

        private static void AddNewOS(List<OSInfo> combinedOSInfo, UserProfile user)
        {
            var newInfo = new OSInfo { OSName = user.OS };
            newInfo.OSVersions.Add(new VersionCount { Version = user.OSVersion, Count = 1 });
            combinedOSInfo.Add(newInfo);
        }
    }
}
