using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_final_Grafos
{
    public class Program
    {
        private static string ArquivoDissimilaridade = "Matriz_Dissimilaridade";
        private static string ArquivoNome_Tema_Pesquisa = "Nome_Tema_Pesquisa";
        private static string ArquivoDados_Aluno_Tema = "Dados_Aluno_Tema";

        public static void Menu()
        {
            Console.WriteLine("\tTrabalho Final de Algoritmos em Grafos\n");
            Console.WriteLine("Integrantes:");
            Console.WriteLine("~> Gustavo Loschi Salomao");
            Console.WriteLine("~> Ryan Lemes Bezerra");
            Console.WriteLine("---------------------------");
        }

        private static Models.Grafo retorna_GrafoDissimilaridade(List<int[]> MatrizDissimilaridade)
        {
            int[] v1 = new int[MatrizDissimilaridade.Count * (MatrizDissimilaridade.Count - 1)];
            int[] v2 = new int[MatrizDissimilaridade.Count * (MatrizDissimilaridade.Count - 1)];
            int[] Peso = new int[MatrizDissimilaridade.Count * (MatrizDissimilaridade.Count - 1)];

            int contVetor = 0;
            for (int i = 0; i < MatrizDissimilaridade.Count; i++)
            {
                for (int j = 0; j < MatrizDissimilaridade.Count; j++)
                {
                    if (i != j)
                    {
                        v1[contVetor] = i + 1;
                        v2[contVetor] = j + 1;
                        Peso[contVetor] = MatrizDissimilaridade[i][j];
                        contVetor++;
                    }
                }
            }

            Models.Grafo GrafoCompletoDisimilar = new Models.Grafo(MatrizDissimilaridade.Count, v1, v2, Peso);

            return GrafoCompletoDisimilar;
        }

        static void Main(string[] args)
        {
            try
            {
                

                List<Models.Aluno> Aluno = new List<Models.Aluno>();
                List<int[]> MatrizDissimilaridade = new List<int[]>();
                List<string[]> NomeTemas = new List<string[]>();
                Models.Grafo GrafoCompletoDissimilar;

                StreamReader srAluno_tema = new StreamReader(ArquivoDados_Aluno_Tema + ".txt");
                StreamReader srNomeTemas = new StreamReader(ArquivoNome_Tema_Pesquisa + ".txt");
                StreamReader srDissimilaridade = new StreamReader(ArquivoDissimilaridade + ".txt");

                #region lendo arquivos

                string linha;
                //Lendo matriz dissimilaridade
                while (true)
                {
                    linha = srDissimilaridade.ReadLine();
                    if (linha == null) break;
                    string[] valores = linha.Split(' ');
                    int[] v = new int[valores.Length];
                    for (int i = 0; i < valores.Length; i++)
                        v[i] = Convert.ToInt32(valores[i]);

                    MatrizDissimilaridade.Add(v);
                }

                GrafoCompletoDissimilar = retorna_GrafoDissimilaridade(MatrizDissimilaridade);//Grafo completo

                //Lendo Nome dos temas
                while (true)
                {
                    linha = srNomeTemas.ReadLine();
                    if (linha == null) break;
                    string[] valores = linha.Split(' ');
                    string nome = "";

                    for (int i = 1; i < valores.Length; i++)
                        nome = nome + valores[i] + " ";

                    NomeTemas.Add(new string[] { valores[0], nome });
                }

                //Lendo arquivo alunos e temas relacionados
                while (true)
                {
                    linha = srAluno_tema.ReadLine();
                    if (linha == null) break;
                    string[] valores = linha.Split(' ');
                    string nome = "";
                    for (int i = 0; i < NomeTemas.Count; i++)
                    {
                        if (Convert.ToInt32(NomeTemas[i][0]) == Convert.ToInt32(valores[1]))
                        {
                            nome = NomeTemas[i][1];
                            break;
                        }

                    }
                    Aluno.Add(new Models.Aluno(Convert.ToInt32(valores[0]), Convert.ToInt32(valores[1]), nome));
                }
                #endregion
                while (true)
                {
                    Menu();
                    Console.Write("\nDigite a quantidade de professores orientadores: ");
                    int quantGrupos = Convert.ToInt32(Console.ReadLine());

                    if (quantGrupos <= Aluno.Count && quantGrupos > 0)
                    {
                        List<string> Grupos = new List<string>();
                        Grupos = GrafoCompletoDissimilar.RetornaGrupos(GrafoCompletoDissimilar, quantGrupos);
                        GrafoCompletoDissimilar.ImprimeGrupo(Grupos, Aluno, NomeTemas);

                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        if (quantGrupos < 0)
                            Console.Write("A quantidade de professores é maior que a quatidade de alunos!");
                        else
                            Console.Write("A quantidade de professores é menor que a quatidade de alunos!");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro do tipo: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}
