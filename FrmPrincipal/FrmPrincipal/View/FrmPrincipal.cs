using MicroOndas.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroOndas.View
{
    public partial class FrmPrincipal : Form, IPrincipal, IDisplay, IMenu, IPreparo, IDetalhe
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        

        public Form PrincipalView { get { return this; } }

        public Button BtnAquecimentoRapido { get { return this.btnAquecimentoRapido; } }

        public Button BtnIniciar { get { return this.btnIniciar; } }

        public Button BtnParar { get { return this.btnParar; } }

        public Button BtnComecar { get { return this.btnComecar; } }

        public TextBox TxtPrato { get { return this.txtPrato; } }

        public ComboBox CbmProgramas { get { return this.cbmProgramas; } }

        public TextBox TxtDetNome { get { return this.txtDetNome; } }

        public TextBox TxtDetPot { get { return this.txtDetPot; } }

        public TextBox TxtDetTempo { get { return this.txtDetTempo; } }

        public RichTextBox RchDetInst { get { return this.rchDetInst; } }

        public Button BtnAddPrgNovo { get { return this.btnAddNovo; } }

        public GroupBox GrpDetalhe { get { return this.grpDetalhe; } }

        public Button BtnAdicPrograma { get { return this.btnAdicPrograma; } }

        public Button BtnDetCancelar { get { return this.btnDetCancelar; } }

        public TextBox TxtDetCarac { get { return this.txtDetCarac; } }

        public Button BtnProgramacao { get { return this.btnProgramacao; } }

        public Button BtnConsultar { get { return this.btnConsultar; } }

        public Button BtnPausarReiniciar { get { return this.btnPausarReiniciar; } }

        public RadioButton RadioArquivo { get { return this.rdbArquivo; } }

        public RadioButton RadioDigitacao { get { return this.rdbDigitacao; } }


        public TextBox TxtTempo { get { return this.txtTempo; } }

        public TextBox TxtPotencia { get { return this.txtPotencia; } }



        

        public TextBox TxtInformaPotencia { get { return this.txtInformaPotencia; } }

        public DateTimePicker DteInformaTempo { get { return this.dteInformaTempo; } }

        public Label LblTempoPreparo { get { return this.lblTempoPreparo; } }

        

        private void Label7_Click(object sender, EventArgs e)
        {

        }
    }
}


