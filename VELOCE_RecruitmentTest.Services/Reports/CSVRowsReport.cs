using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VELOCE_RecruitmentTest.Models;
using VELOCE_RecruitmentTest.Models.Enums;

namespace VELOCE_RecruitmentTest.Services.Reports
{
    public class CSVRowsReport : IRowsReport
    {
        private const string fileExtension = ".csv";
        private readonly string folderPath = "Report\\";

        public CSVRowsReport(string inFolderPath = "Reports\\")
        { 
            folderPath = inFolderPath;
        }

        public string GenerateReport(IEnumerable<RowModel> inRows)
        {
            string filename = DateTime.Now.ToString("yyMMdd_hhmmss") + fileExtension;
            string filePath = folderPath + filename;

            string tempFile = Path.GetTempFileName();

            string reportContent = EncryptReport(inRows);
            File.WriteAllText(tempFile, reportContent);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.Move(tempFile, filePath);

            return Path.GetFullPath(filePath);
        }

        public string GetHeader()
        {
            return "First Name,Last Name,Bith Date,Sex,Title,Age";
        }

        public string EncryptReport(IEnumerable<RowModel> inRows)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(GetHeader());

            foreach(RowModel row in inRows)
            {
                sb.AppendLine(EncryptRow(row));
            }

            return sb.ToString();
        }

        public string EncryptRow(RowModel inRow)
        {
            StringBuilder sb = new StringBuilder();

            string title = String.Empty;
            RowModelSexDictionary.Map.TryGetValue(inRow.Sex, out title);
            int age = 0;
            if (inRow.BirthDate.HasValue)
            {
                DateTime date = inRow.BirthDate.Value;
                age = DateTime.Now.Year - date.Year - 1;
                age += 1 * Convert.ToInt32(DateTime.Now.Month >= date.Month && DateTime.Now.Day >= date.Day);
            }

            sb.AppendFormat("{0:d},{1},{2},{3},{4:d},{5},{6:d}",
                inRow.RowID,
                inRow.FirstName,
                inRow.LastName,
                inRow.BirthDate.Value.ToShortDateString(),
                (int)inRow.Sex,
                title,
                age);

            return sb.ToString();
        }
    }
}
