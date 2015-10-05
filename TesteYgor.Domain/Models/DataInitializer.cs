using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteYgor.Domain.Models
{
    public class DataInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);

            var perfis = new List<Perfil>
            {
                new Perfil { Id=1, Nome="Admin" },
                new Perfil { Id=2, Nome="Users" },
                new Perfil { Id=3, Nome="Power Users" },
            };

            perfis.ForEach(p => context.Perfis.Add(p));
            context.SaveChanges();

            var usuarios = new List<Usuario>
            {
                new Usuario { Id=1, Nome="Admin", Email="admin@admin.com", Senha="1234", CPF="111.111.111-11", Perfis = perfis.Where(p=> p.Id == 1).ToList() },
                new Usuario { Id=2, Nome="João José", Email="joao@joao.com", CPF="222.222.222-22", Senha="1234", Perfis = perfis.Where(p=> p.Id == 2).ToList() }
            };

            usuarios.ForEach(p => context.Usuarios.Add(p));
            context.SaveChanges();

            var transportadoras = new List<Transportadora>
            {
                new Transportadora { Id=1, NomeTransportadora="Transvias", CNPJ="78.375.823/0001-99", Endereco="R. Antônio Carlos, 582 - Consolação, São Paulo - SP" },
                new Transportadora { Id=2, NomeTransportadora="Sontra Cargo - Fretes e Caminhões", CNPJ="37.259.963/0001-14", Endereco="Rua Pais Leme, 136 - Pinheiros, SP" },
                new Transportadora { Id=3, NomeTransportadora="Transportadora Risso", CNPJ="02.221.364/0001-27", Endereco="R. Campos Vergueiro, 140, São Paulo - SP" }
            };

            transportadoras.ForEach(t => context.Transportadoras.Add(t));
            context.SaveChanges();
        }
    }
}
