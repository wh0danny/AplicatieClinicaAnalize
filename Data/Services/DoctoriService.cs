using AplicatieClinicaAnalize.Data.Base;
using AplicatieClinicaAnalize.Models;

namespace AplicatieClinicaAnalize.Data.Services
{
    public class DoctoriService : EntityBaseRepository<Doctor>, IDoctoriService
    {
        //private readonly AppDbContext _context;

        public DoctoriService(AppDbContext context) : base(context)
        {

        }

        /*public void Add(Doctor doctor)
        {
            _context.Doctori.Add(doctor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _context.Doctori.FirstOrDefault(x => x.Id == id);
            _context.Doctori.Remove(result);
            _context.SaveChanges();
        }

        public IEnumerable<Doctor> GetAll()
        {
            var result = _context.Doctori.ToList();
            return result;
        }

        public Doctor GetById(int id)
        {
            var result = _context.Doctori.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public Doctor Update(int id, Doctor noulDoctor)
        {
            _context.Update(noulDoctor);
            _context.SaveChanges();
            return noulDoctor;
        }*/
    }
}
