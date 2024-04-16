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
            int startStroce = countStroceInFile - TableGraf.ArrayTableGraf.GetLength(0);
            using (StreamReader reader = new StreamReader("historyGraf.txt"))
            {
                needStrings = File.ReadAllLines("historyGraf.txt").Skip(startStroce).ToArray();
                reader.Close();
            }
            
            //for (int i = 0; i < result.GetLength(0); i++)
            //{
            //    for (int j = 0; j < result.GetLength(1); j++)
            //    {
            //        workStroce.Cure
            //    }
            //}
        }
        //string[] ParseStringArray(string[] needStrings) 
        //{
        //    for (int i = 0; i < needStrings.Length; i++)
        //    {
        //        needStrings[0] = needStrings[0].Replace("\t", "");
        //    }
        //}
    }
}
