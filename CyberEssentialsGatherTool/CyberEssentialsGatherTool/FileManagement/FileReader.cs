namespace CyberEssentialsGatherTool.FileManagement
{
    public class FileReader
    {
        public List<string> GetAllFilesInFolder(string folderPath)
        {
            return Directory.GetFiles(folderPath).ToList();
        }
    }
}
