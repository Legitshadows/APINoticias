using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APINoticias.Models;

namespace APINoticias.Controllers
{
    public class NoticiasController : Controller
    {
        // GET: api/<NoticiasController>
        [HttpGet("APINoticias")] 
        public IEnumerable<Noticia> Get()
        {
            return Noticia.ObtenerNoticias();
        }

        // GET: api/<NoticiasController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Noticia encontrado = Noticia.ObtenerNoticia(id);

            if (encontrado == null)
            {
                return NotFound(null);
            }

            return Ok(encontrado);
        }

        // POST: api/<NoticiasController>
        [HttpPost("APINoticias")]
        public void Post([FromBody] Noticia value)
        {
            Noticia.AgregarNoticia(value);
        }

        // PUT: api/<NoticiasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Noticia value)
        {
            bool resultado = Noticia.ActualizarNoticia(id, value);

            if (!resultado)
            {
                return NotFound();
            }

            return Ok();
        }
        
    }
}
