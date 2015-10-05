using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TesteYgor.Domain.Providers
{
    interface ICustomPrincipal : IPrincipal
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Email { get; set; }
        List<int> Perfis { get; set; }
        List<string> PerfilNomes { get; set; }
    }
}
