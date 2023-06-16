using AplicatieClinicaAnalize.Models;

namespace AplicatieClinicaAnalize.Data.ViewModels
{
    public class AnalizaNouaDropdownsVM
    {
        public AnalizaNouaDropdownsVM()
        {
            Doctori = new List<Doctor>();
            Clinici = new List<Clinica>();
        }

        public List<Doctor> Doctori { get; set; }
        public List<Clinica> Clinici { get; set; }
    }
}
