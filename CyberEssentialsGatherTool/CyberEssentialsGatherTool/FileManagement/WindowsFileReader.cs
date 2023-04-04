namespace CyberEssentialsGatherTool.FileManagement
{
    public class WindowsFileReader : FileReader
    {
        public string[] ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
