using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteYgor.Domain.Models
{
    public class Transportadora
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome da Transportadora é obrigatório")]
        [Display(Name = "Nome da Transportadora")]
        public string NomeTransportadora { get; set; }

        [Required(ErrorMessage = "CNPJ obrigatório")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        //[Display(Name = "Usuário")]
        //public int Usuario_Id { get; set; }

        //public virtual Usuario Usuario { get; set; }

        public virtual ICollection<AvaliacaoTransportadora> Avaliacoes { get; set; }
    }
}
