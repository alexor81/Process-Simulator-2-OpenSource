// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Utils.Logger;

namespace Utils
{
    public static class MiscUtils
    {
        public const int            TimeSlice           = 16;

        public const int            FastFormUpdateTime  = 32;

        public const int            SlowFormUpdateTime  = 640;

        private static Stopwatch    mStopwatch;
        public static long          TimerMS
        {
            get
            {
                if (mStopwatch == null)
                {
                    mStopwatch = new Stopwatch();
                    mStopwatch.Start();
                }

                return mStopwatch.ElapsedMilliseconds;
            }
        }

        private static string       mProjectPath        = "";
        public static string        ProjectPath
        {
            get
            {
                return mProjectPath;
            }
            set
            {
                mProjectPath = value;
            }
        }

        private static string       mAssemblyPath       = "";
        public static string        AssemblyPath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(mAssemblyPath))
                {
                    mAssemblyPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                }

                return mAssemblyPath;
            }
        }

        private static string       mTempPath           = "";
        public static string        TempPath
        {
            get
            {
                if (String.IsNullOrWhiteSpace(mTempPath))
                {
                    mTempPath = Path.Combine(MiscUtils.AssemblyPath, "Temp");
                }

                try
                {
                    if (Directory.Exists(mTempPath) == false)
                    {
                        Directory.CreateDirectory(mTempPath);
                    }
                }
                catch(Exception lExc)
                {
                    Log.Error("Unable to create temporary directory. " + lExc.Message);
                    throw;
                }

                return mTempPath;
            }
        }
        public static bool          isTempDirectoryExist
        {
            get
            {
                if (Directory.Exists(Path.Combine(MiscUtils.AssemblyPath, "Temp")) == false)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
