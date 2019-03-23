using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mirella_Teste.Models
{
    public class CriarCorridaViewModel
    {
        public int Id { get; set; }
        public int IdMotorista { get; set; }
        public int IdPassageiro { get; set; }
        public DateTime DataCorrida { get; set; }
        public double Valor { get; set; }
    }
}
