using MicroOndas.Interface.Programa;
using MicroOndas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Programas
{
    public class ProgramaFrango : IPrograma
    {
        #region Atributos
        private string caracterAquecedor = "P";

        private string nome = "Frango";

        private string instrucoes = "Esta programação é destinada para o aquecimento de um frango inteiro";

        #endregion

        private VisorConfiguracaoDTO configuracao = new VisorConfiguracaoDTO
        {
            Potencia = 6,
            Tempo = Convert.ToDateTime("00:01:14")
        };

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
