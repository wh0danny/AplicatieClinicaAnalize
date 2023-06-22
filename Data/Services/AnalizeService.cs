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

        public Analiza AdaugaAnalizaNoua(AnalizaNouaVM data)
        {
            var analizaNoua = new Analiza()
            {
                NumeAnaliza = data.NumeAnaliza,
                PretAnaliza = data.PretAnaliza,
                ClinicaId = data.ClinicaId,
                CategorieAnaliza = data.CategorieAnaliza

            };
            _context.Analize.Add(analizaNoua);
            _context.SaveChanges();

            //Adauga Dr pt Analiza
            foreach (var doctorID in data.DoctorIds)
            {
                var AnalizaDoctorNou = new Doctor_Analiza()
                {
                    AnalizaId = analizaNoua.Id,
                    DoctorId = doctorID,
                };
                _context.Doctori_Analize.Add(AnalizaDoctorNou);
            }
            _context.SaveChanges();
            return null;
        }

        public Analiza EditeazaAnalizaNoua(AnalizaNouaVM data)
        {
            var dbAnaliza = _context.Analize.FirstOrDefault(n => n.Id == data.Id);
            if (dbAnaliza != null)
            {
                dbAnaliza.NumeAnaliza = data.NumeAnaliza;
                dbAnaliza.PretAnaliza = data.PretAnaliza;
                dbAnaliza.ClinicaId = data.ClinicaId;
                dbAnaliza.CategorieAnaliza = data.CategorieAnaliza;

                _context.SaveChanges();

            }

            //Remove existing doctors
            var existingDoctorsDb = _context.Doctori_Analize.Where(n => n.AnalizaId == data.Id).ToList();
            _context.Doctori_Analize.RemoveRange(existingDoctorsDb);
            _context.SaveChanges();

            //Adauga Dr pt Analiza
            foreach (var doctorID in data.DoctorIds)
            {
                var AnalizaDoctorNou = new Doctor_Analiza()
                {
                    AnalizaId = data.Id,
                    DoctorId = doctorID,
                };
                _context.Doctori_Analize.Add(AnalizaDoctorNou);
            }
            _context.SaveChanges();
            return null;
        }

        /*public AdaugaAnalizaNoua(AnalizaNouaVM data)
        {
            var analizaNoua = new Analiza()
            {
                NumeAnaliza = data.NumeAnaliza,
                PretAnaliza = data.PretAnaliza,
                ClinicaId = data.ClinicaId,
                CategorieAnaliza = data.CategorieAnaliza

            };
            _context.Analize.Add(analizaNoua);
            _context.SaveChanges();

            //Adauga Dr pt Analiza
            foreach(var doctorID in data.DoctorIds)
            {
                var AnalizaDoctorNou = new Doctor_Analiza()
                {
                    AnalizaId = analizaNoua.Id,
                    DoctorId = doctorID,
                };
                _context.Doctori_Analize.Add(AnalizaDoctorNou);
            }
            _context.SaveChanges();
        }*/

    }
}
