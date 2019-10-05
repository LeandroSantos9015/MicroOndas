using MicroOndas.Interface.Programa;
using MicroOndas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Programas
{
    public class ProgramaCustom : IPrograma
    {
        public string CaracterAquecedor { get; set; }

        public string Nome { get; set; }

        public string InstrucoesDeUso { get; set; }

        public VisorConfiguracaoDTO Configuracao { get; set; }
    }
}
