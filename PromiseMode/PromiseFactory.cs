using System;

namespace PromiseMode
{
    public static class PromiseFactory
    {
        public static IPromise When(Action<IPromise> action, Action<Exception> errorAction = null)
        {
            IPromise result = CreatePromise();

            result.Then(action, errorAction);

            return result;
        }

        public static IPromise When<T>(Action<IPromise, T> action, Action<Exception> errorAction = null)
        {
            IPromise result = CreatePromise();

            result.Then<T>(action, errorAction);

            return result;
        }

        private static IPromise CreatePromise()
        {
            return new Promise();
        }
    }
}
