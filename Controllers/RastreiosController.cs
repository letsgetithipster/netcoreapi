using ApiUsuarios.Models;
using ApiUsuarios.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiUsuarios.Controllers
{
    [Route("api/[Controller]")]
    public class RastreiosController : Controller
    {
        private readonly IRastreioRepository _rastreioRepository;

        public RastreiosController(IRastreioRepository repositorio)
        {
            this._rastreioRepository = repositorio;
        }

        [HttpGet]
        public IEnumerable<Rastreio> GetAll()
        {
            return _rastreioRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetRastreio")]
        public IActionResult GetById(long id)
        {
            Rastreio rastreio = _rastreioRepository.Find(id);

            if (rastreio == null)
                return NotFound();

            return new ObjectResult(rastreio);
        }
    }
}