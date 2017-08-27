// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Utils
{
    public static class StringUtils
    {
        public static readonly string[]                     TypesNames  = new string[] 
        {
            "Boolean",
            "Byte",
            "SByte",
            "Int16",
            "Int32",
            "Int64",
            "UInt16",
            "UInt32",
            "UInt64",
            "Single",
            "Double",
            "Decimal",
            "Char",
            "String",
            "DateTime"
        };

        private static readonly Dictionary<string, Type>    Types       = new Dictionary<string, Type>(StringComparer.Ordinal)
        {
            {"Boolean",     typeof(Boolean)},
            {"Byte",        typeof(Byte)},
            {"SByte",       typeof(SByte)},
            {"Int16",       typeof(Int16)},
            {"Int32",       typeof(Int32)},
            {"Int64",       typeof(Int64)},
            {"UInt16",      typeof(UInt16)},
            {"UInt32",      typeof(UInt32)},
            {"UInt64",      typeof(UInt64)},
            {"Single",      typeof(Single)},
            {"Double",      typeof(Double)},
            {"Decimal",     typeof(Decimal)},
            {"Char",        typeof(Char)},
            {"String",      typeof(String)},
            {"DateTime",    typeof(DateTime)}
        };

        private static readonly Dictionary<string, Object>  InitValues  = new Dictionary<string, Object>(StringComparer.Ordinal)
        {
            {"Boolean",     new Boolean()},
            {"Byte",        new Byte()},
            {"SByte",       new SByte()},
            {"Int16",       new Int16()},
            {"Int32",       new Int32()},
            {"Int64",       new Int64()},
            {"UInt16",      new UInt16()},
            {"UInt32",      new UInt32()},
            {"UInt64",      new UInt64()},
            {"Single",      new Single()},
            {"Double",      new Double()},
            {"Decimal",     new Decimal()},
            {"Char",        new Char()},
            {"String",      ""},
            {"DateTime",    new DateTime()}
        };

        public static bool                                  isTypeSupported(Type aType)
        {
            if (aType.IsArray)
            {
                if(aType.GetArrayRank() == 1)
                {
                    return Types.ContainsKey(aType.GetElementType().Name);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return Types.ContainsKey(aType.Name);
            }
        }

        public static bool                                  isTypeSupported(string aType)
        {
            return Types.ContainsKey(aType);
        }

        public static Type                                  parseType(string aType)
        {
            if(String.IsNullOrWhiteSpace(aType))
            {
                throw new ArgumentException("Type name is empty. ");
            }

            if(aType.StartsWith("System."))
            {
                aType = aType.Substring(7);
            }

            if (Types.ContainsKey(aType) == false)
            {
                throw new ArgumentException("Type '" + aType + "' is not supported. ");
            }

            return Types[aType];
        }

        public static Type                                  getTypeByIndex(int aIndex)
        {
            return Types[TypesNames[aIndex]];
        }

        public static int                                   getIndexByType(Type aType)
        {
            for(int i = 0; i < TypesNames.Length; i++)
            {
                if (TypesNames[i].Equals(aType.Name, StringComparison.Ordinal)) return i;
            }

            throw new ArgumentException("Type '" + aType.Name + "' is not supported. ");
        }

        public static object                                getInitValue(string aType, bool aArray = false)
        {
            if (String.IsNullOrWhiteSpace(aType))
            {
                throw new ArgumentException("Type name is empty. ");
            }

            if (aType.StartsWith("System."))
            {
                aType = aType.Substring(7);
            }

            if (InitValues.ContainsKey(aType) == false)
            {
                throw new ArgumentException("Type '" + aType + "' is not supported. ");
            }

            if (aArray)
            {
                return Array.CreateInstance(Types[aType], 0);
            }
            else
            {
                return InitValues[aType];
            }
        }

        public const string                                 DTwMsFormat = "yyyy.MM.dd HH:mm:ss.fff";
        public const string                                 DTFormat    = "yyyy.MM.dd HH:mm:ss";

        public static float                                 toSingle(string aValue)
        {
            int lLastC = aValue.LastIndexOf(',');

            if (lLastC > aValue.LastIndexOf('.'))
            {
                aValue = aValue.Substring(0, lLastC).Replace(".", "") + "." + aValue.Substring(lLastC + 1);
            }

            return Single.Parse(aValue.Replace(" ", ""), CultureInfo.InvariantCulture);
        }

        public static double                                toDouble(string aValue)
        {
            int lLastC = aValue.LastIndexOf(',');

            if (lLastC > aValue.LastIndexOf('.'))
            {
                aValue = aValue.Substring(0, lLastC).Replace(".", "") + "." + aValue.Substring(lLastC + 1);
            }

            return Double.Parse(aValue.Replace(" ", ""), CultureInfo.InvariantCulture);
        }

        public static decimal                               toDecimal(string aValue)
        {
            int lLastC = aValue.LastIndexOf(',');

            if (lLastC > aValue.LastIndexOf('.'))
            {
                aValue = aValue.Substring(0, lLastC).Replace(".", "") + "." + aValue.Substring(lLastC + 1);
            }

            return Decimal.Parse(aValue.Replace(" ", ""), CultureInfo.InvariantCulture);
        }

        public static object                                StringToObject(Type aType, string aString)
        {
            try
            {
                if (aType == typeof(String))
                {
                    return aString;
                }
                else if (aType == typeof(Single))
                {
                    return Utils.StringUtils.toSingle(aString);
                }
                else if (aType == typeof(Double))
                {
                    return Utils.StringUtils.toDouble(aString);
                }
                else if (aType == typeof(Decimal))
                {
                    return Utils.StringUtils.toDecimal(aString);
                }
                else if (aType == typeof(DateTime))
                {
                    return DateTime.ParseExact(aString, DTwMsFormat, CultureInfo.InvariantCulture);
                }
                else if (aType == typeof(Color))
                {            
                    KnownColor lColor;
                    if (Enum.TryParse(aString, out lColor))
                    {
                        return Color.FromKnownColor(lColor);
                    }
                    else
                    {
                        return System.Drawing.Color.FromArgb(Convert.ToInt32(aString, 16));
                    }
                }
                else if (aType == typeof(Font))
                {
                    string[] lParam = aString.Split(';');
                    return new Font(lParam[0], (float)StringToObject(typeof(Single), lParam[1]), (FontStyle)Enum.Parse(typeof(FontStyle), lParam[2]));
                }
                else
                {
                    object lValue;

                    try
                    {
                        lValue = aType.InvokeMember("Parse", BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, new object[] { aString });
                    }
                    catch (TargetInvocationException lExc)
                    {
                        throw lExc.InnerException;
                    }

                    return lValue;
                }
            }
            catch (Exception lExc)
            {
                throw new ArgumentException("String '" + aString + "' conversion error to object of type '" + aType.FullName + "'. " + lExc.Message, lExc);
            }
        }

        public const char                                   ArrayStringSeparator = '\u0001';

        public static object                                StringToArray(Type aType, string aString)
        {
            Array lArray;
            Type lElementType;
            if (aType.IsArray)
            {
                lElementType = aType.GetElementType();
            }    
            else
            {
                lElementType = aType;
            }

            try
            {
                if (aString.StartsWith("[") == false) throw new ArgumentException("Wrong format. ");

                int lIndex = aString.IndexOf(']');
                if(lIndex == -1) throw new ArgumentException("Wrong format. ");

                if(aString[lIndex + 1] != '{') throw new ArgumentException("Wrong format. ");

                if (aString.EndsWith("}") == false ) throw new ArgumentException("Wrong format. ");

                int lLength         = (int)StringToObject(typeof(Int32), aString.Substring(1, lIndex - 1));
                string[] lValues    = aString.Substring(lIndex + 2, aString.Length - lIndex - 3).Split(ArrayStringSeparator);

                if(lValues.Length == 1 && String.IsNullOrWhiteSpace(lValues[0]) && lLength == 0)
                {
                    return Array.CreateInstance(lElementType, 0);
                }

                if (lValues.Length != lLength) throw new ArgumentException("Wrong length. ");

                lArray = Array.CreateInstance(lElementType, lLength);

                for(int i = 0; i < lLength; i++)
                {
                    lArray.SetValue(StringToObject(lElementType, lValues[i]), i);
                }

                return lArray;
            }
            catch (Exception lExc)
            {
                try
                {
                    lArray = Array.CreateInstance(lElementType, 1);
                    lArray.SetValue(StringToObject(lElementType, aString), 0);
                    return lArray;
                }
                catch {}

                throw new ArgumentException("String '" + aString + "' conversion error to array of type '" 
                                                + aType.FullName + "'. " + lExc.Message, lExc);
            }
        }

        public static string                                ArrayToString(Array aArray, string aFormat = "")
        {
            if (aArray.Rank == 1)
            {
                int lLen = aArray.GetLength(0);
                StringBuilder lStrBld = new StringBuilder("[" + lLen.ToString() + "]{");
                for (int i = 0; i < lLen; i++)
                {
                    lStrBld.Append(StringUtils.ObjectToString(aArray.GetValue(i), aFormat));

                    if ((i + 1) != lLen)
                    {
                        lStrBld.Append(ArrayStringSeparator);
                    }
                }
                lStrBld.Append("}");

                return lStrBld.ToString();
            }
            else
            {
                return aArray.ToString();
            }
        }

        public static string                                ObjectToString(object aObject, string aFormat = "")
        {
            if (aObject == null)
            {
                return "null";
            }
            else if (aObject is Single)
            {
                return ((Single)aObject).ToString(aFormat, CultureInfo.InvariantCulture);
            }
            else if (aObject is Double)
            {
                return ((Double)aObject).ToString(aFormat, CultureInfo.InvariantCulture);
            }
            else if (aObject is Decimal)
            {
                return ((Decimal)aObject).ToString(aFormat, CultureInfo.InvariantCulture);
            }
            else if (aObject is DateTime)
            {
                if (String.IsNullOrWhiteSpace(aFormat))
                {
                    return ((DateTime)aObject).ToString(DTwMsFormat);
                }
                else
                {
                    return ((DateTime)aObject).ToString(aFormat);
                }
            }
            else if (aObject is Color)
            {
                Color lColor = (Color)aObject;
                if (lColor.IsNamedColor)
                {
                    return lColor.Name;
                }
                else
                {
                    return lColor.ToArgb().ToString("X8");
                }
            }
            else if(aObject is Font)
            {
                Font lFont = (Font)aObject;
                return lFont.FontFamily.Name + ";" + ObjectToString(lFont.Size) + ";" + lFont.Style.ToString();
            }
            else if (aObject is Array)
            {
                return ArrayToString(aObject as Array, aFormat);
            }
            else
            {
                return aObject.ToString();
            }
        }

        public static string                                DoubleToString(double aValue, int aRound)
        {
            if (aRound == -1)
            {
                return StringUtils.ObjectToString(aValue);
            }
            else
            {
                string lValue = StringUtils.ObjectToString(Math.Round(aValue, aRound, MidpointRounding.AwayFromZero));
                if (aRound > 0 && lValue.Contains("E") == false)
                {
                    int lSeparator = lValue.LastIndexOf(CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator);
                    int lAddZero;
                    if (lSeparator == -1)
                    {
                        lValue      = lValue + CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator;
                        lAddZero    = lValue.Length + aRound;
                    }
                    else
                    {
                        lAddZero = lSeparator + CultureInfo.InvariantCulture.NumberFormat.NumberDecimalSeparator.Length + aRound;
                    }

                    lValue = lValue.PadRight(lAddZero, '0');
                }

                return lValue;
            }
        }

        public static int                                   getLineCount(string aText)
        {
            return aText.Split(new string[] {Environment.NewLine}, StringSplitOptions.None).Length;
        }

        public static int                                   getLineNumber(string aText, int aIndex)
        {
            return aText.Substring(0, aIndex).Split(new string[] {Environment.NewLine}, StringSplitOptions.None).Length;
        }

        public static int                                   getIndex(string[] aArray, string aValue)
        {
            for (int i = 0; i < aArray.Length; i++)
            {
                if (aValue.Equals(aArray[i], StringComparison.Ordinal))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
