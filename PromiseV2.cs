using System;
using System.Collections.Generic;

namespace Promise
{
    public class Promise
    {
        private List<Call> m_Queue;
        private IEnumerator<Call> m_Iter;

        public PromiseStatus Status { get; private set; }

        public Promise()
        {
            Status = PromiseStatus.Init;
            m_Queue = new List<Call>();
        }

        public Promise Then(Action action)
        {
            m_Queue.Add(new Call() { IsAsync = false, Back = action });
            return this;
        }

        public Promise ThenAsync(Action<Action> action)
        {
            m_Queue.Add(new Call() { IsAsync = true, Back = () => action(Next) });
            return this;
        }

        private IEnumerator<Call> Iter()
        {
            foreach (var item in m_Queue)
            {
                yield return item;
            }
        }

        public void Start()
        {
            if (Status == PromiseStatus.Init)
            {
                Status = PromiseStatus.Started;
                m_Iter = Iter();
                Next();
            }
        }

        private void Next()
        {
            while (m_Iter.MoveNext())
            {
                m_Iter.Current.Back();
                if (m_Iter.Current.IsAsync)
                    break;
            }
        }
    }

    internal class Call
    {
        public bool IsAsync { get; set; }

        public Action Back { get; set; }
    }

    public enum PromiseStatus
    {
        Init = 0,
        Started = 1
    }
}
