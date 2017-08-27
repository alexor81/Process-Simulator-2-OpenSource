// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;

namespace Utils
{
    public class RepeatItemNameChecker
    {
        private HashSet<string> mList = new HashSet<string>(StringComparer.Ordinal);

        public void             addItemName(string aItemName)
        {
            if (String.IsNullOrWhiteSpace(aItemName) == false)
            {
                if (mList.Contains(aItemName))
                {
                    throw new ArgumentException("Item '" + aItemName + "' already exists. ");
                }

                mList.Add(aItemName);
            }
        }

        public void             addItemsNames(string[] aItemsNames)
        {
            foreach(string lName in aItemsNames)
            {
                addItemName(lName);
            }
        }
    }
}
