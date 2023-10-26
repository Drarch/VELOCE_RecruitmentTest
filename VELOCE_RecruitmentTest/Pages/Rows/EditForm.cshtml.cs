using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.NetworkInformation;
using System.Reflection;
using VELOCE_RecruitmentTest.Models;
using VELOCE_RecruitmentTest.Models.Enums;
using VELOCE_RecruitmentTest.Services.Repositories;

namespace VELOCE_RecruitmentTest.Pages.Rows
{
    public class EditFormModel : PageModel
    {
        private readonly IRowRepository rowRepository;

        [BindProperty]
        public RowModel Row { get; set; }

        public EditFormModel(IRowRepository inRowRepository)
        {
            this.rowRepository = inRowRepository;
        }

        public IActionResult OnGet(int RowID)
        {
            Row = rowRepository.GetRowById(RowID) ?? new RowModel();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            rowRepository.UpdateRow(Row);

            return RedirectToPage("/Index");
        }
    }
}
