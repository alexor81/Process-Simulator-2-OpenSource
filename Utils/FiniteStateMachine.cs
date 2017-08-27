// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;

namespace Utils
{
    public class FiniteStateMachine : IDisposable
    {
        private Dictionary<string, Action>  mActions = new Dictionary<string, Action>(StringComparer.Ordinal);

        public                              FiniteStateMachine(string aStateName, Action aStateAction)
        {
            mActions.Add(aStateName, aStateAction);
            mState = aStateName;
        }

        public void                         addState(string aName, Action aAction)
        {
            mActions.Add(aName, aAction);
        }

        public void                         deleteState(string aName)
        {
            mActions.Remove(aName);
        }

        private string                      mState;
        public string                       State
        {
            get { return mState; }
            set { mState = value; }
        }

        public void                         executeStateAction()
        {
            mActions[mState].Invoke();
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
                        if (mActions != null)
                        {
                            mActions.Clear();
                            mActions = null;
                        }
                    }

                    mDisposed = true;
                }
            }

        #endregion
    }
}
