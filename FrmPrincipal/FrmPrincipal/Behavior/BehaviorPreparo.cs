using MicroOndas.Interface;
using MicroOndas.Interface.Programa;
using MicroOndas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroOndas.Behavior
{
    public class BehaviorPreparo
    {
        private IPreparo preparoView { get; set; }

        private Timer timer;

        private double totalSegundosConfiguracao;
        private double quantidadeSegundosQueSePassaram;

        private string Pontos;

        public Action Aquecida { get; set; }

        public Action<String> RegredirDisplay { get; set; }

        public BehaviorPreparo(IPreparo preparoView)
        {
            this.preparoView = preparoView;
        }

        public void IniciarAquecimento(IPrograma programa)
        {
            VisorConfiguracaoDTO configuracao = programa.Configuracao;

            totalSegundosConfiguracao = configuracao.Tempo.TimeOfDay.TotalSeconds;

            AtualizaPontosConformePotencia(programa);

            this.ExecutaTempoParaPreparo();

        }

        public void PausarResumirAquecimento(bool pausado)
        {
            if (pausado)
            {
                timer.Stop();
                this.preparoView.LblTempoPreparo.Text += " Pausado ";
                this.RegredirDisplay("Pausado");
            }
            else
            {
                timer.Start();
                this.preparoView.LblTempoPreparo.Text += " Continuando ";
                this.RegredirDisplay("Continuando");
            }
        }
        

        public void PararAquecimento()
        {
            timer.Stop();

            MessageBox.Show("Aquecimento Interrompido!");
            quantidadeSegundosQueSePassaram = 0;

            this.RegredirDisplay("Zerado");

        }


        private void ExecutaTempoParaPreparo()
        {
            if (timer is null)
            {
                timer = new Timer();
                timer.Interval = 1000;
                timer.Tick += Timer_Tick;
            }

            timer.Start();


        }


        private void AtualizaPontosConformePotencia(IPrograma programa)
        {
            this.Pontos = null;

            string caracterAquecedor = programa.CaracterAquecedor;

            for (int i = 0; i < programa.Configuracao.Potencia; i++)
                this.Pontos += caracterAquecedor;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.RegredirDisplay("Continuando");

            if (totalSegundosConfiguracao == quantidadeSegundosQueSePassaram)
            {
                this.preparoView.LblTempoPreparo.Text += " Aquecida ";
                quantidadeSegundosQueSePassaram = 0;
                timer.Stop();

                this.Aquecida();

                this.RegredirDisplay("Zerado");


                return;

            }

            this.preparoView.LblTempoPreparo.Text += this.Pontos;

            ++quantidadeSegundosQueSePassaram;
        }
    }
}
