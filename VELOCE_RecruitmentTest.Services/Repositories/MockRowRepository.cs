using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VELOCE_RecruitmentTest.Models;
using VELOCE_RecruitmentTest.Models.Enums;

namespace VELOCE_RecruitmentTest.Services.Repositories
{
    public class MockRowRepository : IRowRepository
    {
        private List<RowModel> data { get; set; }

        public MockRowRepository()
        {
            Type.GetType("RowData");
            data = new List<RowModel>()
            {
                new RowModel() {RowID = 1, FirstName = "Test", LastName = "Name", BirthDate = new DateTime(2000, 10, 12), Sex = ESex.Male},
                new RowModel() {RowID = 2, FirstName = "John", LastName = "Smith", BirthDate = new DateTime(1982, 1, 30), Sex = ESex.Unknown},
                new RowModel() {RowID = 3, FirstName = "Test", LastName = "Name", BirthDate = new DateTime(2000, 10, 12), Sex = ESex.Female},
            };
        }

        public IEnumerable<RowModel> GetAllRows()
        {
            return data;
        }

        public int GetMaxId()
        {
            return data.Max(x => x.RowID);
        }

        public RowModel GetRowById(int inRowID)
        {
            return data.FirstOrDefault(x => x.RowID == inRowID);
        }

        public bool DeleteRowById(int inRowID)
        {
            int index = data.FindIndex(x => x.RowID == inRowID);

            if (index < 0)
            {
                return false;
            }

            data.RemoveAt(index);

            return true;
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
            }

            return updateRow;
        }

        public RowModel AddRow(RowModel inRow)
        {
            int newId = GetMaxId() + 1;
            inRow.RowID = newId;
            data.Add(inRow);

            return inRow;
        }
    }
}
