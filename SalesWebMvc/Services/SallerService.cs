using System;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;

namespace SalesWebMvc.Services
{
    public class SallerService
    {
        private readonly SalesWebMvcContext _context ;//"readonly" medida de seguraça pra evitar a modificação

        //injeção de dependencia para a subclasse do context
        public SallerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Saller> FindAll()
        {
            return _context.Saller.ToList();
        }
    }
}
