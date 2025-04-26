using Crud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Crud.Controllers
public class CategoriasController : ControllerBase
{
    private readonly PizzeriaDbContext _context;

    public CategoriasController(PizzeriaDbContext context)
    {
        _context = context;
    }

    // GET: api/Categorias
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategorias()
    {
        return await _context.Categorias.ToListAsync();
    }

    // GET: api/Categorias/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategoria(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);

        if (categoria == null)
        {
            return NotFound();
        }

        return categoria;
    }

    // PUT: api/Categorias/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategoria(int id, Category categoria)
    {
        if (id != categoria.CategoriaId)
        {
            return BadRequest();
        }

        _context.Entry(categoria).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoriaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Categorias
    [HttpPost]
    public async Task<ActionResult<Category>> PostCategoria(Category categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCategoria), new { id = categoria.CategoriaId }, categoria);
    }

    // DELETE: api/Categorias/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoria(int id)
    {
        var categoria = await _context.Categorias.FindAsync(id);
        if (categoria == null)
        {
            return NotFound();
        }

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoriaExists(int id)
    {
        return _context.Categorias.Any(e => e.CategoriaId == id);
    }
}
