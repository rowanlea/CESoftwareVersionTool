namespace CyberEssentialsGatherTool.Model
{
    public class OSInfo
    {
        public string OSName { get; set; }
        public List<VersionCount> OSVersions { get; set; } = new();
    }
}
