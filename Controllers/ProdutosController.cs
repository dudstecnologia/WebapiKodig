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
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;
 
        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> listaProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Produto>> produtoUnico(string codigo)
        {
            var product = await _context.Produtos.FindAsync(codigo);
 
            if (product == null) return NotFound();
 
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> salvarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);

            await _context.SaveChangesAsync();
 
            return CreatedAtAction("GetProducts", new { id = produto.CODIGO }, produto);
        }

        [HttpPut("{codigo}")]
        public async Task<IActionResult> atualizarProduto(string codigo, Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
 
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult<Produto>> excluirProduto(string codigo)
        {
            var produto = await _context.Produtos.FindAsync(codigo);

            if (produto == null) return NotFound();
 
            _context.Produtos.Remove(produto);

            await _context.SaveChangesAsync();
 
            return produto;
        }
    }
}