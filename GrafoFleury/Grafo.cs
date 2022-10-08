using System;
using System.Collections.Generic;
using System.IO;

namespace GrafoFleury
{
    internal class Grafo
    {

        private Dictionary<string, List<string>> _vertices = new Dictionary<string, List<string>>();
        public void AdicionarVertice(string vertice)
        {
            if (!_vertices.ContainsKey(vertice))
            {
                _vertices.Add(vertice, new List<string>());
            }
        }

        public void AdicionarAresta(string vertice1, string vertice2)
        {

            if (!_vertices.ContainsKey(vertice1))
            {
                AdicionarVertice(vertice1);
            }
            if (!_vertices.ContainsKey(vertice2))
            {
                AdicionarVertice(vertice2);
            }

            _vertices[vertice1].Add(vertice2);
            _vertices[vertice2].Add(vertice1);
        }

        public void BuscaFleury(string vertice, int totalArestas)
        {
            string sName = @"C:\Development\ListaFleury.html";
            string sName2 = @"C:\Development\ListaFleury.txt";

            try
            {
                if (File.Exists(sName))
                {
                    File.Delete(sName);
                }

                // Create a new file     
                using (StreamWriter sw = File.CreateText(sName))
                using (StreamWriter sw2 = File.CreateText(sName2))
                {
                    sw.WriteLine("<h1 align='center'>=====Busca de Fleury=====</h1><p></p>");
                    sw2.WriteLine("=====Busca de Fleury=====");

                    int VerticesImpar = 0;
                    string VerticeRecomendado = "";
                    foreach (var v in _vertices)
                    {
                        if (v.Value.Count % 2 != 0)
                        {
                            VerticesImpar++;
                            if (vertice != VerticeRecomendado)
                                VerticeRecomendado = v.Key;
                        }
                        if (VerticesImpar > 2)
                        {
                            sw.WriteLine("<p>Não é possivel encontrar o caminho de Fleury pois tem 3 vertices ou mais com grau impar</p>");
                            sw2.WriteLine("Não é possivel encontrar o caminho de Fleury pois tem 3 vertices ou mais com grau impar");
                            Console.WriteLine("Não é possivel encontrar o caminho de Fleury pois tem 3 vertices ou mais com grau impar");
                            return;
                        }
                    }

                    var pilha = new Stack<string>();
                    var pilhaaux = new Stack<string>();
                    if (VerticesImpar <= 2 && VerticesImpar > 0 && VerticeRecomendado != vertice)
                    {
                        sw.WriteLine("<p>O vertice recomendado para iniciar o caminho de Fleury é {0} portanto não iniciará por {1}</p>", VerticeRecomendado, vertice);
                        sw2.WriteLine("O vertice recomendado para iniciar o caminho de Fleury é {0} portanto não iniciará por {1}", VerticeRecomendado, vertice);
                        Console.WriteLine("O vertice recomendado para iniciar o caminho de Fleury é {0} portanto não iniciará por {1}", VerticeRecomendado, vertice);
                        pilha.Push(VerticeRecomendado);
                    }
                    else
                    {
                        pilha.Push(vertice);
                    }


                    while (pilha.Count > 0)
                    {

                        var verticeAtual = pilha.Peek();
                        var arestas = _vertices[verticeAtual];

                        if (arestas.Count == 0)
                        {
                            pilhaaux.Push(pilha.Pop());
                        }
                        else
                        {
                            var proximoVertice = arestas[0];
                            _vertices[verticeAtual].Remove(proximoVertice);
                            _vertices[proximoVertice].Remove(verticeAtual);
                            pilha.Push(proximoVertice);
                        }
                    }
                    Console.WriteLine();
                    sw.WriteLine("Fleury: ");
                    sw2.WriteLine("Fleury: ");
                    Console.WriteLine("Fleury: ");

                    string saida;

                    while (pilhaaux.Count > 0)
                    {
                        if (pilhaaux.Count > 1)
                        {
                            saida = pilhaaux.Pop();
                            Console.Write(saida + " / ");
                            sw.Write(saida + " / ");
                            sw2.Write(saida + " / ");
                        }
                        else
                        {
                            saida = pilhaaux.Pop();
                            Console.Write(saida);
                            sw.Write(saida);
                            sw2.Write(saida);

                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }

    }
}
