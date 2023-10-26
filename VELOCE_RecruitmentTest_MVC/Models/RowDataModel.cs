using System.ComponentModel.DataAnnotations;
using VELOCE_RecruitmentTest.Data.Enums;

namespace VELOCE_RecruitmentTest.Data
{
    public class RowDataModel
    {
        [Display(Name = "Customer Id")]
        public Guid RowID { get; set; } = Guid.NewGuid();

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = String.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = String.Empty;

        [Display(Name = "Birth Date")]
        public DateOnly BirthDate { get; set; }

        [Display(Name = "Sex")]
        public ESex Sex { get; set; } = ESex.Unknown;
    }
}
