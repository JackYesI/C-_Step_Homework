using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(2,2);
            Matrix matrix1 = new Matrix(2,2);
            matrix.OutputMatrix();
            Console.WriteLine();
            matrix1.OutputMatrix();
            Matrix matrix2 = 5 * matrix;
            Console.WriteLine();
            Console.WriteLine();
            matrix2.OutputMatrix();
        }
    }
}
