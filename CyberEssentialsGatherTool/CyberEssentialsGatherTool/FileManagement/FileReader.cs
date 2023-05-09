namespace CyberEssentialsGatherTool.FileManagement
{
    public class FileReader
    {
        public List<string> GetAllFilesInFolder(string folderPath)
        {
            return Directory.GetFiles(folderPath).ToList();
        }

        public string ReadFileText(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public string[] ReadFileLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }
    }
}
