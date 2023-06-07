using System.Text.Json.Serialization;

namespace CyberEssentialsGatherTool.Model
{
    public class SoftwareInfo
    {
        public string Name { get; set; }
        [JsonIgnore]
        public string Vendor { get; set; }
        public string Version { get; set; }
    }
}