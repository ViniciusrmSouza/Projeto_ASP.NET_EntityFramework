using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class SallerFormViewModel
    {
        public Saller Saller { get; set; }
        public ICollection<Departament> Departaments { get; set; }
    }
}
