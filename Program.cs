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
            var percurso = new List<int>();
            var tabelaDistancias = new int[5, 5];

            CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = ","
            };

            using (var leitorMatriz = new StreamReader($"{desktop}\\matriz.txt"))
            using (var csv = new CsvReader(leitorMatriz, config))
            {
                var linha = 0;
                var coluna = 0;
                while (csv.Read())
                {
                    for (int i = 0; csv.TryGetField<int>(i, out var cidade); i++)
                    {
                        coluna = i % 5;
                        tabelaDistancias[linha, coluna] = cidade;                            
                    }
                    linha++;
                }
            }

            using (var leitorCaminho = new StreamReader($"{desktop}\\caminho.txt"))
            using (var csv = new CsvReader(leitorCaminho, config))
            {
                while (csv.Read())
                {
                    for (int i = 0; csv.TryGetField<int>(i, out var cidade); i++)
                    {
                        percurso.Add(cidade);
                    }
                }
            }

            Console.Write($"A distância percorrida foi de: ");

            for (int i = 0; i < percurso.Count - 1; i++)
            {
                var cidadeAtual = percurso[i] - 1;
                var proximaCidade = percurso[i + 1] - 1;
                distanciaPercorrida += tabelaDistancias[cidadeAtual, proximaCidade];
                distanciasIndividuais += $" {tabelaDistancias[cidadeAtual, proximaCidade]} +";
            }

            Console.Write($"{distanciasIndividuais.Substring(0, distanciasIndividuais.Length - 1)}= {distanciaPercorrida} Km");
        }
    }
}