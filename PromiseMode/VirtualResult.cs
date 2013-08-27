using System;

namespace PromiseMode
{
    public class VirtualResult
    {
        public const string ErrorInfo = "Argument maybe some error.";

        public virtual Type GetResultType()
        {
            throw new NotImplementedException();
        }
    }
}
