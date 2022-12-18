using Core.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Conrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T result,bool success) : base(success)
        {
            Result = result;
        }

        public DataResult(T result,bool success, string message ) : base(success, message)
        {
            Result = result;
        }


        public T Result { get; }
    }
}
