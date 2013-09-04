using System;
using System.Collections.Generic;

namespace PromiseMode
{
    public class Promise : IPromise, INext
    {
        protected dynamic[] m_Result;
        protected List<Action> Chains;
        protected int m_Index;

        private IPromise Then(Action action, Action<Exception> errorAction = null)
        {
            Chains.Add(() =>
            {
                try
                {
                    action();
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

        public Promise()
        {
            Chains = new List<Action>();
        }

        #region IPromise

        public void Start(params dynamic[] args)
        {
            m_Index = -1;
            Next(args);
        }

        public void Next(params dynamic[] args)
        {
            m_Result = args;
            m_Index++;
            if (Chains.Count > m_Index)
            {
                Chains[m_Index]();
            }
        }

        public IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3], m_Result[4], m_Result[5], m_Result[6], m_Result[7], m_Result[8], m_Result[9], m_Result[10], m_Result[11], m_Result[12], m_Result[13], m_Result[14]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3], m_Result[4], m_Result[5], m_Result[6], m_Result[7], m_Result[8], m_Result[9], m_Result[10], m_Result[11], m_Result[12], m_Result[13]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3], m_Result[4], m_Result[5], m_Result[6], m_Result[7], m_Result[8], m_Result[9], m_Result[10], m_Result[11], m_Result[12]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3], m_Result[4], m_Result[5], m_Result[6], m_Result[7], m_Result[8], m_Result[9], m_Result[10], m_Result[11]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3], m_Result[4], m_Result[5], m_Result[6], m_Result[7], m_Result[8], m_Result[9], m_Result[10]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>(Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3], m_Result[4], m_Result[5], m_Result[6], m_Result[7], m_Result[8], m_Result[9]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8>(Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3], m_Result[4], m_Result[5], m_Result[6], m_Result[7], m_Result[8]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2, T3, T4, T5, T6, T7>(Action<INext, T, T1, T2, T3, T4, T5, T6, T7> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3], m_Result[4], m_Result[5], m_Result[6], m_Result[7]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2, T3, T4, T5, T6>(Action<INext, T, T1, T2, T3, T4, T5, T6> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3], m_Result[4], m_Result[5], m_Result[6]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2, T3, T4, T5>(Action<INext, T, T1, T2, T3, T4, T5> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3], m_Result[4], m_Result[5]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2, T3, T4>(Action<INext, T, T1, T2, T3, T4> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3], m_Result[4]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2, T3>(Action<INext, T, T1, T2, T3> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2], m_Result[3]), errorAction);
            return this;
        }

        public IPromise Then<T, T1, T2>(Action<INext, T, T1, T2> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1], m_Result[2]), errorAction);
            return this;
        }

        public IPromise Then<T, T1>(Action<INext, T, T1> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0], m_Result[1]), errorAction);
            return this;
        }

        public IPromise Then<T>(Action<INext, T> action, Action<Exception> errorAction = null)
        {
            dynamic func = action;
            Then(() => func(this, m_Result[0]), errorAction);
            return this;
        }

        public IPromise Then(Action<INext> action, Action<Exception> errorAction = null)
        {
            Then(() => action(this), errorAction);
            return this;
        }

        #endregion
    }
}
