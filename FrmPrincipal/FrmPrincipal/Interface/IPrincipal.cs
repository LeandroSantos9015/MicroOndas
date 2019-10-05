using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroOndas.Interface
{
    public interface IPrincipal
    {
        Form PrincipalView { get; }

        Button BtnIniciar { get; }

        Button BtnAquecimentoRapido { get; }

        Button BtnParar { get; }

        Button BtnComecar { get; }

        Button BtnProgramacao { get; }

        Button BtnConsultar { get; }

        Button BtnPausarReiniciar { get; }

        TextBox TxtPrato { get; }

        RadioButton RadioArquivo { get; }

        RadioButton RadioDigitacao { get; }

    }
}