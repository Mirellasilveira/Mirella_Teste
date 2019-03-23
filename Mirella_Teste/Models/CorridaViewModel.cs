using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mirella_Teste.Models
{
    public class CorridaViewModel
    {
        public int Id { get; set; }
        public string Motorista { get; set; }
        public string Passageiro { get; set; }
        public DateTime DataCorrida { get; set; }
        public double Valor { get; set; }
    }

}
