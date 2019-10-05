using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroOndas.Interface
{
    public interface IDetalhe
    {

        TextBox TxtDetNome { get; }

        TextBox TxtDetPot { get; }

        TextBox TxtDetTempo { get; }

        RichTextBox RchDetInst { get; }

        GroupBox GrpDetalhe { get; }

        Button BtnAdicPrograma { get; }

        Button BtnDetCancelar { get; }

        TextBox TxtDetCarac { get; }

        ComboBox CbmProgramas { get; }

        Button BtnAddPrgNovo { get; }
    }
}
