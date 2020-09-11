using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace MEFTest
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
