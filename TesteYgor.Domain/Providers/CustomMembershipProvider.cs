using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Providers;
using System.Web.Script.Serialization;
using System.Web.Security;
using TesteYgor.Domain.Models;


namespace TesteYgor.Domain.Providers
{
    public class CustomMembershipProvider : DefaultMembershipProvider
    {
        public override bool ValidateUser(string email, string password)
        {
            Usuario user = null;
            using (DataContext db = new DataContext())
            {
                user = db.Usuarios.Include("Perfis").Where(p => p.Email == email & p.Senha == password).FirstOrDefault();

                

                //pessoa = (Pessoa)(from pes in db.Pessoas.Include("Perfis") where pes.Email == email & pes.Senha == password select pes).FirstOrDefault();
            }

            if (user != null)
            {
                CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();

                serializeModel.Id = user.Id;
                serializeModel.Nome = user.Nome;
                serializeModel.Email = user.Email;

                //guarda apenas ids e nomes dos perfis
                serializeModel.Perfis = new List<int>();
                serializeModel.PerfilNomes = new List<string>();
                foreach (Perfil perfil in user.Perfis)
                {
                    serializeModel.Perfis.Add(perfil.Id);
                    serializeModel.PerfilNomes.Add(perfil.Nome);
                }

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                try
                {
                    string userData = serializer.Serialize(serializeModel);

                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                             1,
                             user.Nome,
                             DateTime.Now,
                             DateTime.Now.AddMinutes(240),
                             false,
                             userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    HttpContext.Current.Response.Cookies.Add(faCookie);

                    return true;
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    throw ex;
                }
            }
            else
            {
                return false;
            }
        }

        public void SignOutUser()
        {
            FormsAuthentication.SignOut();
        }
    }
}
