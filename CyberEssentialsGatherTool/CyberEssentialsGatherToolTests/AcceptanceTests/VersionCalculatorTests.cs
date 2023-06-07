using CyberEssentialsGatherTool;
using CyberEssentialsGatherTool.FileManagement;
using CyberEssentialsGatherTool.Model;

namespace CyberEssentialsGatherToolTests.AcceptanceTests
{
    public class VersionCalculatorTests
    {
        private string _baseDirectory = "C:\\Users\\Rowan\\CyberEssentialsFiles\\Real\\";

        [Test]
        public void CalculateSoftware_ReturnsCorrectAmount()
        {
            // Arrange
            List<UserProfile> users = new List<UserProfile>();

            Gather gather = new(users);
            gather.AppendWindowsFiles(_baseDirectory + "Windows");
            gather.AppendMacFiles(_baseDirectory + "Mac");
            gather.AppendJsonFiles(_baseDirectory + "Json");

            var expectedSoftwareCount = 0;
            foreach (UserProfile user in users) 
            {
                expectedSoftwareCount += user.Software.Count;
            }

            // Act
            List<CombinedSoftwareVersions> combinedSoftwareVersions = SoftwareVersionCalculator.CalculateSoftware(users);
            
            var foundCount = 0;
            foreach (var software in combinedSoftwareVersions)
            {
                foreach(var version in software.Versions)
                {
                    foundCount += version.Count;
                }
            }

            // Assert
            foundCount.Should().Be(expectedSoftwareCount);
        }

        [Test]
        public void CalculateOS_ReturnsCorrectAmount()
        {
            // Arrange
            List<UserProfile> users = new List<UserProfile>();

            Gather gather = new(users);
            gather.AppendWindowsFiles(_baseDirectory + "Windows");
            gather.AppendMacFiles(_baseDirectory + "Mac");
            gather.AppendJsonFiles(_baseDirectory + "Json");

            var expectedVersionCount = users.Count;

            // Act
            List<OSInfo> osInfo = OSVersionCalculator.CalculateOSVersion(users);

            var foundVersions = 0;

            foreach (var os in osInfo)
            {
                foreach(var version in os.OSVersions)
                {
                    foundVersions += version.Count;
                }
            }

            // Assert
            foundVersions.Should().Be(expectedVersionCount);
        }
    }
}