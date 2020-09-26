using System;

namespace ConsoleApp_Debug_Release
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            Console.WriteLine("Hello debug!");
#endif

#if RELEASE
            Console.WriteLine("Hello release!");
#endif
            Console.ReadKey();
        }
    }
}
