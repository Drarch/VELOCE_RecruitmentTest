using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VELOCE_RecruitmentTest.Models;

namespace VELOCE_RecruitmentTest.Services.Reports
{
    public interface IRowsReport
    {
        /// <summary>Returns filepath to report of passed rows.</summary>
        /// <param name="inRows">Rows included in report.</param>
        /// <returns>Full path to generated report</returns>
        string GenerateReport(IEnumerable<RowModel> inRows);
    }
}
