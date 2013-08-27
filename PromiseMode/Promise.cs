using System;
using System.Collections.Generic;

namespace PromiseMode
{
    public class Promise : IPromise
    {
        protected VirtualResult m_Result;
        protected Queue<Action<IPromise>> Chains;

        public Promise()
        {
            Chains = new Queue<Action<IPromise>>();
        }

        #region IPromise

        public IPromise Then(Action<IPromise> action, Action<Exception> errorAction = null)
        {
            Chains.Enqueue(promise =>
            {
                try
                {
                    action(this);
                }
                catch (Exception error)
                {
                    if (errorAction != null)
                    {
                        errorAction(error);
                    }
                    else
                    {
                        throw error;
                    }
                }
            });

            return this;
        }

        public IPromise Then<T>(Action<IPromise, T> action, Action<Exception> errorAction = null)
        {
            Chains.Enqueue(promise =>
            {
                try
                {
                    if (m_Result != null && m_Result is Result<T>)
                    {
                        Result<T> result = m_Result as Result<T>;
                        action(this, result.Value);
                    }
                    else
                    {
                        throw new ArgumentException(VirtualResult.ErrorInfo);
                    }
                }
                catch (Exception error)
                {
                    if (errorAction != null)
                    {
                        errorAction(error);
                    }
                    else
                    {
                        throw error;
                    }
                }
            });

            return this;
        }

        public void Next()
        {
            m_Result = null;
            Start();
        }

        public void Next<T>(T result)
        {
            m_Result = new Result<T>(result);
            Start();
        }

        public void Start()
        {
            if (Chains.Count > 0)
            {
                Action<IPromise> action = Chains.Dequeue();
                action(this);
            }
        }

        #endregion
    }
}
