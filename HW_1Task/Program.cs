using System;

namespace HW_1Task
{
    class Program
    {
        static void PrintJugged(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
        static void FillRandom(ref int[][] matrix, int left , int right)
        {
            Random rnd = new Random();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = rnd.Next(left, right + 1);
                }
            }
        }
        static void upRows(ref int[][] matrix, int pos) {
            if (pos == matrix.Length)
            {
                Console.WriteLine("Nothing to do") ;
                return;
            }
            int[][] tmp = new int[matrix.Length][]; // резервуєм тимчасовий масив
            matrix.CopyTo(tmp, 0);// копіюємо в тимчасовий масив
            for (int i = 0; i < pos; i++)
            {
                matrix[i] = tmp[matrix.Length - i - 1];
                matrix[matrix.Length - i - 1] = tmp[i];
            }

        }
        static void downRows(ref int[][] matrix, int pos)
        {
            if (pos == matrix.Length)
            {
                Console.WriteLine("Nothing to do");
                return;
            }
            int[][] tmp = new int[matrix.Length][]; // резервуєм тимчасовий масив
            matrix.CopyTo(tmp, 0);// копіюємо в тимчасовий масив
            for (int i = 0; i < pos; i++)
            {
                matrix[matrix.Length - i - 1] = tmp[i];
                matrix[i] = tmp[matrix.Length - i - 1];
            }

        }
        static void deleteRowWithIndex(ref int[][] matrix, int index) {
            if (index < 0 || matrix.Length <= index)
            {
                Console.WriteLine("Please, enter correct index");
                return;
            }
            int[][] tmp = new int[matrix.Length][]; // резервуєм тимчасовий масив
            matrix.CopyTo(tmp, 0);// копіюємо в тимчасовий масив
            matrix = new int[matrix.Length - 1][];

            for (int i = 0, j = i; i < matrix.Length; i++)
            {
                if (i==index)
                {
                    ++j;
                }
                matrix[i] = tmp[j];
                ++j;
            }
        }
        
        static void addElemInRows<T>(ref T[][] matrix, T elem)
        {
            //int[][] tmp = new int[matrix.Length][]; // резервуєм тимчасовий масив
            //matrix.CopyTo(tmp, 0);// копіюємо в тимчасовий масив
            for (int i = 0; i < matrix.Length; i++)
            {
                Array.Resize(ref matrix[i], matrix[i].Length + 1);
                matrix[i][matrix[i].Length - 1] = elem;
            }
        }
        static int[][] createJugged(params int[] cols)
        {
            int[][] m = new int[cols.Length][];
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = new int[cols[i]];
            }
            return m;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------Fill random-----------------");

            int[][] matrix = createJugged(1,5,6,2,4,8,1);
            FillRandom(ref matrix, 1 ,100);
            PrintJugged(matrix);
            Console.WriteLine( "UpRows" );
            upRows(ref matrix, 2);
            PrintJugged(matrix);
            Console.WriteLine( "DownRows" );
            downRows(ref matrix, 2);
            PrintJugged(matrix);
            Console.WriteLine();
            deleteRowWithIndex(ref matrix, 3);
            Console.WriteLine( "Deleted element " );
            PrintJugged(matrix);
            Console.WriteLine("Add element in rows");
            addElemInRows(ref matrix, 228);
            PrintJugged(matrix);
        }
    }
}
