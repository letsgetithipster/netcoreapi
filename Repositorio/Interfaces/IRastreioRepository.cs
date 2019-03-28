using System.Collections.Generic;
using ApiUsuarios.Models;

namespace ApiUsuarios.Repositorio
{
    public interface IRastreioRepository
    {
        Rastreio Find(long id);
        IEnumerable<Rastreio> GetAll();
    }
}