using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Console.Domain
{
    public class Animal
    {
        public Animal() { }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
