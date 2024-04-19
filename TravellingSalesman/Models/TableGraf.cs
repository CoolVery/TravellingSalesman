using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesman.Models
{
    internal class TableGraf
    {
        static int m = int.MaxValue;
        static int[,] arrayTableGraf = { { 0, 1, 2, 3, 4}, { 1, m, 2, 1, 5 }, { 2, 3, m, 2, 1}, { 3, 4, 1, m, 2}, { 4, 5, 3, 3, m } };

        public static int[,] ArrayTableGraf { get => arrayTableGraf; set => arrayTableGraf = value; }
        public static int M { get => m; set => m = value; }

        public static void PrintTable()
        {
            for (int i = 0; i < arrayTableGraf.GetLength(0); i++)
            {
                for (int j = 0; j < arrayTableGraf.GetLength(1); j++)
                {
                    Console.Write("{0,5:0}", arrayTableGraf[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
