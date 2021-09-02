using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departament> departaments = new List<Departament>();
            departaments.Add(new Departament(1, "Eletronics"));
            departaments.Add(new Departament(2, "Tools"));

            
            return View(departaments);
        }
    }
}
