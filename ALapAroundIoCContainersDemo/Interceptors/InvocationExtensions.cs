using System.Text;
using Castle.DynamicProxy;

namespace ALapAroundIoCContainersDemo.Interceptors
{
    public static class InvocationExtensions
    {
         public static string GetFormatedMethodString(this IInvocation invocation)
         {
             StringBuilder sb = new StringBuilder(invocation.TargetType.FullName)
                .Append(".")
                .Append(invocation.Method)
                .Append("(");

             for (int i = 0; i < invocation.Arguments.Length; i++)
             {
                 if (i > 0)
                     sb.Append(", ");

                 sb.Append(invocation.Arguments[i]);
             }

             sb.Append(")");
             return sb.ToString();
         }
    }
}