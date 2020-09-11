using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Reflection;
using System.Text;

namespace MEFTest
{
    public class Test
    {
        public static string Get()
        {
            ContainerConfiguration cc = new ContainerConfiguration().WithAssembly(Assembly.GetExecutingAssembly());
            CompositionHost ch = cc.CreateContainer();
            IBook b = ch.GetExport<IBook>();
            return b.GetTitle();
        }
    }
}
