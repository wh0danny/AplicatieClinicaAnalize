using AplicatieClinicaAnalize.Data.Base;
using AplicatieClinicaAnalize.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicatieClinicaAnalize.Models
{
    public class AnalizaNouaVM
    {
        public int Id { get; set; }

        [Display(Name = "Nume Analiza")]
        //[Required(ErrorMessage = "Numele este obligatoriu")]
        public string NumeAnaliza { get; set; }
        [Display(Name = "Pret Analiza")]
        //[Required(ErrorMessage = "Pretul este obligatoriu")]
        public double PretAnaliza { get; set; }
        [Display(Name = "Selectati o categorie")]
        //[Required(ErrorMessage = "Categoria este obligatorie")]
        public CategorieAnaliza CategorieAnaliza { get; set; }

        //Relationships
        [Display(Name = "Nume Doctor")]
        //[Required(ErrorMessage = "Numele doctorului este obligatoriu")]
        public List<int> DoctorIds { get; set; }
        [Display(Name = "Nume Clinica")]
        //[Required(ErrorMessage = "Selectati o clinica")]
        public int ClinicaId { get; set; }
    }
}
