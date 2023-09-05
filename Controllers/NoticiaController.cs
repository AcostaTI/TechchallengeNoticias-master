
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Webapiaspnet.Data;
using Webapiaspnet.Data.DTO;
using Webapiaspnet.Models;
namespace Webapiaspnet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly WebapiContext _context;
           public NoticiaController(WebapiContext context)
        {
            _context = context;    
        }
        // GET: api/<NoticiaController>
        [HttpGet]
        public IEnumerable<Noticia> GetNoticia([FromQuery] int skip = 0, [FromQuery] int take = 9)
        {
            return _context.Noticia.Skip(skip).Take(take);
        }
        // GET api/<NoticiaController>/5
        [HttpGet("{id}")]
        public IActionResult NoticiaPorId(int id)
        {
            var noticia = _context.Noticia.FirstOrDefault(n => n.Id == id);
            if (noticia == null)
            {
                return NotFound();
            }
            return Ok(noticia);
        }
        // POST api/<NoticiaController>
        [HttpPost]
        [Authorize]
        public IActionResult AddNoticia([FromBody] CreateNoticiaDto noticiadto)
        {
            //Noticia noticia = noticiadto;
            Noticia noticia = new Noticia
            {
                Titulo = noticiadto.Titulo,
                Descricao = noticiadto.Descricao,
                DataPublicacao = noticiadto.DataPublicacao,
                Autor = noticiadto.Autor
            };
            _context.Noticia.Add(noticia);
            _context.SaveChanges();
            return CreatedAtAction(nameof(NoticiaPorId), new { id = noticia.Id }, noticia);
        }
        // PUT api/<NoticiaController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateNoticia(int id, [FromBody] UpdateNoticiaDto noticiadto)
        {
            var noticia = _context.Noticia.FirstOrDefault(noticia => noticia.Id == id);
            if (noticia == null) return NotFound();
            noticia = new Noticia
            {
                Titulo = noticiadto.Titulo,
                Descricao = noticiadto.Descricao,
                DataPublicacao = noticiadto.DataPublicacao,
                Autor = noticiadto.Autor
            };
            _context.SaveChanges();
            return NoContent();
        }
        // DELETE api/<NoticiaController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteNoticia(int id)
        {
            var noticia = _context.Noticia.FirstOrDefault(noticia => noticia.Id == id);
            if (noticia  == null) return NotFound();
            _context.Remove(noticia);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
