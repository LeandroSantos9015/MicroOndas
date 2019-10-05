using MicroOndas.Interface;
using MicroOndas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroOndas.Behavior
{
    public class BehaviorMenu
    {
        IMenu menuView { get; set; }

        public BehaviorMenu(IMenu menuView)
        {
            this.menuView = menuView;

        }

        private bool VerificaSeAsConfiguracoesEstaoCorretasPraProsseguir(Int16 potencia, DateTime tempo)
        {
            string mensagem = null;

            if (potencia == 0 && tempo.Minute == 0 && tempo.Second == 0)
                mensagem = "* Não foi informado tempo nem potência!\n";

            else
            {
                if (potencia > 10)
                    mensagem = "* Potência não pode ser maior que 10\n";

                else if (potencia < 1)
                    mensagem = "* Potência não pode ser menor que 1\n";


                if(tempo.TimeOfDay.TotalSeconds > 120)
                    mensagem += "* Tempo não pode ser maior que 2 minutos\n";

                else if (tempo.TimeOfDay.TotalSeconds < 1)
                    mensagem += "* Tempo não pode ser menor que 1 segundo\n";

                // 3.a Se o tempo não tiver sido parametrizado, lançar uma exceção solicitando a parametrização do tempo antes de iniciar o aquecimento. 
                // No meu caso não se aplicou pois o tratamento já consiste no fato de eu ter um DateTimePicker impossibilitando valores nulos ou vazio
                

            }



            // colocar um throw aqui
            if (mensagem != null)
            {
                mensagem += String.Format("\nCorrija o{0} erro{0} informado{0} acima e tente novamente", mensagem.Length > 40 ? "(s)" : "");
                MessageBox.Show(mensagem);
                return false;
            }

            return true;
        }


        public VisorConfiguracaoDTO PegarValorInformados()
        {
            Int16 potencia = 0;

            Int16.TryParse(this.menuView.TxtInformaPotencia.Text, out potencia);

            DateTime tempo = this.menuView.DteInformaTempo.Value;

            if (VerificaSeAsConfiguracoesEstaoCorretasPraProsseguir(potencia, tempo))
                return new VisorConfiguracaoDTO { Potencia = potencia, Tempo = tempo };
            else
                return null;
        }

        public VisorConfiguracaoDTO AquecimentoRapido()
        {
            return new VisorConfiguracaoDTO { Potencia = 8, Tempo = Convert.ToDateTime("00:00:30") };
        }

    }
}
