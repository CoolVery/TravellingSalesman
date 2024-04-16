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
        public static void WriteTableGrafInFile(int skipIndexRow, int skipIndexColumn)
        {
            using (StreamWriter streamWriter = new StreamWriter("historyGraf.txt", true))
            {
                for (int i = 0; i < TableGraf.ArrayTableGraf.GetLength(0); i++)
                {                  
                    if (i == skipIndexRow) continue;
                    for (int j = 0; j < TableGraf.ArrayTableGraf.GetLength(1); j++)
                    {
                        if (j == skipIndexColumn) continue;
                        if (TableGraf.ArrayTableGraf[i, j] == -1) streamWriter.Write("M\t");
                        else streamWriter.Write($"{TableGraf.ArrayTableGraf[i, j]}\t");

                    }
                    streamWriter.WriteLine();
                }
                streamWriter.Close();
            }

        }
    }
}
