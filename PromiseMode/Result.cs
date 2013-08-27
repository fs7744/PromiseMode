using System;

namespace PromiseMode
{
    public class Result<T> : VirtualResult
    {
        private T m_Value;
        public T Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
            }
        }

        public Result(T result)
        {
            this.Value = result;
        }

        public override Type GetResultType()
        {
            return typeof(T);
        }
    }
}
