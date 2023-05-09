using CyberEssentialsGatherTool.FileManagement;

namespace CyberEssentialsGatherToolTests.FileManagement
{
    internal class FileUtilsTests
    {
        [Test]
        public void GetFileNameFromFullPath_WhenGivenSingleSlashPath_ReturnsName()
        {
            // Arrange
            string path = @"C:\Users\Rowan\CyberEssentialsFiles\Windows\Rowan Lea Test1#Microsoft Windows 10 Pro#10.0.19044.csv";
            string expectedFileName = "Rowan Lea Test1#Microsoft Windows 10 Pro#10.0.19044.csv";

            // Act
            string foundName = FileUtils.GetFileNameFromFullPath(path);

            // Assert
            foundName.Should().Be(expectedFileName);
        }

        [Test]
        public void GetFileNameFromFullPath_WhenGivenDoubleSlashPath_ReturnsName()
        {
            // Arrange
            string path = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Windows\\Rowan Lea Test1#Microsoft Windows 10 Pro#10.0.19044.csv";
            string expectedFileName = "Rowan Lea Test1#Microsoft Windows 10 Pro#10.0.19044.csv";

            // Act
            string foundName = FileUtils.GetFileNameFromFullPath(path);

            // Assert
            foundName.Should().Be(expectedFileName);
        }
    }
}
