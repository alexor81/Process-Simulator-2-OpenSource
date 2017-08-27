// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System.Windows.Forms.DataVisualization.Charting;

namespace Utils
{
    public static class ChartUtils
    {
        public const double     MaxValue = (double)decimal.MaxValue * 0.32d;

        public const double     MinValue = (double)decimal.MinValue * 0.32d;

        public static double    getValue(Series aSeries, double aX)
        {
            if(aX <= aSeries.Points[0].XValue)
            {
                return aSeries.Points[0].YValues[0];
            }

            int lLast = aSeries.Points.Count - 1;

            if (aX >= aSeries.Points[lLast].XValue)
            {
                return aSeries.Points[lLast].YValues[0];
            }

            int lFirst  = 0;
            int lMiddle = 0;
            double lValue;

            while (lFirst <= lLast)
            {
                lMiddle = lFirst + (lLast - lFirst) / 2;
                lValue = aSeries.Points[lMiddle].XValue;

                if (lValue > aX)
                {
                    lLast = lMiddle - 1;
                }
                else if (lValue < aX)
                {
                    lFirst = lMiddle + 1;
                }
                else
                {
                    break;
                }
            }

            if (lMiddle > 0)
            {
                double lY1 = aSeries.Points[lMiddle - 1].YValues[0];
                double lY2 = aSeries.Points[lMiddle].YValues[0];

                if (ValuesCompare.EqualDelta1.compare(lY1, lY2))
                {
                    return lY1;
                }
                else
                {
                    double lX1 = aSeries.Points[lMiddle - 1].XValue;
                    double lX2 = aSeries.Points[lMiddle].XValue;

                    return lY1 + (lY2 - lY1) / (lX2 - lX1) * (aX - lX1);
                }
            }
            else
            {
                double lY1 = aSeries.Points[lMiddle].YValues[0];
                double lY2 = aSeries.Points[lMiddle + 1].YValues[0];

                if (ValuesCompare.EqualDelta1.compare(lY1, lY2))
                {
                    return lY1;
                }
                else
                {
                    double lX1 = aSeries.Points[lMiddle].XValue;
                    double lX2 = aSeries.Points[lMiddle + 1].XValue;

                    return lY1 + (lY2 - lY1) / (lX2 - lX1) * (aX - lX1);
                }
            }
        }
    }
}
