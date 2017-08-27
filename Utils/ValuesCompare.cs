// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;

namespace Utils
{
    public class ValuesCompare
    {
        public static readonly string[]         Operations = new string[]  { "Equal",
                                                                             "Not equal",
                                                                             "Less than",
                                                                             "Greater than",
                                                                             "Less than or equal",
                                                                             "Greater than or equal" };

        public static int                       OperationNameToNumber(string aOperationName)
        {
            for (int i = 0; i < Operations.Length; i++)
            {
                if (Operations[i].Equals(aOperationName, StringComparison.Ordinal)) return i;
            }

            throw new ArgumentException("Unknown operation. ");
        }

        public static readonly ValuesCompare    NotEqualDelta1  = new ValuesCompare("Not equal", 1);
        public static readonly ValuesCompare    EqualDelta1     = new ValuesCompare("Equal", 1);

        public                                  ValuesCompare()
        {
        }

        public                                  ValuesCompare(string aOperationName)
        {
            OperationName = aOperationName;
        }

        public                                  ValuesCompare(string aOperationName, ulong aDelta)
        {
            OperationName = aOperationName;
            Delta = aDelta;
        }

        private int                             mOperation  = 0;
        public int                              OperationNumber
        {
            get
            {
                return mOperation;
            }
            set
            {
                if (value > 5 || value < 0)
                {
                    throw new ArgumentException("Unknown operation. ");
                }
                mOperation = value;
            }
        }
        public string                           OperationName
        {
            get
            {
                return Operations[mOperation];
            }
            set
            {
                mOperation = OperationNameToNumber(value);
            }
        }

        private ulong                           mDelta      = 1;
        public ulong                            Delta
        {
            get { return mDelta; }
            set { mDelta = value; }
        }

        public bool                             compare(float aValue1, float aValue2)
        {
            if (aValue1 >= 0.0F && aValue2 >= 0.0F)
            {
                ulong lValue1 = Converters.SingleToUInt64Bits(aValue1);
                ulong lValue2 = Converters.SingleToUInt64Bits(aValue2);

                return compare(lValue1, lValue2);
            }
            else if (aValue1 < 0.0F && aValue2 < 0.0F)
            {
                ulong lValue1 = Converters.SingleToUInt64Bits(-aValue1);
                ulong lValue2 = Converters.SingleToUInt64Bits(-aValue2);

                return compare(lValue2, lValue1);
            }
            else
            {
                switch (mOperation)
                {
                    case 0: return false;
                    case 1: return true;
                    case 2:
                    case 4: return (aValue2 >= 0.0D);
                    case 3:
                    case 5: return (aValue1 >= 0.0D);
                }

                throw new Exception("Unknown operation. ");
            }
        }

        public bool                             compare(double aValue1, double aValue2)
        {
            if (aValue1 >= 0.0D && aValue2 >= 0.0D)
            {
                ulong lValue1 = Converters.DoubleToUInt64Bits(aValue1);
                ulong lValue2 = Converters.DoubleToUInt64Bits(aValue2);

                return compare(lValue1, lValue2);
            }
            else if (aValue1 < 0.0D && aValue2 < 0.0D)
            {
                ulong lValue1 = Converters.DoubleToUInt64Bits(-aValue1);
                ulong lValue2 = Converters.DoubleToUInt64Bits(-aValue2);

                return compare(lValue2, lValue1);
            }
            else
            {
                switch (mOperation)
                {
                    case 0: return false;
                    case 1: return true;
                    case 2: 
                    case 4: return (aValue2 >= 0.0D);
                    case 3:
                    case 5: return (aValue1 >= 0.0D);
                }

                throw new Exception("Unknown operation. ");
            }
        }

        private bool                            compare(ulong aValue1, ulong aValue2)
        {
            ulong lDiff = aValue1 > aValue2 ? aValue1 - aValue2 : aValue2 - aValue1;

            switch (mOperation)
            {
                case 0: if (lDiff <= mDelta) { return true; } else { return false; };                               // ==

                case 1: if (lDiff > mDelta) { return true; } else { return false; };                                // !=

                case 2: if ((aValue1 < aValue2) && (lDiff > mDelta)) { return true; } else { return false; };       // <

                case 3: if ((aValue1 > aValue2) && (lDiff > mDelta)) { return true; } else { return false; };       // >

                case 4: if ((aValue1 < aValue2) || (lDiff <= mDelta)) { return true; } else { return false; };      // <=

                case 5: if ((aValue1 > aValue2) || (lDiff <= mDelta)) { return true; } else { return false; };      // >=
            }

            throw new ArgumentException("Unknown operation. ");
        }
 
        private static bool                     equals(object aValue1, object aValue2)
        {
            try
            {
                if (aValue1 is Boolean)
                {
                    return (Convert.ToBoolean(aValue1) == Convert.ToBoolean(aValue2));
                }
                else if (aValue1 is Byte)
                {
                    return (Convert.ToByte(aValue1) == Convert.ToByte(aValue2));
                }
                else if (aValue1 is SByte)
                {
                    return (Convert.ToSByte(aValue1) == Convert.ToSByte(aValue2));
                }
                else if (aValue1 is Int16)
                {
                    return (Convert.ToInt16(aValue1) == Convert.ToInt16(aValue2));
                }
                else if (aValue1 is Int32)
                {
                    return (Convert.ToInt32(aValue1) == Convert.ToInt32(aValue2));
                }
                else if (aValue1 is Int64)
                {
                    return (Convert.ToInt64(aValue1) == Convert.ToInt64(aValue2));
                }
                else if (aValue1 is UInt16)
                {
                    return (Convert.ToUInt16(aValue1) == Convert.ToUInt16(aValue2));
                }
                else if (aValue1 is UInt32)
                {
                    return (Convert.ToUInt32(aValue1) == Convert.ToUInt32(aValue2));
                }
                else if (aValue1 is UInt64)
                {
                    return (Convert.ToUInt64(aValue1) == Convert.ToUInt64(aValue2));
                }
                else if (aValue1 is Single)
                {
                    return EqualDelta1.compare(Convert.ToSingle(aValue1), Convert.ToSingle(aValue2));
                }
                else if (aValue1 is Double)
                {
                    return EqualDelta1.compare(Convert.ToDouble(aValue1), Convert.ToDouble(aValue2));
                }
                else if (aValue1 is Decimal)
                {           
                    return (Convert.ToDecimal(aValue1) == Convert.ToDecimal(aValue2));
                }
                else if (aValue1 is Char)
                {
                    return (Convert.ToChar(aValue1) == Convert.ToChar(aValue2));
                }
                else if (aValue1 is String)
                {
                    return Convert.ToString(aValue1).Equals(Convert.ToString(aValue2), StringComparison.Ordinal);
                }
                else if (aValue1 is DateTime)
                {
                    return Convert.ToDateTime(aValue1).Equals(Convert.ToDateTime(aValue2));
                }
            }
            catch { }

            return false;
        }

        public static bool                      isEqual(object aValue1, object aValue2)
        {
            if (aValue1 == null || aValue2 == null) return false;

            if (ReferenceEquals(aValue1, aValue2)) return true;

            Type lType1 = aValue1.GetType();
            Type lType2 = aValue2.GetType();

            if (lType1 != lType2) return false;

            if (lType1.IsArray)
            {
                Array lArray1 = aValue1 as Array;
                Array lArray2 = aValue2 as Array;

                if (lArray1 == null || lArray2 == null) return false;

                Type lType1Element = lType1.GetElementType();
                if (lType1Element != lType2.GetElementType()) return false;

                if (lArray1.Rank != 1 || lArray1.Rank != lArray2.Rank) return false;

                if (lArray1.Length != lArray2.Length) return false;

                for(int i = 0; i < lArray1.Length; i++)
                {
                    if (equals(lArray1.GetValue(i), lArray2.GetValue(i)) == false) return false;
                }

                return true;
            }
            else
            {
                return equals(aValue1, aValue2);
            }
        }

        public static bool                      isNotEqual(object aValue1, object aValue2)
        {
            return !isEqual(aValue1, aValue2);
        }
    }
}