namespace CyberEssentialsGatherTool.Model
{
    public class CombinedSoftwareVersions
    {
        public string SoftwareName { get; set; }

        public List<VersionCount> Versions { get; set; } = new();
    }
}
