using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroOndas.Interface
{
    public interface IDisplay
    {

        TextBox TxtTempo { get; }

        TextBox TxtPotencia { get; }

    }
}
