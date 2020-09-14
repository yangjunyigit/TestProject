using System;
using System.Collections.Generic;
using System.Composition;
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
            //ch.SatisfyImports();
            IBook b = ch.GetExport<IBook>("MathBook");
            //Lazy<IBook,Dictionary<string,object>> b = ch.gete
            return b.GetTitle();
        }
    }
}
