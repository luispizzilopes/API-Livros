using ApiLivros.Context;
using ApiLivros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDesejosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ListaDesejosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ListaDesejo>> Get()
        {
            try
            {
                return _context.ListaDesejos.ToList(); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult<ListaDesejo> Get(int id)
        {
            var item = _context.ListaDesejos.FirstOrDefault(i => i.LivroId == id);

            try
            {
                if(item != null)
                {
                    return Ok(item);
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
        public ActionResult Post(ListaDesejo item)
        {
            try
            {
                _context.ListaDesejos.Add(item);
                _context.SaveChanges();

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, ListaDesejo item)
        {
            try
            {
                if(item.LivroId == id)
                {
                    _context.ListaDesejos.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
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
            var item = _context.ListaDesejos.FirstOrDefault(i => i.LivroId == id);

            try
            {
                if(item != null)
                {
                    _context.ListaDesejos.Remove(item);
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
