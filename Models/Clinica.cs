using AplicatieClinicaAnalize.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace AplicatieClinicaAnalize.Models
{
    public class Clinica:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo Clinica")]
        [Required(ErrorMessage = "Logo clinica este obligatoriu")]
        public string LogoClinica { get; set; }
        [Display(Name = "Nume Clinica")]
        [Required(ErrorMessage = "Nume clinica este obligatoriu")]
        public string NumeClinica { get; set; }
        [Display(Name = "Descriere Clinica")]
        [Required(ErrorMessage = "Descriere clinica este obligatoriu")]
        public string DescriereClinica { get; set; }

        //Relationships
        public List<Analiza> Analize { get; set; }
    }
}
