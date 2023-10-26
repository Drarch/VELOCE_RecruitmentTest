using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using VELOCE_RecruitmentTest.Models.Enums;

namespace VELOCE_RecruitmentTest.Models
{
    [BindProperties]
    public class RowModel
    {
        [Display(Name = "Row Id")]
        public int RowID { get; set; } = -1;

        [Display(Name = "First Name")]
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required, MaxLength(150)]
        public string LastName { get; set; }


        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Birth Date is required.")]
        public DateTime? BirthDate { get; set; } = null;

        [Display(Name = "Sex")]
        [Required]
        public ESex Sex { get; set; } = ESex.Unknown;
    }
}
