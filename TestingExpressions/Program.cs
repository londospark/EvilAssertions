using System;
using static TestingExpressions.Assertions;

namespace TestingExpressions
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
