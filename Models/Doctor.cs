using AplicatieClinicaAnalize.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace AplicatieClinicaAnalize.Models
{
    public class Doctor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Poza de profil")]
        [Required(ErrorMessage = "Poza de profil este obligatorie")]
        public string PozaDeProfilURL { get; set; }

        [Display(Name = "Nume Doctor")]
        [Required(ErrorMessage = "Numele Doctorului este obligatoriu")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Numele Doctorului trebuie sa contina intre 3 si 50 de caractere")]
        public string NumeDoctor { get; set; }

        [Display(Name = "Despre Doctor")]
        [Required(ErrorMessage = "Descrierea Doctorului este obligatorie")]
        public string DespreDoctor { get; set; }

        //Relationships
        public List<Doctor_Analiza> Doctori_Analize { get; set; }
    }
}
    