using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._2
{
    class Loja
    {
        string nome, rg;
        int tipo;
        double salariobase, comissao, horaextra;

        public static void ImprimeMenu()
        {
            Console.WriteLine("1 - Cadastrar funcionário.");
            Console.WriteLine("2 - Lançar vendas.");
            Console.WriteLine("3 - Lançar hora extra.");
            Console.WriteLine("4 - Imprimir salário.");
            Console.WriteLine("5 - Finalizar programa.\n");
            Console.Write("Digite a opção desejada: ");
        }

        public static void AcumulaVendas (Loja [] func, ref bool aux)
        {
            string rg;
            aux=true;
                Console.Write("RG do funcionário: ");
                rg = Console.ReadLine();
                for (int i =0; i < 10; i++)
                {
                    if (rg == func[i].rg && func[i].tipo == 2)
                    {
                        Console.Write("Total de vendas realizadas: ");
                        func[i].comissao += Convert.ToDouble(Console.ReadLine()) * (5/100);
                        aux = false;
                    }
                    if (aux == true && i == 9) Console.WriteLine("Funcionário não encontrado ou não é vendedor.");
            }
        }

        public static void AcumulaExtras (Loja [] func, ref bool aux)
        {
            string rg;
            aux = true;
                Console.Write("RG do funcionário: ");
                rg = Console.ReadLine();
                for (int i =0; i  < 10; i++)
                {
                    if (rg == func[i].rg && func[i].tipo == 1)
                    {
                        Console.Write("Total horas extras realizadas: ");
                        func[i].horaextra += Convert.ToDouble(Console.ReadLine());
                        aux = false;
                    }
                    if (aux == true && i == 9) Console.WriteLine("Funcionário não encontrado ou não é vendedor.");
            }
        }

        public static void CadastraFuncionario (Loja [] func, int i, ref bool aux)
        {
            aux = true;
            while (aux)
            {
                Console.Write("Digite o tipo do funcionário (1-Adm / 2-Vendedor): ");
                func[i].tipo = Convert.ToInt32(Console.ReadLine());
                if (func[i].tipo == 1 || func[i].tipo == 2) aux = false;
                else Console.WriteLine("Tipo inválido.");
            }
            Console.Write("Nome: ");
            func[i].nome = Console.ReadLine();
            Console.Write("RG: ");
            func[i].rg = Console.ReadLine();
            Console.Write("Salário base: ");
            func[i].salariobase = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Cadastro concluído.\n");
        }

        public static void ImprimeSalario(Loja[] func)
        {
            string rg;
            Console.Write("Digite o RG: ");
            rg = Console.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                if (rg == func[i].rg)
                {
                    Console.WriteLine("Funcionário: " + func[i].nome);
                    func[i].salariobase += (func[i].comissao + func[i].horaextra);
                    Console.WriteLine("Salário à receber: R$ " + func[i].salariobase);
                }
            }
        }

        static void Main(string[] args)
        {
            bool aux = true;
            int opcao=1, quantfunc=0;
            Loja[] func = new Loja[10];

            for (int i = 0; i < 10; i++) func[i] = new Loja();

                while (opcao > 0 && opcao <= 4)
                {
                    ImprimeMenu();
                    opcao = Convert.ToInt32(Console.ReadLine());
                    if (opcao == 1)
                    {
                        func[quantfunc] = new Loja();
                        CadastraFuncionario(func, quantfunc, ref aux);
                        quantfunc++;
                        if (aux) ImprimeMenu();
                    }
                    else if (opcao == 2) AcumulaVendas(func, ref aux);
                    else if (opcao == 3) AcumulaExtras(func, ref aux);
                    else if (opcao == 4) ImprimeSalario(func);
                }
        }
    }
}