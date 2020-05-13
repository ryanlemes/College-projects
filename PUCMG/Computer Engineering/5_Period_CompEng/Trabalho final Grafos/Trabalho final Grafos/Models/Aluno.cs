using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_final_Grafos.Models
{
    public class Aluno
    {
        public int Cod_aluno, Cod_tema;
        public string Nome_tema;
        public Aluno(int cod_aluno, int cod_tema, string nome_tema)
        {
            this.Cod_aluno = cod_aluno;
            this.Cod_tema = cod_tema;
            this.Nome_tema = nome_tema;
        }

        
    }
}
