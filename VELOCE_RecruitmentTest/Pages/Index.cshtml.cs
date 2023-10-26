using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting.Internal;
using System.Collections;
using VELOCE_RecruitmentTest.Models;
using VELOCE_RecruitmentTest.Services.Reports;
using VELOCE_RecruitmentTest.Services.Repositories;

namespace VELOCE_RecruitmentTest.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRowRepository RowRepository;
        private readonly IRowsReport RowReport;
        public IEnumerable<RowModel> RowsData { get; set; }

        public IndexModel(IRowRepository inRowRepository)
        {
            this.RowRepository = inRowRepository;
            this.RowReport = new CSVRowsReport();
        }

        public void OnGet()
        {
            RowsData = RowRepository.GetAllRows();
        }

        public IActionResult OnPostDelete(int rowId)
        {
            RowRepository.DeleteRowById(rowId);

            return Page();
        }

        public IActionResult OnGetDownloadReport()
        {
            string filePath = RowReport.GenerateReport(RowRepository.GetAllRows());
            var file = System.IO.File.OpenRead(filePath);
            return File(file, "application/octet-stream", Path.GetFileName(filePath));
        }

    }
}