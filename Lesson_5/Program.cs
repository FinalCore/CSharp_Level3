/*   Задание
 *   1. Написать приложение, считающее в раздельных потоках: 
        a. факториал числа N, которое вводится с клавиатуры; 
        b. сумму целых чисел до N.
*/
using System;
using System.Threading;

namespace Lesson_5
{
    
    public class Factorial
    {
        public int Fact { get; set; } = 1;
        public int Number { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region a) факториал числа N, которое вводится с клавиатуры. Итерация делается в одном из двух потоков, и ее результат передается другому потоку.

            //Factorial arg = new Factorial();
            //Console.WriteLine("Введите число, для которого нужно вычислить факториал");
            //arg.Number = int.Parse(Console.ReadLine());

            //Thread thread = new Thread(()=> FactorialCalc(arg));

            //// запускаем вторичный поток
            //thread.Start();

            //// приостанавливаем первичный поток
            //Thread.Sleep(200);
            //// запускаем первичный поток
            //FactorialCalc(arg);
            //Console.WriteLine(new string('-', 25) + $"\nРезультат равен {arg.Fact}");
            #endregion

            #region b) сумма целых чисел до N. Каждая итерация суммирования чисел делается в отдельном потоке
            Console.WriteLine("Введите максимальное число последовательности, для которой нужно вычислить сумму");
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            Thread[] threads = new Thread[number];
            for (int i = 0; i < number; i++)
            {
                threads[i] = new Thread(() => Sum(ref number, ref sum));
            }

            foreach(var item in threads)
            {
                item.Start();
                item.Join();
            }
            //thread.Start();
            //thread.Join();
            Console.WriteLine("Завершение основного потока");
            Console.WriteLine("Сумма чисел последовтельности равна {0}", sum);
            #endregion
            Console.ReadKey();
        }

        
        /// <summary>
        /// Метод, вычисляющий факториал числа
        /// </summary>    
        static void FactorialCalc(object arg)
        {
            Factorial argument = (Factorial)arg;
                if (argument.Number == 0 || argument.Number == 1)
                    return;
                else
                {
                    while (argument.Number > 1)
                    {
                        argument.Fact *= argument.Number;                    
                        Console.WriteLine($"Поток №{Thread.CurrentThread.GetHashCode()} промежуточный результат: {argument.Number}");
                        argument.Number--;
                        Thread.Sleep(200);
                    }
                   
                }         
            
        }
      
        /// <summary>
        /// Метод, вычисляющий сумму последовательности целых чисел
        /// </summary>
        /// <param name="number"></param>
        /// <param name="sum"></param>
        static void Sum(ref int number, ref int sum)
        {
            sum += number--;
            Console.WriteLine($"Итерация выполнена в потоке {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(200);
            //for (int i = number; i > 0; i--)
            //{
            //    sum += i;
            //    Console.WriteLine($"Итерация {number - i} выполнена в потоке {Thread.CurrentThread.ManagedThreadId}");
            //    //Thread.Sleep(200);
            //    //Thread.CurrentThread.Interrupt();
            //}
            return;
        }
    }
}
