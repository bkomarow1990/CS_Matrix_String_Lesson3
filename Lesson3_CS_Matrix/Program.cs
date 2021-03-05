using System;
using System.Linq;

namespace Lesson3_CS_Matrix
{
    class Program
    {
        static void fillRandMatrix(ref int[,] m, int right, int left) {
            Random rnd = new Random();
            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    m[i, j] = rnd.Next(right, left + 1);
                }
            }
        }
        static int MaxInMatrix(int[,] m) {
            int max = m[0, 0];
            foreach (int item in m)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }
        static void printMatrix(int[,] m) {
            int count = 0;
            foreach (var item in m)
            {
                Console.Write($"{item} ");
                if (count == m.GetLength(0) - 1)
                {
                    Console.WriteLine();
                    count = 0;
                }
                else {
                    ++count;
                }

            }
            Console.WriteLine();
        }
        static void PrintJugged(int[][] matrix) {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write($"{matrix[i][j]}, ");
                }
                Console.WriteLine();
            }
        }
        static double AvgArray(int[] arr) {
            return arr.Average();
        }
        static int SumJugged(int[][] matrix) {
            int sum = 0;
            foreach (int[] line in matrix)
            {
                foreach (int item in line)
                {
                    sum += item;
                    Console.Write($"{item}, ");
                }
                Console.WriteLine();
            }
            return sum;
        }
        static int[][] createJugged(params int [] cols ) {
            int[][] m = new int[cols.Length][];
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = new int[cols[i]];
            }
            return m;
        }
        static void RevereseByRows(int[][] m) {
            for (int i = 0, j=m.Length -1; i<j; i++, --j)
            {
                var tmp = m[i];
                m[i] = m[j];
                m[j] = tmp;
            }
        }
        static int[] SeperatlyJuged(int [][]arr) {
            int []m = new int[arr.Length];
     
            for (int i = 0; i < arr.Length ; i++)
            {
                m[i] += arr[i].Sum();
            }
            return m;
        }
        static void pasteRow(ref int[][] matrix,int [] arr, int index) {
            if (index < 0 || index> matrix.Length)
            {
                return;
            }
            Array.Resize(ref matrix, matrix.Length + 1);
            int i = matrix.Length-2;
            int []tmp;
            matrix[matrix.Length - 1] = arr;
            while (index<=i)
            {
                tmp = matrix[i];
                matrix[i] = matrix[i + 1];
                matrix[i + 1] = tmp;
                --i;
            }
            // 1 2 3 4
            // 3 4 4
            // paste here
            // 2 4 1 5 6 5
        }
        static void Main(string[] args)
        {
            int[,] matrix = new int[3, 4];
            fillRandMatrix(ref matrix, 2, 99);
            printMatrix(matrix);
            Console.WriteLine("--------------------- 2nd part ---------------------!");
          
            const int rows = 3;
            int[][] m = new int[rows][] {
                new int[4] { 1,2,3,4},
                new [] { 10,20,30},
                new[] { 100,200}
            };
            PrintJugged(m);
            Console.WriteLine(SumJugged(m));
            Console.WriteLine("--------------------- 3th part ---------------------!");
            int[] m2 = new int[] { 100, 23, 456 };
            Console.WriteLine($"Avg : {AvgArray(m2)}");
            int[][] automatrix = createJugged(2, 4, 1, 5, 3);
            RevereseByRows(automatrix);
            PrintJugged(automatrix);
            int [] parr = { 1,2,3,4,5};
            pasteRow(ref automatrix, parr, 2);
            Console.WriteLine();
            PrintJugged(automatrix);
            Console.WriteLine("--------------------- 4th part ---------------------!");
            string text = @"A illia is gai, taki da";
            String []sarr=text.Split(' ');
            Console.WriteLine("--------------------- 5th part ---------------------!");
            Array.Sort(sarr, (v1,v2)=> v1.Length.CompareTo(v2.Length));
            foreach (var item in sarr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------- 6th part ---------------------!");
        }
    }
}
