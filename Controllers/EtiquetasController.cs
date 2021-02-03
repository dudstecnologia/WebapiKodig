using Microsoft.AspNetCore.Mvc;
using WebapiKodig.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebapiKodig.Domain.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebapiKodig.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class EtiquetasController : Controller
    {
        private readonly AppDbContext _context;
 
        public EtiquetasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Etiqueta>> listaEtiquetas()
        {
            return await _context.Etiquetas.ToListAsync();
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Etiqueta>> etiquetaUnica(string codigo)
        {
            var product = await _context.Etiquetas.FindAsync(codigo);
 
            if (product == null) return NotFound();
 
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Etiqueta>> salvarEtiqueta(Etiqueta etiqueta)
        {
            _context.Etiquetas.Add(etiqueta);

            await _context.SaveChangesAsync();
 
            return CreatedAtAction("etiquetaUnica", new { codigo = etiqueta.CODIGO }, etiqueta);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> atualizarEtiqueta(string codigo, Etiqueta etiqueta)
        {
            _context.Entry(etiqueta).State = EntityState.Modified;
 
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult<Etiqueta>> excluirEtiqueta(string codigo)
        {
            var etiqueta = await _context.Etiquetas.FindAsync(codigo);

            if (etiqueta == null) return NotFound();
 
            _context.Etiquetas.Remove(etiqueta);

            await _context.SaveChangesAsync();
 
            return etiqueta;
        }
    }
}