using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_final_Grafos.Models
{
    public class Grafo
    {
        public Grafo(int quant_vertices, int[] vertice_v1, int[] vertice_v2, int[] peso_aresta)
        {
            this.quant_vertices = quant_vertices;
            this.vertice_v1 = vertice_v1;
            this.vertice_v2 = vertice_v2;
            this.peso_aresta = peso_aresta;
        }

        private int Quant_vertices;
        private int[] Vertice_v1;
        private int[] Vertice_v2;
        private int[] Peso_aresta;

        public int quant_vertices
        {
            get { return Quant_vertices; }
            set { Quant_vertices = value; }
        }
        public int[] vertice_v1
        {
            get { return Vertice_v1; }
            set { Vertice_v1 = value; }
        }
        public int[] vertice_v2
        {
            get { return Vertice_v2; }
            set { Vertice_v2 = value; }
        }
        public int[] peso_aresta
        {
            get { return Peso_aresta; }
            set { Peso_aresta = value; }
        }
        public int getGrau(int vertice) //Retorna o grau de um vértice
        {
            int cont = 0; //Contador para contar o grau do vertice
            for (int i = 0; i < peso_aresta.Length; i++) //Conta quantas arestas incidem no vértice
            {
                if ((this.vertice_v1[i] == vertice || this.vertice_v2[i] == vertice))
                    cont++;
            }
            return cont;
        }
        public Grafo getAGMKruskal(int vertice) //Retorna a Árvore Geradora Mínima pelo Algoritmo de Kruskal
        {
            List<int[]> ListaArestas = new List<int[]>();
            List<int[]> AGM = new List<int[]>();

            int nincluidos = 0;
            int cont = 0;

            int pos_menorPeso = 0;

            for (int i = 0; i < peso_aresta.Length; i++) //Identifica qual a posição da aresta de menor peso
            {
                if (vertice_v1[i] == vertice || vertice_v2[i] == vertice)
                {
                    if (peso_aresta[i] < peso_aresta[pos_menorPeso])
                        pos_menorPeso = i;
                }
            }

            for (int i = 0; i < peso_aresta.Length; i++) //Preenche em uma lista os valores dos vetores do grafo
                ListaArestas.Add(new int[] { vertice_v1[i], vertice_v2[i], peso_aresta[i] });

            //Adiciona na lista AGM a aresta de menor peso
            AGM.Add(new int[] { ListaArestas[pos_menorPeso][0], ListaArestas[pos_menorPeso][1], ListaArestas[pos_menorPeso][2] });

            //Remove da lista a aresta de menor peso
            ListaArestas.RemoveAt(pos_menorPeso);

            ListaArestas = ListaArestas.OrderBy(item => item[2]).ToList();

            while (nincluidos < quant_vertices - 2) //Algoritmo de Kruskal
            {
                if (!verifica_caminho(AGM, ListaArestas[cont][0], ListaArestas[cont][1]))
                {
                    AGM.Add(new int[] { ListaArestas[cont][0], ListaArestas[cont][1], ListaArestas[cont][2] });
                    nincluidos++;
                }
                cont++;
            }
            int[] vetor_v1 = new int[AGM.Count];
            int[] vetor_v2 = new int[AGM.Count];
            int[] vetor_peso = new int[AGM.Count];

            for (int i = 0; i < AGM.Count; i++) //Imprime na tela a fila da ordem de inserção, e preenche nos vetores os valores da árvore geradora mínima
            {
                int[] valores = AGM[i];
                vetor_v1[i] = valores[0];
                vetor_v2[i] = valores[1];
                vetor_peso[i] = valores[2];

            }

            //Cria o grafo da árvore geradora mínima
            Grafo grafo_arvore_geradora = new Grafo(quant_vertices, vetor_v1, vetor_v2, vetor_peso);
            return grafo_arvore_geradora;
        }
        private bool verifica_caminho(List<int[]> Lista_AGM, int v1, int v2) //Verifica se há uma aresta ligada ao vértices v1 e uma outra ligada ao vértice v2
        {
            int vertice_caminho = v1;

            for (int i = 0; i < Lista_AGM.Count; i++)
            {
                if (vertice_caminho == Lista_AGM[i][0])
                    vertice_caminho = Lista_AGM[i][1];
                else if (vertice_caminho == Lista_AGM[i][1])
                    vertice_caminho = Lista_AGM[i][0];
            }

            if (vertice_caminho == v1) return false;
            else
            {
                for (int y = 0; y < Lista_AGM.Count; y++)
                {
                    if (vertice_caminho == v2) return true;
                    else
                    {
                        for (int i = 0; i < Lista_AGM.Count; i++)
                        {
                            if (vertice_caminho == Lista_AGM[i][0])
                                vertice_caminho = Lista_AGM[i][1];
                            else if (vertice_caminho == Lista_AGM[i][1])
                                vertice_caminho = Lista_AGM[i][0];
                        }
                    }

                }
                return false;
            }
        }

        private void QuickSort(int[] v1, int[] v2, int[] peso, int left, int right) //Ordena os vetores em ordem crescente
        {
            int i = left, j = right;
            int pivot = peso[(left + right) / 2];

            while (i <= j)
            {
                while (peso[i].CompareTo(pivot) < 0)// if peso[i] == pivot = 1 else -1
                {
                    i++;
                }

                while (peso[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    //Troca
                    int tmp = peso[i];
                    peso[i] = peso[j];
                    peso[j] = tmp;

                    int tmp2 = v1[i];
                    v1[i] = v1[j];
                    v1[j] = tmp2;

                    int tmp3 = v2[i];
                    v2[i] = v2[j];
                    v2[j] = tmp3;

                    i++;
                    j--;
                }
            }

            //Chamadas Recursivas
            if (left < j)
            {
                QuickSort(v1, v2, peso, left, j);
            }

            if (i < right)
            {
                QuickSort(v1, v2, peso, i, right);
            }
        }

        private List<string> BuscaProfundidade(int vertice)
        {
            List<int[]> Dados = new List<int[]>();
            List<string> ListaGruposdeConexos = new List<string>();

            //Inicializando 
            // Onde 
            // ~> dados[x][0] = vertice
            // ~> dados[x][1] = cor
            // ~> dados[x][2] = predecessor 

            for (int i = 0; i < quant_vertices; i++)
            {
                Dados.Add(new int[] { (i + 1), 0, -1, 0 });
            }

            for (int i = 0; i < quant_vertices; i++)
            {
                string grupo = "";

                Dados = PreencheDFS(Dados, i);

                for (int quant = 0; quant < Dados.Count; quant++)
                {
                    if (Dados[quant][1] == 2 && Dados[quant][3] == 0)
                    {
                        grupo += Dados[quant][0] + ";";
                        Dados[quant][3] = 1;
                    }
                }
                if (grupo != "")
                    ListaGruposdeConexos.Add(grupo);
            }

            return ListaGruposdeConexos;

        }
        private List<int[]> PreencheDFS(List<int[]> Dados, int posicao)
        {
            // Adiciona todos os adjacentes do vertice enviado (Dados[x][0])
            int[] adjacentes = PreencheAdjacentes(Dados[posicao][0]);

            // Adiciona a cor azul no vertice
            Dados[posicao][1] = 1;

            for (int q = 0; q < adjacentes.Length; q++)
            {
                int pos_adjacente = 0;
                for (int k = 0; k < Dados.Count; k++)
                {
                    if (adjacentes[q] == Dados[k][0] || adjacentes[q] == Dados[k][0])
                    {
                        pos_adjacente = k;
                        break;
                    }
                }
                if (Dados[pos_adjacente][1] == 0)
                {
                    Dados[pos_adjacente][2] = pos_adjacente;
                    Dados = PreencheDFS(Dados, pos_adjacente);
                }
            }

            // Recebe cor vemelha
            Dados[posicao][1] = 2;
            return Dados;
        }
        
        private int[] PreencheAdjacentes(int u) //Preenche todos os vértices adjacentes de u em um vetor
        {
            int[] adjacentes = new int[getGrau(u)];
            int cont_adjacente = 0;

            for (int i = 0; ((i < peso_aresta.Length) && (cont_adjacente != adjacentes.Length)); i++) //adiciona ao vetor os vértices adjacentes a u + 1(vertices)
            {
                if (vertice_v2[i] == u)
                {
                    adjacentes[cont_adjacente] = vertice_v1[i];
                    cont_adjacente++;
                }
                else if (vertice_v1[i] == u)
                {
                    adjacentes[cont_adjacente] = vertice_v2[i];
                    cont_adjacente++;
                }
            }

            return adjacentes;
        }
        private List<int[]> PreencheArestasAdjacentes(int vertice)//retorna as arestas adjacentes ao vertice
        {
            List<int[]> Adjacentes = new List<int[]>();

            for (int i = 0; i < vertice_v1.Length; i++)
            {
                if (vertice == vertice_v1[i])
                    Adjacentes.Add(new int[] { vertice_v1[i], vertice_v2[i], peso_aresta[i] });

                else if (vertice == vertice_v2[i])
                    Adjacentes.Add(new int[] { vertice_v2[i], vertice_v1[i], peso_aresta[i] });
            }
            return Adjacentes;
        }
        public List<string> RetornaGrupos(Grafo grafoCompleto, int k)
        {
            Grafo AGM_grafoCompleto = grafoCompleto.getAGMKruskal(1);

            List<int[]> ListaAGM = new List<int[]>();
            List<string> Grupos = new List<string>();

            int contNulos = 0;

            for (int i = 0; i < AGM_grafoCompleto.Vertice_v1.Length; i++)
            {
                ListaAGM.Add(new int[] { AGM_grafoCompleto.vertice_v1[i], AGM_grafoCompleto.vertice_v2[i], AGM_grafoCompleto.peso_aresta[i] });
            }

            for (int j = 0; j < k - 1; j++)
            {
                int PosMaiorPeso = 0;

                for (int i = 0; i < ListaAGM.Count; i++)
                {
                    if (ListaAGM[PosMaiorPeso][2] < ListaAGM[i][2])
                        PosMaiorPeso = i;
                }

                if (AGM_grafoCompleto.getGrau(ListaAGM[PosMaiorPeso][0]) == 1)
                {
                    Grupos.Add(ListaAGM[PosMaiorPeso][0].ToString());
                    contNulos++;
                }
                else if (AGM_grafoCompleto.getGrau(ListaAGM[PosMaiorPeso][1]) == 1)
                {
                    Grupos.Add(ListaAGM[PosMaiorPeso][1].ToString());
                    contNulos++;
                }

                ListaAGM.RemoveAt(PosMaiorPeso);
            }

            int[] vertice1 = new int[ListaAGM.Count + contNulos];
            int[] vertice2 = new int[ListaAGM.Count + contNulos];
            int[] peso_aresta = new int[ListaAGM.Count + contNulos];

            int l;

            for (l = 0; l < ListaAGM.Count; l++)
            {
                vertice1[l] = ListaAGM[l][0];
                vertice2[l] = ListaAGM[l][1];
                peso_aresta[l] = ListaAGM[l][2];
            }

            int m = 0;
            for (int j = l; j < l + contNulos; j++)
            {
                vertice1[j] = Convert.ToInt32(Grupos[m]);
                vertice2[j] = 0;
                peso_aresta[j] = 0;
                m++;
            }

            Grafo GrafoGrupos = new Grafo(AGM_grafoCompleto.quant_vertices, vertice1, vertice2, peso_aresta);

            Grupos = GrafoGrupos.BuscaProfundidade(Vertice_v1[0]);

            return Grupos;
        }
        public void ImprimeGrupo(List<string> Grupos, List<Aluno> Alunos, List<string[]> Tema)
        {
            int id;
            Aluno aluno = new Aluno(0, 0, "0");

            for (int i = 0; i < Grupos.Count; i++)
            {
                Console.WriteLine($"\n\nGrupo {i + 1}:");

                string[] grupoUnitario = Grupos[i].Split(';');
                for (int j = 0; j < grupoUnitario.Length - 1; j++)
                {
                    id = Convert.ToInt32(grupoUnitario[j]);
                    for (int l = 0; l < Alunos.Count; l++)
                    {
                        if (Alunos[l].Cod_tema == Convert.ToInt32(Tema[id - 1][0]))
                        {
                            aluno = Alunos[l];
                            break;
                        }
                    }

                    Console.WriteLine($"Aluno: {aluno.Cod_aluno}");
                    Console.WriteLine($"Tema: {aluno.Nome_tema}");
                    Console.WriteLine("----------------------------------------------------------");
                }
            }
        }
    }
}
