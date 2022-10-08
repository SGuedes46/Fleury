using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafoFleury
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalVertices = 0;
            Grafo grafo = new Grafo();

            string caminho = @"C:\Development\Grafo.txt";
            if (caminho == null)
            {
                Console.WriteLine("Informe o caminho do arquivo");
                caminho = Console.ReadLine();
            }
            
            string[] lines = System.IO.File.ReadAllLines(caminho);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] linha = lines[i].Split(',');
                grafo.AdicionarAresta(linha[0], linha[1]);
                totalVertices++;
            }

            Console.WriteLine("Informe o vertice inicial");
            string verticeInicial = Console.ReadLine();
            grafo.BuscaFleury(verticeInicial, totalVertices);

            Console.ReadKey();
            
        }
        
    }

    
    
}


