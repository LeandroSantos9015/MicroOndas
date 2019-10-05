using MicroOndas.Behavior;
using MicroOndas.Interface;
using MicroOndas.Interface.Programa;
using MicroOndas.Model;
using MicroOndas.Programas;
using MicroOndas.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilitarios;

namespace MicroOndas.Controller
{
    public class CtrlPrincipal
    {
        public IPrincipal PrincipalView { get; set; }

        private BehaviorDisplay ComportamentoDisplay;
        private BehaviorMenu ComportamentoMenu;
        private BehaviorPreparo ComportamentoPreparo;
        private BehaviorDetalhe ComportamentoDetalhe;

        public CtrlPrincipal()
        {
            this.InicializacComportamentos();
            this.DelegarEventos();

            this.AcaoOutrosBehaviors();

            this. AcaoRadioButton();

        }

        private void AcaoRadioButton()
        {
            string arquivo = Path.Combine(Environment.CurrentDirectory, "microOndas.txt");

            DirectoryInfo Dir = new DirectoryInfo(Environment.CurrentDirectory);

            File.Create(arquivo);

            FileInfo[] Files = Dir.GetFiles("microOndas.txt", SearchOption.AllDirectories);

            /*
             *  Não tive tempo de terminar =/
             * 
             * */

        }

        private void InicializacComportamentos()
        {
            var inicializa = new FrmPrincipal();
            this.PrincipalView = inicializa;

            this.ComportamentoDisplay = new BehaviorDisplay(inicializa);
            this.ComportamentoMenu = new BehaviorMenu(inicializa);
            this.ComportamentoPreparo = new BehaviorPreparo(inicializa);
            this.ComportamentoDetalhe = new BehaviorDetalhe(inicializa);
        }

        private void DelegarEventos()
        {

            this.PrincipalView.BtnComecar.Click += BtnComecar_Click;

            this.PrincipalView.BtnIniciar.Click += BtnIniciar_Click;

            this.PrincipalView.BtnAquecimentoRapido.Click += BtnAquecimentoRapido_Click;

            this.PrincipalView.BtnParar.Click += BtnParar_Click;

            this.PrincipalView.BtnProgramacao.Click += BtnProgramacao_Click;

            this.PrincipalView.BtnConsultar.Click += BtnConsultar_Click;

            this.PrincipalView.BtnPausarReiniciar.Click += BtnPausarReiniciar_Click;


        }

        private void BtnPausarReiniciar_Click(object sender, EventArgs e)
        {
            bool valor = this.PrincipalView.BtnPausarReiniciar.Text.StartsWith("Pausar");

            this.ComportamentoPreparo.PausarResumirAquecimento(valor);

            this.PrincipalView.BtnPausarReiniciar.Text = valor ? "Continuar" : "Pausar";
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            this.ComportamentoDetalhe.BotoesEventosConsultar();



            string alimento = this.PrincipalView.TxtPrato.Text;

            IPrograma programaEncontrado = this.ComportamentoDetalhe.Programas.Where(x => x.Nome.ToLower().Contains(alimento.Trim().ToLower())).FirstOrDefault();

            if (programaEncontrado is null)
            {
                MessageBox.Show("Não foi encontrada nenhuma programação referente ao seu prato");

                return;
            }

            this.ComportamentoDetalhe.PreencheDetalhamentoPrograma(programaEncontrado);

        }

        private void BtnProgramacao_Click(object sender, EventArgs e)
        {
            EventoBotaoProgramacao();
        }

        private void EventoBotaoProgramacao()
        {
            bool valor = this.PrincipalView.BtnProgramacao.Text.StartsWith("Prog");

            this.ComportamentoDetalhe.HabilitaDesabilitaBotoesAdicaoPrograma(!valor);

            this.PrincipalView.BtnProgramacao.Text = valor ? "Cancela Programação" : "Programação";
        }

        private void BtnParar_Click(object sender, EventArgs e)
        {
            this.HabilitaDesabilitaComponentes(false);

            this.PrincipalView.BtnPausarReiniciar.Enabled = false;

            this.ComportamentoPreparo.PararAquecimento();

        }

        private void BtnComecar_Click(object sender, EventArgs e)
        {
            string alimentoInformado = this.PrincipalView.TxtPrato.Text;

            bool temProgramado = this.ComportamentoDetalhe.VerificaSeAlimentoEhCompativelComAlgumPrograma(alimentoInformado);

            if (this.PrincipalView.TxtPrato.Text.Length > 0)
                this.HabilitaDesabilitaComponentes(false);

            if (temProgramado)
                EventoBotaoProgramacao();


        }

        private void BtnAquecimentoRapido_Click(object sender, EventArgs e)
        {

            var configuracao = this.ComportamentoMenu.AquecimentoRapido();

            this.TentaLigarMicroOndas(new ProgramaAquecimentoRapido());

        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            IPrograma programaExecutado = null;

            if (!this.PrincipalView.BtnProgramacao.Text.StartsWith("Prog"))
                programaExecutado = this.ComportamentoDetalhe.PegaProgramaSelecionadoNaCombo();

            else
                programaExecutado = new ProgramaCustom
                {
                    CaracterAquecedor = ".",
                    Configuracao = this.ComportamentoMenu.PegarValorInformados(),
                    InstrucoesDeUso = "Apenas Aquece",
                    Nome = "Botão"
                };


            this.TentaLigarMicroOndas(programaExecutado);

        }

        private void TentaLigarMicroOndas(IPrograma programa)
        {

            VisorConfiguracaoDTO configuracao = programa.Configuracao;

            if (configuracao is null) return;

            this.HabilitaDesabilitaComponentes(true);

            this.ComportamentoDisplay.AtualizaDisplay(configuracao);

            this.ComportamentoPreparo.IniciarAquecimento(programa);

            this.PrincipalView.BtnPausarReiniciar.Enabled = true;

            this.EventosDisplay();
            this.AcaoDesligamento();

        }

        private void HabilitaDesabilitaComponentes(bool microOndasLigado)
        {
            this.PrincipalView.BtnAquecimentoRapido.Enabled = !microOndasLigado;
            this.PrincipalView.BtnComecar.Enabled = !microOndasLigado;
            this.PrincipalView.BtnIniciar.Enabled = !microOndasLigado;
            this.PrincipalView.BtnPausarReiniciar.Enabled = microOndasLigado;
            this.PrincipalView.BtnParar.Enabled = microOndasLigado;
            this.PrincipalView.BtnProgramacao.Enabled = !microOndasLigado;

            this.ComportamentoDetalhe.HabilitaDesabilitaBotoesAdicaoPrograma(true);

        }

        private void AcaoDesligamento()
        {
            this.ComportamentoPreparo.Aquecida = () => { HabilitaDesabilitaComponentes(false); };
        }

        private void AcaoOutrosBehaviors()
        {
            this.ComportamentoDetalhe.AcaoOutrosBehaviors = (x) => { EventosOutroBehavior(x); };
        }

        private void EventosOutroBehavior(IPrograma programa)
        {
            this.ComportamentoDisplay.AtualizaDisplay(programa.Configuracao);

            this.ComportamentoDetalhe.PreencheDetalhamentoPrograma(programa);
        }

        private void EventosDisplay()
        {
            this.ComportamentoPreparo.RegredirDisplay = (x) => { this.ComportamentoDisplay.PonteiroDisplay(x); };

        }
    }
}
