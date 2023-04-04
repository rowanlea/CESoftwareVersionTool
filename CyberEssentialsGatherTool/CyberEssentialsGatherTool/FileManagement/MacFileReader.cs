namespace CyberEssentialsGatherTool.FileManagement
{
    public class MacFileReader : FileReader
    {
        public string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
