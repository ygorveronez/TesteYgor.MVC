using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteYgor.Domain.Models
{
    public class Perfil
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do perfil é obrigatório")]
        public string Nome { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        
    }
}
