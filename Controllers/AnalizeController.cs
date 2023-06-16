using AplicatieClinicaAnalize.Data;
using AplicatieClinicaAnalize.Data.Services;
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

    }
}
