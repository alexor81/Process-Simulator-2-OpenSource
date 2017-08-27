// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Collections.Generic;

namespace Utils.NameValueList
{
    public static class Clipboard
    {
        private static List<string>     mNames    = new List<string>();
        private static List<object>     mValues   = new List<object>();

        public static void              clear()
        {
            mNames.Clear();
            mValues.Clear();
        }
        
        public static bool              isEmpty
        {
            get { return (mNames.Count == 0);  }
        }

        public static void              add(string aName, object aValue)
        {
            mNames.Add(aName);
            mValues.Add(aValue);
        }

        public static void              get(out string[] aNames, out object[] aValues)
        {
            aNames  = mNames.ToArray();
            aValues = mValues.ToArray();
        }    
    }
}
