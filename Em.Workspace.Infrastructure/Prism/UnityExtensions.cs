using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em.Workspace.Infrastructure.Prism
{
    public static class UnityContainerExtensions
    {
        public static void RegisterTypeForNavigation<T>(this IUnityContainer container)
        {
            container.RegisterType(typeof(Object), typeof(T), typeof(T).FullName);
        }

        public static void RegisterTypeForNavigation(this IUnityContainer container, Type type)
        {
            container.RegisterType(typeof(Object), type, type.FullName);
        }
    }
}
