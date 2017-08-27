// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;

namespace Utils
{
    public class ValueScale
    {
        private double  mInMax = 27648.0D;
        public double   InMax 
        { 
            get { return mInMax; } 
        }

        private double  mInMin = 0.0D;
        public double   InMin
        {
            get { return mInMin; }
        }

        private double  mOutMax = 100.0D;
        public double   OutMax
        {
            get { return mOutMax; }
        }

        private double  mOutMin = 0.0D;
        public double   OutMin
        {
            get { return mOutMin; }
        }

        private double  mConC;
        private double  mConC1;
        private double  mUConC;
        private double  mUConC1;

        public          ValueScale()
        {
            calcC();
        }

        public          ValueScale(double aInMax, double aInMin, double aOutMax, double aOutMin)
        {
            setProperties(aInMax, aInMin, aOutMax, aOutMin);
        }

        public void     checkProperties(double aInMax, double aInMin, double aOutMax, double aOutMin)
        {
            if (aInMax <= aInMin)
            {
                throw new ArgumentException("The upper bound of input value has to be greater than lower bound. ");
            }

            if (aOutMax <= aOutMin)
            {
                throw new ArgumentException("The upper bound of output value has to be greater than lower bound. ");
            }
        }

        public void     setProperties(double aInMax, double aInMin, double aOutMax, double aOutMin)
        {
            checkProperties(aInMax, aInMin, aOutMax, aOutMin);

            mInMax  = aInMax;
            mInMin  = aInMin;
            mOutMax = aOutMax;
            mOutMin = aOutMin;

            calcC();
        }

        private void    calcC()
        {
            mConC   = (mOutMax - mOutMin) / (mInMax - mInMin);
            mConC1  = mOutMin - mInMin * mConC;
            mUConC  = (mInMax - mInMin) / (mOutMax - mOutMin);
            mUConC1 = mInMin - mOutMin * mUConC;
        }

        public double   scale(double aValue)
        {
            return aValue * mConC + mConC1;
        }

        public double   unscale(double aValue)
        {
            return aValue * mUConC + mUConC1;
        }
    }
}
