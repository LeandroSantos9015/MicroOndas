using MicroOndas.Interface;
using MicroOndas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Behavior
{
    /// <summary>
    /// Classe que define o comportamento do display do microondas
    /// </summary>
    public class BehaviorDisplay
    {

        IDisplay displayView { get; set; }

        DateTime tempo;

        Int64 passagem = 1;

        public BehaviorDisplay(IDisplay displayView)
        {
            this.displayView = displayView;

            this.displayView.TxtTempo.Text = DateTime.Now.ToShortTimeString();
            this.displayView.TxtPotencia.Text = "0";

        }

        public void PonteiroDisplay(string acao)
        {
            if (acao.Equals("Continuando"))
            {
                this.displayView.TxtTempo.Text = tempo.AddSeconds(-passagem).ToString("mm:ss");
                passagem++;

            }
            else if (acao.Equals("Zerado"))
                this.displayView.TxtTempo.Text = tempo.AddSeconds(-tempo.TimeOfDay.TotalSeconds).ToString("mm:ss");

        }

        public void AtualizaDisplay(VisorConfiguracaoDTO visor)
        {
            tempo = new DateTime();

            this.displayView.TxtTempo.Text = visor.Tempo.ToString("mm:ss");
            this.displayView.TxtPotencia.Text = visor.Potencia.ToString();

            this.tempo = visor.Tempo;
            this.passagem = 0;

        }


    }
}
