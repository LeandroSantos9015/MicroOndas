using MicroOndas.Interface.Programa;
using MicroOndas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Programas
{
    /// <summary>
    /// Classe abstrata que tem por finalidade definir qual a programação que o microondas deve exercer
    /// </summary>
    public abstract class APrograma : IPrograma
    {

        public abstract string CaracterAquecedor { get; set; }

        public abstract string InstrucoesDeUso { get; set; }

        public abstract string Nome { get; set; }

        public abstract VisorConfiguracaoDTO Configuracao { get; set; }

    }
}
