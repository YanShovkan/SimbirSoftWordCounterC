using System;
using System.Net;

namespace WordCounder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для запуска алгоритма введите ссылку на страницу, для выхода ввкдите \"exit\"");
            Finder finder = new Finder();
            string url = Console.ReadLine().ToString();
            while (!url.Equals("exit"))
            {
                finder.FindWords(url);
                Console.WriteLine("Для запуска алгоритма введите ссылку на страницу, для выхода ввкдите \"exit\"");
                url = Console.ReadLine().ToString();
            }
        }
    }
}
