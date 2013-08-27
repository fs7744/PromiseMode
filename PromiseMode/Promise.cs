using System;
using System.Collections.Generic;

namespace PromiseMode
{
    public class Promise : IPromise,INext
    {
        protected VirtualResult m_Result;
        protected Queue<Action<INext>> Chains;

        public Promise()
        {
            Chains = new Queue<Action<INext>>();
        }

        #region IPromise

        public IPromise Then(Action<INext> action, Action<Exception> errorAction = null)
        {
            Chains.Enqueue(promise =>
            {
                try
                {
                    action(promise);
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

        public IPromise Then<T>(Action<INext, T> action, Action<Exception> errorAction = null)
        {
            Chains.Enqueue(promise =>
            {
                try
                {
                    if (m_Result != null && m_Result is Result<T>)
                    {
                        Result<T> result = m_Result as Result<T>;
                        action(promise, result.Value);
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
                Action<INext> action = Chains.Dequeue();
                action(this);
            }
        }

        #endregion
    }
}
