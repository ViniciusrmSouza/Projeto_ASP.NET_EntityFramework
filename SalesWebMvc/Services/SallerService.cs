using System;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using Microsoft.EntityFrameworkCore;

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

        public void Insert(Saller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Saller FindById(int id)
        {
            return _context.Saller.Include(obj => obj.Departament).FirstOrDefault(obj => obj.Id == id);//por padrão só pega os sellers do banco mas com o Incluse ja obtem tbm os objetos associados
        }
        public void Remove(int id)
        {
            var obj = _context.Saller.Find(id);
            _context.Saller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
