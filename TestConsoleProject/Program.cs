using System;
using System.Threading;

namespace TestConsoleProject
{
    class Program
    {
        static object lockObject = new object();
        static void Main(string[] args)
        {
            int number = 0;
            Thread thread = new Thread(() => MyTreadMethod(ref number));
            thread.IsBackground = true;

            // запускаем воторичный поток
            thread.Start();
            Thread.Sleep(200);
            // запускаем первичный поток
            MyTreadMethod(ref number);
            Console.WriteLine(new string('-', 15) + $"\n{number}");
            Console.ReadKey();
        }

        #region Пример поочередного выполнения итерций цикла двумя потоками
        static void MyTreadMethod(ref int number)
        {
            while (number < 10)
            {
                ++number;
                Console.WriteLine($"Поток №{Thread.CurrentThread.GetHashCode()} промежуточный результат: {number}");
                Thread.Sleep(400);
            }
            return;
        }
        #endregion

        #region Пример, когда второй поток начниает работу после завершения первого

        //static void MyTreadMethod(int number)
        //{
        //    lock(lockObject)
        //    {
        //        int value = 0;
        //        for (int i = 0; i < 5; i++)
        //        {
        //            number++;
        //            value++;
        //            Console.WriteLine($"Поток №{Thread.CurrentThread.GetHashCode()} промежуточный результат: {number} тестовое число: {value}");
        //            Thread.Sleep(200);
        //        }
        //        return;
        //    }            
        //}

        #endregion
    }
}
