using ApiUsuarios.Models;
using ApiUsuarios.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiUsuarios.Controllers
{
    [Route("api/[Controller]")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepositorio;

        public UsuariosController(IUsuarioRepository repository)
        {
            this._usuarioRepositorio = repository;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetById(long id)
        {
            Usuario usuario = _usuarioRepositorio.Find(id);

            if (usuario == null)
                return NotFound();

            return new ObjectResult(usuario);
        }

        [HttpGet("nome/{name}", Name = "GetUsuarioNome")]
        public IEnumerable<Usuario> GetByName(string name)
        {
            return _usuarioRepositorio.FindByName(name);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (usuario == null)
                return BadRequest();

            _usuarioRepositorio.Add(usuario);

            return CreatedAtRoute("GetUsuario", new { id = usuario.UsuarioId }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.UsuarioId != id)
                return BadRequest();

            Usuario _usuario = _usuarioRepositorio.Find(id);

            if (_usuario == null)
                return NotFound();

            _usuario.Email = usuario.Email;
            _usuario.Nome = usuario.Nome;

            _usuarioRepositorio.Update(_usuario);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Usuario usuario = _usuarioRepositorio.Find(id);

            if (usuario == null)
                return NotFound();

            _usuarioRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}