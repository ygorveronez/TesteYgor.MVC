using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteYgor.Domain.Providers
{
    public class CustomPrincipalSerializeModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<int> Perfis { get; set; }
        public List<string> PerfilNomes { get; set; }
    }
}
