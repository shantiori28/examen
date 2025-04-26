namespace Crud.Models
{
    public int ProductoId { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int CategoriaId { get; set; }
    public Category Categoria { get; set; }
}
