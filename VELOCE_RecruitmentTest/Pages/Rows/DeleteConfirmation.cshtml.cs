using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VELOCE_RecruitmentTest.Models;
using VELOCE_RecruitmentTest.Services.Repositories;

namespace VELOCE_RecruitmentTest.Pages.Rows
{
    public class DeleteConfirmationModel : PageModel
    {
        private readonly IRowRepository rowRepository;

        [BindProperty]
        public RowModel Row { get; set; }


        public DeleteConfirmationModel(IRowRepository inRowRepository)
        {
            this.rowRepository = inRowRepository;
        }

        public IActionResult OnGet(int RowID)
        {
            Row = rowRepository.GetRowById(RowID);

            if (Row == null)
            { 
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            rowRepository.DeleteRowById(Row.RowID);

            return RedirectToPage("/Index");
        }
    }
}
