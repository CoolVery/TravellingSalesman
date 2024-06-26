﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingSalesman.Models;
using TravellingSalesman.WorkWithFile;
using TravellingSalesman.WorkWithTable;

namespace TravellingSalesman.WorkWithUser
{
    internal class MethodsForUser
    {
        /// <summary>
        /// Input data in table graf
        /// </summary>
        public static void InputTable()
        {
            Console.WriteLine("Введите количество графов");
            int countGrafs = Convert.ToInt32(Console.ReadLine());
            int[,] arrayAll = new int[countGrafs + 1, countGrafs + 1];
            for (int i = 1; i < arrayAll.GetLength(0); i++)
            {
                Console.WriteLine($"Введите значения строки {i} через пробел");
                string rowValue = Console.ReadLine();
                string[] elementRow = rowValue.Split(" ");
                for (int j = 1; j < arrayAll.GetLength(1); j++)
                {
                    if (elementRow[j - 1] == "М" || elementRow[j - 1] == "M") arrayAll[i, j] = -1;
                    else arrayAll[i, j] = Convert.ToInt32(elementRow[j - 1]);
                }
            }
            for (int i = 0; i < arrayAll.GetLength(0); i++)
            {
                arrayAll[0, i] = i;
                arrayAll[i, 0] = i;
            }
            TableGraf.ArrayTableGraf = arrayAll;
        }
        public static void MainCicleWork()
        {
            int sumRowReductions = Reductions.StringReduction();
            int sumColumnReductions = Reductions.ColumnReduction();
            int startRoot = sumColumnReductions + sumRowReductions;
            int[] arrayMaxZeroCellAndIndexs = CalculationOfGraphValues.CountMaximumZeroRating();
            WriteFile.WriteTableGrafInFile(arrayMaxZeroCellAndIndexs[1], arrayMaxZeroCellAndIndexs[2], false);
            OutputGraf.PrintGraf(startRoot);
            while (Checks.ChecksLenghtTable())
            {
                ReadFile.ReadTableGraf();
                sumRowReductions = Reductions.StringReduction();
                sumColumnReductions = Reductions.ColumnReduction();
                int newRoot = startRoot + sumColumnReductions + sumRowReductions;
                int newRootWithoutGraf = CalculationOfGraphValues.CountRootWithoutGraf(startRoot, arrayMaxZeroCellAndIndexs[0]);

                arrayMaxZeroCellAndIndexs = CalculationOfGraphValues.CountMaximumZeroRating();
                WriteFile.WriteTableGrafInFile(arrayMaxZeroCellAndIndexs[1], arrayMaxZeroCellAndIndexs[2], true);

                if (newRoot < newRootWithoutGraf)
                {
                    OutputGraf.PrintWithGraf(newRoot, arrayMaxZeroCellAndIndexs);
                    startRoot = newRoot;
                    
                }
                else if (newRootWithoutGraf < newRoot) 
                {
                    OutputGraf.PrintWithoutGraf(newRoot, arrayMaxZeroCellAndIndexs);
                    startRoot = newRootWithoutGraf;
                   
                }
               
            }
        }
    }
}
