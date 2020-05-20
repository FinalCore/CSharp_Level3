using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Examples_from_Webinar.StartAsync("Hello, World!"); 
            //Console.ReadKey();

            //Задание 1. Даны две двумерных матрицы размерностью 100х100 каждая. Задача: написать приложение, производящее их параллельное умножение. Матрицы заполняются случайными целыми числами от 0 до 10.

            // Создаем две матрицы и заполняем их псевдослучайными числами
            var matrix1 = MatrixFilling(16);
            Thread.Sleep(200);
            var matrix2 = MatrixFilling(16);
            DisplayMatrix(matrix1);
            Console.WriteLine(new string('_', 20));
            DisplayMatrix(matrix2);
            Console.WriteLine(new string('_', 20));
            MatrixMultAsyncStart(matrix1, matrix2);
            Console.ReadKey();
        }

        //public static /*async*/ void MatrixMultAsyncStart(int[,] a, int[,] b)
        //{
        //    int[,] outputMatrix = new int[a.GetLength(0), a.GetLength(0)];
        //    for (int i = 0; i < a.GetLength(0); i++)
        //    {                
        //        for (int j = 0; j < a.GetLength(1); j++)
        //        {
        //            int sum = 0;
        //            for (int k = 0; k < a.GetLength(0); k++)
        //            {
        //                var result = /*await Task.Run(() => */a[k, j] * b[i, k];
        //                sum += result;
        //            }
        //            outputMatrix[i, j] = sum;
        //        }
        //    }       
        //}

        public static async void MatrixMultAsyncStart(int[,] a, int[,] b)
        {
            var stopWatch = Stopwatch.StartNew();
            
            int[,] outputMatrix = new int[a.GetLength(0), a.GetLength(0)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                await Task.Run(() =>
                {
                    Console.WriteLine("Асинхронная задача выполняется в потоке {0}", Thread.CurrentThread.ManagedThreadId);
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        int sum = 0;
                        //await Task.Run(() =>
                        //{
                        for (int k = 0; k < a.GetLength(0); k++)
                        {
                            var result = a[k, j] * b[i, k];
                            sum += result;
                        }
                        outputMatrix[i, j] = sum;
                    }
            }).ConfigureAwait(true);
        }
                      
            DisplayMatrix(outputMatrix);
            Console.WriteLine(new string('_', 20));
            Console.WriteLine("Прошло {0} милисекунд", stopWatch.ElapsedMilliseconds);
        }

        public static int[,] MatrixFilling(int size)
        {
            var matrix = new int[size, size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rand.Next(11);
                }
                
            }
            return matrix;
        }              

        public static void DisplayMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {                
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"{a[i, j]}  ");
                }
                Console.WriteLine();                
            }
        }
    }
}
