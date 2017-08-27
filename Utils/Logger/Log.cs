// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using API;

namespace Utils.Logger
{
    public class Log : IDisposable
    {
        private static Log                      mLog;
        private static LogForm                  mLogForm;
        private static Thread                   mLogFormThread;
        private static TextWriterTraceListener  mFileTraceListener;
        private static LogTraceListener         mLogTraceListener;

        public static void                      Init(int aInstanceNum)
        {
            mLog = new Log(aInstanceNum); 
        }

        private                                 Log(int aInstanceNum)
        {
            string lPath = MiscUtils.AssemblyPath + "\\Log\\";
            if (Directory.Exists(lPath) == false)
            {
                Directory.CreateDirectory(lPath);
            }

            mFileTraceListener  = new TextWriterTraceListener(lPath + DateTime.Now.ToString("yyyyMMdd_HHmmss_") + StringUtils.ObjectToString(aInstanceNum) + ".log");
            mLogForm            = new LogForm();
            mLogTraceListener   = new LogTraceListener(mLogForm);           

            Trace.Listeners.Clear();
            Trace.Listeners.Add(mFileTraceListener);
            Trace.Listeners.Add(mLogTraceListener);
            Trace.AutoFlush = true;
        }

        private static void                     log(string aDateTime, string aType, string aMessage, string aDetails)
        {
            string lMessage = string.Format("{0}\t{1}\t{2}", aDateTime, aType, aMessage);
            if (String.IsNullOrWhiteSpace(aDetails) == false)
            {
                lMessage = lMessage + Environment.NewLine + aDetails;
            }
            Trace.WriteLine(lMessage);
        }

        public static event EventHandler<MessageStringEventArgs> ErrorEvent;
        private static void                     raiseError(string aMessage)
        {
            ErrorEvent?.Invoke(null, new MessageStringEventArgs(aMessage));
        }

        private static int                      mErrorCount = 0;
        public static int                       ErrorCount { get { return mErrorCount; } }

        private static int                      mInfoCount = 0;
        public static int                       InfoCount { get { return mInfoCount; } }

        public static void                      Error(string aMessage, string aDetails = "")
        {
            mErrorCount         = mErrorCount + 1;
            string lDateTime    = StringUtils.ObjectToString(DateTime.Now);
            log(lDateTime, "Error", aMessage, aDetails);           
            raiseError(lDateTime + " " + aMessage);
        }

        public static void                      Info(string aMessage, string aDetails = "")
        {
            mInfoCount = mInfoCount + 1;
            log(StringUtils.ObjectToString(DateTime.Now), "Info", aMessage, aDetails);            
        }

        public static void                      showLogForm()
        {
            if (mLogFormThread == null)
            {
                mLogFormThread = new Thread(() => { Application.Run(mLogForm); });
                mLogFormThread.TrySetApartmentState(ApartmentState.STA);
                mLogFormThread.Start();
            }
            else
            {
                mLogForm.ShowForm();
            }
        }

        public static void                      clearLogForm()
        {
            if (mLogForm != null)
            {
                mLogForm.ClearAllMessages();
            }
        }

        public static void                      disposeLogForm()
        {
            if (mLogForm != null)
            {
                mLogForm.DisposeForm();
                mLogForm = null;
            }

            if (mLogFormThread != null)
            {
                mLogFormThread.Abort();
                mLogFormThread = null;
            }
        }

        public static void                      Close()
        {
            Trace.WriteLine(string.Format("Error: {0}\t Info: {1}", mErrorCount, mInfoCount));
            mLog.Dispose();
        }

        #region IDisposable

            private bool                    mDisposed = false;

            public void                     Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void          Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    if (aDisposing)
                    {
                        Trace.Close();

                        if (mFileTraceListener != null)
                        {
                            mFileTraceListener.Dispose();
                            mFileTraceListener = null;
                        }

                        if (mLogTraceListener != null)
                        {
                            mLogTraceListener.Dispose();
                            mLogTraceListener = null;
                        }

                        disposeLogForm();
                    }
                    mDisposed = true;
                }
            }

        #endregion
    }
}
