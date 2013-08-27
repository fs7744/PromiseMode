using System;

namespace PromiseMode
{
    public interface IPromise
    {
        IPromise Then(Action<INext> action, Action<Exception> errorAction = null);

        IPromise Then<T>(Action<INext, T> action, Action<Exception> errorAction = null);

        void Start();
    }
}
