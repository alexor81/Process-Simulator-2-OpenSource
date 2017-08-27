// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;

namespace Utils
{
    public static class Converters
    {
        public static ulong         ToUInt64(object aValue)
        {
            ulong lValue;

            if (aValue is SByte)
            {
                lValue = Converters.SByteToUInt64Bits((sbyte)aValue);
            }
            else if (aValue is Int16)
            {
                lValue = Converters.Int16ToUInt64Bits((short)aValue);
            }
            else if (aValue is Int32)
            {
                lValue = Converters.Int32ToUInt64Bits((int)aValue);
            }
            else if (aValue is Int64)
            {
                lValue = Converters.Int64ToUInt64Bits((long)aValue);
            }
            else if (aValue is Single)
            {
                lValue = Converters.SingleToUInt64Bits((float)aValue);
            }
            else if (aValue is Double)
            {
                lValue = Converters.DoubleToUInt64Bits((double)aValue);
            }
            else
            {
                lValue = Convert.ToUInt64(aValue);
            }

            return lValue;
        }

        public static object        FromUInt64(Type aType, ulong aValue)
        {
            if (aType == typeof(Byte))
            {
                return UInt64ToByte(aValue);
            }
            else if (aType == typeof(SByte))
            {
                return UInt64ToSByte(aValue);
            }
            else if (aType == typeof(Int16))
            {
                return UInt64ToInt16(aValue);
            }
            else if (aType == typeof(Int32))
            {
                return UInt64ToInt32(aValue);
            }
            else if (aType == typeof(Int64))
            {
                return UInt64ToInt64(aValue);
            }
            else if (aType == typeof(UInt16))
            {
                return UInt64ToUInt16(aValue);
            }
            else if (aType == typeof(UInt32))
            {
                return UInt64ToUInt32(aValue);
            }
            else if (aType == typeof(UInt64))
            {
                return aValue;
            }
            else if (aType == typeof(Single))
            {
                return UInt64ToSingle(aValue);
            }
            else if (aType == typeof(Double))
            {
                return UInt64ToDouble(aValue);
            }

            return aValue;
        }

        public static unsafe ulong  SByteToUInt64Bits(sbyte aValue)
        {
            ulong lValue = *((ulong*)&aValue);
            return lValue & 255UL;
        }

        public static byte          UInt64ToByte(ulong aValue)
        {
            return Convert.ToByte(aValue & 255UL);
        }

        public static unsafe sbyte  UInt64ToSByte(ulong aValue)
        {
            byte lValue = UInt64ToByte(aValue);
            return *((sbyte*)&lValue);
        }

        public static unsafe ulong  Int16ToUInt64Bits(short aValue)
        {
            ulong lValue = *((ulong*)&aValue);
            return lValue & 65535UL;
        }

        public static ushort        UInt64ToUInt16(ulong aValue)
        {
            return Convert.ToUInt16(aValue & 65535UL);
        }

        public static unsafe short  UInt64ToInt16(ulong aValue)
        {
            ushort lValue = UInt64ToUInt16(aValue);
            return *((short*)&lValue);
        }

        public static unsafe ulong  Int32ToUInt64Bits(int aValue)
        {
            ulong lValue = *((ulong*)&aValue);
            return lValue & 4294967295UL;
        }

        public static uint          UInt64ToUInt32(ulong aValue)
        {
            return Convert.ToUInt32(aValue & 4294967295UL);
        }

        public static unsafe int    UInt64ToInt32(ulong aValue)
        {
            uint lValue = UInt64ToUInt32(aValue);
            return *((int*)&lValue);
        }

        public static unsafe ulong  Int64ToUInt64Bits(long aValue)
        {
            return *((ulong*)&aValue);
        }

        public static unsafe long   UInt64ToInt64(ulong aValue)
        {
            return *((long*)&aValue);
        }

        public static unsafe ulong  SingleToUInt64Bits(float aValue)
        {
            ulong lValue = *((ulong*)&aValue);
            return lValue & 4294967295UL;
        }

        public static unsafe float  UInt64ToSingle(ulong aValue)
        {
            uint lValue = UInt64ToUInt32(aValue);
            return *((float*)&lValue);
        }

        public static unsafe ulong  DoubleToUInt64Bits(double aValue)
        {
            return *((ulong*)&aValue);
        }

        public static unsafe double UInt64ToDouble(ulong aValue)
        {
            return *((double*)&aValue);
        }    
    
        private static object       convertSimpleType(Type aType, object aValue)
        {
            if (aType == typeof(Boolean))
            {
                return Convert.ToBoolean(aValue);
            }
            else if (aType == typeof(Byte))
            {
                return Convert.ToByte(aValue);
            }
            else if (aType == typeof(SByte))
            {
                return Convert.ToSByte(aValue);
            }
            else if (aType == typeof(Int16))
            {
                return Convert.ToInt16(aValue);
            }
            else if (aType == typeof(Int32))
            {
                return Convert.ToInt32(aValue);
            }
            else if (aType == typeof(Int64))
            {
                return Convert.ToInt64(aValue);
            }
            else if (aType == typeof(UInt16))
            {
                return Convert.ToUInt16(aValue);
            }
            else if (aType == typeof(UInt32))
            {
                return Convert.ToUInt32(aValue);
            }
            else if (aType == typeof(UInt64))
            {
                return Convert.ToUInt64(aValue);
            }
            else if (aType == typeof(Single))
            {
                return Convert.ToSingle(aValue);
            }
            else if (aType == typeof(Double))
            {
                return Convert.ToDouble(aValue);
            }
            else if (aType == typeof(Decimal))
            {
                return Convert.ToDecimal(aValue);
            }
            else if (aType == typeof(Char))
            {
                return Convert.ToChar(aValue);
            }
            else if (aType == typeof(String))
            {
                return StringUtils.ObjectToString(aValue);
            }
            else if (aType == typeof(DateTime))
            {
                return Convert.ToDateTime(aValue);
            }

            throw new ArgumentException("Unknown type. ");
        }

        public static object        convertValue(Type aType, object aValue)
        {
            if (aValue == null) throw new ArgumentException("Null value is prohibited. ");

            Type lValueType = aValue.GetType();    

            if (aType.IsArray == false && lValueType.IsArray == false)
            {
                if (aType == lValueType)
                {
                    return aValue;
                }
                else
                {
                    return convertSimpleType(aType, aValue);
                }
            }

            Type lNewElementType;
            Array lArray = aValue as Array;
            if (lArray == null)
            {
                lNewElementType = aType.GetElementType();

                if (lValueType == typeof(String))
                {
                    return StringUtils.StringToArray(lNewElementType, (string)aValue);
                }

                Array lNewArray = Array.CreateInstance(lNewElementType, 1);
                lNewArray.SetValue(convertValue(lNewElementType, aValue), 0);
                return lNewArray;
            }
            else
            {
                if (lArray.Rank != 1)
                {
                    throw new ArgumentException("Only one dimension array is supported. ");
                }

                if (aType == typeof(String))
                {
                    return StringUtils.ArrayToString(lArray);
                }

                if (aType.IsArray)
                {
                    lNewElementType = aType.GetElementType();
                }
                else
                {
                    lNewElementType = aType;
                }

                if (lNewElementType == lValueType.GetElementType()) return aValue;

                Array lNewArray = Array.CreateInstance(lNewElementType, lArray.Length);
                for(int i = 0; i < lArray.Length; i++)
                {
                    lNewArray.SetValue(convertValue(lNewElementType, lArray.GetValue(i)), i);
                }
                return lNewArray;
            }
        }  
    }
}
