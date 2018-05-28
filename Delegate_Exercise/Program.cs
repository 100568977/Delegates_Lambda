using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using FileParserNetStandard;
using ObjectLibrary;

public delegate List<List<string>> Parser(List<List<string>> data);

namespace Delegate_Exercise
{
    internal class Delegate_Exercise
    {
        public static void Main(string[] args)
        {
            DataParser dataParser = new DataParser();
            CsvHandler csvHandler = new CsvHandler();
            FileHandler fileHandler = new FileHandler();
            string csvReadPath = @"C:\Users\kbke2\Desktop\TAFE 2018\Dev Ops\Week 7\Files\data.csv";
            string csvWritePath = @"C:\Users\kbke2\Desktop\TAFE 2018\Dev Ops\Week 7\Files\processed_data.csv";

            Func<List<List<string>>, List<List<string>>> processBlueprint = new Func<List<List<string>>, List<List<string>>>(dataParser.StripQuotes);
            processBlueprint += dataParser.StripWhiteSpace;
            processBlueprint += StripHash;

            csvHandler.ProcessCsv(csvReadPath, csvWritePath, processBlueprint);
        }
        public static List<List<string>> StripHash(List<List<string>> data)
        {
            for (int line = 0; line < data.Count; line++)
            {
                for (int dataBlock = 0; dataBlock < data[line].Count; dataBlock++)
                {
                    data[line][dataBlock] = data[line][dataBlock].Trim('#');
                }
            }
            return data;
        }
    }
}