using System;
using System.Collections.Generic;
using System.Linq;
using VELOCE_RecruitmentTest.Models;
using System.IO;

namespace VELOCE_RecruitmentTest.Services.Repositories
{
    public class CSVRowRepository : IRowRepository
    {
        private const string filePath = "rows.csv";
        private List<RowModel> data { get; set; }

        public CSVRowRepository()
        {
            data = new List<RowModel>();

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            var dataLines = File.ReadLines(filePath).Where(x => !string.IsNullOrEmpty(x) && char.IsDigit(x[0]));
            foreach (var line in dataLines)
            {
                RowModel row = line.decryptCSVRowModel();
                if (row != null)
                {
                    data.Add(row);
                }
            }
            
        }

        private void AddRowToCSV(RowModel inRow)
        {
            File.AppendAllText(filePath, inRow.encryptCSV() + "\n\r");
        }

        private void RemoveRowFromCSV(int inRowID)
        {
            string tempFile = Path.GetTempFileName();
            IEnumerable<string> linesToKeep = File.ReadLines(filePath).Where(l => !l.StartsWith(inRowID.ToString("d")));

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(filePath);
            File.Move(tempFile, filePath);
        }

        private void UpdateRowInCSV(RowModel inRow)
        {
            RemoveRowFromCSV(inRow.RowID);
            AddRowToCSV(inRow);
        }

        public RowModel AddRow(RowModel inRow)
        {
            int newId = GetMaxId() + 1;
            inRow.RowID = newId;
            data.Add(inRow);
            AddRowToCSV(inRow);

            return inRow;
        }

        public bool DeleteRowById(int inRowID)
        {
            int index = data.FindIndex(x => x.RowID == inRowID);

            if (index < 0)
            {
                return false;
            }

            data.RemoveAt(index);
            RemoveRowFromCSV(inRowID);

            return true;
        }

        public IEnumerable<RowModel> GetAllRows()
        {
            return data;
        }

        public int GetMaxId()
        {
            return data.Count > 0 ? data.Max(x => x.RowID) : 0;
        }

        public RowModel GetRowById(int inRowID)
        {
            return data.FirstOrDefault(x => x.RowID == inRowID);
        }

        public RowModel UpdateRow(RowModel inRow)
        {
            RowModel updateRow = data.FirstOrDefault(x => x.RowID == inRow.RowID);
            if (updateRow == null)
            {
                updateRow = this.AddRow(inRow);
            }
            else
            {
                updateRow.FirstName = inRow.FirstName;
                updateRow.LastName = inRow.LastName;
                updateRow.BirthDate = inRow.BirthDate;
                updateRow.Sex = inRow.Sex;

                UpdateRowInCSV(updateRow);
            }

            return updateRow;
        }
    }
}
