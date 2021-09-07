using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
namespace SalesWebMvc.Controllers
{
    public class SallersController : Controller
    {
        private readonly SallerService _sallerService;
        private readonly DepartamentService _departamentService;

        public SallersController(SallerService sallerService, DepartamentService departamentService)
        {
            _sallerService = sallerService;
            _departamentService = departamentService;
        }

        public IActionResult Index()//Controlador
        {
            var list = _sallerService.FindAll();//Acessando o model
            return View(list);//Encaminhar para view onde o @Model vai corresponder a esse objeto que é passado como parametro no View()
        }

        public IActionResult Create()
        {
            var departaments = _departamentService.FindAll();
            var viewModel = new SallerFormViewModel { Departaments = departaments};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Saller saller)
        {
            _sallerService.Insert(saller);
            return RedirectToAction(nameof(Index));
        }
    }
}
