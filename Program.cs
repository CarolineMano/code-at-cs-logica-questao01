using System;
using System.IO;
using System.Linq;

namespace Questao01
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // int[][] tabelaDistancias;
            // int[] percurso;
            int distanciaPercorrida = 0;
            string distanciasIndividuais = "";
            
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var tabelaDistancias = File.ReadAllLines($"{desktop}\\matriz.txt")
                                    .Select(l => l.Split(',').Select(i => int.Parse(i)).ToArray())
                                    .ToArray();

            // var percurso = File.ReadAllLines($"{desktop}\\caminho.txt")
            //                 .Select(l => l.Split(',').Select(i => int.Parse(i)).ToArray());

            var percurso = File.ReadAllLines($"{desktop}\\caminho.txt")[0].Split(",")
                            .Select(i => int.Parse(i)).ToArray();

            Console.Write($"A distância percorrida foi de: ");

            for (int i = 0; i < percurso.Length - 1; i++)
            {
                var cidadeAtual = percurso[i] - 1;
                var proximaCidade = percurso[i+1] - 1;
                distanciaPercorrida += tabelaDistancias[cidadeAtual][proximaCidade];
                distanciasIndividuais += $" {tabelaDistancias[cidadeAtual][proximaCidade]} +";
            }

            Console.Write($"{distanciasIndividuais.Substring(0, distanciasIndividuais.Length - 1)}= {distanciaPercorrida} Km");
        }
    }
}