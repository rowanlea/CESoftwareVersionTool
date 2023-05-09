using CyberEssentialsGatherTool.FileManagement;

namespace CyberEssentialsGatherToolTests.AcceptanceTests
{
    public class GetFileDataTests
    {
        [Test]
        public void GetWindowsFilesInPath()
        {
            // Arrange
            string containingFolder = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Windows";
            string firstExpectedPath = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Windows\\Rowan Lea Test1#Microsoft Windows 10 Pro#10.0.19044.csv";
            string secondExpectedPath = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Windows\\Rowan Lea Test2#Microsoft Windows 10 Pro#10.0.19044.csv";

            FileReader reader = new FileReader();

            // Act
            var files = reader.GetAllFilesInFolder(containingFolder);

            // Assert
            files.Count.Should().Be(2);
            files.Should().Contain(firstExpectedPath);
            files.Should().Contain(secondExpectedPath);
        }

        [Test]
        public void GetWindowsFileData()
        {
            // Arrange
            string containingFolder = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Windows\\Rowan Lea Test1#Microsoft Windows 10 Pro#10.0.19044.csv";
            FileReader reader = new FileReader();

            // Act
            var fileData = reader.ReadFileLines(containingFolder);

            // Assert
            fileData.Count().Should().Be(506);
            fileData[0].Should().Be(@"""Name"",""Version"",""Vendor""");
            fileData[1].Should().Be(@"""Python 3.9.13 pip Bootstrap (64-bit)"",""3.9.13150.0"",""Python Software Foundation""");
        }

        [Test]
        public void GetMacFilesInPath()
        {
            // Arrange
            string containingFolder = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Mac";
            string firstExpectedPath = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Mac\\MacBook Air Test1.spx";
            string secondExpectedPath = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Mac\\MacBook Air Test2.spx";

            FileReader reader = new FileReader();

            // Act
            var files = reader.GetAllFilesInFolder(containingFolder);

            // Assert
            files.Count.Should().Be(2);
            files.Should().Contain(firstExpectedPath);
            files.Should().Contain(secondExpectedPath);
        }

        [Test]
        public void GetMacFileData()
        {
            // Arrange
            string containingFolder = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Mac\\MacBook Air Test1.spx";
            FileReader reader = new FileReader();

            // Act
            var fileData = reader.ReadFileText(containingFolder);

            // Assert
            fileData.Should().NotBeNull();
            fileData.Length.Should().BeGreaterThan(100);
        }
    }
}