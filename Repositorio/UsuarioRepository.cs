using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiUsuarios.Models;

namespace ApiUsuarios.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _contexto;

        public UsuarioRepository(UsuarioDbContext contexto)
        {
            this._contexto = contexto;
        }

        public void Add(Usuario user)
        {
            _contexto.Usuarios.Add(user);
            _contexto.SaveChanges();
        }

        public Usuario Find(long id)
        {
            return _contexto.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _contexto.Usuarios.ToList();
        }

        public IEnumerable<Usuario> FindByName(string name)
        {
            //LINQ Query syntax:
            var query = (from usuarios in _contexto.Usuarios
                        where usuarios.Nome == name
                        select usuarios).ToList();

            return query;


            //LINQ Method syntax:
            //var query = _contexto.Usuarios
            //                    .Where(u => u.Nome == name)
            //                    .ToList();

            //return query;
        }

        public void Remove(long id)
        {
            Usuario entity = _contexto.Usuarios.First(u => u.UsuarioId == id);
            _contexto.Usuarios.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Usuario user)
        {
            _contexto.Usuarios.Update(user);
            _contexto.SaveChanges();
        }
    }
}
