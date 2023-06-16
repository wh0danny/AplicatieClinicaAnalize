using AplicatieClinicaAnalize.Data.Base;
using AplicatieClinicaAnalize.Data.ViewModels;
using AplicatieClinicaAnalize.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicatieClinicaAnalize.Data.Services
{
    public class AnalizeService:EntityBaseRepository<Analiza>,IAnalizeService
    {
        private readonly AppDbContext _context;

        public AnalizeService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public Analiza GetAnalizaById(int id)
        {
            var DetaliiAnaliza = _context.Analize
                .Include(c => c.Clinica)
                .Include(da => da.Doctori_Analize).ThenInclude(d => d.Doctor)
                .FirstOrDefault(n => n.Id == id);

            return DetaliiAnaliza;
        }

        public AnalizaNouaDropdownsVM GetAnalizaNouaDropdownsValues()
        {
            var response = new AnalizaNouaDropdownsVM();
            response.Doctori = _context.Doctori.OrderBy(n => n.NumeDoctor).ToList();
            response.Clinici = _context.Clinici.OrderBy(n => n.NumeClinica).ToList();
            return response;
        }
    }
}
