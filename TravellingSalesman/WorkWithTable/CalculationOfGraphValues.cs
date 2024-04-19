using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingSalesman.Models;

namespace TravellingSalesman.WorkWithTable
{
    internal class CalculationOfGraphValues
    {
        public static int[] CountMaximumZeroRating()
        {
            int maxElem = 0;
            int indexRowMax = 0;
            int indexColumnMax = 0;
            if (TableGraf.ArrayTableGraf.GetLength(0) != 2)
            {
                int[,] evaluationOfZeroCells = ZeroCellEvaluation();

                for (int i = 0; i < evaluationOfZeroCells.GetLength(0); i++)
                {
                    for (int j = 0; j < evaluationOfZeroCells.GetLength(1); j++)
                    {
                        if (evaluationOfZeroCells[i, j] > maxElem)
                        {
                            maxElem = evaluationOfZeroCells[i, j];
                            indexRowMax = i;
                            indexColumnMax = j;
                        }
                    }
                }
            }
            else
            {
                maxElem = 0;
                indexRowMax = 1;
                indexColumnMax = 1;

            }
            return new int[] { maxElem, indexRowMax, indexColumnMax };
        }
        static int[,] ZeroCellEvaluation()
        {
            int[,] result = new int[TableGraf.ArrayTableGraf.GetLength(0), TableGraf.ArrayTableGraf.GetLength(1)];
            for (int i = 1; i < result.GetLength(0); i++)
            {
                for (int j = 1; j < result.GetLength(1); j++)
                {
                    if (TableGraf.ArrayTableGraf[i, j] == 0)
                    {
                        result[i, j] = CountSumMinValueForZeroCells(i, j);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// Calculates the sum of the minimum values of a row and column
        /// </summary>
        /// <param name="indexRow">Row index of cell zero</param>
        /// <param name="indexColumn">Column index of cell zero</param>
        /// <returns>Sum of minimum row and column values</returns>
        static int CountSumMinValueForZeroCells(int indexRow, int indexColumn)
        {
            List<int> row = new List<int>();
            List<int> column = new List<int>();
            for (int i = 1; i < TableGraf.ArrayTableGraf.GetLength(0); i++)
            {
                if (TableGraf.ArrayTableGraf[indexRow, i] == -1 || i == indexColumn) continue;
                row.Add(TableGraf.ArrayTableGraf[indexRow, i]);
            }
            for (int i = 1; i < TableGraf.ArrayTableGraf.GetLength(1); i++)
            {
                if (TableGraf.ArrayTableGraf[i, indexColumn] == -1 || i == indexRow) continue;
                column.Add(TableGraf.ArrayTableGraf[i, indexColumn]);
            }
            if (row.Min() == TableGraf.M && column.Min() == TableGraf.M)
            {
                return TableGraf.M;
            }
            return (int)(row.Min() + column.Min());
        }
        public static int CountRootWithoutGraf(int root, int maxZeroCall)
        {
            if(maxZeroCall == TableGraf.M) return TableGraf.M;
            else return root + maxZeroCall;
        }
    }
}
