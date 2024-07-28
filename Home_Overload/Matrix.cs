using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Overload
{
    internal class Matrix
    {
        private int n;
        private int m;
        private int[,] data;
        public Matrix() {}
        public Matrix(int n = 1, int m = 1)
        {
            this.n = n;
            this.m = m;
            data = new int[n, m];
            InputMatrix();
        }
        public int N { get { return n; } }
        public int M { get { return m; } }
        private void InputMatrix()
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    data[i, j] = rand.Next(10);
                }
            }
        }
        public void OutputMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{data[i,j]} \t");
                }Console.WriteLine();
            }
        }
        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (!(left.n == right.n && left.m == right.m))
            {
                Matrix result = new Matrix();
                return result;
            }
            Matrix result_ = new Matrix(left.N, right.M);
            for (int i = 0; i < left.n; i++)
            {
                for (int j = 0; j < left.m; j++)
                {
                    result_.data[i,j] = left.data[i,j] + right.data[i,j];
                }

            }
            return result_;
        }
        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (!(left.n == right.n && left.m == right.m))
            {
                Matrix result = new Matrix();
                return result;
            }
            Matrix result_ = new Matrix(left.N, right.M);
            for (int i = 0; i < left.n; i++)
            {
                for (int j = 0; j < left.m; j++)
                {
                    result_.data[i, j] = left.data[i, j] - right.data[i, j];
                }

            }
            return result_;
        }
        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (!((left.n == right.m) || (left.n == right.n && left.m == right.m)))
            {
                Matrix result = new Matrix();
                return result;
            }
            Matrix result_ = new Matrix(left.N, right.M);
            for (int i = 0; i < left.n; i++)
            {
                for (int j = 0; j < right.m; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < left.m; k++)
                    {
                        sum += left.data[i, k] * right.data[k, j];
                    }
                    result_.data[i, j] = sum;
                }
            }
            return result_;
        }
        public static Matrix operator *(Matrix left, int right)
        {
            Matrix result_ = new Matrix(left.N, left.M);
            for (int i = 0; i < left.n; i++)
            {
                for (int j = 0; j < left.m; j++)
                {
                    result_.data[i, j] = left.data[i,j] * right;
                }
            }
            return result_;
        }
        public static Matrix operator *(int right, Matrix left)
        {
            Matrix result_ = new Matrix(left.N, left.M);
            for (int i = 0; i < left.n; i++)
            {
                for (int j = 0; j < left.m; j++)
                {
                    result_.data[i, j] = left.data[i, j] * right;
                }
            }
            return result_;
        }
        public static bool operator ==(Matrix left, Matrix right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Matrix left, Matrix right)
        {
            return !(left == right);
        }
        public override bool Equals(object obj)
        {
            Matrix matrix = obj as Matrix;
            if (matrix == null)
            {
                return false;
            }
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    if (this.data[i,j] != matrix.data[i,j]) return false;
                }
            }
            return true;
        }
    }
}
