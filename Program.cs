using System;
using System.Linq;

namespace Questao01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] tabelaDistancias = new int[5,5];
            int[] percurso;
            int distanciaPercorrida = 0;
            string distanciasIndividuais = "";

            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    Console.WriteLine($"Informe a distância da cidade {i + 1} à cidade {j + 1}");
                    int.TryParse(Console.ReadLine(), out tabelaDistancias[i, j]);
                    tabelaDistancias[j, i] = tabelaDistancias[i, j];
                }
            }

            Console.Write("Informe as cidades do percurso separadas por vírgula:");
            var entradaUsuario = Console.ReadLine()!.Split(',');
            percurso = entradaUsuario.Select(x => int.Parse(x)).ToArray();

            Console.Write($"A distância percorrida foi de: ");

            for (int i = 0; i < percurso.Length - 1; i++)
            {
                var cidadeAtual = percurso[i] - 1;
                var proximaCidade = percurso[i+1] - 1;
                distanciaPercorrida += tabelaDistancias[cidadeAtual, proximaCidade];
                distanciasIndividuais += $" {tabelaDistancias[cidadeAtual, proximaCidade]} +";
            }

            Console.Write($"{distanciasIndividuais.Substring(0, distanciasIndividuais.Length - 1)}= {distanciaPercorrida} Km");
        }
    }
}