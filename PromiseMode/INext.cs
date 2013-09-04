using System;

namespace PromiseMode
{
    public interface INext
    {
        void Next(params dynamic[] args);
    }
}
