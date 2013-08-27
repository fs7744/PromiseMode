using System;

namespace PromiseMode
{
    public interface INext
    {
        void Next();

        void Next<T>(T result);
    }
}
