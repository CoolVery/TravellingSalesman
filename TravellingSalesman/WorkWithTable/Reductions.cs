using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingSalesman.Models;

namespace TravellingSalesman.WorkWithTable
{
    internal class Reductions
    {
        /// <summary>
        /// String reduction method. Reduces rows from a graph table
        /// </summary>
        /// <returns>Returns a Sum of row reduction values</returns>
        public static int StringReduction()
        {
            List<int> listReductionRow = new List<int>();
            for (int i = 1; i < TableGraf.ArrayTableGraf.GetLength(0); i++)
            {
                List<int> listRowValue = new List<int>();
                //Fills the sheet with row values except -1
                for (int j = 1; j < TableGraf.ArrayTableGraf.GetLength(1); j++)
                {
                    if (TableGraf.ArrayTableGraf[i, j] == -1) continue;
                    else listRowValue.Add(TableGraf.ArrayTableGraf[i, j]);
                }
                //Finds and adds the minimum value to the string reduction list
                int minValue = listRowValue.Min();
                listReductionRow.Add(minValue);
                //Subtracts the minimum value from each row
                for (int j = 1; j < TableGraf.ArrayTableGraf.GetLength(1); j++)
                {
                    if (TableGraf.ArrayTableGraf[i, j] == -1) continue;
                    TableGraf.ArrayTableGraf[i, j] -= minValue;
                }
            }
            return listReductionRow.Sum();
        }
        /// <summary>
        /// Column reduction method. Reduces columns from a graph table
        /// </summary>
        /// <returns>Returns a Sum of column reduction values</returns>
        public static int ColumnReduction()
        {
            List<int> listReductionColumn = new List<int>();
            for (int i = 1; i < TableGraf.ArrayTableGraf.GetLength(1); i++)
            {
                List<int> listColumnValue = new List<int>();
                //Fills the sheet with column values except -1
                for (int j = 1; j < TableGraf.ArrayTableGraf.GetLength(0); j++)
                {
                    if (TableGraf.ArrayTableGraf[j, i] == -1) continue;
                    else listColumnValue.Add(TableGraf.ArrayTableGraf[j, i]);
                }
                //Finds and adds the minimum value to the string reduction list
                int minValue = listColumnValue.Min();
                listReductionColumn.Add(minValue);
                //Subtracts the minimum value from each column
                for (int j = 1; j < TableGraf.ArrayTableGraf.GetLength(0); j++)
                {
                    if (TableGraf.ArrayTableGraf[j, i] == -1) continue;
                    TableGraf.ArrayTableGraf[j, i] -= minValue;
                }
            }
            return listReductionColumn.Sum();
        }
    }
}
