using System;

namespace Compropago.Sdk.Exceptions
{
    public class CompropagoHttpExceptions : BaseException
    {
        public int Code;

        public CompropagoHttpExceptions(int code) : base(code + "")
        {
            Code = code;
        }

        public CompropagoHttpExceptions(int code, string message) : base(code + ": " + message)
        {
            Code = code;
        }

        public CompropagoHttpExceptions(int code, string message, Exception inner) : base(code + ": " + message, inner)
        {
            Code = code;
        }
    }
}
