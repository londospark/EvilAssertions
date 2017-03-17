using System;
using System.Linq.Expressions;

namespace EvilAssertions
{
    internal static class ExpressionExtensions
    {
        public static string Details(this Expression ex)
        {
            if (ex.NodeType == ExpressionType.MemberAccess)
            {
                var memberExpression = ((MemberExpression) ex);
                return $"{memberExpression.Member.Name} := {ValueOf(memberExpression)}";
            }

            return ex.ToString();
        }

        private static object ValueOf(Expression member)
        {
            var objectMember = Expression.Convert(member, typeof(object));
            var getterLambda = Expression.Lambda<Func<object>>(objectMember);
            var getter = getterLambda.Compile();
            return getter();
        }
    }
}