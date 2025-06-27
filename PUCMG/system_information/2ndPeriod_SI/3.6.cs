using System;
using System.Threading;
using System.Diagnostics;

namespace lab1pooex36 {

    class Program {
		

        static void ImprimeNomes()
        {
            Console.WriteLine("Laborat�rio 1 de Programa��o Orientada Por Objetos");
            Console.WriteLine("Alunos: �talo Rodrigues Alves e Ryan Lemes Bezerra");
            Console.WriteLine("Sistemas de Informa��o - 2� per�odo - Manh�");
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
            
            // Valida��es relacionadas aos operandos
            double aux=0;
            bool canconvert = Double.TryParse(args[0], out aux);
            if (canconvert == false) Console.WriteLine("Parametro de entrada inv�lido.");
            canconvert = Double.TryParse(args[2], out aux);
            if (canconvert == false) Console.WriteLine("Parametro de entrada inv�lido.");
            
            // Valida��es relacionadas aos operadores  
			if (args[1] == "+") Console.WriteLine("Resultado: " + Soma(args));
            else if (args[1] == "-") Console.WriteLine("Resultado: " + Subtrai(args));
            else if (args[1] == "*" || args[1] == "x" || args[1] == "X") Console.WriteLine("Resultado: " + Multiplica(args));
            else if (args[1] == "/") Console.WriteLine("Resultado: " + Divide(args));
            else Console.WriteLine("Opera��o inv�lida.");
            }
        }
    }