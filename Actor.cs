using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ActorModel
{
    public abstract class Actor
    {
        public const int Waiting = 0;
        public const int Excuting = 1;
        public const int Ended = 2;
        private ConcurrentQueue<Message> m_MessageBox;
        private object m_Iter;
        internal int m_Status;

        public bool Finished { get; internal set; }

        internal int MessageCount
        {
            get
            {
                return m_MessageBox.Count;
            }
        }

        public Actor()
        {
            m_MessageBox = new ConcurrentQueue<Message>();
        }

        public void Finish()
        {
            Finished = true;
        }

        protected abstract void Receive(dynamic message);

        public void Send(dynamic message)
        {
            if (Finished) return;

            m_MessageBox.Enqueue(new Message() { Content = message });

            Dispatcher.Instance.ReadyToExecute(this);
        }

        internal IEnumerator<Message> DoNext()
        {
            while (!Finished)
            {
                Message message;
                if (m_MessageBox.TryDequeue(out message))
                {
                    yield return message;
                }
                else
                    yield return null;
            }
        }

        internal void Execute()
        {
            IEnumerator<Message> iter = null;
            if (m_Iter == null)
            {
                iter = DoNext();
                System.Threading.Thread.VolatileWrite(ref m_Iter, (object)iter);
                //m_Iter = DoNext();
            }
            iter = m_Iter as IEnumerator<Message>;

            while (iter != null && iter.MoveNext() && iter.Current != null)
            {
                Receive(iter.Current.Content);
            };
        }
    }
}
