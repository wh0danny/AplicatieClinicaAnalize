using AplicatieClinicaAnalize.Data;
using AplicatieClinicaAnalize.Data.Services;
using AplicatieClinicaAnalize.Models;
using Microsoft.AspNetCore.Mvc;

namespace AplicatieClinicaAnalize.Controllers
{
    public class DoctoriController : Controller
    {
        private readonly IDoctoriService _service;

        public DoctoriController(IDoctoriService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }

        //Get: Doctori/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("PozaDeProfilURL,NumeDoctor,DespreDoctor")]Doctor doctor)
        {
            _service.Add(doctor);
            return RedirectToAction(nameof(Index));   
        }


        //Get: Actors/Details/1
        public IActionResult Details(int id)
        {
            var detaliiDoctor = _service.GetById(id);
            if(detaliiDoctor == null)
            {
                return View("Empty");
            }
            else
            {
                return View(detaliiDoctor);
            }
        }

        //Get: Doctori/Edit/1
        public IActionResult Edit(int id)
        {
            var detaliiDoctor = _service.GetById(id);
            if (detaliiDoctor == null)
            {
                return View("Empty");
            }
            return View(detaliiDoctor);
        }

        [HttpPost]
        public IActionResult Edit(int id, Doctor doctor)
        {
            _service.Update(id, doctor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Doctori/Delete/1
        public IActionResult Delete(int id)
        {
            var detaliiDoctor = _service.GetById(id);
            if (detaliiDoctor == null)
            {
                return View("Empty");
            }
            return View(detaliiDoctor);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var detaliiDoctor = _service.GetById(id);
            if (detaliiDoctor == null)
            {
                return View("Empty");
            }
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
