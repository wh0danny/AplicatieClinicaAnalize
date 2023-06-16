using AplicatieClinicaAnalize.Data.Base;
using AplicatieClinicaAnalize.Models;

namespace AplicatieClinicaAnalize.Data.Services
{
    public class CliniciService:EntityBaseRepository<Clinica>, ICliniciService
    {
        public CliniciService(AppDbContext context) : base(context)
        {
            
        }
    }
}
