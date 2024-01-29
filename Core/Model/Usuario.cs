using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{

    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Usuario(int id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }
    }
}
