using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using a parallel for loop to slam the singleton instance almost simultaneously
            Parallel.For(0, 100, i =>
            {
                Singleton.Instance.Write(i.ToString());
            });
        }
    }

    public sealed class Singleton
    {
        // Called first
        private static readonly Singleton instance = new Singleton();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit.
        // Called third
        static Singleton()
        {
        }

        // Called second
        private Singleton()
        {
            // If called more than once multiple timestamps will display.
            Console.WriteLine($"[{DateTime.UtcNow.ToString("HH:MM:ss.ffffff")}]");
        }

        // Called fourth
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public void Write(string param)
        {
            Console.WriteLine($"[{param}]");
        }
    }
}
