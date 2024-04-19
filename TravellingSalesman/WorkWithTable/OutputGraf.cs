using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingSalesman.Models;

namespace TravellingSalesman.WorkWithTable
{
    internal class OutputGraf
    {
        public static void PrintGraf(int root)
        {
            Console.WriteLine($"Корень - {root}");
        }
        public static void PrintWithGraf(int root, int[] arrayMaxZeroCellAndIndexs)
        {
            Console.WriteLine($"Идем из {TableGraf.ArrayTableGraf[arrayMaxZeroCellAndIndexs[1],0]} -> {TableGraf.ArrayTableGraf[0, arrayMaxZeroCellAndIndexs[2]]} | Стоимость {root}");
        }
        public static void PrintWithoutGraf(int root, int[] arrayMaxZeroCellAndIndexs)
        {
            Console.WriteLine($"Идем из {TableGraf.ArrayTableGraf[arrayMaxZeroCellAndIndexs[1], 0]} -> {TableGraf.ArrayTableGraf[0, arrayMaxZeroCellAndIndexs[2]]} без него| Стоимость {root}");
        }
    }
}
