using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Conrete
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T result) : base(result, false)
        {
        }

        public ErrorDataResult(T result, string message) : base(result, false, message)
        {

        }
        public ErrorDataResult(string message) : base(default(T), false, message)
        {

        }
        public ErrorDataResult() : base(default(T), false)
        {

        }
    }
}
