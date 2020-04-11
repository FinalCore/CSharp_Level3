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
            Factorial arg = new Factorial();
            Console.WriteLine("Введите число, для которого нужно вычислить факториал");
            arg.Number = int.Parse(Console.ReadLine());

            Thread thread = new Thread(()=> FactorialCalc(arg));

            // запускаем вторичный поток
            thread.Start();

            // приостанавливаем первичный поток
            Thread.Sleep(200);
            // запускаем первичный поток
            FactorialCalc(arg);
            Console.WriteLine(new string('-', 25) + $"\nРезультат равен {arg.Fact}");
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
    }
}
