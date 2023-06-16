using AplicatieClinicaAnalize.Data;
using AplicatieClinicaAnalize.Data.Services;
using AplicatieClinicaAnalize.Models;
using Microsoft.AspNetCore.Mvc;

namespace AplicatieClinicaAnalize.Controllers
{
    public class CliniciController : Controller
    {
        private readonly ICliniciService _service;

        public CliniciController(ICliniciService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }

        // Get: Clinici/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("LogoClinica,NumeClinica,DescriereClinica")] Clinica clinica)
        {
//            if (!ModelState.IsValid) return View(clinica);
            _service.Add(clinica);
            return RedirectToAction(nameof(Index));
        }

        //Get: Clinici/Details/1
        public IActionResult Details(int id)
        {
            var detaliiClinica = _service.GetById(id);
            if (detaliiClinica == null)
            {
                return View("Empty");
            }
            else
            {
                return View(detaliiClinica);
            }
        }

        //Get: Cinemas/Edit/1
        public IActionResult Edit(int id)
        {
            var detaliiClinica = _service.GetById(id);
            if (detaliiClinica == null)
            {
                return View("Empty");
            }
            else
            {
                return View(detaliiClinica);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("LogoClinica,NumeClinica,DescriereClinica")] Clinica clinica)
        {
            _service.Update(id, clinica);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/1
        public IActionResult Delete(int id)
        {
            var detaliiClinica = _service.GetById(id);
            if (detaliiClinica == null)
            {
                return View("Empty");
            }
            else
            {
                return View(detaliiClinica);
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
