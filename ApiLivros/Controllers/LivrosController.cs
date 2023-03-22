using ApiLivros.Context;
using ApiLivros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LivrosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Livro>> Get()
        {
            var livros = _context.Livros.ToList();

            try
            {
                if(livros != null)
                {
                    return Ok(livros);
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<Livro> Get(int id)
        {
            var livro = _context.Livros.FirstOrDefault(p => p.LivroId == id);

            try
            {
                if(livro != null)
                {
                    return Ok(livro);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpPost]
        public ActionResult Post(Livro livro)
        {
            try
            {
                _context.Livros.Add(livro);
                _context.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Livro livro)
        {
            try
            {
                if(livro.LivroId == id)
                {
                    _context.Livros.Entry(livro).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                    _context.SaveChanges();

                    return Ok();
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var livro = _context.Livros.FirstOrDefault(p => p.LivroId == id); 
            
            try
            {
                if(livro != null)
                {
                    _context.Livros.Remove(livro);
                    _context.SaveChanges();

                    return Ok(); 
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
