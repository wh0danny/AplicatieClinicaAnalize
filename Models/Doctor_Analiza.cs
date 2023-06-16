namespace AplicatieClinicaAnalize.Models
{
    public class Doctor_Analiza
    {
        public int AnalizaId { get; set; }
        public Analiza Analiza { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
