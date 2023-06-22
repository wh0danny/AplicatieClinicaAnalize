using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicatieClinicaAnalize.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Cantitate { get; set; }
        public double Pret { get; set; }

        public int AnalizaId { get; set; }
        [ForeignKey("AnalizaId")]
        public Analiza Analiza { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

    }
}
