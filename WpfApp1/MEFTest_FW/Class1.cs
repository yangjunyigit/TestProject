using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MEFTest_FW
{
    public class Class1
    {
        public void Get()
        {
            AssemblyCatalog ac = new AssemblyCatalog(Assembly.GetExecutingAssembly());

            DirectoryCatalog dc = new DirectoryCatalog("");
            CompositionContainer cc = new CompositionContainer(ac);
        }
    }
}
