using System;

namespace _1_add
{//Создайте свой класс, объекты которого будут занимать много места в памяти (например, в
 //   коде класса будет присутствовать большой массив) и реализуйте для этого класса,
 //формализованный шаблон очистки.
    class MyClass : IDisposable
    {
        private bool disposed = false;

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        ~MyClass()
        {
            Console.WriteLine("Finalise");
            CleanUp(false);
        }

        private void CleanUp(bool clean)
        {
            if (!this.disposed)
            {
                if (clean)
                {
                    Console.Write("Освобождение ресурсов\n");

                    for (int i = 0; i < 40; i++)
                    {
                        Console.Write("F");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Закончили");
            }
            this.disposed = true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var myClass = new MyClass())
            {
                Console.WriteLine(myClass);
            }
            Console.WriteLine(new string('-', 20));


            var myClass2 = new MyClass();
            Console.WriteLine(myClass2);

            myClass2.Dispose();
            myClass2.Dispose();
            myClass2.Dispose();
            myClass2.Dispose();

            var myClass3 = new MyClass();

            Console.ReadKey();
            Console.WriteLine("Нажмите любую клавишу для очистки");
        }
    }
}
