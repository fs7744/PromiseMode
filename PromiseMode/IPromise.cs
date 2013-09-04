using System;

namespace PromiseMode
{
    public interface IPromise
    {
        IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
            Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
            Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
            Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
            Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
            Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8, T9>(
            Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8, T9> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2, T3, T4, T5, T6, T7, T8>(
            Action<INext, T, T1, T2, T3, T4, T5, T6, T7, T8> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2, T3, T4, T5, T6, T7>(
            Action<INext, T, T1, T2, T3, T4, T5, T6, T7> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2, T3, T4, T5, T6>(
            Action<INext, T, T1, T2, T3, T4, T5, T6> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2, T3, T4, T5>(
            Action<INext, T, T1, T2, T3, T4, T5> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2, T3, T4>(
            Action<INext, T, T1, T2, T3, T4> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2, T3>(
            Action<INext, T, T1, T2, T3> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1, T2>(
            Action<INext, T, T1, T2> action,
            Action<Exception> errorAction = null);

        IPromise Then<T, T1>(
            Action<INext, T, T1> action,
            Action<Exception> errorAction = null);

        IPromise Then<T>(
            Action<INext, T> action,
            Action<Exception> errorAction = null);

        IPromise Then(
            Action<INext> action,
            Action<Exception> errorAction = null);

        void Start(params dynamic[] args);
    }
}
