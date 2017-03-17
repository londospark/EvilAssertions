using System;
using System.Linq;
using System.Linq.Expressions;

namespace TestingExpressions
{
    internal class Assertions
    {
        public static void Assert(Expression<Func<object, bool>> assertion)
        {
            var param = assertion.Parameters.First();
            if (param.Name != "that") throw new Exception("The proper format is 'Assert(that => {expression})'");
            if (assertion.Compile().Invoke(null)) return;
            var operation = (BinaryExpression) assertion.Body;
            Console.WriteLine("Operation: " + operation.NodeType);
            Console.WriteLine("LHS: "+ operation.Left.Details());
            Console.WriteLine("RHS: "+ operation.Right.Details());
            throw new Exception($"Expected {operation.Left.Details()} to {operation.NodeType} {operation.Right.Details()}");
        }
    }
}