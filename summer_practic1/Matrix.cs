using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace summer_practic1
{
    public class Matrix
    {
        // поля
        private int n = 3;
        private int m = 3;
        private double[,] matr = new double[3, 3];

        // св-ва
        public int N { get => n; set => n = value; }
        public int M { get => m; set => m = value; }
        public double[,] Matr { get => matr; set => matr = value; }

        public double this[int i, int j] // ввод и вывод эл-а из i строки и j столбца
        {
            get => this.matr[i, j];
            set => this.matr[i, j] = value;
        }

        public Matrix()
        {

        }

        public Matrix(int flag) // для заполнения 0-ми
        {
            if (flag == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matr[i, j] = 0;
                    }
                }
            }
        }

        public Matrix(DataGridView d)
        {
            double[,] result = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result[i, j] = Convert.ToDouble(d[i, j].Value);
                }
            }
            this.matr = result;
        }

        public void CopyMatr (DataGridView d)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    d[i, j].Value = this[i, j];
                }
            }
        }

        public Matrix T() // транспонирование матрицы
        {
            Matrix c = new Matrix();
            for (int i = 0; i < this.n; i++)
            {
                for (int j = 0; j < this.m; j++)
                {
                    c.matr[j, i] = this.matr[i, j];
                }
            }
            return c;
        }

        public double det()
        {
            double res = 0;
            res += this.matr[0, 0] * this.matr[1, 1] * this.matr[2, 2];
            res += this.matr[1, 0] * this.matr[2, 1] * this.matr[0, 2];
            res += this.matr[2, 0] * this.matr[0, 1] * this.matr[1, 2];
            res -= this.matr[2, 0] * this.matr[1, 1] * this.matr[0, 2];
            res -= this.matr[0, 0] * this.matr[2, 1] * this.matr[1, 2];
            res -= this.matr[1, 0] * this.matr[0, 1] * this.matr[2, 2];

            return res;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            Matrix buf = new Matrix(0);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    buf.matr[i, j] = Math.Round(a.matr[i, j] + b.matr[i, j], 2);
                }
            }
            return buf;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            Matrix buf = new Matrix(0);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    buf.matr[i, j] = Math.Round(a.matr[i, j] - b.matr[i, j], 2);
                }
            }
            return buf;
        }

        public static Matrix operator *(Matrix a, double b)
        {
            Matrix buf = new Matrix(0);
            for (int i = 0; i < a.n; i++)
            {
                for (int j = 0; j < a.m; j++)
                {
                    buf.matr[i, j] = Math.Round(a.matr[i, j] * b, 2);
                }
            }
            return buf;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix buf = new Matrix(0);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        buf.Matr[i, j] = Math.Round(a.Matr[i, k] * b.Matr[k, j] + buf.Matr[i, j], 2);
                    }
                }
            }
            return buf;
        }
    }
}
