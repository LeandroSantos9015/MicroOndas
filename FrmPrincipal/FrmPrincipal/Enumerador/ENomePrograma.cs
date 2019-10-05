using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Enumerador
{
    public enum ENomePrograma
    {
        [Description("Rapido")]
        AquecimentoRapido = 1,

        [Description("Frango")]
        Frango = 2,

        [Description("Pizza")]
        Pizza = 3,

        [Description("Congelados")]
        Congelados = 4,

        [Description("Custom 1")]
        Customizado1 = 5,

        [Description("Custom 2")]
        Customizado2 = 6

    }
}
