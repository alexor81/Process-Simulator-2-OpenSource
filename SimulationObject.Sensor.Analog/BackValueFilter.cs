using System;
using System.Timers;
using Utils;

namespace SimulationObject.Sensor.Analog
{
    public class BackValueFilter : IDisposable
    {
        private AnalogSensor        mAnalogSensor;
        private uint                mDelayMS;
        private Timer               mOutTimer;
        private Timer               mInTimer;

        public                      BackValueFilter(AnalogSensor aAnalogSensor, uint aDelayMS)
        {
            mAnalogSensor       = aAnalogSensor;
            mDelayMS            = aDelayMS;

            mOutTimer           = new Timer(aDelayMS);
            mOutTimer.AutoReset = false;

            mInTimer            = new Timer(aDelayMS);
            mInTimer.Elapsed    += new ElapsedEventHandler(InTimerElapsed);
            mInTimer.AutoReset  = false;
        }

        private double              mLastOutValue;
        public void                 addOutValue(double aValue)
        {
            mLastOutValue       = aValue;

            mIgnore             = true;
            mOutTimer.Interval  = mDelayMS;
            mOutTimer.Start();
        }

        private double              mLastInValue;
        public void                 addInValue(double aValue)
        {
            mLastInValue = aValue;

            if (mIgnore && mOutTimer.Enabled == false)
            {
                if (ValuesCompare.EqualDelta1.compare(mLastOutValue, mLastInValue))
                {
                    mInTimer.Stop();
                    mIgnore = false;
                }
                else
                {
                    if (mInTimer.Enabled == false)
                    {
                        mInTimer.Interval = mDelayMS;
                        mInTimer.Start();
                    }
                }
            }
        }

        private void                InTimerElapsed(object aSender, ElapsedEventArgs aEventArgs)
        {
            if (mIgnore)
            {
                mIgnore = false;
                mAnalogSensor.setValueOutside(mLastInValue);
            }
        }

        private volatile bool       mIgnore = false;
        public bool                 Ignore { get { return mIgnore; } }

        #region IDisposable

            private bool            mDisposed = false;

            public void             Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void  Dispose(bool aDisposing)
            {
                if (!mDisposed)
                {
                    if (aDisposing)
                    {
                        if (mOutTimer != null)
                        {
                            mOutTimer.Dispose();
                            mOutTimer = null;
                        }

                        if (mInTimer != null)
                        {
                            mInTimer.Dispose();
                            mInTimer = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
