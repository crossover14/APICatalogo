using APICatalogo.Contexto;
using APICatalogo.Filter;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {


        private readonly AppDbContext _context;
        public ProdutosController(AppDbContext contexto)
        {
            _context = contexto;
        }

        //Api/Produtos
        [HttpGet("/primeiro")]
        public ActionResult<Produto> Get2()
        {
            return _context.Produtos.FirstOrDefault();
        }

        //Api/Produtos/1/ 
        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return _context.Produtos.AsNoTracking().ToList();
        }

        [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
        public async Task<ActionResult<Produto>> Get([FromQuery]int id)
        {
;
           // Teste para erros...
            // throw new Exception("Exception ao retornar produto pelo ID");

            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Produto produto)
        {
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }

            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Produto produto)
        {
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest(ModelState);
            // }
            if (id != produto.ProdutoId)
            {
                return BadRequest();

            }
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();


        }
        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (id != produto.ProdutoId)
            {
                return BadRequest();

            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return produto;



        }
    }
}
