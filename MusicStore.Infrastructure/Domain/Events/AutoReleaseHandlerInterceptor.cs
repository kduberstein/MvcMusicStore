#region Using Directives

using System.Reflection;
using Castle.DynamicProxy;
using Castle.MicroKernel;

#endregion

namespace MusicStore.Infrastructure.Domain.Events
{
    public class AutoReleaseHandlerInterceptor : IInterceptor
    {
        private static readonly MethodInfo Execute = typeof (IDomainEventHandler).GetMethod("Execute");
        private readonly IKernel _kernel;

        public AutoReleaseHandlerInterceptor(IKernel kernel)
        {
            _kernel = kernel;
        }

        public void Intercept(IInvocation invocation)
        {
            if (invocation.Method != Execute)
            {
                invocation.Proceed();

                return;
            }

            try
            {
                invocation.Proceed();
            }
            finally
            {
                _kernel.ReleaseComponent(invocation.Proxy);
            }
        }
    }
}