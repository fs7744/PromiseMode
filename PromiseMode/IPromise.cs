using System;

namespace PromiseMode
{
    public interface IPromise
    {
        IPromise Then(Action<IPromise> action, Action<Exception> errorAction = null);

        IPromise Then<T>(Action<IPromise,T> action, Action<Exception> errorAction = null);
        
        void Next();

        void Next<T>(T result);

        void Start();
    }
}
