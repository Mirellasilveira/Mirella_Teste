using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mirella_Teste.Models
{
    public class ListarCorridasViewModel
    {
        public List<CorridaViewModel> Corridas { get; set; }
        public List<MotoristaViewModel> Motoristas { get; set; }
        public List<PassageirosViewModel> Passageiros { get; set; }
    }
}
