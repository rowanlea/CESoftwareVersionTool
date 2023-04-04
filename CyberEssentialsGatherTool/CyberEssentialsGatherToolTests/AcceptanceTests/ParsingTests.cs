using CyberEssentialsGatherTool;
using CyberEssentialsGatherTool.FileManagement;
using CyberEssentialsGatherTool.Parsing;

namespace CyberEssentialsGatherToolTests.AcceptanceTests
{
    internal class ParsingTests
    {
        [Test]
        public void ParseWindowsFileData()
        {
            // Arrange
            string dataPath = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Windows\\Rowan Lea Test1#Microsoft Windows 10 Pro#10.0.19044.csv";
            WindowsFileReader reader = new WindowsFileReader();
            var fileData = reader.ReadFile(dataPath);

            WindowsParser parser = new WindowsParser();

            // Act
            UserProfile profile = parser.ParseFile(dataPath, fileData);

            // Assert
            profile.Name.Should().Be("Rowan Lea Test1");
            profile.OS.Should().Be("Microsoft Windows 10 Pro");
            profile.OSVersion.Should().Be("10.0.19044");

            profile.Software.Count.Should().Be(505);
            profile.Software[0].Name.Should().Be("Python 3.9.13 pip Bootstrap (64-bit)");
            profile.Software[0].Vendor.Should().Be("Python Software Foundation");
            profile.Software[0].Version.Should().Be("3.9.13150.0");
        }

        [Test]
        public void ParseMacFileData()
        {
            // Arrange
            string dataPath = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Mac\\MacBook Air Test1.spx";
            MacFileReader reader = new MacFileReader();
            var fileData = reader.ReadFile(dataPath);

            MacParser parser = new MacParser();

            // Act
            UserProfile profile = parser.ParseFile(fileData);

            // Assert
            profile.Software.Count.Should().Be(318);
            profile.Software[0].Name.Should().Be("GarageBand");
            profile.Software[0].Version.Should().Be("10.4.8");
        }

        [Test]
        public void ParseMacOSData()
        {
            // Arrange
            string dataPath = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Mac\\MacBook Air Test1.spx";
            MacFileReader reader = new MacFileReader();
            var fileData = reader.ReadFile(dataPath);

            MacParser parser = new MacParser();

            // Act
            UserProfile profile = parser.ParseFile(fileData);

            // Assert
            profile.Name.Should().Be("Rowan Lea (rowan)");
            profile.OS.Should().Be("macOS");
            profile.OSVersion.Should().Be("12.3 (21E230)");
        }
    }
}
