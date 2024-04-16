using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellingSalesman.Models;

namespace TravellingSalesman.WorkWithTable
{
    internal class Checks
    {
        public static bool ChecksLenghtTable()
        {
            if (TableGraf.ArrayTableGraf.GetLength(0) == 1) return false;
            else return true;
        }
    }
}
