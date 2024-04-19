using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingSalesman.Models;

namespace TravellingSalesman.WorkWithFile
{
    internal class WriteFile
    {
        public static void WriteTableGrafInFile(bool firstWriteFile)
        {
            using (StreamWriter streamWriter = new StreamWriter("historyGraf.txt", firstWriteFile))
            {
                for (int i = 0; i < TableGraf.ArrayTableGraf.GetLength(0); i++)
                {
                    for (int j = 0; j < TableGraf.ArrayTableGraf.GetLength(1); j++)
                    {
                        if (TableGraf.ArrayTableGraf[i, j] == -1) streamWriter.Write("M\t");
                        else streamWriter.Write($"{TableGraf.ArrayTableGraf[i, j]}\t");

                    }
                    streamWriter.WriteLine();
                }
                streamWriter.Close();
            }
            
        }
        public static void WriteTableGrafInFile(int skipIndexRow, int skipIndexColumn, bool firstWriteFile)
        {
            int reverstRootRow = TableGraf.ArrayTableGraf[skipIndexRow, 0];
            int reverstRootColumn = TableGraf.ArrayTableGraf[0, skipIndexColumn];
            int indexReversRowRoot = 0;
            int indexReversColumnRoot = 0;

            for (int i = 1; i < TableGraf.ArrayTableGraf.GetLength(0); i++)
            {
                if (TableGraf.ArrayTableGraf[0, i] == reverstRootRow) indexReversRowRoot = i;
                if (TableGraf.ArrayTableGraf[i, 0] == reverstRootColumn) indexReversColumnRoot = i;
            }
            if (indexReversColumnRoot == 0 && indexReversRowRoot == 0) TableGraf.ArrayTableGraf[indexReversColumnRoot, indexReversRowRoot] = 0;
            else TableGraf.ArrayTableGraf[indexReversColumnRoot, indexReversRowRoot] = TableGraf.M;
            using (StreamWriter streamWriter = new StreamWriter("historyGraf.txt", firstWriteFile))
            {
                for (int i = 0; i < TableGraf.ArrayTableGraf.GetLength(0); i++)
                {                  
                    if (i == skipIndexRow) continue;
                    for (int j = 0; j < TableGraf.ArrayTableGraf.GetLength(1); j++)
                    {
                        if (j == TableGraf.ArrayTableGraf.GetLength(1) - 2 && j+1 == skipIndexColumn)
                        {
                            if (TableGraf.ArrayTableGraf[i, j] == TableGraf.M) streamWriter.Write("M");
                            else streamWriter.Write($"{TableGraf.ArrayTableGraf[i, j]}");
                        }
                        else if (j == skipIndexColumn) continue;

                        else if (j == TableGraf.ArrayTableGraf.GetLength(1) - 1)
                        {
                            if (TableGraf.ArrayTableGraf[i, j] == TableGraf.M) streamWriter.Write("M");
                            else streamWriter.Write($"{TableGraf.ArrayTableGraf[i, j]}");
                        }                        
                        else
                        {
                            if (TableGraf.ArrayTableGraf[i, j] == TableGraf.M) streamWriter.Write("M\t");
                            else streamWriter.Write($"{TableGraf.ArrayTableGraf[i, j]}\t");
                        }
                    }
                    streamWriter.WriteLine();
                }
                streamWriter.Close();
            }

        }
    }
}
