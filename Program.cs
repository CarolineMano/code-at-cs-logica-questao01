using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace Questao01
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanciaPercorrida = 0;
            string distanciasIndividuais = "";
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            int[] percurso;
            int[][] tabelaDistancias;

            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };

            using (var leitorMatriz = new StreamReader($"{desktop}\\matriz.txt"))
            using (var csv = new CsvParser(leitorMatriz, config))
            {
                if (!csv.Read())
                    return;

                var numColunas = csv.Record!.Length;
                tabelaDistancias = new int[numColunas][];

                for (int i = 0; i < numColunas; i++)
                {
                    tabelaDistancias[i] = csv.Record.Select(int.Parse).ToArray();
                    csv.Read();
                }
            }

            using (var leitorCaminho = new StreamReader($"{desktop}\\caminho.txt"))
            using (var csv = new CsvParser(leitorCaminho, config))
            {
                if (!csv.Read())
                    return;

                percurso = csv.Record!.Select(int.Parse).ToArray();
            }

            Console.Write($"A distância percorrida foi de: ");

            for (int i = 0; i < percurso.Length - 1; i++)
            {
                var cidadeAtual = percurso[i] - 1;
                var proximaCidade = percurso[i + 1] - 1;
                distanciaPercorrida += tabelaDistancias[cidadeAtual][proximaCidade];
                distanciasIndividuais += $" {tabelaDistancias[cidadeAtual][proximaCidade]} +";
            }

            Console.Write($"{distanciasIndividuais.Substring(0, distanciasIndividuais.Length - 1)}= {distanciaPercorrida} Km");
        }
    }
}