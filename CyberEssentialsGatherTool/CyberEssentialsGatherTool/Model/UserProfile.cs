namespace CyberEssentialsGatherTool.Model
{
    public class UserProfile
    {
        public string Name { get; set; }
        public string OS { get; set; }
        public string OSVersion { get; set; }
        public List<SoftwareInfo> Software { get; set; } = new List<SoftwareInfo>();
    }
}
