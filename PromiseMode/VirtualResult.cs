using System;

namespace PromiseMode
{
    public abstract class VirtualResult
    {
        public abstract Type GetResultType();

        public abstract string GetResultValueString();
    }

    public static class ResultErrorHandler
    {
        public const string ErrorInfo =
            @"Argument maybe some error.
            The method need {0}.
            But the argument is {1} and it's value is {2}.";

        public static ArgumentException GetException<T>(VirtualResult result)
        {
            return new ArgumentException(string.Format(ErrorInfo, typeof(T).FullName,
                result == null ? "null" : result.GetResultType().FullName,
                result.GetResultValueString()));
        }
    }
}
