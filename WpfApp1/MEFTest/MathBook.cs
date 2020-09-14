using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace MEFTest
{
    [Export("MathBook",typeof(IBook))]
    [ExportMetadata("aaa","")]
    [ExportMetadata("bbb", "")]
    public class MathBook : IBook
    {
        public string GetTitle()
        {
            return "Math Book";
        }
    }
}
