using System.ComponentModel.DataAnnotations;

namespace AplicatieClinicaAnalize.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Adresa de email")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
