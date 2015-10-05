using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TesteYgor.Domain.Providers
{
    public class CustomPrincipal : ICustomPrincipal
    {
        public IIdentity Identity
        {
            get;
            private set;
        }

        public bool IsInRole(string role)
        {
            CustomPrincipal user = (CustomPrincipal)HttpContext.Current.User;
            if (user.PerfilNomes.IndexOf(role) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public CustomPrincipal(string id)
        {
            this.Identity = new GenericIdentity(id);
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<int> Perfis { get; set; }
        public List<string> PerfilNomes { get; set; }
    }
}
