using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteYgor.Domain.Models;

namespace TesteYgor.Domain.Repositories
{
    public class TransportadoraRepository : IRepository<Transportadora>
    {
        private DataContext db = new DataContext();

        public ICollection<Transportadora> SelectEntities()
        {
            return db.Transportadoras.Include("Avaliacoes").ToList();
        }

        public Transportadora SelectEntity(int id)
        {
            return db.Transportadoras.Include("Avaliacoes").First(f => f.Id == id);
        }

        public void InsertEntity(Transportadora entity)
        {
            db.Transportadoras.Add(entity);
            db.SaveChanges();
        }

        public void UpdateEntity(Transportadora entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEntity(Transportadora entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void AvaliarTransportadora(AvaliacaoTransportadora entity)
        {
            db.Avaliacoes.Add(entity);
            db.SaveChanges();
        }

    }
}
