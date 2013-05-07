using System.Diagnostics;
using Castle.DynamicProxy;

namespace ALapAroundIoCContainersDemo.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            string formattedMethod = invocation.GetFormatedMethodString();
            Trace.WriteLine(formattedMethod);

            invocation.Proceed();

            string returnValue = string.Format("Returned {0}", invocation.ReturnValue);
            Trace.WriteLine(returnValue);
        }
    }
}