using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteYgor.Domain.Models;

namespace TesteYgor.Domain.Repositories
{
    public class UsuarioRepository : IRepository<Usuario>
    {
        private DataContext db = new DataContext();

        public ICollection<Usuario> SelectEntities()
        {
            return db.Usuarios.ToList();
        }

        public Usuario SelectEntity(int id)
        {
            return db.Usuarios.Find(id);
        }

        public void InsertEntity(Usuario entity)
        {
            db.Usuarios.Add(entity);
            db.SaveChanges();
        }

        public void UpdateEntity(Usuario entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEntity(Usuario entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }


        
    }
}
