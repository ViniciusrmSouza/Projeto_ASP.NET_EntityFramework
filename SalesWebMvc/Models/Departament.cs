using System.Collections.Generic;
using System;
using System.Linq;
namespace SalesWebMvc.Models
{
    public class Departament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Saller> Sallers { get; set; } = new List<Saller>();//Implementar o tipo mais generico da coleção

        public Departament()
        {
        }
        public Departament(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddSeller(Saller saller)
        {
            Sallers.Add(saller);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sallers.Sum(saller => saller.TotalSales(initial, final));//retorna a soma de todas as vendas do metodo TotalSales de todos Sallers na lista
        }
    }
}
