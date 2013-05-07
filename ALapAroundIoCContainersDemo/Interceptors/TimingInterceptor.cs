using System.Diagnostics;
using Castle.DynamicProxy;

namespace ALapAroundIoCContainersDemo.Interceptors
{
    public class TimingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            invocation.Proceed();
            stopwatch.Stop();

            string formattedMethod = invocation.GetFormatedMethodString();
            string message = string.Format("{0} took {1}ms", formattedMethod, stopwatch.ElapsedMilliseconds);
            Trace.WriteLine(message);
        }
    }
}