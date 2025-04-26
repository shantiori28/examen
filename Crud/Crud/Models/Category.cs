using System.ComponentModel.DataAnnotations;

namespace Crud.Models
{
    public class Category
    {
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<Productos> Productos { get; set; }
    }
}
