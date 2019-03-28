using ApiUsuarios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuarios.Repositorio
{
    public class RastreioRepository : IRastreioRepository
    {
        private readonly RastreioDbContext _contexto;

        public RastreioRepository(RastreioDbContext contexto)
        {
            this._contexto = contexto;
        }

        public IEnumerable<Rastreio> GetAll()
        {
            return _contexto.Rastreio.ToList();
        }

        public Rastreio Find(long id)
        {
            return _contexto.Rastreio.FirstOrDefault(r => r.AcessoId == id);
        }    
    }
}
