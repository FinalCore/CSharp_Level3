using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson_6
{
    class Examples_from_Webinar
    {
        // Нужный код скопировать в метод Main класса Program 

        #region Статический метод Invoke класса Parallel позволяет запускать любое количество методов параллельно (в разных птоках) 
        //Parallel.Invoke(
        //    MyMethod1,
        //    () =>   Console.WriteLine("Метод 2 запущен в потоке {0}", Thread.CurrentThread.ManagedThreadId),
        //    () => { Console.WriteLine("Метод 3 запущен в потоке {0}", Thread.CurrentThread.ManagedThreadId); Thread.Sleep(200);}
        //    );            
        #endregion

        #region У метода Parallel.Invoke() есть много опций, доступных из класса ParallelOptions. 
        //Например, мы можем запустить 100 методов всего лишь в трех потоках 

        //Parallel.Invoke(new ParallelOptions { MaxDegreeOfParallelism = 3 }, Enumerable.Repeat(new Action(MyMethod1), 100).ToArray());
        #endregion

        #region Можно организовать параллельное выполнение методов в цикле for и foreach
        //Parallel.For(0, 100, i => Console.WriteLine("Метод 2 запущен в потоке {0}", Thread.CurrentThread.ManagedThreadId));
        //var messages = Enumerable.Repeat(new Action(MyMethod1), 100);
        //Parallel.ForEach(messages, i => Console.WriteLine("Метод запущен в потоке {0}", Thread.CurrentThread.ManagedThreadId));
        #endregion

        #region Можно, например, ограничить количество производимых итераций
        //var result = Parallel.For(0, 100, (i, state) =>
        //{
        //    if (i > 15) state.Break();
        //    Console.WriteLine("Метод 2 запущен в потоке {0}", Thread.CurrentThread.ManagedThreadId);
        //});
        //Console.WriteLine("Выполнилось {0} итераций", result.LowestBreakIteration);
        #endregion

        #region Работа с задачами (Task)
        //const string msg = "Hello, World!";
        //Task<int> myTask = new Task<int>(() => GetMessageLength(msg));
        //myTask.Start();

        //// После запуска Task'а основной поток приложения продолжает работать
        //for (int i = 0; i < 20; i++)
        //Console.WriteLine("Работа в основном потоке");

        //// Можно получить результат выполнения задачи из основного потока
        //var result = myTask.Result;
        //Console.WriteLine("Длина строки {0} равна {1}", msg, result);
        #endregion

        #region Правильная работа с задачами путем использования статических методов класса Task
        //const string msg = "Hello, World!";
        ////var myTask = Task.Run(() => GetMessageLength(msg));
        //var result = Task.Run(() => GetMessageLength(msg));
        //// Создаем новую задачу, которая автоматически стартует после завершения первой.
        //result.ContinueWith(t => Console.WriteLine("Длина строки {0} равна {1}", msg, t.Result));

        //// После запуска Task'а основной поток приложения продолжает работать
        //for (int i = 0; i < 20; i++)
        //    Console.WriteLine("Работа в основном потоке");  
        #endregion
                                 
        public static void MyMethod1()
        {
            Console.WriteLine("Метод 1 запущен в потоке {0}", Thread.CurrentThread.ManagedThreadId);
        }

        static int GetMessageLength(string msg)
        {
            Console.WriteLine("ThreadID: {0}, TaskID: {1} - started", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            Thread.Sleep(400);
            Console.WriteLine("ThreadID: {0}, TaskID: {1} - finished", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            return msg.Length;
        }

        //Ключевое слово async разрешает использование await в этом методе и изменяет обработку возвращаемого из метода результата. На этом влияние async на код заканчивается
        public static async void StartAsync(string msg)
        {
            // До ключевого слова await программа выполняется в синхронном режиме. 
            await Task.Run(() => Console.WriteLine("Длина сообщения: {0}", GetMessageLength(msg))); // После слова await программа работает в асинхронном режиме, т.е задача запускается в отдельном потоке

            // после строки с await программа пытается вернуться в тот же самый поток, который был до await. Await сообщает асинхронной операции, что необходимо выполнить оставшуюся часть метода, когда операция завершится, и вернуть результат из async-метода.
        }

    }
}
