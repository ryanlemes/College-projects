using System;
using System.Threading;
using System.Diagnostics;

namespace lab1pooex36 {

    class Program {
		

        static void ImprimeNomes()
        {
            Console.WriteLine("Laboratório 1 de Programação Orientada Por Objetos");
            Console.WriteLine("Alunos: Ítalo Rodrigues Alves e Ryan Lemes Bezerra");
            Console.WriteLine("Sistemas de Informação - 2º período - Manhã");
        }

        static double Soma(string[]args)
        {
            return (Convert.ToDouble(args[0]) + Convert.ToDouble(args[2]));
        }

        static double Subtrai(string[] args)
        {
            return (Convert.ToDouble(args[0]) - Convert.ToDouble(args[2]));
        }

        static double Multiplica(string[] args)
        {
            return (Convert.ToDouble(args[0]) * Convert.ToDouble(args[2]));
        }

        static double Divide(string[] args)
        {
            return (Convert.ToDouble(args[0]) / Convert.ToDouble(args[2]));
        }
        
        static void Main(string[] args)
        {
			
            ImprimeNomes();
            
            // Validações relacionadas aos operandos
            double aux=0;
            bool canconvert = Double.TryParse(args[0], out aux);
            if (canconvert == false) Console.WriteLine("Parametro de entrada inválido.");
            canconvert = Double.TryParse(args[2], out aux);
            if (canconvert == false) Console.WriteLine("Parametro de entrada inválido.");
            
            // Validações relacionadas aos operadores  
			if (args[1] == "+") Console.WriteLine("Resultado: " + Soma(args));
            else if (args[1] == "-") Console.WriteLine("Resultado: " + Subtrai(args));
            else if (args[1] == "*" || args[1] == "x" || args[1] == "X") Console.WriteLine("Resultado: " + Multiplica(args));
            else if (args[1] == "/") Console.WriteLine("Resultado: " + Divide(args));
            else Console.WriteLine("Operação inválida.");
            }
        }
    }