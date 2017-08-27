// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Diagnostics;

namespace Utils.Logger
{
    public class LogTraceListener: TraceListener
    {
        private LogForm         mLogForm;

        public                  LogTraceListener(LogForm aLogForm)
        {
            mLogForm = aLogForm;
        }

        public override void    Write(string aMessage)
        {
            mLogForm.LogMessage(aMessage);
        }

        public override void    WriteLine(string aMessage)
        {
            mLogForm.LogMessage(aMessage);
        }
    }
}
