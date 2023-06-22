using AplicatieClinicaAnalize.Data;
using AplicatieClinicaAnalize.Data.Services;
using AplicatieClinicaAnalize.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace AplicatieClinicaAnalize.Controllers
{
    public class AnalizeController : Controller
    {
        private readonly IAnalizeService _service;

        public AnalizeController(IAnalizeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var data = _service.GetAll(n => n.Clinica);
            return View(data);
        }

        public IActionResult Filter(string searchString)
        {
            var data = _service.GetAll(n => n.Clinica);

            if (!string.IsNullOrEmpty(searchString))
            {
                var rezultateCautare = data.Where(n => n.NumeAnaliza.Contains(searchString)).ToList();
                return View("Index", rezultateCautare);
            }

            return View("Index", data);
        }

        //Get: Analiza/Details/1
        public IActionResult Details(int id)
        {
            var detaliiAnaliza = _service.GetAnalizaById(id);
            return View(detaliiAnaliza);
        }

        //Get: Analiza/Create
        public IActionResult Create()
        {
            var analizaDropDownData = _service.GetAnalizaNouaDropdownsValues();

            ViewBag.ClinicaId = new SelectList(analizaDropDownData.Clinici, "Id", "NumeClinica");
            ViewBag.DoctoriIds = new SelectList(analizaDropDownData.Doctori, "Id", "NumeDoctor");

            return View();
        }

        [HttpPost]
        public IActionResult Create(AnalizaNouaVM analiza)
        {
            _service.AdaugaAnalizaNoua(analiza);
            return RedirectToAction(nameof(Index));
        }

        //Get: Analiza/Edit/1
        public IActionResult Edit(int id)
        {
            var analizaDetalii = _service.GetAnalizaById(id);
            /*if(analizaDetalii == null)
            {
                return View("Empty");
            }else*/

            var response = new AnalizaNouaVM()
            {
                Id = analizaDetalii.Id,
                NumeAnaliza = analizaDetalii.NumeAnaliza,
                PretAnaliza = analizaDetalii.PretAnaliza,
                CategorieAnaliza = analizaDetalii.CategorieAnaliza,
                ClinicaId = analizaDetalii.ClinicaId,
                DoctorIds = analizaDetalii.Doctori_Analize.Select(n => n.DoctorId).ToList(),
            };

            var analizaDropDownData = _service.GetAnalizaNouaDropdownsValues();

            ViewBag.ClinicaId = new SelectList(analizaDropDownData.Clinici, "Id", "NumeClinica");
            ViewBag.DoctoriIds = new SelectList(analizaDropDownData.Doctori, "Id", "NumeDoctor");

            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, AnalizaNouaVM analiza)
        {
            _service.EditeazaAnalizaNoua(analiza);
            return RedirectToAction(nameof(Index));
        }


    }
}
