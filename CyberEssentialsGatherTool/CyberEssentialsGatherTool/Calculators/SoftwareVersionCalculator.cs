using CyberEssentialsGatherTool.Model;

namespace CyberEssentialsGatherTool.Calculators
{
    public static class SoftwareVersionCalculator
    {
        public static List<CombinedSoftwareVersions> CalculateSoftware(List<UserProfile> users)
        {
            List<CombinedSoftwareVersions> combinedSoftwareVersions = new();

            foreach (var user in users)
            {
                foreach (var software in user.Software)
                {
                    var foundSoftware = combinedSoftwareVersions.Where(s => s.SoftwareName == software.Name);
                    if (foundSoftware.Any())
                    {
                        AddVersion(software, foundSoftware);
                    }
                    else
                    {
                        AddNewSoftware(combinedSoftwareVersions, software);
                    }
                }
            }

            return combinedSoftwareVersions;
        }

        private static void AddVersion(SoftwareInfo software, IEnumerable<CombinedSoftwareVersions> foundSoftware)
        {
            var foundVersion = foundSoftware.FirstOrDefault().Versions
                                        .Where(v => v.Version == software.Version);

            if (foundVersion.Any())
            {
                foundVersion.FirstOrDefault().Count++;
            }
            else
            {
                foundSoftware.FirstOrDefault().Versions.Add(new VersionCount { Version = software.Version, Count = 1 });
            }
        }

        private static void AddNewSoftware(List<CombinedSoftwareVersions> combinedSoftwareVersions, SoftwareInfo software)
        {
            var newSoftware = new CombinedSoftwareVersions { SoftwareName = software.Name };
            newSoftware.Versions.Add(new VersionCount { Version = software.Version, Count = 1 });
            combinedSoftwareVersions.Add(newSoftware);
        }
    }
}
