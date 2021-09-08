using System.Linq;
using SalesWebMvc.Data;
using System.Collections.Generic;
using SalesWebMvc.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Departament>> FindAllAsync()
        {
            return await _context.Departament.OrderBy(x => x.Name).ToListAsync();//fazendo chamadas assincronas(executar a aplicação independente do acesso ao banco nesse caso) para acesso a banco de dados 
        }
    }
}
