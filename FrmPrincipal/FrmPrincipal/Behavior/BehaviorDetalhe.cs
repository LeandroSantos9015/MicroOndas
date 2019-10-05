using MicroOndas.Interface;
using MicroOndas.Interface.Programa;
using MicroOndas.Model;
using MicroOndas.Programas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroOndas.Behavior
{
    public class BehaviorDetalhe
    {
        IDetalhe detalhe { get; set; }

        public IList<IPrograma> Programas;

        public Action<IPrograma> AcaoOutrosBehaviors { get; set; }


        public BehaviorDetalhe(IDetalhe detalhe)
        {
            this.detalhe = detalhe;

            this.Programas = ListaProgramasPreDefinidos();

            this.CarregaProgramas();

            this.DelegarEventos();

        }

        private IList<IPrograma> ListaProgramasPreDefinidos()
        {
            // adicionar mais
            return new List<IPrograma>
            {
                new ProgramaFrango(),
                new ProgramaPizza()
            };
        }

        private void DelegarEventos()
        {
            this.detalhe.BtnDetCancelar.Click += BtnDetCancelar_Click;
            this.detalhe.BtnAdicPrograma.Click += BtnAdicPrograma_Click;

            this.detalhe.CbmProgramas.SelectedValueChanged += CbmProgramas_SelectedValueChanged;

            this.detalhe.BtnAddPrgNovo.Click += BtnAddPrgNovo_Click;

        }

        private void BtnDetCancelar_Click(object sender, EventArgs e)
        {
            this.HabilitaDesabilitaBotoesAdicaoPrograma(false);
        }

        private void BtnAdicPrograma_Click(object sender, EventArgs e)
        {

            this.AdicionaProgramas();
            this.HabilitaDesabilitaBotoesAdicaoPrograma(false);

        }

        private void BtnAddPrgNovo_Click(object sender, EventArgs e)
        {
            this.HabilitaDesabilitaBotoesAdicaoPrograma(true);

            this.detalhe.TxtDetTempo.Text = string.Empty;
            this.detalhe.TxtDetPot.Text = string.Empty;
            this.detalhe.TxtDetNome.Text = string.Empty;
            this.detalhe.TxtDetCarac.Text = string.Empty;
            this.detalhe.RchDetInst.Text = string.Empty;
        }

        private void CbmProgramas_SelectedValueChanged(object sender, EventArgs e)
        {
            IPrograma programa = null;

            if (this.detalhe.CbmProgramas.SelectedValue is IPrograma)
                programa = (IPrograma)this.detalhe.CbmProgramas.SelectedItem;

            if (programa is null) return;

            this.AcaoOutrosBehaviors(programa);
        }

        public void PreencheDetalhamentoPrograma(IPrograma programa)
        {
            this.detalhe.TxtDetNome.Text = programa.Nome;

            this.detalhe.TxtDetPot.Text = programa.Configuracao.Potencia.ToString();

            this.detalhe.TxtDetTempo.Text = programa.Configuracao.Tempo.ToString("mm:ss");

            this.detalhe.RchDetInst.Text = programa.InstrucoesDeUso;

            this.detalhe.TxtDetCarac.Text = programa.CaracterAquecedor;
        }

        private void AdicionaProgramas()
        {
            string nome = this.detalhe.TxtDetNome.Text;
            string potencia = this.detalhe.TxtDetPot.Text;
            string instr = this.detalhe.RchDetInst.Text;
            string tempo = this.detalhe.TxtDetTempo.Text;
            string caract = this.detalhe.TxtDetCarac.Text;

            short pot = 0;
            short.TryParse(potencia, out pot);

            IPrograma programaCustom = new ProgramaCustom
            {
                CaracterAquecedor = caract,
                Configuracao = new VisorConfiguracaoDTO { Potencia = pot, Tempo = Convert.ToDateTime($"00:{tempo}") },
                InstrucoesDeUso = instr,
                Nome = nome
            };

            if (this.Programas.Where(x => x.Nome == nome).Count() > 0)
                MessageBox.Show("Já existe programa com esse nome");

            else
            {
                this.Programas.Add(programaCustom);
                this.CarregaProgramas();

                this.detalhe.GrpDetalhe.Enabled = false;
            }
        }

        public void BotoesEventosConsultar()
        {
            this.detalhe.GrpDetalhe.Enabled = true;
            this.detalhe.BtnAdicPrograma.Enabled = false;
            this.detalhe.BtnDetCancelar.Enabled = false;
        }

        public void HabilitaDesabilitaBotoesAdicaoPrograma(bool habilita)
        {
            this.detalhe.CbmProgramas.Enabled = !habilita;
            this.detalhe.GrpDetalhe.Enabled = habilita;
            this.detalhe.BtnAddPrgNovo.Enabled = !habilita;
            this.detalhe.BtnDetCancelar.Enabled = habilita;
            this.detalhe.BtnAdicPrograma.Enabled = habilita;


            if (habilita)
                this.detalhe.TxtDetNome.Focus();

            else
                this.detalhe.CbmProgramas.Focus();
        }

        private void CarregaProgramas()
        {
            this.detalhe.CbmProgramas.DataSource = this.Programas.ToList();
            this.detalhe.CbmProgramas.DisplayMember = "Nome";
        }

        public bool VerificaSeAlimentoEhCompativelComAlgumPrograma(string alimento)
        {
            IPrograma programaEncontrado = this.Programas.Where(x => x.Nome.ToLower().Contains(alimento.Trim().ToLower())).FirstOrDefault();

            if (programaEncontrado is null)
            {
                MessageBox.Show("Não foi encontrada nenhuma programação referente ao seu prato\nPorém você pode aquece-lo normalmente");
                return false;
            }

            else
            {
                this.detalhe.CbmProgramas.SelectedItem = programaEncontrado;
                return true;
            }

        }

        public IPrograma PegaProgramaSelecionadoNaCombo()
        {
            return (IPrograma)this.detalhe.CbmProgramas.SelectedValue;
        }
    }
}
