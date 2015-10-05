using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteYgor.Domain.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<AvaliacaoTransportadora> Avaliacoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Perfil>().HasKey(p => p.Id).ToTable("Perfis");
            modelBuilder.Entity<Usuario>().HasKey(p => p.Id).ToTable("Usuarios");
            modelBuilder.Entity<Transportadora>().HasKey(p => p.Id).ToTable("Transportadoras");
            modelBuilder.Entity<AvaliacaoTransportadora>().HasKey(q => new { q.Usuario_Id, q.Transportadora_Id }).ToTable("AvaliacaoTransportadora");

            //modelBuilder.Entity<Usuario>().HasMany(x => x.Transportadoras).WithRequired(x => x.Usuario).HasForeignKey(x => x.Usuario_Id);

            modelBuilder.Entity<Perfil>().HasMany(x => x.Usuarios).WithMany(y => y.Perfis);

            modelBuilder.Entity<AvaliacaoTransportadora>().HasRequired(a => a.Transportadora).WithMany(a => a.Avaliacoes).HasForeignKey(a => a.Transportadora_Id);
            modelBuilder.Entity<AvaliacaoTransportadora>().HasRequired(a => a.Usuario).WithMany(a => a.Avaliacoes).HasForeignKey(a => a.Usuario_Id);
            
            
        }


    }
}
