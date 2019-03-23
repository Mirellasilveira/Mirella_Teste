using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mirella_Teste.Models
{
    public class CriarMotoristaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string ModeloCarro { get; set; }
        public bool Status { get; set; }
        public string Sexo { get; set; }
    }
}
