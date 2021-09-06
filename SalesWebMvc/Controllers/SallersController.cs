using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Services;
namespace SalesWebMvc.Controllers
{
    public class SallersController : Controller
    {
        private readonly SallerService _sallerService;

        public SallersController(SallerService sallerService)
        {
            _sallerService = sallerService;
        }

        public IActionResult Index()//Controlador
        {
            var list = _sallerService.FindAll();//Acessando o model
            return View(list);//Encaminhar para view onde o @Model vai corresponder a esse objeto que é passado como parametro no View()
        }
    }
}
