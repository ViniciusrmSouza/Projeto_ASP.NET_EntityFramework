using System.Linq;
using SalesWebMvc.Data;
using System.Collections.Generic;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class DepartamentService
    {
        private readonly SalesWebMvcContext _context;//"readonly" medida de seguraça pra evitar a modificação

        //injeção de dependencia para a subclasse do context
        public DepartamentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Departament> FindAll()
        {
            return _context.Departament.OrderBy(x => x.Name).ToList();
        }
    }
}
