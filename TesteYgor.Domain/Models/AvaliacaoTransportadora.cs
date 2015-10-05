using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteYgor.Domain.Models
{
    public class AvaliacaoTransportadora
    {
        public int Usuario_Id { get; set; }
        public int Transportadora_Id { get; set; }
        public int Avaliacao { get; set; }
        public DateTime DataAvaliacao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Transportadora Transportadora { get; set; }
    }
}
