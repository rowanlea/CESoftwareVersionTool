﻿using CyberEssentialsGatherTool.FileManagement;
using CyberEssentialsGatherTool.Model;
using CyberEssentialsGatherTool.Parsing;

namespace CyberEssentialsGatherToolTests.AcceptanceTests
{
    internal class ParsingTests
    {
        // NOTE: These tests will fail, the "quick and crude" approach I took didn't intend for the project to be public.
        // I will fix these at some point, but feel free to edit the file paths for your own use if you wish to use the tests.

        [Test]
        public void ParseWindowsFileData()
        {
            // Arrange
            string dataPath = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Windows\\Rowan Lea Test1#Microsoft Windows 10 Pro#10.0.19044.csv";
            FileReader reader = new FileReader();
            var fileData = reader.ReadFileLines(dataPath);

            WindowsParser parser = new WindowsParser();

            // Act
            UserProfile profile = parser.ParseFile(dataPath, fileData);

            // Assert
            profile.Name.Should().Be("Rowan Lea Test1");
            profile.OS.Should().Be("Microsoft Windows 10 Pro");
            profile.OSVersion.Should().Be("10.0.19044");

            profile.Software.Count.Should().Be(504);
            profile.Software[0].Name.Should().Be("Python 3.9.13 pip Bootstrap (64-bit)");
            profile.Software[0].Vendor.Should().Be("Python Software Foundation");
            profile.Software[0].Version.Should().Be("3.9.13150.0");
        }

        [Test]
        public void ParseMacFileData()
        {
            // Arrange
            string dataPath = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Mac\\MacBook Air Test1.spx";
            FileReader reader = new FileReader();
            var fileData = reader.ReadFileText(dataPath);

            MacParser parser = new MacParser();

            // Act
            UserProfile profile = parser.ParseFile(fileData);

            // Assert
            profile.Software.Count.Should().Be(309);
            profile.Software[0].Name.Should().Be("GarageBand");
            profile.Software[0].Version.Should().Be("10.4.8");
        }

        [Test]
        public void ParseMacOSData()
        {
            // Arrange
            string dataPath = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Mac\\MacBook Air Test1.spx";
            FileReader reader = new FileReader();
            var fileData = reader.ReadFileText(dataPath);

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
