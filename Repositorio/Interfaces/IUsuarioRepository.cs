using System.Collections.Generic;
using ApiUsuarios.Models;

namespace ApiUsuarios.Repositorio
{
    public interface IUsuarioRepository
    {
        void Add(Usuario user);
        Usuario Find(long id);
        IEnumerable<Usuario> FindByName(string name);
        IEnumerable<Usuario> GetAll();
        void Remove(long id);
        void Update(Usuario user);
    }
}