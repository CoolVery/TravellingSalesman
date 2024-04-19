using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingSalesman.Models;

namespace TravellingSalesman.WorkWithFile
{
    internal class ReadFile
    {
        public static void ReadTableGraf()
        {
            string[] needStrings;
            int[,] result = new int[TableGraf.ArrayTableGraf.GetLength(0) - 1, TableGraf.ArrayTableGraf.GetLength(1) - 1];
            int countStroceInFile = 0;
            string[] linesInFile = File.ReadAllLines("historyGraf.txt");
            countStroceInFile = linesInFile.Length;
            int startStroce = countStroceInFile - result.GetLength(0);
            using (StreamReader reader = new StreamReader("historyGraf.txt"))
            {
                needStrings = File.ReadAllLines("historyGraf.txt").Skip(startStroce).ToArray();
                reader.Close();
            }
            ParseStringArray(needStrings);
        }
        static void ParseStringArray(string[] needStrings)
        {
            int[,] tempArray = new int[TableGraf.ArrayTableGraf.GetLength(0) - 1, TableGraf.ArrayTableGraf.GetLength(1) - 1];
            TableGraf.ArrayTableGraf = tempArray;
            for (int i = 0; i < needStrings.Length; i++)
            {
                string[] splitArrayString = needStrings[i].Split("\t");
                
                for (int j = 0; j < splitArrayString.Length; j++)
                {
                    if (splitArrayString[j] == "M" || splitArrayString[j] == "М")
                    {
                        TableGraf.ArrayTableGraf[i, j] = TableGraf.M;
                    }
                    else TableGraf.ArrayTableGraf[i, j] = Convert.ToInt32(splitArrayString[j]);
                }
            }
        }
    }
}
