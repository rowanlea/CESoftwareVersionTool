using CyberEssentialsGatherTool.Model;
using IronXL;

namespace CyberEssentialsGatherTool.Spreadsheet
{
    public static class SoftwareSpreadsheetWriter
    {
        public static void WriteToSpreadsheet(List<CombinedSoftwareVersions> softwareInfoList, string baseDirectory)
        {
            var file = Path.Combine(baseDirectory, "Software Info.xlsx");
            WorkBook workBook = WorkBook.Load(file);
            WorkSheet workSheet = workBook.DefaultWorkSheet;

            workSheet["A1"].Value = "Software Name";
            workSheet["B1"].Value = "Version";
            workSheet["C1"].Value = "Count";

            var offset = 2;
            foreach (var softwareInfo in softwareInfoList)
            {
                workSheet[$"A{offset}"].Value = softwareInfo.SoftwareName;

                foreach (var version in softwareInfo.Versions)
                {
                    workSheet[$"B{offset}"].StringValue = version.Version;
                    workSheet[$"C{offset}"].Value = version.Count;
                    offset++;
                }
            }

            workBook.Save();
        }
    }
}
