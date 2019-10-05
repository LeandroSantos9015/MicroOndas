using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroOndas.Interface
{
    public interface IMenu
    {
        TextBox TxtInformaPotencia { get; }

        DateTimePicker DteInformaTempo { get; }


    }
}
