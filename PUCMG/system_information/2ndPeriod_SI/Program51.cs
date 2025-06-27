using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Utilizando obrigatoriamente o conceito de herança, fazer programas (codificado
//inicialmente em Java e depois em C#) que atenda os seguintes requisitos (Exercício para
//entregar): Criar uma classe base Telefone e uma classe TelefoneEletronico derivada de Telefone. 
//Em Telefone, crie um membro protected TipoDoTelefone do tipo string, e um método public Ring( )
//que imprime uma mensagem como: "Tocando o <TipoDoTelefone>." Em TelefoneEletronico, o construtor deve ajustar (set) o TipoDoTelefone para "Digital". 
//No método Run( ), chamar o método Ring( ) no TelefoneEletronico para testar a herança.

namespace ConsoleApplication1
{
    public class Telefone
    {
        protected string TipoDoTelefone = "Analogico";
        public string TipoDoTelefone1   
        {
             get 
             {
                 return TipoDoTelefone;
             }
            set
            {
                TipoDoTelefone = value;
            }
         } 
       
        public static void Ring()
        {
            TelefoneEletronico TipoDoTelefone = new TelefoneEletronico();
            TipoDoTelefone.TipoDoTelefone = "Digital";
            System.Console.Write("Tocando o " + TipoDoTelefone.TipoDoTelefone);
        }
        public class TelefoneEletronico : Telefone
        {
            public static void Run()
            {
                Ring();
            }
        }
        class Program : TelefoneEletronico
        {
            static void Main(string[] args)
            {              
                Console.WriteLine("Programado por Italo, João, Paula e Ryan");
                Run();

                Console.WriteLine("Finalizando o programa. Clique em qualquer tecla para finalizar");
                Console.ReadKey();
            }
        }
    }
}
