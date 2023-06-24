using System.ComponentModel.DataAnnotations;

namespace AplicatieClinicaAnalize.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Adresa de email")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
