using CyberEssentialsGatherTool.Model;
using IronXL;

namespace CyberEssentialsGatherTool.Spreadsheet
{
    public static class OSSpreadsheetWriter
    {
        public static void WriteToSpreadsheet(List<OSInfo> osInfoList, string baseDirectory)
        {
            var file = Path.Combine(baseDirectory, "OS Info.xlsx");
            WorkBook workBook = WorkBook.Load(file);
            WorkSheet workSheet = workBook.DefaultWorkSheet;

            workSheet["A1"].Value = "OS";
            workSheet["B1"].Value = "Version";
            workSheet["C1"].Value = "Count";

            var offset = 2;
            foreach(var osInfo in osInfoList)
            {
                workSheet[$"A{offset}"].Value = osInfo.OSName;

                foreach (var version in osInfo.OSVersions)
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
