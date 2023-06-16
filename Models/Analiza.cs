using AplicatieClinicaAnalize.Data.Base;
using AplicatieClinicaAnalize.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicatieClinicaAnalize.Models
{
    public class Analiza:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string NumeAnaliza { get; set; }
        public double PretAnaliza { get; set; }
        public CategorieAnaliza CategorieAnaliza { get; set; }

        //Relationships
        public List<Doctor_Analiza> Doctori_Analize { get; set; }

        //Clinica
        public int ClinicaId { get; set; }
        [ForeignKey("ClinicaId")]
        public Clinica Clinica { get; set; }
    }
}
