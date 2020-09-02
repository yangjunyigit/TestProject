using System;

namespace WpfApp1
{
    public class WindowExFixEventArgs:EventArgs
    {
        private object content;

        public WindowExFixEventArgs(object content)
        {
            this.content = content;
        }
    }
}