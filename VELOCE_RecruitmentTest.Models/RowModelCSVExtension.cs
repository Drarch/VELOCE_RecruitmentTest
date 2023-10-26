using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VELOCE_RecruitmentTest.Models
{
    public static  class RowModelCSVExtension
    {
        /// <summary>Encrypts given RowModel object to CSV line.</summary>
        /// <param name="inRow">Given RowModel object</param>
        /// <returns>Encrypted RowModel object CSV line.</returns>
        public static string encryptCSV(this RowModel inRow)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0:d},{1},{2},{3},{4:d}", inRow.RowID, inRow.FirstName, inRow.LastName, inRow.BirthDate.Value.ToShortDateString(), (int)inRow.Sex);

            return sb.ToString();
        }

        /// <summary>Decrypts given RowModel from CSV line string.</summary>
        /// <param name="inCSVLine">String line inCSV format</param>
        /// <param name="delimiter">Delimiter of CSV format.</param>
        /// <returns>New RowModel object with CSV data.</returns>
        public static RowModel decryptCSVRowModel(this string inCSVLine, char delimiter = ',')
        {
            string[] fields = inCSVLine.Split(delimiter);
            if (fields.Length < 5)
            {
                return null;
            }

            RowModel result = new RowModel()
            {
                RowID = Convert.ToInt32(fields[0]),
                FirstName = fields[1],
                LastName = fields[2],
                BirthDate = Convert.ToDateTime(fields[3]),
                Sex = (Models.Enums.ESex)Enum.ToObject(typeof(Models.Enums.ESex), Convert.ToInt32(fields[4]))
            };
            
            return result;
        }
    }
}
