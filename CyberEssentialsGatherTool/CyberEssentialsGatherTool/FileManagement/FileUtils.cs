namespace CyberEssentialsGatherTool.FileManagement
{
    public static class FileUtils
    {
        public static string GetFileNameFromFullPath(string path)
        {
            string fileName = path.Substring(path.LastIndexOf('\\') + 1);
            return fileName;
        }
    }
}
