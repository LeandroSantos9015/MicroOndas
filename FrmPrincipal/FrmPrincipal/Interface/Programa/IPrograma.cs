using MicroOndas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Interface.Programa
{
    public interface IPrograma
    {

        string CaracterAquecedor { get; set; }

        string Nome { get; }

        string InstrucoesDeUso { get; }

        VisorConfiguracaoDTO Configuracao { get; }

    }
}
