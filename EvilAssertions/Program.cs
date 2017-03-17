using System;
using static EvilAssertions.Assertions;

namespace EvilAssertions
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = 1;
            Assert(that => num == 2);
            Console.ReadLine();
        }
    }
}
