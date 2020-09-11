using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace MEFTest
{
    [Export(typeof(IBook))]
    public class HistoryBook : IBook
    {
        public string GetTitle()
        {
            return "History Book";
        }
    }
}
