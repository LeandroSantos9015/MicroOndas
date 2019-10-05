using MicroOndas.Interface.Programa;
using MicroOndas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Programas
{
    public class ProgramaAquecimentoRapido : IPrograma
    {
        #region Atributos
        private string caracterAquecedor = "A";

        private string nome = "Aquecimento Rápido";

        private string instrucoes = "Esta programação é destinada para o aquecimentos rápdiso";

        private VisorConfiguracaoDTO configuracao = new VisorConfiguracaoDTO
        {
            Potencia = 8,
            Tempo = Convert.ToDateTime("00:00:30")
        };


        #endregion

        public string CaracterAquecedor
        {
            get { return this.caracterAquecedor; }

            set { caracterAquecedor = value; }
        }

        public string Nome
        {
            get { return this.nome; }

            set { nome = value; }

        }

        public string InstrucoesDeUso
        {
            get { return this.instrucoes; }

            set { instrucoes = value; }
        }


        public VisorConfiguracaoDTO Configuracao
        {
            get { return configuracao; }

            set { configuracao = value; }
        }



    }
}
