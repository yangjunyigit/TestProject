using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEFTest_FW
{
    [Export(typeof(IBook))]
    public class MathBook : IBook
    {
        public string GetTitle()
        {
            return "Math Book";
        }
    }
}
