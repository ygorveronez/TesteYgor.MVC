using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteYgor.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [Display(Name = "e-Mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "e-Mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string CPF { get; set; }

        public virtual ICollection<Perfil> Perfis { get; set; }
        //public virtual ICollection<Transportadora> Transportadoras { get; set; }

        public virtual ICollection<AvaliacaoTransportadora> Avaliacoes { get; set; }
    }
}
