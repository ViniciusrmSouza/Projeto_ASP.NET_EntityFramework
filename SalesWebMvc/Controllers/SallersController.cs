using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using SalesWebMvc.Services.Exceptions;
using System.Diagnostics;

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
            var viewModel = new SallerFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Saller saller)
        {
            _sallerService.Insert(saller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)//int opcional
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error),new { message = "Id not provided"});
            }

            var obj = _sallerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sallerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sallerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sallerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Departament> departaments = _departamentService.FindAll();
            SallerFormViewModel viewModel = new SallerFormViewModel { Saller = obj, Departaments = departaments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Saller saller)
        {
            if(id != saller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                _sallerService.Update(saller);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)//ApplicationException é exception mais generica("super tipo")
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };//id interno da requisicao
            return View(viewModel);
        }
    }
}
