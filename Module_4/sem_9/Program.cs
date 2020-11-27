using System;
using System.Threading;
using System.Threading.Tasks;

namespace sem_9
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // cпособ 1
            Task task1 = new Task(() => SomeTask((int)Task.CurrentId));
            task1.Start();

            // способ 2
            Task task2 = Task.Factory.StartNew(() => SomeTask((int)Task.CurrentId));

            // способ 3
            Task task3 = Task.Run(() => SomeTask((int)Task.CurrentId));

            // вложенные таски
            
            Task outer = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Начало внешнего заднаия");

                var inner = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Начало внутреннего задания");
                    Thread.Sleep(1000);
                    Console.WriteLine("Окончание внутреннего задания");
                }, TaskCreationOptions.AttachedToParent);

            });
            
            outer.Wait();

            // массивы задач
            
            Task[] tasks1 =
            {
                new Task(() => Console.WriteLine("First Task")),
                new Task(() => Console.WriteLine("Second Task")),
                new Task(() => Console.WriteLine("Third Task"))
            };

            foreach (var t in tasks1)
                t.Start();

            Task[] tasks2 = new Task[3];
            int j = 1;
            for (int i = 0; i < tasks2.Length; i++)
                tasks2[i] = Task.Factory.StartNew(() => Console.WriteLine($"Task {j++}"));

            Task.WaitAll(tasks1);
            Task.WaitAll(tasks2);
            

            // возвращение значений из тасков
            
            Task<Human> task5 = Task.Run(() =>
            {
                return new Human { Name = "Cherry", Age = 19 };
            });

            Human human1 = task5.Result; // вернет результат задания
            Console.WriteLine(human1);
            

            // Последовательное выполнение задач с передачей параметра
            
            Task<int> task6 = new Task<int>(() => (int)Task.CurrentId);
            
            // задача продолжения
            Task task7 = task6.ContinueWith(id => SomeTask(task6.Result));

            task6.Start();

            // ждем окончания второй задачи
            task7.Wait();
            
            // Длинная последовательность задач

            /*Task task1 = new Task(() => {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });

            // задача продолжения
            Task task2 = task1.ContinueWith(Display);

            Task task3 = task1.ContinueWith((Task t) =>
            {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });

            Task task4 = task2.ContinueWith((Task t) =>
            {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });

            task1.Start();

            task4.Wait();
            */

            Console.WriteLine("Завершение метода Main");
            Console.ReadLine();
        }

        static void SomeTask(int id)
        {
            Console.WriteLine($"Task witn id {id} says Hi!");
        }

        static void Display(Task t)
        {
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
        }

        static void AnotherTask(Task t)
        {
            Console.WriteLine($"Id задачи продолжения: {Task.CurrentId}");
            Console.WriteLine($"Id предыдущей задачи: {t.Id}");
            Thread.Sleep(2000);
        }
    }
}
